using W = MeuBarbeiro.API.Models.Worker;

namespace MeuBarbeiro.API.Repository.Worker
{
    public interface IWorkerRepository
    {
        public Task<IEnumerable<W.Worker>> FindAll(long id);
        public Task<W.Worker?> FindById(long id);
        public Task<W.Worker> Create(W.Worker worker);
        public Task<W.Worker> Update(W.Worker worker);
        public Task<bool> Delete(long id);
    }
}
