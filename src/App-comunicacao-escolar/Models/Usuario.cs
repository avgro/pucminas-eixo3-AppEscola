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
        [Required(ErrorMessage = "Obrigatório informar a senha!")]
        [DataType(DataType.Password)]
        [MaxLength(100)]
        public string? Senha { get; set; }
        [MaxLength(320)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
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
        [MaxLength(10)]
        public string? Cep { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o perfil!")]
        public PerfilUsuarioEnum Perfil { get; set; }

        public ICollection<Conversa>? Conversas { get; set; }
        public ICollection<Mensagem>? Mensagem { get; set; }
    }

    public enum PerfilUsuarioEnum
    {
        [Display(Name = "Administrador")]
        Admin,
        [Display(Name = "Professor")]
        Professor,
        [Display(Name = "Responsável de aluno")]
        ResponsavelAluno,
        [Display(Name = "Outros")]
        Outro

    }
}