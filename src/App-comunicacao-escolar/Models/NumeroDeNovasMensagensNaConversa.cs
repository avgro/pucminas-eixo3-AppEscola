using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("NumeroDeNovasMensagensNaConversa")]
    public class NumeroDeNovasMensagensNaConversa
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public int NumeroDeMensagensNaoLidas { get; set; }
        public int? ConversaId { get; set; }
        [ForeignKey("ConversaId")]
        public Conversa? Conversa { get; set; }
    }
}
