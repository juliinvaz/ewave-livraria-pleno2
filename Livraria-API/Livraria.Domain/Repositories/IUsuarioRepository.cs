using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario> 
    {
        Task<bool> ExisteCPFCadastradoAsync(string cpf, int? id);
         
    }
}
