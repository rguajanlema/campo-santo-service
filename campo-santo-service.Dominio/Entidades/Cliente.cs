using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;
        public string Direccion {  get; private set; }
        public Cedula Cedula { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Telefono Telefono { get; private set; } = null !;

        public Cliente(string nombre, string apellido, string direccion, Cedula cedula, Email email, Telefono telefono)
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

            Id = Guid.CreateVersion7();
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            Cedula = cedula;
        }
    }
}
