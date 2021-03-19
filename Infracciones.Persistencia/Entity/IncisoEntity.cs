using System;

namespace Infracciones.Persistencia.Entity
{
    public class IncisoEntity
    {
        public int Id { get; set; }
        public int Multa { get; set; }
        public bool IsDescuento { get; set; }
        public bool IsDeposito { get; set; }
        public bool IsActivo { get; set; }
        public int UsuarioIdAlta { get; set; }
        public int? UsuarioIdBaja { get; set; }
        public int FraccionId { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime? FechaDeBaja { get; set; }
    }
}