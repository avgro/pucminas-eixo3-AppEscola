using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Responsaveis")]
    public class Responsavel
    {
        [ForeignKey("Usuario")]
        public int ResponsavelId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        [Display(Name ="Responsável por")]
        public ICollection<Aluno>? Alunos { get; set; }
    }
}