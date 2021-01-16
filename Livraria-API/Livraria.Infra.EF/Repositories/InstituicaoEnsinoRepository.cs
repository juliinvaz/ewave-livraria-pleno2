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
    public class InstituicaoEnsinoRepository : Repository<InstituicaoEnsino>, IInstuicaoEnsinoRepository
    {        
        public InstituicaoEnsinoRepository(DataContext dataContext) : base(dataContext) 
        {            
        }

        public Task<bool> ExisteCNPJCadastradoAsync(string cnpj, int? instituicaoId)
        {
            var result = Context.Set<InstituicaoEnsino>().Local.Any(x => (!instituicaoId.HasValue && x.CNPJ.Equals(cnpj)) || (instituicaoId.HasValue && x.CNPJ.Equals(cnpj) && x.Id != instituicaoId.Value));

            if (!result)
            {
                result = Context.Set<InstituicaoEnsino>().Any(x => (!instituicaoId.HasValue && x.CNPJ.Equals(cnpj)) || (instituicaoId.HasValue && x.CNPJ.Equals(cnpj) && x.Id != instituicaoId.Value));
            }

            return Task.FromResult(result);
        }
        public async Task<IEnumerable<InstituicaoEnsino>> ObterInstituicaoEnsinoPorSituacaoAsync(int situacaoId)
        {
            var insituicaoEnsino = await Context.Set<InstituicaoEnsino>().IgnoreAutoIncludes().Where(x => x.SituacaoId == situacaoId).ToListAsync();

            return insituicaoEnsino;
        }

        public async Task<IEnumerable<InstituicaoEnsino>> ObterTodosInstituicaoEnsinoAsync()
        {
            var insituicaoEnsino = await Context.Set<InstituicaoEnsino>().IgnoreAutoIncludes().ToListAsync();
            return insituicaoEnsino;
        }
    }
}

