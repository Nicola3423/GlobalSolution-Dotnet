using Microsoft.EntityFrameworkCore;
using SeuProjeto.Models;

namespace SeuProjeto.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PontuacaoQuiz> PontuacoesQuiz { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }
        public DbSet<FeedbackUsuario> FeedbackUsuarios { get; set; }
        public DbSet<DicaEconomia> DicasEconomia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS"); // Nome da tabela no Oracle
                entity.HasKey(u => u.UsuarioId);
                entity.Property(u => u.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(u => u.Nome).IsRequired().HasMaxLength(100).HasColumnName("NOME");
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100).HasColumnName("EMAIL");
                entity.Property(u => u.Senha).IsRequired().HasMaxLength(255).HasColumnName("SENHA");
                entity.Property(u => u.DataCadastro).HasColumnName("DATA_CADASTRO");
            });

            modelBuilder.Entity<PontuacaoQuiz>(entity =>
            {
                entity.ToTable("PONTUACOES_QUIZ");
                entity.HasKey(p => p.PontuacaoId);
                entity.Property(p => p.PontuacaoId).HasColumnName("PONTUACAO_ID");
                entity.Property(p => p.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(p => p.QuizId).HasColumnName("QUIZ_ID");
                entity.Property(p => p.Pontuacao).IsRequired().HasColumnName("PONTUACAO");
                entity.Property(p => p.DataParticipacao).HasColumnName("DATA_PARTICIPACAO");

                entity.HasOne(p => p.Usuario)
                    .WithMany(u => u.Pontuacoes)
                    .HasForeignKey(p => p.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Conteudo>(entity =>
            {
                entity.ToTable("CONTEUDOS");
                entity.HasKey(c => c.ConteudoId);
                entity.Property(c => c.ConteudoId).HasColumnName("CONTEUDO_ID");
                entity.Property(c => c.Titulo).IsRequired().HasMaxLength(255).HasColumnName("TITULO");
                entity.Property(c => c.Descricao).HasMaxLength(1000).HasColumnName("DESCRICAO");
                entity.Property(c => c.Tipo).HasMaxLength(50).HasColumnName("TIPO");
                entity.Property(c => c.DataPublicacao).HasColumnName("DATA_PUBLICACAO");
            });

            modelBuilder.Entity<Interacao>(entity =>
            {
                entity.ToTable("INTERACOES");
                entity.HasKey(i => i.InteracaoId);
                entity.Property(i => i.InteracaoId).HasColumnName("INTERACAO_ID");
                entity.Property(i => i.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(i => i.ConteudoId).HasColumnName("CONTEUDO_ID");
                entity.Property(i => i.TipoInteracao).HasMaxLength(50).HasColumnName("TIPO_INTERACAO");
                entity.Property(i => i.DataInteracao).HasColumnName("DATA_INTERACAO");

                entity.HasOne(i => i.Usuario)
                    .WithMany(u => u.Interacoes)
                    .HasForeignKey(i => i.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(i => i.Conteudo)
                    .WithMany(c => c.Interacoes)
                    .HasForeignKey(i => i.ConteudoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<FeedbackUsuario>(entity =>
            {
                entity.ToTable("FEEDBACK_USUARIO");
                entity.HasKey(f => f.FeedbackId);
                entity.Property(f => f.FeedbackId).HasColumnName("FEEDBACK_ID");
                entity.Property(f => f.UsuarioId).HasColumnName("USUARIO_ID");
                entity.Property(f => f.ConteudoId).HasColumnName("CONTEUDO_ID");
                entity.Property(f => f.Mensagem).IsRequired().HasMaxLength(500).HasColumnName("MENSAGEM");
                entity.Property(f => f.DataFeedback).HasColumnName("DATA_FEEDBACK");

                entity.HasOne(f => f.Usuario)
                    .WithMany(u => u.Feedbacks)
                    .HasForeignKey(f => f.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(f => f.Conteudo)
                    .WithMany(c => c.Feedbacks)
                    .HasForeignKey(f => f.ConteudoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DicaEconomia>(entity =>
            {
                entity.ToTable("DICAS_ECONOMIA");
                entity.HasKey(d => d.DicaId);
                entity.Property(d => d.DicaId).HasColumnName("DICA_ID");
                entity.Property(d => d.Titulo).IsRequired().HasMaxLength(255).HasColumnName("TITULO");
                entity.Property(d => d.Descricao).HasMaxLength(1000).HasColumnName("DESCRICAO");
                entity.Property(d => d.DataPublicacao).HasColumnName("DATA_PUBLICACAO");
            });
        }
    }
}
