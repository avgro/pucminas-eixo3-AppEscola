using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Conversas")]
    public class Conversa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserir assunto da mensagem!")]
        [MaxLength(100)]
        public string? Assunto { get; set; }
        [Display(Name = "Mensagem")]
        [Required(ErrorMessage = "Inserir o conteúdo da mensagem!")]
        [MaxLength(10000)]
        public string? PrimeiraMensagem { get; set; }
        [Display(Name = "Remetente")]
        [MaxLength(200)]
        public string? RemetenteNome { get; set; }
        public int? RemetenteId { get; set; }
        public ICollection<Usuario>? Participantes { get; set; }
        public ICollection<Mensagem>? Mensagens { get; set; }
        public ICollection<NumeroDeNovasMensagensNaConversa>? NumeroDeNovasMensagensNaConversa { get; set; }
        public ICollection<UsuariosQueArquivaramConversa>? UsuariosQueArquivaramConversa { get; set; }

    }
}
