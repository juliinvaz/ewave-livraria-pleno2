using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var result = Context.Set<Usuario>().Local.Any(x => x.CPF.Equals(cpf) && (id.IsNotNull() && x.Id == id));

            if (result.IsNull())
            {
                result = Context.Set<Usuario>().Any(x => x.CPF.Equals(cpf) && (id.IsNotNull() && x.Id == id));
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
