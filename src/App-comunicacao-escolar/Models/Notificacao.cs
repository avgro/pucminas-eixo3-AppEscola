using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Notificacoes")]
    public class Notificacao
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserir o assunto da notificação!")]
        [MaxLength(50)]
        public string? Assunto { get; set; }
        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "Inserir o conteúdo da notificação!")]
        [MaxLength(300)]
        public string? Conteudo { get; set; }
        [Display(Name = "Turma")]
        public int? TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        public Turma? Turma { get; set; }
        [Display(Name = "Tipo de usuário")]
        public PerfilUsuarioNotificacaoEnum Perfil { get; set; }
    }
    public enum PerfilUsuarioNotificacaoEnum
    {
        [Display(Name = "Todos")]
        Todos = 0,
        [Display(Name = "Responsável de aluno")]
        ResponsavelAluno = 1,
        [Display(Name = "Professor")]
        Professor = 2
    }
}
