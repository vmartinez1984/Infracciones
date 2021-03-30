using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infracciones.Dto
{
    public class Inciso
    {
        public int Id { get; set; }
        [Required]
        public int Multa { get; set; }

        [DisplayName("¿Tiene descuento?")]
        public bool IsDescuento { get; set; }

        [DisplayName("¿Amerita deposito?")]
        public bool IsDeposito { get; set; }

        [DisplayName("¿Esta activo?")]
        public bool IsActivo { get; set; }

        [Required]
        [DisplayName("Usuario alta")]
        public int UsuarioIdAlta { get; set; }

        [DisplayName("Usuario alta")]
        public int? UsuarioIdBaja { get; set; }

        [Required]
        [DisplayName("Fracción")]
        public int FraccionId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Motivo { get; set; }

        [DisplayName("Fecha de registro")]
        public DateTime FechaDeRegistro { get; set; }

        [DisplayName("Fecha de baja")]
        public DateTime? FechaDeBaja { get; set; }
    }
}