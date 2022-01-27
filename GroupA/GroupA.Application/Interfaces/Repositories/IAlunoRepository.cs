using GroupA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Application.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAlunos();

        Task<Aluno> GetAlunoById(int alunoId);

        Task DeleteAlunoById(int alunoId);

        Task<Aluno> CreateAluno(Aluno aluno);

        Task<Aluno> UpdateAluno(int alunoId, Aluno alunoUpdate);
    }
}
