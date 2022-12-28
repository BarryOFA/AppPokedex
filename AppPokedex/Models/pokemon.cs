using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppPokedex.Models
{
    public class pokemon
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el nombre de un Pokemon")]
        [Display(Name = "Pokemon")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el tipo de un Pokemon")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Debe el ingresar el peso del Pokemon")]
        [Range(1, 500, ErrorMessage = "Debe estar entre 1 y 500 kilogramos")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "Debe el ingresar la altura del Pokemon")]
        [Range(1, 1000, ErrorMessage = "Debe estar entre 1 y 1000 centimetros")]
        public float Altura { get; set; }

        public bool genero { get; set; }

        [Display(Name = "Fecha de creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public pokemon(string nombre, string tipo, int peso)
        {
            Nombre = nombre;
            Tipo = tipo;
            Peso = peso;

        }
    }
}