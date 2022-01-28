using GroupA.Application.Interfaces.Repositories;
using GroupA.Application.Interfaces.Services;
using GroupA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public Task<Aluno> CreateAluno(Aluno aluno)
        {
            aluno.CreatedAt = DateTime.Now;

            return _repository.CreateAluno(aluno);
        }

        public Task DeleteAlunoById(int alunoId)
        {
            return _repository.DeleteAlunoById(alunoId);
        }

        public Task<Aluno> GetAlunoById(int alunoId)
        {
            return _repository.GetAlunoById(alunoId);
        }

        public Task<List<Aluno>> GetAlunos()
        {
            return _repository.GetAlunos();
        }

        public Task<Aluno> UpdateAluno(int alunoId, Aluno aluno)
        {
            return _repository.UpdateAluno(alunoId, aluno);
        }
    }
}
