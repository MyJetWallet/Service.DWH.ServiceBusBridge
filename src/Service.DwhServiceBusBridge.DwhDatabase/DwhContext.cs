using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class DwhContext : DbContext
    {
        public const string Schema = "sbus";
        public const string TestTableName = "test_table";
        
        public static ILoggerFactory LoggerFactory { get; set; }
        
        public DbSet<TestEntity> TestTable { get; set; }

        public DwhContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (LoggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<TestEntity>().ToTable(TestTableName);
            modelBuilder.Entity<TestEntity>().HasKey(e => new { e.Id });
            modelBuilder.Entity<TestEntity>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<TestEntity>().Property(e => e.Message).HasMaxLength(255);
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        
        public DateTime Timestamp { get; set; }
    }
}