using Microsoft.EntityFrameworkCore;
namespace App_comunicacao_escolar.Models

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Conversa>? Conversas { get; set; }
        public DbSet<Mensagem>? Mensagens { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Professor>? Professores { get; set; }
        public DbSet<Responsavel>? Responsaveis { get; set; }
        public DbSet<NumeroDeNovasMensagensNaConversa>? NumeroDeNovasMensagensNaConversa { get; set; }
        public DbSet<UsuariosQueArquivaramConversa>? UsuariosQueArquivaramConversa { get; set; }
        public DbSet<MensagemArquivosAnexados>? Anexos { get; set; }
        public DbSet<Disciplina>? Disciplinas { get; set; }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<HorariosDaDisciplina>? HorariosDasDisciplinas { get; set; }
        public DbSet<Turma>? Turmas { get; set; }
        public DbSet<Agenda>? Agendas { get; set; }
        public DbSet<EventoDaAgenda>? EventosDaAgenda { get; set; }
        public DbSet<AutorizacaoEvento>? AutorizacoesEventos { get; set; }
        public DbSet<Notificacao>? Notificacoes { get; set; }
        public DbSet<UsuarioLeuNotificacao>? UsuarioLeuNotificacao { get; set; }
        public DbSet<AlunoLinhaDoTempo>? AlunosLinhaDoTempo { get; set; }
        public DbSet<PostagemLinhaDoTempo>? PostagensLinhaDoTempo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasIndex(d => d.NomeDeUsuario).IsUnique();
            modelBuilder.Entity<Usuario>()
            .HasIndex(d => d.Email).IsUnique();

            modelBuilder.Entity<Disciplina>()
            .HasIndex(d => d.Codigo).IsUnique();

            modelBuilder.Entity<Turma>()
            .HasIndex(d => d.Codigo).IsUnique();

            modelBuilder.Entity<Aluno>()
            .HasIndex(d => d.CodigoDoAluno).IsUnique();

            modelBuilder.Entity<Conversa>()
            .HasMany(c => c.Mensagens)
            .WithOne(m => m.Conversa)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conversa>()
            .HasMany(c => c.NumeroDeNovasMensagensNaConversa)
            .WithOne(n => n.Conversa)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conversa>()
            .HasMany(c => c.UsuariosQueArquivaramConversa)
            .WithOne(u => u.Conversa)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mensagem>()
            .HasMany(m => m.Anexos)
            .WithOne(a => a.MensagemDosAnexos)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Mensagem>()
            .HasOne(m => m.MensagemRespondida)
            .WithMany(mr => mr.Respostas)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Disciplina>()
            .HasMany(d => d.HorariosDaDisciplina)
            .WithOne(h => h.Disciplina)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
            .HasMany(t => t.Disciplinas)
            .WithOne(d => d.Turma)
            .OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Turma>()
            .HasMany(t => t.Alunos)
            .WithOne(d => d.Turma)
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EventoDaAgenda>()
            .HasMany(e => e.Autorizacoes)
            .WithOne(a => a.Evento)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aluno>()
            .HasMany(a => a.Autorizacoes)
            .WithOne(au => au.Aluno)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notificacao>()
            .HasMany(n => n.NotificacoesLidas)
            .WithOne(nl => nl.Notificacao)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AlunoLinhaDoTempo>()
            .HasMany(a => a.Postagens)
            .WithOne(p => p.LinhaDoTempo)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
