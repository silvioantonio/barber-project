using MeuBarbeiro.API.Context;
using Microsoft.EntityFrameworkCore;

namespace MeuBarbeiro.API.Repository.Worker
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly MySQLContext _context;

        public WorkerRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<Models.Worker.Worker> Create(Models.Worker.Worker worker)
        {
            _context.Add(worker);
            await _context.SaveChangesAsync();
            return worker;
        }

        public async Task<bool> Delete(long id)
        {
            Models.Worker.Worker? worker = await _context.Workers.Where(p => p.Id == id).Include(ph => ph.ProviderHours).FirstOrDefaultAsync();
            if (worker != null)
            {
                foreach (var item in worker.ProviderHours)
                {
                    _context.ProviderHours.Remove(item);
                }

                if(worker.Appointments != null && worker.Appointments.Any())
                    foreach (var item in worker.Appointments)
                    {
                        _context.Appointments.Remove(item);
                    }

                _context.Workers.Remove(worker);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Models.Worker.Worker>> FindAll(long id)
        {
            var response = await _context.Workers.Where(w => w.ProviderId == id).Include(ph => ph.ProviderHours).Include(a => a.Appointments).ToListAsync();
            return response;
        }

        public async Task<Models.Worker.Worker?> FindById(long id)
        {
            return await _context.Workers.AsNoTracking().Where(w => w.Id == id).Include(ph => ph.ProviderHours).Include(a => a.Appointments).FirstOrDefaultAsync();
        }

        public async Task<Models.Worker.Worker> Update(Models.Worker.Worker worker)
        {
            _context.Workers.Update(worker);
            await _context.SaveChangesAsync();
            return worker;
        }
    }
}
