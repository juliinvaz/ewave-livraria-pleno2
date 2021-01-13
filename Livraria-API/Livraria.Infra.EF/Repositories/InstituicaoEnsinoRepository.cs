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
    public class InstituicaoEnsinoRepository : Repository<InstituicaoEnsino>, IInstuicaoEnsinoRepository
    {
        protected DataContext Context { get; }
        public InstituicaoEnsinoRepository(DataContext dataContext) : base(dataContext) 
        {
            Context = dataContext;
            
        }

        public Task<bool> ExisteCNPJCadastradoAsync(string cnpj, int? instituicaoId)
        {
            var result = Context.Set<InstituicaoEnsino>().Local.Any(x => x.CNPJ.Equals(cnpj) && (instituicaoId.IsNotNull() && x.Id == instituicaoId));

            if (result.IsNull())
            {
                result = Context.Set<InstituicaoEnsino>().Any(x => x.CNPJ.Equals(cnpj) && (instituicaoId.IsNotNull() && x.Id == instituicaoId));
            }

            return Task.FromResult(result);
        }
    }
}
