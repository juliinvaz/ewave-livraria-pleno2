using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IEstadoRepository : IRepository<Estado> 
    {
        Task<IEnumerable<Estado>> ObterTodosAsync();
    }
}
