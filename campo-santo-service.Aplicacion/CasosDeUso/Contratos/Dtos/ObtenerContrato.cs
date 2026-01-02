using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Contratos.Dtos
{
    public record ObtenerContrato(
        Guid id, 
        string nombre,
        string apellido,
        string codigo,
        string cedula
        )
    {

    }
}
