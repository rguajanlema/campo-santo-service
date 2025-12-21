using campo_santo_service.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Dominio.ObjetosDeValor
{
    public sealed record FechaContrato
    {
        public DateTime Valor { get; }
        public FechaContrato(DateTime fecha)
        {
            if (DateTime.UtcNow.Date < fecha.Date)
            {
                throw new ExcepcionDeReglaDeNegocio($"La {nameof(fecha)} es mayor que la fecha actual");
            }

            Valor = fecha;
        }
    }
}
