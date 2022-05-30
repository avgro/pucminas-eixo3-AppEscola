using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App_comunicacao_escolar.Models
{
    [Table("AutorizacoesEventos")]
    public class AutorizacaoEvento
    {
        [Key]
        public int Id { get; set; }
        public int? AlunoId { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno? Aluno { get; set; }
        public int? EventoId { get; set; }
        [ForeignKey("EventoId")]
        public EventoDaAgenda? Evento { get; set; }
        [Display(Name = "Autorizado")]
        public bool? Autorizado { get; set; }
        [Display(Name = "Assinado por")]
        public string? AssinadoPor { get; set; }
    }
}