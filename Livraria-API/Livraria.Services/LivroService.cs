using Livraria.Domain.Exceptions;
using Livraria.Domain;
using Livraria.Domain.Repositories;
using Livraria.Infra.Extentions;
using System;
using System.Threading.Tasks;
using Livraria.Domain.Services;
using Livraria.Domain.Models;
using Livraria.Domain.Enums;
using System.Collections.Generic;

namespace Livraria.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task AlterarAsync(int id, string titulo, string genero, string autor, string sinopse, string capa, int situacaoId)
        {

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (titulo.IsNullOrEmpty()) throw new ArgumentNullException(nameof(titulo));
            if (genero.IsNullOrEmpty()) throw new ArgumentNullException(nameof(genero));
            if (autor.IsNullOrEmpty()) throw new ArgumentNullException(nameof(autor));
            if (sinopse.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sinopse));
            if (capa.IsNullOrEmpty()) throw new ArgumentNullException(nameof(capa));
            if (situacaoId.IsLessThanZero()) throw new ArgumentNullException(nameof(situacaoId));
            
            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            if (livro.SituacaoId != (int)EInstituicaoEnsinoSituacao.Ativo) throw new LivroInvalidoParaAlterarException();

            //var existeCPFCadastrado = await _repository.ExisteCPFCadastradoAsync(cpf, id);
            //if (existeCPFCadastrado) throw new UsuarioCPFJaInformadoException();

            //TODO Validar se a cidade inforada existe no banco de dados
            //var cidade = await _cidadeRepository.getByIdAsync(cidadeId)
            //if (cidade.IsNull()) throw new CidadeNaoEncontradaException();

            livro.Titulo = titulo;
            livro.Genero = genero;
            livro.Autor = autor;
            livro.Sinopse = sinopse;
            livro.Capa = capa;
            livro.Situacao.Id = situacaoId;

            await _repository.UpdateAsync(livro);
        }

        public async Task AtivarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            livro.SituacaoId = (int)EUsuarioSituacao.Ativo;

            await _repository.UpdateAsync(livro);
        }

        public async Task CriarAsync(string titulo, string genero, string autor, string sinopse, string capa, int situacaoId)
        {

            if (titulo.IsNullOrEmpty()) throw new ArgumentNullException(nameof(titulo));
            if (genero.IsNullOrEmpty()) throw new ArgumentNullException(nameof(genero));
            if (autor.IsNullOrEmpty()) throw new ArgumentNullException(nameof(autor));
            if (sinopse.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sinopse));
            if (capa.IsNullOrEmpty()) throw new ArgumentNullException(nameof(capa));
            if (situacaoId.IsLessThanZero()) throw new ArgumentNullException(nameof(situacaoId));

            //var existeCPFCadastrado = await _repository.ExisteCPFCadastradoAsync(cpf, null);
            //if (existeCPFCadastrado) throw new UsuarioCPFJaInformadoException();

            //TODO Validar se a cidade inforada existe no banco de dados
            //var cidade = await _cidadeRepository.getByIdAsync(cidadeId)
            //if (cidade.IsNull()) throw new CidadeNaoEncontradaException();

            var livro = new Livro
            {
                Titulo = titulo,
                Genero = genero,
                Autor = autor,
                Sinopse = sinopse,
                Capa = capa,
                SituacaoId = (int)EInstituicaoEnsinoSituacao.Ativo
            };

            await _repository.CreateAsync(livro);
        }

        public async Task InativarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            if (livro.SituacaoId != (int)ELivroSituacao.Disponivel) throw new LivroSituacaoInvalidaParaInativarException();

            livro.SituacaoId = (int)EInstituicaoEnsinoSituacao.Inativo;

            await _repository.UpdateAsync(livro);
        }

        public async Task<Livro> ObterPorIdAsync(int id)
        {
            return await _repository.GetByAsync(id);
        }

        public async Task<IEnumerable<Livro>> ObterPorSituacaoAsync(int situacaoId)
        {
            return await _repository.ObterLivrosPorSituacaoAsync(situacaoId);
        }

        public async Task<IEnumerable<Livro>> ObterTodosAsync()
        {
            return await _repository.ObterTodosLivrosAsync();
        }


    }
}
