using Livraria.Domain.Exceptions;
using Livraria.Domain;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Threading.Tasks;
using Livraria.Domain.Services;
using Livraria.Domain.Models;
using Livraria.Domain.Enums;

namespace Livraria.Services
{
    public class InstituicaoEnsinoService : IInstituicaoEnsinoService
    {
        private readonly IInstuicaoEnsinoRepository _repository;

        public InstituicaoEnsinoService(IInstuicaoEnsinoRepository repository)
        {
            _repository = repository;
        }

        public async Task AlterarAsync(int id, string nome, string cnpj, string telefone, int cidadeId, string logradouro, string cep, string numero)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            cep = cep.Replace("-", "");

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (nome.IsNullOrEmpty()) throw new ArgumentNullException(nameof(nome));
            if (cnpj.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cnpj));
            if (telefone.IsNullOrEmpty()) throw new ArgumentNullException(nameof(telefone));
            if (cidadeId.IsLessThanZero()) throw new ArgumentNullException(nameof(cidadeId));
            if (logradouro.IsNullOrEmpty()) throw new ArgumentNullException(nameof(logradouro));
            if (cep.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cep));

            var instituicaoEnsino = await _repository.GetByAsync(id);
            if (instituicaoEnsino.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            if (instituicaoEnsino.SituacaoId != (int)EInstituicaoEnsinoSituacao.Ativo) throw new InstituicaoEnsinoSituacaoInvalidaParaAlterarException();

            var existeCNPJCadastrado = await _repository.ExisteCNPJCadastradoAsync(cnpj, id);
            if (existeCNPJCadastrado) throw new InstituicaoEnsinoCNPJJaInformadoException();

            //TODO Validar se a cidade inforada existe no banco de dados
            //var cidade = await _cidadeRepository.getByIdAsync(cidadeId)
            //if (cidade.IsNull()) throw new CidadeNaoEncontradaException();

            instituicaoEnsino.Nome = nome;
            instituicaoEnsino.CNPJ = cnpj;
            instituicaoEnsino.Telefone = telefone;
            instituicaoEnsino.Endereco.CidadeId = cidadeId;
            instituicaoEnsino.Endereco.Logradouro = logradouro;
            instituicaoEnsino.Endereco.CEP = cep;
            instituicaoEnsino.Endereco.Numero = numero;

            await _repository.UpdateAsync(instituicaoEnsino);
        }

        public async Task AtivarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var instituicaoEnsino = await _repository.GetByAsync(id);
            if (instituicaoEnsino.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            instituicaoEnsino.SituacaoId = (int)EInstituicaoEnsinoSituacao.Ativo;

            await _repository.UpdateAsync(instituicaoEnsino);
        }

        public async Task CriarAsync(string nome, string cnpj, string telefone, int cidadeId, string logradouro, string cep, string numero)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            cep = cep.Replace("-", "");

            if (nome.IsNullOrEmpty()) throw new ArgumentNullException(nameof(nome));
            if (cnpj.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cnpj));
            if (telefone.IsNullOrEmpty()) throw new ArgumentNullException(nameof(telefone));
            if (cidadeId.IsLessThanZero()) throw new ArgumentNullException(nameof(cidadeId));
            if (logradouro.IsNullOrEmpty()) throw new ArgumentNullException(nameof(logradouro));
            if (cep.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cep));

            var existeCNPJCadastrado = await _repository.ExisteCNPJCadastradoAsync(cnpj, null);
            if (existeCNPJCadastrado) throw new InstituicaoEnsinoCNPJJaInformadoException();

            //TODO Validar se a cidade inforada existe no banco de dados
            //var cidade = await _cidadeRepository.getByIdAsync(cidadeId)
            //if (cidade.IsNull()) throw new CidadeNaoEncontradaException();

            var endereco = new Endereco { 
                CidadeId = cidadeId, 
                Logradouro = logradouro,
                CEP = cep,
                Numero = numero
            };

            var instituicao = new InstituicaoEnsino
            {
                Nome = nome,
                CNPJ = cnpj,
                Telefone = telefone,
                Endereco = endereco,
                SituacaoId = (int)EInstituicaoEnsinoSituacao.Ativo
            };

            await _repository.CreateAsync(instituicao);
        }

        public async Task InativarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var instituicaoEnsino = await _repository.GetByAsync(id);
            if (instituicaoEnsino.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            instituicaoEnsino.SituacaoId = (int)EInstituicaoEnsinoSituacao.Inativo;

            await _repository.UpdateAsync(instituicaoEnsino);
        }
    }
}
