using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Clientes.Dtos
{
    public class ClienteResponse
    {
        public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Cedula { get; set; }
    public string Correo { get; set; }
    public string Telefono { get; set; }
    public List<ClienteContratoResponse> contratos { get; set; }
    }
}
