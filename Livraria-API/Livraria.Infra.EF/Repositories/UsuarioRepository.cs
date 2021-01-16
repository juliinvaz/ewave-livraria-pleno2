using Livraria.Domain.Models;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        protected DataContext Context { get; }
        public UsuarioRepository(DataContext dataContext) : base(dataContext) 
        {
            Context = dataContext;
            
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
    }
}
