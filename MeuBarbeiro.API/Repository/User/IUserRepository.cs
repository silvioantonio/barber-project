using U = MeuBarbeiro.API.Models.User;

namespace MeuBarbeiro.API.Repository.User
{
    public interface IUserRepository
    {
        public Task<IEnumerable<U.User>> FindAll();
        public Task<U.User?> FindById(long id);
        public Task<U.User> Create(U.User user);
        public Task<U.User> Update(U.User user);
        public Task<bool> Delete(long id);
        public Task<bool> FindByPhone(string phone);
    }
}
