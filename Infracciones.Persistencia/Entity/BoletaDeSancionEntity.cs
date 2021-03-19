using System;

namespace Infracciones.Persistencia.Entity
{
    public class BoletaDeSancionEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ReglamentoId { get; set; }
        public int EstatusDeBoletaDeSancion { get; set; }
        public string NumeroDeLicencia { get; set; }
        public string NombreDelConductor { get; set; }
        public string Placa { get; set; }
        public string CoordenadasGps { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
        public string ReferenciaDeBanco { get; set; }
        public DateTime FechaDeRegistro { get; set; }
    }
}