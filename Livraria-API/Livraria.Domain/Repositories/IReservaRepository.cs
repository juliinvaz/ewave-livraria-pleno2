using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IReservaRepository : IRepository<Reserva> 
    {
        Task<IEnumerable<Reserva>> ObterTodosAsync();
    }
}
