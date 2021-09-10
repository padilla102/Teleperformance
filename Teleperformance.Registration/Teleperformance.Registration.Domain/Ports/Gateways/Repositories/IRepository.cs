using System.Collections.Generic;
using System.Threading.Tasks;
using Teleperformance.Registration.Domain.Shared;

namespace Teleperformance.Registration.Domain.Ports.Gateways.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAll();
        Task<T> Add(T entity);
        Task Delete(T entity);
    }
}
