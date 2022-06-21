using MeuBarbeiro.API.Data.ValueObjects;

namespace MeuBarbeiro.API.Services.User
{
    public interface IUserService
    {
        public Task<IEnumerable<UserVO>> FindAll();
        public Task<UserVO> FindById(long id);
        public Task<UserVO> Create(UserVO userVO);
        public Task<UserVO> Update(UserVO userVO);
        public Task<bool> Delete(long id);
    }
}
