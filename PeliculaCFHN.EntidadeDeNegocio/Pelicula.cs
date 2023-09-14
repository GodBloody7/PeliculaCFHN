using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculaCFHN.EntidadeDeNegocio
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Genero")]
        [Required(ErrorMessage = "Genero es obligatorio")]
        [Display(Name = "Genero")]
        public int IdGenero { get; set; }

        [ForeignKey("Director")]
        [Required(ErrorMessage = "Director es obligatorio")]
        [Display(Name = "Director")]
        public int IdDirector { get; set; }

        [Required(ErrorMessage = "Título es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Fecha de Estreno es obligatorio")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string FechaEstreno { get; set; }

        [Required(ErrorMessage = "Actores es obligatorio")]
        [MaxLength(2000, ErrorMessage = "Máximo 2000 caracteres")]
        public string Actores { get; set; }

        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [MaxLength(6000, ErrorMessage = "Máximo 6000 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Imagen es obligatorio")]
        [MaxLength(2000, ErrorMessage = "Máximo 2000 caracteres")]
        public string Imagen { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Genero Genero { get; set; }

        [ValidateNever]
        public Director Director { get; set; }
    }
}