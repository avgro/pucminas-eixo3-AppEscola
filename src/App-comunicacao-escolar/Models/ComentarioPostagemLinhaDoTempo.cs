using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("ComentariosPostagensLinhaDoTempo")]
    public class ComentarioPostagemLinhaDoTempo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Conteudo da postagem")]
        [Required(ErrorMessage = "Inserir conteudo da postagem!")]
        [MaxLength(2000)]
        public string? Conteudo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int? AutorId { get; set; }
        [ForeignKey("AutorId")]
        public Usuario? Autor { get; set; }
        [Display(Name = "Postagem linha do tempo")]
        public int? PostagemLinhaDoTempoId { get; set; }
        [ForeignKey("PostagemLinhaDoTempoId")]
        public PostagemLinhaDoTempo? Postagem { get; set; }
    }
}
