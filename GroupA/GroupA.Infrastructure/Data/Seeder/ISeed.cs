using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Infrastructure.Data.Seeder
{
    public interface ISeed
    {
        public void Executar(ModelBuilder modelBuilder);
    }
}
