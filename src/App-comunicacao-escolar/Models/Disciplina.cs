using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Disciplinas")]
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserir nome da disciplina!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Inserir o código da disciplina!")]
        [MaxLength(20)]
        public string? Codigo { get; set; }
        public string? NomeComCodigoEntreParenteses { get; set; }
        public int? TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        public Turma? Turma { get; set; }
        public ICollection<Professor>? Professores { get; set; }
        [Display(Name ="Horários da disciplina")]
        public ICollection<HorariosDaDisciplina>? HorariosDaDisciplina { get; set; }
    }
}
