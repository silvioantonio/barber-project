using MeuBarbeiro.API.Data.ValueObjects;

namespace MeuBarbeiro.API.Services.Worker
{
    public interface IWorkerService
    {
        public Task<IEnumerable<WorkerVO>> FindAll(long id);
        public Task<WorkerVO> FindById(long id);
        public Task<WorkerVO> Create(WorkerVO workerVO);
        public Task<WorkerVO> Update(WorkerVO workerVO);
        public Task<bool> Delete(long id);
    }
}
