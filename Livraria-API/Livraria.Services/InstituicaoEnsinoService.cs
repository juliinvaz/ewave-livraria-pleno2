using Livraria.Domain.Exceptions;
using Livraria.Domain.Models;
using Livraria.Domain.Services;
using Livraria.Infra.EF.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Services
{
    public class InstituicaoEnsinoService : IInstituicaoEnsinoService
    {
        private readonly InstituicaoEnsinoRepository _repository;

        public InstituicaoEnsinoService(InstituicaoEnsinoRepository repository)
        {
            _repository = repository;
        }

        public Task AlterarAsync(int id, string nome, string cnpj, string telefone, int cidadeId, string logadouro, string cep, string numero)
        {
            throw new NotImplementedException();
        }

        public Task AtivarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CriarAsync(string nome, string cnpj, string telefone, int cidadeId, string logadouro, string cep, string numero)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            cep = cep.Replace("-", "");

            if (nome.IsNullOrEmpty()) throw new ArgumentNullException(nameof(nome));
            if (cnpj.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cnpj));
            if (telefone.IsNullOrEmpty()) throw new ArgumentNullException(nameof(telefone));
            if (cidadeId.IsLessThanZero()) throw new ArgumentNullException(nameof(cidadeId));
            if (logadouro.IsNullOrEmpty()) throw new ArgumentNullException(nameof(logadouro));
            if (cep.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cep));

            var existeCNPJCadastrado = await _repository.ExisteCNPJCadastradoAsync(cnpj, null);
            if (existeCNPJCadastrado) throw new InstituicaoEnsinoCNPJJaInformadoException();

            var endereco = new Endereco { 
                CidadeId = cidadeId, 
                Logradouro = logadouro,
                CEP = cep,
                Numero = numero
            };

            var instituicao = new InstituicaoEnsino
            {
                Nome = nome,
                CNPJ = cnpj,
                Telefone = telefone,
                Endereco = endereco
            };

            await _repository.CreateAsync(instituicao);


        }

        public Task InativarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
