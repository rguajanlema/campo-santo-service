using campo_santo_service.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IPagoRepository
    {
        Task<Pago?> ObtenerPorId(Guid id);
        Task Agregar(Pago pago);
    }
}
