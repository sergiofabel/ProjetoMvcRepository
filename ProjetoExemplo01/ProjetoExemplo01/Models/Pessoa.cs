using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoExemplo01.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public int Idade { get; set; }

    }
}