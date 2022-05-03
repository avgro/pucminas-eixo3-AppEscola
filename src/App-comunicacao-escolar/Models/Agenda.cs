﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_comunicacao_escolar.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome da disciplina")]
        [Required(ErrorMessage = "Inserir nome da agenda!")]
        [MaxLength(50)]
        public string? Nome { get; set; }
    }
}