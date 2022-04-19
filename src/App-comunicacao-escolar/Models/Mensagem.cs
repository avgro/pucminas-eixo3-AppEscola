using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Mensagem")]
    public class Mensagem
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Remetente")]
        [MaxLength(200)]
        public string? RemetenteNome { get; set; }
        public int? RemetenteId { get; set; }
        [Display(Name = "Destinatários")]
        public string? listaDestinatarios { get; set; }
        public string? listaDestinatariosNome { get; set; }
        [Display(Name = "Conteúdo")]
        [MaxLength(10000)]
        public string? Conteudo { get; set; }
        public int? ConversaId { get; set; }
        [ForeignKey("ConversaId")]
        public Conversa? Conversa { get; set; }
        public int? MensagemRespondidaId { get; set; }
        [ForeignKey("MensagemRespondidaId")]
        public Mensagem? MensagemRespondida { get; set; }
        public DateTime? DataEnvio { get; set; }
        public ICollection<Usuario>? Participantes { get; set; }
        public ICollection<Mensagem>? Respostas { get; set; }
        public ICollection<MensagemArquivosAnexados>? Anexos { get; set; }
    }
}
