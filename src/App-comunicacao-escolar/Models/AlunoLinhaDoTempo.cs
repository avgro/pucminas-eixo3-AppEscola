using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("AlunosLinhaDoTempo")]
    public class AlunoLinhaDoTempo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }
        public virtual Aluno? Aluno { get; set; }
        public ICollection<PostagemLinhaDoTempo>? Postagens { get; set; }

        internal Task<string?> ToPagedListAsync(int pagina, int v)
        {
            throw new NotImplementedException();
        }
    }
}