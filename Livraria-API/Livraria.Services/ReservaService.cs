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
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ReservaService(IReservaRepository repository, ILivroRepository livroRepository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task CriarAsync(int usuarioId, int livroId)
        {

            if (usuarioId.IsLessThanZero()) throw new ArgumentNullException(nameof(usuarioId));
            if (livroId.IsLessThanZero()) throw new ArgumentNullException(nameof(livroId));

            var usuario = await _usuarioRepository.GetByAsync(usuarioId);
            if (usuario.IsNull()) throw new UsuarioNaoEncontradoException();
            if (usuario.SituacaoId != (int)EUsuarioSituacao.Ativo) throw new ReservaLivroSituacaoIvalidaParaEmprestarException();


            var livro = await _livroRepository.GetByAsync(livroId);
            if (livro.IsNull()) throw new LivroNaoEncontradoException();
            if (livro.SituacaoId != (int)ELivroSituacao.Disponivel) throw new ReservaLivroSituacaoIvalidaParaEmprestarException();


            var reserva = new Reserva
            {
                Data = DateTime.Now,
                UsuarioId = usuarioId,
                LivroId = livroId,
                SituacaoId = (int)EReservaSituacao.Ativo
            };

            livro.SituacaoId = (int)ELivroSituacao.Reservado;

            await _livroRepository.UpdateAsync(livro);
            await _repository.CreateAsync(reserva);
        }

        public async Task InativarAsync(int id)
        {
            if (id.IsLessThanZero()) throw new ArgumentNullException(nameof(id));

            var reserva = await _repository.GetByAsync(id);
            if (reserva.IsNull()) throw new ReservaNaoEncontradaException();


            reserva.SituacaoId = (int)EReservaSituacao.Inativo;
            reserva.Livro.SituacaoId = (int)ELivroSituacao.Disponivel;

            await _repository.UpdateAsync(reserva);
        }

        public async Task<Reserva> ObterPorIdAsync(int id)
        {
            return await _repository.GetByAsync(id);
        }

        public async Task<IEnumerable<Reserva>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }
    }
}
