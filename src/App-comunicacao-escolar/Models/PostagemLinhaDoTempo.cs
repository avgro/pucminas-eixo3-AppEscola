using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("PostagensLinhaDoTempo")]
    public class PostagemLinhaDoTempo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Assunto da postagem")]
        [Required(ErrorMessage = "Inserir assunto da postagem!")]
        [MaxLength(50)]
        public string? Assunto { get; set; }
        [Display(Name = "Conteudo da postagem")]
        [Required(ErrorMessage = "Inserir conteudo da postagem!")]
        [MaxLength(1000)]
        public string? Conteudo { get; set; }
        [Display(Name = "Imagem do post")]
        public string? CodigoImagemPostada { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Usuario? Autor { get; set; }
        [Display(Name ="Linha do tempo")]
        public int? LinhaDoTempoId { get; set; }
        [ForeignKey("LinhaDoTempoId")]
        public AlunoLinhaDoTempo? LinhaDoTempo { get; set; }
    }
}
