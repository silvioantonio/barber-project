using MeuBarbeiro.API.Context;
using P = MeuBarbeiro.API.Models.Provider;
using Microsoft.EntityFrameworkCore;

namespace MeuBarbeiro.API.Repository.Provider
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly MySQLContext _context;

        public ProviderRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Models.Provider.Provider> Create(Models.Provider.Provider provider)
        {
            _context.Add(provider);
            await _context.SaveChangesAsync();
            return provider;
        }

        public async Task<bool> Delete(long id)
        {
            P.Provider? provider = await _context.Providers.Where(p => p.Id == id).Include(a => a.Address).Include(o => o.ProviderOpeningHours).FirstOrDefaultAsync();
            if (provider != null)
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Models.Provider.Provider>> FindAll()
        {
            List<P.Provider> providers = await _context.Providers.ToListAsync();
            return providers;
        }

        public async Task<bool> FindByEmail(string email)
        {
            var hasProvider = await _context.Providers.Where(p => p.Email.Equals(email)).AnyAsync();
            return hasProvider;
        }

        public async Task<Models.Provider.Provider?> FindById(long id)
        {
            P.Provider? provider = await _context.Providers.Where(p => p.Id == id).Include(a => a.Address).Include(ph => ph.ProviderOpeningHours).FirstOrDefaultAsync();
            return provider;
        }

        public async Task<Models.Provider.Provider> Update(Models.Provider.Provider provider)
        {
            _context.Providers.Update(provider);
            await _context.SaveChangesAsync();
            return provider;
        }
    }
}
