using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class DbFactory : IDesignTimeDbContextFactory<Db>
    {
        public Db CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Db>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=HastaTakipDB;trusted_connection=true;trustservercertificate=true;");

            return new Db(optionsBuilder.Options);
        }
    }
}
