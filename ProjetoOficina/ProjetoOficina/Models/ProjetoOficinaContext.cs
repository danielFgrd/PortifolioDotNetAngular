using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoOficina.Models
{
    public partial class ProjetoOficinaContext : DbContext
    {
        public ProjetoOficinaContext()
        {
        }

        public ProjetoOficinaContext(DbContextOptions<ProjetoOficinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<OrdemServico> OrdemServico { get; set; }
        public virtual DbSet<PoliticaAcesso> PoliticaAcesso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ProjetoOficina.Properties.Resources.StrConexao);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdemServico>(entity =>
            {
                entity.Property(e => e.AvaliacaoMecanico).HasColumnType("text");

                entity.Property(e => e.DefeitoEspecificado).HasColumnType("text");

                entity.Property(e => e.IdVeiculoManutencao).HasColumnName("idVeiculoManutencao");

                entity.Property(e => e.ObsLiberacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.OrdemServicoIdEstadoNavigation)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__OrdemServ__IdEst__4222D4EF");

                entity.HasOne(d => d.IdEstadoOrcamentoNavigation)
                    .WithMany(p => p.OrdemServicoIdEstadoOrcamentoNavigation)
                    .HasForeignKey(d => d.IdEstadoOrcamento)
                    .HasConstraintName("FK__OrdemServ__IdEst__4316F928");

                entity.HasOne(d => d.IdMecanicoResponsavelNavigation)
                    .WithMany(p => p.OrdemServicoIdMecanicoResponsavelNavigation)
                    .HasForeignKey(d => d.IdMecanicoResponsavel)
                    .HasConstraintName("FK__OrdemServ__IdMec__403A8C7D");

                entity.HasOne(d => d.IdProprietarioNavigation)
                    .WithMany(p => p.OrdemServicoIdProprietarioNavigation)
                    .HasForeignKey(d => d.IdProprietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdemServ__IdPro__3F466844");

                entity.HasOne(d => d.IdVeiculoManutencaoNavigation)
                    .WithMany(p => p.OrdemServico)
                    .HasForeignKey(d => d.IdVeiculoManutencao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrdemServ__idVei__412EB0B6");
            });

            modelBuilder.Entity<PoliticaAcesso>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPoliticaAcessoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPoliticaAcesso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdPolit__440B1D61");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProprietarioNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.IdProprietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Veiculo__IdPropr__44FF419A");
            });
        }
    }
}
