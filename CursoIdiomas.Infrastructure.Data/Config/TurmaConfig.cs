using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infrastructure.Data.Context
{
    public class TurmaConfig : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("Turmas");

            builder.HasKey(t => t.Id);

            builder.Property(a => a.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("Date");

            builder.Property(a => a.DataModificacao)
                .HasColumnName("DataModificacao")
                .HasColumnType("Date");

            builder.Property(t => t.Codigo)
                .IsRequired()
                .HasColumnName("Codigo")
                .HasMaxLength(50);

            builder.Property(t => t.Idioma)
                .IsRequired()
                .HasColumnName("Idioma")
                .HasMaxLength(50);
        }
    }
}