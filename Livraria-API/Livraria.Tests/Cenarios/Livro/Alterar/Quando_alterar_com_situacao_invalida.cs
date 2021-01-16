using FluentAssertions;
using Livraria.Domain.Enums;
using Livraria.Domain.Exceptions;
using Livraria.Domain.Repositories;
using Livraria.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Livraria.Tests.Cenarios.Livro.Alterar
{
    public class Quando_alterar_com_situacao_invalida
    {
        private readonly LivroService _service;
        private readonly Mock<ILivroRepository> _mockRepository = new Mock<ILivroRepository>();

        private readonly int _id = 14;
        private readonly string _titulo = "A era do dragão";
        private readonly string _genero = "Ação";
        private readonly string _autor = "Cleber";
        private readonly string _sinopse = "era uma vez ....";
        private readonly string _capa = "https://media.fstatic.com/Jbi83dhbCZdMVjd2p3QVfaBOq1I=/290x478/smart/media/movies/covers/2011/03/a13d3df4f66386987fdfea49e5654a14.jpg";
        private readonly int _situacaoId = (int)ELivroSituacao.Emprestado;

        public Quando_alterar_com_situacao_invalida()
        {

            _mockRepository.Setup(x => x.GetByAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Domain.Models.Livro
                {
                    Id = _id,
                    Titulo = _titulo,
                    Genero = _genero,
                    Autor = _autor,
                    Sinopse = _sinopse,
                    Capa = _capa,
                    SituacaoId = _situacaoId
                }
                ));

            _service = new LivroService(_mockRepository.Object);
        }


        [Fact]
        public void Quando_rodar_funcao()
        {
            var action = new Action(() => _service.AlterarAsync(_id, _titulo, _genero, _autor, _sinopse, _capa).GetAwaiter().GetResult());

            action.Should().Throw<LivroInvalidoParaAlterarException>();
        }
    }
}
