using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infracciones.Dto
{
    [Description("Boleta de sanción")]
    public class BoletaDeSancion
    {
        [Range(0,int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }


        [DisplayName("Numero de licencia")]
        public string NumeroDeLicencia { get; set; }

        public string Placa { get; set; }

        [Required(ErrorMessage ="El nombre es obligatorio")]
        [DisplayName("Nombre del conductor")]
        public string NombreDelConductor { get; set; }

        [DisplayName("Fecha de registo")]
        public DateTime FechaDeRegistro { get; set; }

        [DisplayName("Correo electrónico")]
        public string Correo { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [DisplayName("Reglamento")]
        public int ReglamentoId { get; set; }

        [Required]
        [DisplayName("Estatus")]
        public int EstatusDeBoletaDeSancion { get; set; }

        [DisplayName("Coordenadas GPS")]
        public string CoordenadasGps { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        [DisplayName("Referencia de banco")]
        public string ReferenciaDeBanco { get; set; }
    }
}