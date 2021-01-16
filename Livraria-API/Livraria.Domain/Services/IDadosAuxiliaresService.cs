using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Services
{
    public interface IDadosAuxiliaresService
    {
        Task<IEnumerable<Estado>> ObterTodosEstadosAsync();
        Task<IEnumerable<Cidade>> ObterCidadesPorEstadoAsync(int estadoId);
    }
}
