using MeuBarbeiro.API.Context;
using MeuBarbeiro.API.Util.Filter;
using Microsoft.EntityFrameworkCore;
using A = MeuBarbeiro.API.Models.Appointment;

namespace MeuBarbeiro.API.Repository.Appointment
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MySQLContext _context;

        public AppointmentRepository(MySQLContext context)
        {
            _context = context;
        }

        public async Task<A.Appointment> Create(A.Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> Delete(long id)
        {
            var appointment = await _context.Appointments.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (appointment != null)
            {
                _context.Remove(appointment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<A.Appointment?> FindById(long id)
        {
            return await _context.Appointments.AsNoTracking().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<A.Appointment>> FindAllById(long id, PaginationFilter validFilter)
        {
            return await _context.Appointments
                .Where(a => a.WorkerId == id)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
        }
    }
}
