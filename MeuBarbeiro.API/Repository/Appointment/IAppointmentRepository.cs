using MeuBarbeiro.API.Util.Filter;
using A = MeuBarbeiro.API.Models.Appointment;

namespace MeuBarbeiro.API.Repository.Appointment
{
    public interface IAppointmentRepository
    {
        public Task<A.Appointment> Create(A.Appointment appointment);
        public Task<bool> Delete(long id);
        public Task<IEnumerable<A.Appointment>> FindAllById(long id, PaginationFilter validFilter);
        public Task<A.Appointment?> FindById(long id);
    }
}
