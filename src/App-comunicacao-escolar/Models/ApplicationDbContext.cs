using Microsoft.EntityFrameworkCore;
namespace App_comunicacao_escolar.Models

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Conversa> Conversas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NumeroDeNovasMensagensNaConversa> numeroDeNovasMensagensNaConversa { get; set; }
    }
}
