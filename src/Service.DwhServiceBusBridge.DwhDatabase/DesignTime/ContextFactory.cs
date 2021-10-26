using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Service.DwhServiceBusBridge.DwhDatabase.DesignTime
{
    public class ContextFactory: IDesignTimeDbContextFactory<DwhContext>
    {
        public ContextFactory()
        {
        }

        public DwhContext CreateDbContext(string[] args)
        {
            var connString = string.Empty;

            while (string.IsNullOrEmpty(connString))
            {
                Console.Write("Connection string: ");
                connString = Console.ReadLine();
            }

            var optionsBuilder = new DbContextOptionsBuilder<DwhContext>();
            optionsBuilder.UseSqlServer(connString);
            //optionsBuilder.UseNpgsql(connString);

            return new DwhContext(optionsBuilder.Options);
        }
    }
}