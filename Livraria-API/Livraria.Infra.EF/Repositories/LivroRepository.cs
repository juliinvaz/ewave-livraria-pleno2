using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Livro>> ObterLivrosPorSituacaoAsync(int situacaoId)
        {
            var livros = await Context.Set<Livro>().IgnoreAutoIncludes().Where(x => x.SituacaoId == situacaoId).ToListAsync();

            return livros;
        }

        public async Task<IEnumerable<Livro>> ObterTodosLivrosAsync()
        {
            var livros = await Context.Set<Livro>().IgnoreAutoIncludes().ToListAsync();
            return livros;
        }
    }
}
