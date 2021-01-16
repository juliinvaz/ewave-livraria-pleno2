using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario> 
    {
        Task<bool> ExisteCPFCadastradoAsync(string cpf, int? id);
        Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync();
        Task<IEnumerable<Usuario>> ObterUsuariosPorSituacaoAsync(int situacaoId);
    }
}
