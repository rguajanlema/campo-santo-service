using campo_santo_service.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos
{
    public record BuscarClienteQuery(
    TipoBusqueda Tipo,
    string Valor
);

}
