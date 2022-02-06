using GroupA.Application.Interfaces.Repositories;
using GroupA.Application.Utils;
using GroupA.Domain.Entities;
using GroupA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        protected readonly DbSet<Aluno> DbSet;

        public AlunoRepository(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<Aluno>();
        }

        public async Task<Aluno> CreateAluno(Aluno aluno)
        {
            await DbSet.AddAsync(aluno);
            await SaveChanges();

            return aluno;
        }

        public async Task DeleteAlunoById(int alunoId)
        {
            DbSet.Remove(new Aluno { Ra = alunoId });
            await SaveChanges();
        }

        public async Task<Aluno> GetAlunoById(int alunoId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Ra == alunoId);
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            try
            {
                return await DbSet.ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }    

            return await DbSet.ToListAsync();
        }

        public async Task<Aluno> UpdateAluno(int alunoId, Aluno alunoUpdate)
        {
            var aluno = DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Ra == alunoId).Result;

            if (aluno != null)
            {
                aluno.Name = alunoUpdate.Name;
                aluno.Email = alunoUpdate.Email;
                aluno.UpdatedAt = DateUtil.GetCurrentDate();

                DbSet.Update(aluno);
                await SaveChanges();

                return aluno;
            }

            throw new NotFoundException();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
