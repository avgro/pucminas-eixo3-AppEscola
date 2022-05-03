using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("EventosDaAgenda")]
    public class EventoDaAgenda
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome do evento")]
        [Required(ErrorMessage = "Inserir nome do evento!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Display(Name = "Início do evento")]
        [Required(ErrorMessage = "Inserir horário de início do evento!")]
        public DateTime? InicioDoEvento { get; set; }
        [Display(Name = "Fim do evento")]
        [Required(ErrorMessage = "Inserir horário do fim do evento!")]
        public DateTime? FimDoEvento { get; set; }
        public int? AgendaId { get; set; }
        [ForeignKey("AgendaId")]
        public Agenda? Agenda { get; set; }
    }
}
