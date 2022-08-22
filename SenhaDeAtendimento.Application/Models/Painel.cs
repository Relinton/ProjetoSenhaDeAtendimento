using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenhaDeAtendimento.Application.Models
{
    [Table("Painel")]
    public class Painel
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Column("Guiche")]
        [Display(Name = "Guichê")]
        public string Guiche { get; set; }
    }
}
