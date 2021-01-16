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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IInstuicaoEnsinoRepository _instuicaoEnsinoRepository;
        private readonly ICidadeRepository _cidadeRepository;

        public UsuarioService(IUsuarioRepository repository, IInstuicaoEnsinoRepository instuicaoEnsinoRepository, ICidadeRepository cidadeRepository)
        {
            _repository = repository;
            _instuicaoEnsinoRepository = instuicaoEnsinoRepository;
            _cidadeRepository = cidadeRepository;
        }

        public async Task AlterarAsync(int id, string nome, string cpf, string telefone, string email, int instituicaoId)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (nome.IsNullOrEmpty()) throw new ArgumentNullException(nameof(nome));
            if (cpf.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cpf));
            if (telefone.IsNullOrEmpty()) throw new ArgumentNullException(nameof(telefone));
            if (email.IsNullOrEmpty()) throw new ArgumentNullException(nameof(email));
            if (instituicaoId.IsLessThanZero()) throw new ArgumentNullException(nameof(instituicaoId));

            var usuario = await _repository.GetByAsync(id);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            if (usuario.SituacaoId != (int)EInstituicaoEnsinoSituacao.Ativo) throw new UsuarioInvalidoParaAlterarException();

            var existeCPFCadastrado = await _repository.ExisteCPFCadastradoAsync(cpf, id);
            if (existeCPFCadastrado) throw new UsuarioCPFJaInformadoException();

            var instituicaoEnsino = await _instuicaoEnsinoRepository.GetByAsync(instituicaoId);
            if (instituicaoEnsino.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();
                   

            usuario.Nome = nome;
            usuario.CPF = cpf;
            usuario.Telefone = telefone;
            usuario.Email = email;
            usuario.InstituicaoId = instituicaoId;

            await _repository.UpdateAsync(usuario);
        }

        public async Task AtivarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var usuario = await _repository.GetByAsync(id);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            usuario.SituacaoId = (int)EUsuarioSituacao.Ativo;

            await _repository.UpdateAsync(usuario);
        }

        public async Task CriarAsync(string nome, string cpf, string telefone, string email, int instituicaoId)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (nome.IsNullOrEmpty()) throw new ArgumentNullException(nameof(nome));
            if (cpf.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cpf));
            if (telefone.IsNullOrEmpty()) throw new ArgumentNullException(nameof(telefone));
            if (email.IsNullOrEmpty()) throw new ArgumentNullException(nameof(email));
            if (instituicaoId.IsLessThanZero()) throw new ArgumentNullException(nameof(instituicaoId));

            var existeCPFCadastrado = await _repository.ExisteCPFCadastradoAsync(cpf, null);
            if (existeCPFCadastrado) throw new UsuarioCPFJaInformadoException();

            var instituicaoEnsino = await _instuicaoEnsinoRepository.GetByAsync(instituicaoId);
            if (instituicaoEnsino.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            
            var usuario = new Usuario
            {
                Nome = nome,
                CPF = cpf,
                Telefone = telefone,
                Email = email,
                InstituicaoId = instituicaoId,
                SituacaoId = (int)EInstituicaoEnsinoSituacao.Ativo
            };

            await _repository.CreateAsync(usuario);
        }

        public async Task InativarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var usuario = await _repository.GetByAsync(id);
            if (usuario.IsNull()) throw new InstituicaoEnsinoNaoEncontradaException();

            usuario.SituacaoId = (int)EInstituicaoEnsinoSituacao.Inativo;

            await _repository.UpdateAsync(usuario);
        }

        public async Task InformarEnderecoAsync(int id, string logradouro, string numero, string cep, int cidadeId)
        {
            cep = cep.Replace("-", "");

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (logradouro.IsNullOrEmpty()) throw new ArgumentNullException(nameof(logradouro));
            if (cidadeId.IsLessThanZero()) throw new ArgumentNullException(nameof(cidadeId));            
            if (cep.IsNullOrEmpty()) throw new ArgumentNullException(nameof(cep));

            var usuario = await _repository.GetByAsync(id);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();

            //TODO Validar se a cidade inforada existe no banco de dados
            //var cidade = await _cidadeRepository.getByIdAsync(cidadeId)
            //if (cidade.IsNull()) throw new CidadeNaoEncontradaException();

            if (usuario.Endereco.IsNull())  {
                var endereco = new Endereco
                {
                    CidadeId = cidadeId,
                    Logradouro = logradouro,
                    CEP = cep,
                    Numero = numero
                };
                usuario.Endereco = endereco;
            }
            else
            {
                usuario.Endereco.CidadeId = cidadeId;
                usuario.Endereco.Logradouro = logradouro;
                usuario.Endereco.CEP = cep;
                usuario.Endereco.Numero = numero;
            }

            await _repository.UpdateAsync(usuario);
        }
    }
}
