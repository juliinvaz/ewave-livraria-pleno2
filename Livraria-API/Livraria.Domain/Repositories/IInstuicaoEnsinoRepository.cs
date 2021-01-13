using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IInstuicaoEnsinoRepository : IRepository<InstituicaoEnsino> 
    {
        Task<bool> ExisteCNPJCadastradoAsync(string cnpj, int? instituicaoId);
         
    }
}
