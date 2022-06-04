using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o nome!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o sobrenome!")]
        [MaxLength(100)]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o nome de usuário!")]
        [Display(Name = "Nome de usuário")]
        [MaxLength(50)]
        public string? NomeDeUsuario { get; set; }
        [Display(Name = "Nome display lista")]
        [MaxLength(250)]
        public string? NomeDisplayLista { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string? Senha { get; set; }
        [MaxLength(320)]
        [Required(ErrorMessage = "Obrigatório informar o email!")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        [MaxLength(14)]
        [Display(Name = "Telefone (Móvel)")]
        public string? TelefoneMovel { get; set; }
        [MaxLength(14)]
        [Display(Name = "Telefone (Fixo)")]
        public string? TelefoneFixo { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o endereço!")]
        [MaxLength(200)]
        public string? Logradouro { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o endereço!")]
        [MaxLength(50)]
        public string? Cidade { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o endereço!")]
        [MaxLength(10)]
        public string? Estado { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o endereço!")]
        [Display(Name = "CEP")]
        [MaxLength(9)]
        public string? Cep { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o perfil!")]
        [Display(Name = "Tipo de usuário")]
        public PerfilUsuarioEnum Perfil { get; set; }

        public ICollection<Conversa>? Conversas { get; set; }
        public ICollection<Mensagem>? Mensagem { get; set; }
        public ICollection<EventoDaAgenda>? EventosCadastrados { get; set; }
        public ICollection<UsuarioLeuNotificacao>? NotificacoesLidas { get; set; }
        public ICollection<PostagemLinhaDoTempo>? PostagensLinhaDoTempo { get; set; }
        public virtual Responsavel? Responsavel { get; set; }
        public virtual Professor? Professor { get; set; }
    }

    public enum PerfilUsuarioEnum
    {
        [Display(Name = "Administrador")]
        Admin,
        [Display(Name = "Responsável de aluno")]
        ResponsavelAluno,
        [Display(Name = "Professor")]
        Professor,
        [Display(Name = "Outros")]
        Outro

    }
    public enum PerfilUsuarioSelecionavelEnum
    {
        [Display(Name = "Responsável de aluno")]
        ResponsavelAluno = 1,
        [Display(Name = "Professor")]
        Professor = 2,
        [Display(Name = "Outros")]
        Outros = 3

    }
}