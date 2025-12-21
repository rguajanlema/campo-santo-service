using campo_santo_service.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Dominio.Repositorios
{
    public interface IContratoRepository
    {
        Task<Contrato?> ObtenerPorId(Guid id);
        Task Agregar(Contrato contrato);
        Task<IEnumerable<Contrato>> ObtenerTodo();
    }
}
