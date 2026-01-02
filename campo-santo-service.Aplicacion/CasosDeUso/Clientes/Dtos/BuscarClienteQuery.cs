using campo_santo_service.Dominio.Enums;

namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos
{
    public record BuscarClienteQuery(
    TipoBusqueda Tipo,
    string Valor
);

}
