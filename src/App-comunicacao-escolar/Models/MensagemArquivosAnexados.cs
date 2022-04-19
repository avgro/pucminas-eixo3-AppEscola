using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("MensagemMensagemArquivosAnexados")]
    public class MensagemArquivosAnexados
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Remetente")]
        [MaxLength(300)]
        public string? NomeOriginalDoArquivo { get; set; }
        [MaxLength(50)]
        public string? NomeUnicoDoArquivo { get; set; }
        public int? MensagemDosAnexosId { get; set; }
        [ForeignKey("MensagemDosAnexosId")]
        public Mensagem? MensagemDosAnexos { get; set; }

    }
}
