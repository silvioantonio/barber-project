using AutoMapper;
using MeuBarbeiro.API.Data.ValueObjects;
using MeuBarbeiro.API.Repository.User;
using U = MeuBarbeiro.API.Models.User;

namespace MeuBarbeiro.API.Services.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserVO> Create(UserVO userVO)
        {
            if (userVO.PhoneNumber != null)
            {
                var hasUser = await _userRepository.FindByPhone(userVO.PhoneNumber);

                if (hasUser)
                {
                    throw new ArgumentException("Telefone já cadastrado!");
                }
            }

            var user = _mapper.Map<U.User>(userVO);
            var response = await _userRepository.Create(user);
            return _mapper.Map<UserVO>(response);
        }

        public async Task<bool> Delete(long id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserVO>> FindAll()
        {
            var response = await _userRepository.FindAll();
            var list = response.Select(user => _mapper.Map<UserVO>(user));
            return list;
        }

        public async Task<UserVO> FindById(long id)
        {
            var response = await _userRepository.FindById(id);
            return _mapper.Map<UserVO>(response);
        }

        public async Task<UserVO> Update(UserVO userVO)
        {
            var user = _mapper.Map<U.User>(userVO);
            var response = await _userRepository.Update(user);
            return _mapper.Map<UserVO>(response);
        }
    }
}
