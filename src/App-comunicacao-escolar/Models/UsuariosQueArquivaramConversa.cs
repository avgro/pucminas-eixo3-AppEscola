using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("UsuariosQueArquivaramConversa")]
    public class UsuariosQueArquivaramConversa
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int? ConversaId { get; set; }
        [ForeignKey("ConversaId")]
        public Conversa? Conversa { get; set; }
    }
}
