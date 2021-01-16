using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IEmprestimoRepository : IRepository<Emprestimo> 
    {
        Task<int> ObterQuantidadeDeEmpestimosEmAndamentoPorUsuarioAsync(int usuarioId);
        Task<bool> VerificarEmprestimosAtrasadosPorUsuarioAsync(int usuarioId);
        Task<bool> VerificarEmprestimosDevolvidoAtrasadoPorUsuarioAsync(int usuarioId);
        Task<IEnumerable<Emprestimo>> ObterTodosEmprestimosAsync();
    }
}
