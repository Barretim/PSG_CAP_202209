using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedVet.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace MedVet.Domain.EF
{
    public partial class MedVetContext : DbContext
    {
        public virtual DbSet<Atendimento> Atendimentos { get; set; } = null!;
        public virtual DbSet<Cidade> Cidades { get; set; } = null!;
        public virtual DbSet<Convenio> Convenios { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pessoa> Pessoas { get; set; } = null!;
        public virtual DbSet<TipoAtendimento> TipoAtendimentos { get; set; } = null!;
        public virtual DbSet<TipoPessoa> TipoPessoas { get; set; } = null!;
       
        public MedVetContext()
        { }

        public MedVetContext(DbContextOptions<MedVetContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInsert).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInsert).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoAtendimento>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInsert).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoPessoa>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInsert).HasDefaultValueSql("(getdate())");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}