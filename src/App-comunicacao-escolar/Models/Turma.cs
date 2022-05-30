using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome da turma")]
        [Required(ErrorMessage = "Inserir nome da turma!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Inserir o código da turma!")]
        [MaxLength(20)]
        public string? Codigo { get; set; }
        public string? NomeComCodigoEntreParenteses { get; set; }
        public ICollection<Disciplina>? Disciplinas { get; set; }
        public ICollection<Aluno>? Alunos { get; set; }
        public ICollection<Agenda>? Agendas { get; set; }
    }
}
