using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Dominio.Entidades
{
    public sealed class Cliente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;
        public string Direccion {  get; private set; }
        public Cedula Cedula { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Telefono Telefono { get; private set; } = null !;

        private readonly List<Contrato> _contratos = new();
        public IReadOnlyCollection<Contrato> Contratos => _contratos;

        internal Cliente(
            Guid id, 
            string nombre, 
            string apellido, 
            string direccion, 
            Cedula cedula, 
            Email email, 
            Telefono telefono
            )
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(apellido)} es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(direccion))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(direccion)} es obligatorio");
            }
            if(cedula is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(cedula)} es obligatorio");
            }
            if (email is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(email)} es obligatorio");
            }
            if (telefono is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(telefono)} es obligatorio");
            }

            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            Cedula = cedula;
            Telefono = telefono;
        }

        public static Cliente Crear(
            string nombre, 
            string apellido, 
            string direccion, 
            Cedula cedula, 
            Email email, 
            Telefono telefono
            )
        {
            return new Cliente(
                Guid.CreateVersion7(), 
                nombre, 
                apellido, 
                direccion, 
                cedula, 
                email, 
                telefono
                );
        }

        public static Cliente Reidatar(
            Guid id, 
            string nombre, 
            string apellido, 
            string direccion, 
            Cedula cedula, 
            Email email, 
            Telefono telefono
            )
        {
            return new Cliente(
                id, 
                nombre, 
                apellido, 
                direccion, 
                cedula, 
                email, 
                telefono
                );
        }
        public void RehidratarContrato(
            Guid id,
            CodigoContrato codigo,
            FechaContrato fechaInicio,
            DateTime fechaFinaliza,
            EnumContrato tipo,
            EstadoContrato estado,
            string observacion,
            decimal monto,
            Guid clienteId,
            Guid espacioId
            )
        {
            _contratos.Add(
                Contrato.Reidratar(
                    id,
                    codigo,
                    clienteId,
                    tipo,
                    monto,
                    fechaInicio,
                    fechaFinaliza,
                    espacioId,
                    estado,
                    observacion
                    )
                );
        }
    }
}
