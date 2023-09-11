﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculaCFHN.EntidadeDeNegocio
{
    public class Director
    {
        [Key]
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]

        public string Apellido { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(15, ErrorMessage = "Maximo 15 caracteres")]

        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]

        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(00, ErrorMessage = "Maximo 00 caracteres")]

        public string Imagen { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

    }
}
