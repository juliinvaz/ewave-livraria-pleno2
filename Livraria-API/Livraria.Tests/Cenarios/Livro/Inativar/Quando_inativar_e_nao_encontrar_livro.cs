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
    public class Quando_inativar_e_nao_encontrar_livro
    {
        private readonly LivroService _service;
        private readonly Mock<ILivroRepository> _mockRepository = new Mock<ILivroRepository>();

        private readonly int _id = 14;

        public Quando_inativar_e_nao_encontrar_livro()
        {

            _mockRepository.Setup(x => x.GetByAsync(It.IsAny<int>())).Returns(Task.FromResult<Domain.Models.Livro>(null));

            _service = new LivroService(_mockRepository.Object);
        }


        [Fact]
        public void Quando_rodar_funcao()
        {
            var action = new Action(() => _service.InativarAsync(_id).GetAwaiter().GetResult());

            action.Should().Throw<LivroNaoEncontradoException>();
        }
    }
}
