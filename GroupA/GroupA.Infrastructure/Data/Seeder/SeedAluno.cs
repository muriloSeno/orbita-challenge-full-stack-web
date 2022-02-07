using GroupA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Infrastructure.Data.Seeder
{
    public class SeedAluno : ISeed
    {
        public void Executar(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
            new Aluno
            {
              Name = "Murilo Seno Gomes",
              Cpf = "12304877782",
              Ra = 101235,
              Email = "Email.Teste@gmail.com",
              CreatedAt = DateTime.Now
          });
        }
    }
}