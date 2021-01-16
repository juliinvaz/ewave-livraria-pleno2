using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface IInstuicaoEnsinoRepository : IRepository<InstituicaoEnsino> 
    {
        Task<bool> ExisteCNPJCadastradoAsync(string cnpj, int? instituicaoId);
        Task<IEnumerable<InstituicaoEnsino>> ObterTodosInstituicaoEnsinoAsync();
        Task<IEnumerable<InstituicaoEnsino>> ObterInstituicaoEnsinoPorSituacaoAsync(int situacaoId);
    }
}

