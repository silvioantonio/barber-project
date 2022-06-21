using MeuBarbeiro.API.Data.ValueObjects;

namespace MeuBarbeiro.API.Services.Appointment
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<AppointmentVO>> FindAllById(long id, int? page, int? size);
        public Task<AppointmentVO> FindById(long id);
        public Task<AppointmentVO> Create(AppointmentCreateVO appointmentCreateVO);
        public Task<bool> Delete(long id);
    }
}
