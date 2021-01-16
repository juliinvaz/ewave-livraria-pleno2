using Livraria.Domain.Models;
using Livraria.Infra.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Repositories
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IEnumerable<Livro>> ObterLivrosPorSituacaoAsync(int situacaoId);
        Task<IEnumerable<Livro>> ObterTodosLivrosAsync();
    }
}
