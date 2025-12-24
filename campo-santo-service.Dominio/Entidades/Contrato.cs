using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;


namespace campo_santo_service.Dominio.Entidades
{
    public sealed class Contrato
    {
        public Guid Id { get; private set; }
        public CodigoContrato Codigo { get; private set; } = null!;
        public FechaContrato FechaInicio { get; private set; }
        public DateTime FechaFinaliza { get; private set; }
        public EnumContrato Tipo { get; private set; }
        public EstadoContrato Estado { get; private set; }
        public string Observacion { get; private set; } = null!;
        public decimal Monto { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid EspacioId { get; private set; }
        private readonly List<Pago> _pagos;
        public IReadOnlyCollection<Pago> Pagos => _pagos;

        private Contrato(Guid id, CodigoContrato numeroContrato, Guid clienteId, EnumContrato tipo, decimal monto, 
            FechaContrato fecha, DateTime fechaFinaliza, Guid nichoId, EstadoContrato estado, string observacion
            )
        {
            _pagos = new List<Pago>();

            if (numeroContrato == null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(numeroContrato)} es obligatorio");
            }
            if(monto == decimal.Zero)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(monto)} es obligatorio");
            }
            if (monto < decimal.Zero)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(monto)} no es correcto");
            }
            if (string.IsNullOrEmpty(observacion))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(observacion)} es obligatorio");
            }

            Id = id;
            FechaInicio = fecha;
            Tipo = tipo;
            Monto = monto;
            ClienteId = clienteId;
            EspacioId = nichoId;
            FechaFinaliza = fechaFinaliza;
            Codigo = numeroContrato.GenerarSiguiente();
            Estado = estado;
            Observacion = observacion;
        }
        public static Contrato Crear(
            CodigoContrato numeroContrato, Guid clienteId,  EnumContrato tipo, decimal monto, 
            FechaContrato fecha, Guid nichoId, EstadoContrato estado, string observacion)
        {
            return new Contrato(Guid.CreateVersion7(), numeroContrato, clienteId, tipo, monto, fecha, DateTime.UtcNow.AddYears(10), nichoId, estado,observacion);
        }
        public static Contrato Reidratar(
            Guid id, CodigoContrato numeroContrato, Guid clienteId, EnumContrato tipo, decimal monto, 
            FechaContrato fecha, DateTime fechaFinaliza ,Guid nichoId, EstadoContrato estado, string observacion)
        {
            return new Contrato(id,numeroContrato,clienteId,tipo,monto,fecha,fechaFinaliza,nichoId, estado, observacion);
        }
        public void RegistrarPago(FechaContrato fecha, decimal monto, EstadoConceptos concepto, string descripcion)
        {
            if (monto <= 0)
                throw new ExcepcionDeReglaDeNegocio("El monto debe ser mayor a cero");

            if (_pagos.Any(p => p.FechaPago.Valor.Year == fecha.Valor.Year))
                throw new ExcepcionDeReglaDeNegocio("El año ya fue pagado");

            _pagos.Add(Pago.RegistarPago(Id, fecha, monto, concepto, descripcion));
        }

        public int ObtenerAniosAtrasados(DateOnly fechaActual)
        {
            if (fechaActual.Year < FechaInicio.Valor.Year)
                return 0;

            var anioInicio = FechaInicio.Valor.Year;
            var anioActual = fechaActual.Year;

            var aniosEsperados = Enumerable
                .Range(anioInicio, anioActual - anioInicio + 1);

            var aniosPagados = _pagos
                .Select(p => p.FechaPago.Valor.Year)
                .Distinct();

            return aniosEsperados.Except(aniosPagados).Count();
        }

        public void RegistrarPagoInicial(FechaContrato fecha, decimal monto, string descripcion)
        {
            if (_pagos.Any())
                throw new ExcepcionDeReglaDeNegocio(
                    "El contrato ya tiene un pago inicial");

            _pagos.Add(
                Pago.RegistrarPagoInicial(
                    Id,
                    fecha,
                    monto,
                    descripcion
                )
            );
        }
        
        public void RehidratarPago( Guid pagoId, FechaContrato fecha, decimal monto, EstadoConceptos concepto, string observacion)
        {
            _pagos.Add(
                Pago.Rehidratar(
                    pagoId,
                    Id,
                    fecha,
                    monto,
                    concepto,
                    observacion
                )
            );
        }

    }
}
