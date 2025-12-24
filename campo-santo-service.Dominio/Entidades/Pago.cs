using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Dominio.Entidades
{
    public class Pago
    {
        public Guid Id { get; private set; } 
        public Guid ContratoId { get; private set; }
        public FechaContrato FechaPago { get; private set; }
        public decimal Monto { get; private set; }
        public EstadoConceptos Concepto { get; private set; }
        public string Observacion { get; private set; } = null!;

        private Pago(Guid id, Guid contratoId, FechaContrato fechaPago, decimal monto, EstadoConceptos concepto, string observacion)
        {
            if(monto < 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(monto)} es incorrecto");
            }
            if (string.IsNullOrEmpty(observacion))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(observacion)} es requerido");
            }

            Id = id;
            ContratoId = contratoId;
            FechaPago = fechaPago;
            Monto = monto;
            Concepto = concepto;
            Observacion = observacion;
        }
        internal static Pago RegistarPago(Guid contratoId, FechaContrato fecha, decimal monto, EstadoConceptos concepto, string observacion )
        {
            return new Pago(Guid.CreateVersion7(),contratoId, fecha, monto, concepto, observacion);
        }

        public static Pago Rehidratar(Guid id, Guid contratoId, FechaContrato fechaPago, decimal monto, EstadoConceptos concepto, string observacion)
        {
            return new Pago(id, contratoId, fechaPago, monto, concepto, observacion);
        }

        internal static Pago RegistrarPagoInicial(Guid contratoId, FechaContrato fecha, decimal monto, string descripcion)
        {
            return new Pago(
                Guid.CreateVersion7(),
                contratoId,
                fecha,
                monto,
                EstadoConceptos.Inicio,
                descripcion
            );
        }

    }
}
