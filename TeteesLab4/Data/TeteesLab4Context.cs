using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TeteesLab4.Models
{
    public class TeteesLab4Context : DbContext
    {
        public TeteesLab4Context (DbContextOptions<TeteesLab4Context> options)
            : base(options)
        {
        }

        public DbSet<TeteesLab4.Models.Tetees> Tetees { get; set; }
    }
}
