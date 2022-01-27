using GroupA.Application.Interfaces.Repositories;
using GroupA.Application.Utils;
using GroupA.Domain.Entities;
using GroupA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly SqlDbContext _dbContext;

        public AlunoRepository(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Aluno> CreateAluno(Aluno aluno)
        {
            _dbContext.Alunos.Add(aluno);
            await _dbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task DeleteAlunoById(int alunoId)
        {
            var aluno = await _dbContext.Alunos.FindAsync(alunoId);
            if (aluno == null)
            {
                _dbContext.Alunos.Remove(aluno);
                await _dbContext.SaveChangesAsync();
            }
            else throw new NotFoundException();
        }

        public async Task<Aluno> GetAlunoById(int alunoId)
        {
            var aluno = await _dbContext.Alunos.FindAsync(alunoId);
            if (aluno != null)
            {
                return aluno;
            }

            throw new NotFoundException();
        }

        public Task<List<Aluno>> GetAlunos()
        {
            return Task.FromResult(_dbContext.Alunos.ToList());
        }

        public async Task<Aluno> UpdateAluno(int alunoId, Aluno alunoUpdate)
        {
            var aluno = await _dbContext.Alunos.FindAsync(alunoId);
            if (aluno != null)
            {
                aluno.Name = alunoUpdate.Name;
                aluno.Email = alunoUpdate.Email;
                aluno.UpdatedAt = DateUtil.GetCurrentDate();

                _dbContext.Alunos.Update(aluno);
                await _dbContext.SaveChangesAsync();

                return aluno;
            }

            throw new NotFoundException();
        }
    }
}
