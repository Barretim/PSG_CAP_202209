using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeFacil.DB.EF
{
    public partial class ViajeFacilContexto : DbContext
    {

        public ViajeFacilContexto() : base()
        { }

        public ViajeFacilContexto(DbContextOptions<ViajeFacilContexto> options) : base(options)
        { }

        public virtual DbSet<cidade> Cidades { get; set; } = null!;
        public virtual DbSet<endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<estado> Estados { get; set; } = null!;
        public virtual DbSet<evento> Eventos { get; set; } = null!;
        public virtual DbSet<instituicao> Instituicaos { get; set; } = null!;
        public virtual DbSet<pais> TiposServico { get; set; } = null!;
        public virtual DbSet<participanteevento> Participanteeventos { get; set; } = null!;
        public virtual DbSet<pontoparada> Pontoparadas { get; set; } = null!;
        public virtual DbSet<regiao> Regiaos { get; set; } = null!;
        public virtual DbSet<rota> Rotas { get; set; } = null!;
        public virtual DbSet<tipousuario> Tipousuarios { get; set; } = null!;
        public virtual DbSet<usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
