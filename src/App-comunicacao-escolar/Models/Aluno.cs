using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Inserir nome do aluno!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Inserir sobrenome do aluno!")]
        [MaxLength(50)]
        public string? Sobrenome { get; set; }
        [Display(Name = "Código do aluno")]
        [Required(ErrorMessage = "Inserir o código do aluno!")]
        [MaxLength(20)]
        public string? CodigoDoAluno { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Inserir a data de nascimento do aluno!")]
        [Column(TypeName = "date")]
        public DateTime DataDeNascimento { get; set; }
        public string? NomeAlunoComCodigoEntreParenteses { get; set; }
        [Display(Name ="Turma")]
        public int? TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        public Turma? Turma { get; set; }
        public ICollection<AutorizacaoEvento>? Autorizacoes { get; set; }
        public ICollection<Responsavel>? Responsaveis { get; set; }

        public string RemoverHorasDeDateTime(DateTime? dataEnvio)
        {
            if (dataEnvio != null)
            {
                string dataEnvioString = dataEnvio!.ToString()!;
                List<string> separarData = dataEnvioString.Split(" ").ToList();
                dataEnvioString = separarData[0];
                return dataEnvioString;
            }
            return "";

        }
    }
}
