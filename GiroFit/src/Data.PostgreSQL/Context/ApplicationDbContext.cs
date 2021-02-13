using Domain.Models.PostgreSql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.PostgreSQL.Context {

    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //TABLES
        public DbSet<User> User { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Train> Train { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<ExerciseTrain> ExerciseTrain { get; set; }
        public DbSet<TrainModule> TrainModule { get; set; }
        public DbSet<UserModule> UserModule { get; set; }
        public DbSet<UserTrain> UserTrain { get; set; }
        public DbSet<UserExercise> UserExercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            if(optionsBuilder.IsConfigured) {
                base.OnConfiguring(optionsBuilder);
                return;
            }

            string pathToContentRoot = Directory.GetCurrentDirectory().Replace(".Data.PostgreSQL", ".WebApi");
            string json = Path.Combine("WebApi", "appsettings.json");

            if(!File.Exists(json)) {
                string pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(pathToContentRoot)
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = configurationBuilder.Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {

            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null)) {
                if(entry.State == EntityState.Added) {
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified) {
                    entry.Property("UpdateDate").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> Commit() {
            return await SaveChangesAsync();
        }
    }
}
