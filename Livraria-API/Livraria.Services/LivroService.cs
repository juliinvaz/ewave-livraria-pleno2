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

        public async Task AlterarAsync(int id, string titulo, string genero, string autor, string sinopse, string capa)
        {

            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));
            if (titulo.IsNullOrEmpty()) throw new ArgumentNullException(nameof(titulo));
            if (genero.IsNullOrEmpty()) throw new ArgumentNullException(nameof(genero));
            if (autor.IsNullOrEmpty()) throw new ArgumentNullException(nameof(autor));
            if (sinopse.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sinopse));
            if (capa.IsNullOrEmpty()) throw new ArgumentNullException(nameof(capa));
            
            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            if (livro.SituacaoId != (int)ELivroSituacao.Disponivel) throw new LivroInvalidoParaAlterarException();

            livro.Titulo = titulo;
            livro.Genero = genero;
            livro.Autor = autor;
            livro.Sinopse = sinopse;
            livro.Capa = capa;

            await _repository.UpdateAsync(livro);
        }

        public async Task AtivarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            if (livro.SituacaoId != (int)ELivroSituacao.Inativo) throw new LivroSituacaoInvalidaParaAtivarException();

            livro.SituacaoId = (int)ELivroSituacao.Disponivel;

            await _repository.UpdateAsync(livro);
        }

        public async Task CriarAsync(string titulo, string genero, string autor, string sinopse, string capa)
        {

            if (titulo.IsNullOrEmpty()) throw new ArgumentNullException(nameof(titulo));
            if (genero.IsNullOrEmpty()) throw new ArgumentNullException(nameof(genero));
            if (autor.IsNullOrEmpty()) throw new ArgumentNullException(nameof(autor));
            if (sinopse.IsNullOrEmpty()) throw new ArgumentNullException(nameof(sinopse));
            if (capa.IsNullOrEmpty()) throw new ArgumentNullException(nameof(capa));

            var livro = new Livro
            {
                Titulo = titulo,
                Genero = genero,
                Autor = autor,
                Sinopse = sinopse,
                Capa = capa,
                SituacaoId = (int)ELivroSituacao.Disponivel
            };

            await _repository.CreateAsync(livro);
        }

        public async Task InativarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var livro = await _repository.GetByAsync(id);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();

            if (livro.SituacaoId != (int)ELivroSituacao.Disponivel) throw new LivroSituacaoInvalidaParaInativarException();

            livro.SituacaoId = (int)ELivroSituacao.Inativo;

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
