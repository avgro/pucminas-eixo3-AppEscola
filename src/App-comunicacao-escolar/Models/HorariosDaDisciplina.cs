using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("HorariosDasDisciplinas")]
    public class HorariosDaDisciplina
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserir horário de início da aula!")]
        public string? HorarioInicio { get; set; }

        [Required(ErrorMessage = "Inserir horário do fim da aula!")]
        public string? HorarioFim { get; set; }
        public DiaDaSemanaEnum DiaDaSemana { get; set; }
        public int? DisciplinaId { get; set; }
        [ForeignKey("DisciplinaId")]
        public Disciplina? Disciplina { get; set; }
    }

    public enum DiaDaSemanaEnum
    {
        Domingo,
        Segunda,
        [Display(Name = "Terça")]
        Terca,
        Quarta,
        Quinta,
        Sexta,
        [Display(Name ="Sábado")]
        Sabado

    }
}
