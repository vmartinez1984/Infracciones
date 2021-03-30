using System;
using System.ComponentModel.DataAnnotations;

namespace Infracciones.Dto
{
    public class Imagen
    {
        [Required]
        public DateTime FechaDeRegistro { get; set; }
        [Required]
        //[MaxLength(Int32.MaxValue)]
        public string ImagenEnBase64 { get; set; }
        public string NombreDelArchivo { get; set; }
        [Required]
        public int BoletaDeSancionId { get; set; }
        public int Id { get; set; }
        [Required]
        public int TipoDeImagenId { get; set; }
    }
}