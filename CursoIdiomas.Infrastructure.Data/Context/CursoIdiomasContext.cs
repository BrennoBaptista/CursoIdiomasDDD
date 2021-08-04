using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoIdiomas.Infrastructure.Data.Context
{
    public class CursoIdiomasContext : DbContext
    {
        public CursoIdiomasContext() { }
        public CursoIdiomasContext(DbContextOptions<CursoIdiomasContext> options)
            : base(options)
        { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (prop.GetColumnType() == null)
                    prop.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfiguration(new AlunoConfig());
            modelBuilder.ApplyConfiguration(new TurmaConfig());

            base.OnModelCreating(modelBuilder);
        }

        private string GetConnectionString()
        {
            return "Server=(localdb)\\MSSQLLocalDB;" +
                   "Database=CursoIdiomasDDD;" +
                   "Trusted_Connection=True;" +
                   "MultipleActiveResultSets=True;";
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
