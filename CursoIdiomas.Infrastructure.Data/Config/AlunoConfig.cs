using CursoIdiomas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoIdiomas.Infrastructure.Data.Context
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("Date");

            builder.Property(a => a.DataModificacao)
                .HasColumnName("DataModificacao")
                .HasColumnType("Date");

            builder.Property(a => a.Matricula)
                .IsRequired()
                .HasColumnName("Matricula")
                .HasMaxLength(15);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(50);

            builder.Property(a => a.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasMaxLength(50);

            builder.Property(a => a.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasMaxLength(13);

            builder.Property(a => a.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(100);

            builder.Property(a => a.Endereco)
                .IsRequired()
                .HasColumnName("Endereco")
                .HasMaxLength(150);

            #region
            /*
            builder.OwnsOne(a => a.Telefone, telefone =>
            {
                telefone.Property(a => a.Residencial)
                .HasColumnName("Residencial")
                .HasMaxLength(13);

                telefone.Property(a => a.Celular)
                .IsRequired()
                .HasColumnName("Celular")
                .HasMaxLength(13);
            });

            builder.OwnsOne(a => a.Endereco, endereco =>
            {
                endereco.Property(a => a.Cep)
                .IsRequired()
                .HasColumnName("Cep")
                .HasMaxLength(8);

                endereco.Property(a => a.Logradouro)
                .IsRequired()
                .HasColumnName("Logradouro")
                .HasMaxLength(100);

                endereco.Property(a => a.Bairro)
                .IsRequired()
                .HasColumnName("Bairro")
                .HasMaxLength(50);

                endereco.Property(a => a.Cidade)
                .IsRequired()
                .HasColumnName("Cidade")
                .HasMaxLength(50);

                endereco.Property(a => a.Estado)
                .IsRequired()
                .HasColumnName("Estado")
                .HasMaxLength(50);

                endereco.Property(a => a.Lote)
                .IsRequired()
                .HasColumnName("Lote")
                .HasMaxLength(25);

                endereco.Property(a => a.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(50);
            });
            */
            #endregion

            builder.HasOne(t => t.Turma).WithMany(a => a.Alunos).HasForeignKey(a => a.TurmaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}