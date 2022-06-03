using Microsoft.EntityFrameworkCore;
using ThermalModelServer.Model;

namespace ThermalModelServer
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cluster>(e =>
            {
                e.HasKey(s =>s.Id );

                e.ToTable("Cluster");
            });

            modelBuilder.Entity<Block>(e =>
            {
                e.HasKey(s => s.Id);

                e.HasIndex(s =>
                    new { s.ClusterId, s.Number });

                e.ToTable("Block");
            });

            modelBuilder.Entity<Sensor>(e =>
            {
                e.HasKey(s => s.Id );

                e.HasIndex(s =>
                    new { s.BlockId, s.Number });

                e.ToTable("Sensor");
            });

            modelBuilder.Entity<Data>(e =>
            {
                e.HasOne(d => d.Sensor)
                .WithMany(s => s.Datas);

                e.HasKey(d => new { d.SensorId, d.CheckDate });

                e.ToTable("Data");
            });
        }

        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}
