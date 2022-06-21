using AutoMapper;
using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Repository.Worker;
using MeuBarbeiro.API.Services.Provider;

namespace MeuBarbeiro.API.Services.Worker
{
    public class WorkerService : IWorkerService
    {
        private readonly IMapper _mapper;
        private readonly IWorkerRepository _workerRepository;
        private readonly IProviderService _providerService;

        public WorkerService(IMapper mapper, IWorkerRepository workerRepository, IProviderService providerService)
        {
            _mapper = mapper;
            _providerService = providerService;
            _workerRepository = workerRepository;
        }

        public async Task<WorkerVO> Create(WorkerVO workerVO)
        {
            if (workerVO.ProviderId <= 0)
            {
                throw new ArgumentException("Provedor Invalido!");
            }

            var providerVO = await _providerService.FindById(workerVO.ProviderId);

            if (providerVO == null)
            {
                throw new ArgumentException("Provedor não encontrado!");
            }

            var provider = _mapper.Map<Models.Provider.Provider>(providerVO);

            var worker = new Models.Worker.Worker
            {
                Name = workerVO.Name,
                AvatarId = workerVO.AvatarId,
                Appointments = workerVO.Appointments,
                ProviderHours = workerVO.ProviderHours,
                ProviderId = provider.Id
            };

            var response = await _workerRepository.Create(worker);
            return _mapper.Map<WorkerVO>(response);
        }

        public async Task<bool> Delete(long id)
        {
            return await _workerRepository.Delete(id);
        }

        public async Task<IEnumerable<WorkerVO>> FindAll(long id)
        {
            var response = await _workerRepository.FindAll(id);
            var list = new List<WorkerVO>();
            foreach (var item in response)
            {
                list.Add(new WorkerVO
                {
                    Name = item.Name,
                    AvatarId = item.AvatarId,
                    ProviderId = item.ProviderId,
                    Id = item.Id,
                    ProviderHours = item.ProviderHours,
                    Appointments = item.Appointments,
                });
            }
            return list;
        }

        public async Task<WorkerVO> FindById(long id)
        {
            var response = await _workerRepository.FindById(id);
            return _mapper.Map<WorkerVO>(response);
        }

        public async Task<WorkerVO> Update(WorkerVO workerVO)
        {
            if (workerVO.ProviderId <= 0)
            {
                throw new ArgumentException("Provedor Invalido!");
            }

            var providerVO = await _providerService.FindById(workerVO.ProviderId);

            if (providerVO == null)
            {
                throw new ArgumentException("Provedor não encontrado!");
            }

            var provider = _mapper.Map<Models.Provider.Provider>(providerVO);

            var worker = new Models.Worker.Worker
            {
                Id = workerVO.Id,
                Name = workerVO.Name,
                AvatarId = workerVO.AvatarId,
                Appointments = workerVO.Appointments,
                ProviderHours = workerVO.ProviderHours,
                ProviderId = provider.Id,
            };

            var response = await _workerRepository.Update(worker);
            return _mapper.Map<WorkerVO>(response);
        }
    }
}
