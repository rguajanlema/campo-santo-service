using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos
{
    public class ObtenerEspacioDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Piso { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
    }
}
