using MeuBarbeiro.API.Models.Provider;
using P = MeuBarbeiro.API.Models.Provider;
namespace MeuBarbeiro.API.Repository.Provider
{
    public interface IProviderRepository
    {
        public Task<IEnumerable<P.Provider>> FindAll();
        public Task<P.Provider?> FindById(long id);
        public Task<P.Provider> Create(P.Provider provider);
        public Task<P.Provider> Update(P.Provider provider);
        public Task<bool> Delete(long id);
        public Task<bool> FindByEmail(string email);
    }
}
