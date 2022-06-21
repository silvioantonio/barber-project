using MeuBarbeiro.API.Data.ValueObjects;

namespace MeuBarbeiro.API.Services.Provider
{
    public interface IProviderService
    {
        public Task<IEnumerable<ProviderVO>> FindAll();
        public Task<ProviderVO> FindById(long id);
        public Task<ProviderVO> Create(ProviderVO providerVO);
        public Task<ProviderVO> Update(ProviderVO providerVO);
        public Task<bool> Delete(long id);
    }
}
