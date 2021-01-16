using Livraria.Domain.DTOs;
using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface ICidadeRepository : IRepository<Cidade> 
    {
        Task<IEnumerable<Cidade>> ObterCidadesPorEstadoAsync(int estadoId);
    }
}
