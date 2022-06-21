using AutoMapper;
using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Repository.Appointment;
using MeuBarbeiro.API.Services.Worker;
using MeuBarbeiro.API.Util.Enums;
using MeuBarbeiro.API.Util.Filter;
using A = MeuBarbeiro.API.Models.Appointment;

namespace MeuBarbeiro.API.Services.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IWorkerService _workerService;

        public AppointmentService(IMapper mapper, IAppointmentRepository appointmentRepository, IWorkerService workerService)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _workerService = workerService;
        }

        public async Task<AppointmentVO> Create(AppointmentCreateVO appointmentCreateVO)
        {
            var worker = await _workerService.FindById(appointmentCreateVO.ProviderId);
            var filteredWorkerHour = worker.ProviderHours.Where(w => w.StatusHour == StatusHour.Livre && w.Id == appointmentCreateVO.ProviderHourId).ToArray();
            if (!filteredWorkerHour.Any())
            {
                throw new ArgumentException("A data para agendamento não esta disponivel!");
            }

            for (int i = 0; i < filteredWorkerHour.Length; i++)
            {
                filteredWorkerHour[i].StatusHour = StatusHour.Agendado;
            }

            worker.ProviderHours = filteredWorkerHour;

            await _workerService.Update(worker);

            var appointment = await _appointmentRepository.Create(new A.Appointment
            {
                ProviderHourId = filteredWorkerHour[0].Id,
                WorkerId = appointmentCreateVO.ProviderId,
                UserId = appointmentCreateVO.UserId,
                CreatedAt = DateTime.Now,
                Date = appointmentCreateVO.Date.Date
            });

            return _mapper.Map<AppointmentVO>(appointment);
        }

        public async Task<bool> Delete(long id)
        {
            ValidateId(id);

            var appointment = await FindById(id);
            if(appointment != null)
            {
                var response = await _workerService.FindById(appointment.WorkerId);

                foreach (var hour in response.ProviderHours)
                {
                    if (hour.Id == appointment.ProviderHourId)
                        hour.StatusHour = StatusHour.Livre;
                }

                await _workerService.Update(response);
            }
            
            await _appointmentRepository.Delete(id);
            return true;
        }

        public async Task<AppointmentVO> FindById(long id)
        {
            ValidateId(id);

            var response = await _appointmentRepository.FindById(id);
            return _mapper.Map<AppointmentVO>(response);
        }

        public async Task<IEnumerable<AppointmentVO>> FindAllById(long id, int? page, int? size)
        {
            ValidateId(id);

            var validFilter = new PaginationFilter(page ?? 1, size ?? 10);
            var response = await _appointmentRepository.FindAllById(id, validFilter);
            return _mapper.Map<IEnumerable<A.Appointment>, IEnumerable<AppointmentVO>>(response);
        }

        private void ValidateId(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
