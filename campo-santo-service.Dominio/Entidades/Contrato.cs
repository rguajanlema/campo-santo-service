using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;


namespace campo_santo_service.Dominio.Entidades
{
    public class Contrato
    {
        public Guid Id { get; private set; }
        public CodigoContrato NumeroContrato { get; private set; } = null!;
        public Guid ClienteId { get; private set; }
        public Guid DifuntoId { get; private set; }
        public EnumContrato Tipo { get; private set; }
        public decimal Monto { get; private set; }
        public DateTime Fecha { get; private set; }
        public Guid NichoId { get; private set; }
        public Cliente Cliente { get; private set; }
        public Difunto Difunto { get; private set; }

        public Contrato(CodigoContrato numeroContrato, Guid clienteId, Guid difuntoId, EnumContrato tipo,  decimal monto, Guid nichoId)
        {
            if(numeroContrato == null)
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

            Id = Guid.CreateVersion7();
            Fecha = DateTime.UtcNow;
            Tipo = tipo;
            Monto = monto;
            ClienteId = clienteId;
            DifuntoId = difuntoId;
            NichoId = nichoId;
            NumeroContrato = numeroContrato.GenerarSiguiente();
        }
        public void Recuperar(Guid id, CodigoContrato numeroContrato, EnumContrato tipo, decimal monto, DateTime fecha, Cliente cliente, Difunto difunto)
        {
            Id = id;
            Tipo = tipo;
            Monto = monto;
            NumeroContrato = numeroContrato;
            Tipo = tipo;
            Fecha = fecha;
            Cliente = cliente;
            Difunto = difunto;
        }
    }
}
