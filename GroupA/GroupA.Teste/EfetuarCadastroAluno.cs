using GroupA.Application.Interfaces.Repositories;
using GroupA.Application.Services;
using GroupA.Application.Utils;
using GroupA.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GroupA.Teste
{
    public class EfetuarCadastroAluno
    {
        private readonly Aluno _alunoMock = new Aluno
        {
            Id = 1,
            Ra = 12342,
            Name = "test",
            Cpf = "421.531.321-21",
            CreatedAt = DateUtil.GetCurrentDate(),
            Email = "TESTE@TESTE.COM.BR",
        };

        private Mock<IAlunoRepository> MockAlunoRepository()
        {
            var mock = new Mock<IAlunoRepository>();

            mock.Setup(x => x.CreateAluno(It.IsAny<Aluno>()));

            return mock;
        }

        [Fact]
        public async Task DeveInserirAlunoComSucesso()
        {
            var alunoRepository = MockAlunoRepository();

            var alunoService = new AlunoService(alunoRepository.Object);

            await alunoService.CreateAluno(_alunoMock);

            alunoRepository.Verify(x => x.CreateAluno(It.IsAny<Aluno>()), Times.Once());
        }
    }
}
