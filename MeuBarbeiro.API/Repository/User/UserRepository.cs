using MeuBarbeiro.API.Context;
using Microsoft.EntityFrameworkCore;
using U = MeuBarbeiro.API.Models.User;

namespace MeuBarbeiro.API.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<U.User> Create(U.User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(long id)
        {
            U.User? user = await _context.Users.Where(user => user.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<U.User>> FindAll()
        {
            List<U.User> users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<bool> FindByPhone(string phone)
        {
            var hasUser = await _context.Users.Where(user => user.PhoneNumber.Equals(phone)).AnyAsync();
            return hasUser;
        }

        public async Task<U.User?> FindById(long id)
        {
            U.User? user = await _context.Users.Where(user => user.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<U.User> Update(U.User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
