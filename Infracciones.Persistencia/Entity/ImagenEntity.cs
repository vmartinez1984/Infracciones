using System;

namespace Infracciones.Persistencia.Entity
{
    public class ImagenEntity
    {
        public int Id { get;  set; }
        public int BoletaDeSancionId { get; set; }
        public int TipoDeImagenId { get; set; }
        public bool IsActivo { get; set; }
        public string RutaDeArchivo { get; set; }
        public DateTime FechaDeRegistro { get; set; }
    }
}