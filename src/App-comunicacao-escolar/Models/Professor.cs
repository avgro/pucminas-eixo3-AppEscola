using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Professores")]
    public class Professor
    {
        [ForeignKey("Usuario")]
        public int ProfessorId { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage="Obrigado informar a formação do professor!")]
        [Display(Name = "Formação")]
        public string? Formacao { get; set; }
        [Required(ErrorMessage = "Obrigado informar o nível do professor!")]
        [Display(Name = "Nível")]
        public NivelDoProfessorEnum Nivel { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public ICollection<Disciplina>? Disciplinas { get; set; }
    }

    public enum NivelDoProfessorEnum
    {
        [Display(Name = "Ensino Fundamental")]
        EnsinoFundamental,
        [Display(Name = "Educação Infantil")]
        EducacaoInfantil
    }
}