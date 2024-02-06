using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Brans> Branslar { get; set; }

        public DbSet<Doktor> Doktorlar { get; set; }

        public DbSet<DoktorHasta> DoktorHastalar { get; set; }

        public DbSet<Hasta> Hastalar { get; set; }

        public DbSet<Klinik> Klinikler { get; set; }

        public Db(DbContextOptions options) : base(options)
        {
                
        }
    }
}
