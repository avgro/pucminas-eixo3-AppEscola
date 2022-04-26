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
        public DbSet<HorariosDaDisciplina>? HorariosDasDisciplinas { get; set; }
        public DbSet<Turma>? Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
            .HasIndex(d => d.NomeDeUsuario).IsUnique();
            modelBuilder.Entity<Usuario>()
            .HasIndex(d => d.Email).IsUnique();

            modelBuilder.Entity<Disciplina>()
            .HasMany(d => d.HorariosDaDisciplina)
            .WithOne(h => h.Disciplina)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
            .HasMany(t => t.Disciplinas)
            .WithOne(d => d.Turma)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
