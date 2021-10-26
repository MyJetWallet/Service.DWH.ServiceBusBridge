using Microsoft.EntityFrameworkCore;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public interface IDwhDbContextFactory
    {
        DwhContext Create();
    }

    public class DwhDbContextFactory : IDwhDbContextFactory
    {
        private readonly DbContextOptionsBuilder<DwhContext> _dbContextOptionsBuilder;

        public DwhDbContextFactory(DbContextOptionsBuilder<DwhContext> dbContextOptionsBuilder)
        {
            _dbContextOptionsBuilder = dbContextOptionsBuilder;
        }


        public DwhContext Create()
        {
            return new DwhContext(_dbContextOptionsBuilder.Options);
        }
    }
}