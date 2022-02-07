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

        public async Task<Aluno> CreateAluno(Aluno aluno)
        {
            aluno.CreatedAt = DateTime.Now;

            return await _repository.CreateAluno(aluno);
        }

        public async Task DeleteAlunoById(int alunoId)
        {
            await _repository.DeleteAlunoById(alunoId);
        }

        public async Task<Aluno> GetAlunoById(int alunoId)
        {
            return await _repository.GetAlunoById(alunoId);
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _repository.GetAlunos();
        }

        public async Task<Aluno> UpdateAluno(int alunoId, Aluno aluno)
        {
            return await _repository.UpdateAluno(alunoId, aluno);
        }
    }
}
