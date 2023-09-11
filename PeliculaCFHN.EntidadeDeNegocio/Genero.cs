using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeliculaCFHN.EntidadeDeNegocio
{
    public class Genero
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string Nombre { get; set; }

        [NotMapped]
        public string Top_Aux { get; set; }

    }
}
