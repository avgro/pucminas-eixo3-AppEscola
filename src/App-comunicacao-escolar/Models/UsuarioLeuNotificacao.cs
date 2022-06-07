using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("UsuarioLeuNotificacao")]
    public class UsuarioLeuNotificacao
    {
        [Key]
        public int Id { get; set; }
        public int? NotificacaoId { get; set; }
        [ForeignKey("NotificacaoId")]
        public Notificacao? Notificacao { get; set; }
        public int? UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}
