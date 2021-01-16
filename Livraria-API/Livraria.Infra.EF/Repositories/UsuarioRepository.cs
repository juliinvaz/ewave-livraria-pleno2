using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<bool> ExisteCPFCadastradoAsync(string cpf, int? id)
        {
            var result = Context.Set<Usuario>().Local.Any(x => (!id.HasValue && x.CPF.Equals(cpf)) || (id.HasValue && x.CPF.Equals(cpf) && x.Id != id.Value));

            if (!result)
            {
                result = Context.Set<Usuario>().Any(x => (!id.HasValue && x.CPF.Equals(cpf)) || (id.HasValue && x.CPF.Equals(cpf) && x.Id != id.Value));
            }

            return Task.FromResult(result);
        }

        public async Task<IEnumerable<Usuario>> ObterUsuariosPorSituacaoAsync(int situacaoId)
        {
            var usuarios = await Context.Set<Usuario>().IgnoreAutoIncludes().Where(x => x.SituacaoId == situacaoId).ToListAsync();

            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync()
        {
            var usuarios = await Context.Set<Usuario>().IgnoreAutoIncludes().ToListAsync();
            return usuarios;
        }
    }
}
