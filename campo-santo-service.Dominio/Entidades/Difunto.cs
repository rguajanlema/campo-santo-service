using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;


namespace campo_santo_service.Dominio.Entidades
{
    public sealed class Difunto
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public string Apellido { get; private set; } = null!;
        public Genero Genero { get; private set; }
        public Cedula Cedula { get; private set; } = null!;
        public FechaNacimiento FechaNacimiento { get; private set; } = null!;
        public FechaNacimiento FechaFallecimiento { get; private set; } = null!;

        public Difunto(string nombre, string apellido, Genero genero, Cedula cedula, FechaNacimiento fechaNacimiento, FechaNacimiento fechaFallecimiento)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(apellido)} es obligatorio");
            }
            if (cedula is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(cedula)} es obligatorio");
            }
            if (fechaNacimiento is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(fechaNacimiento)} es obligatorio");
            }
            if (fechaFallecimiento is null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(fechaFallecimiento)} es obligatorio");
            }
            

            Id = Guid.CreateVersion7();
            Nombre = nombre;
            Apellido = apellido;
            Genero = genero;
            FechaNacimiento = fechaNacimiento;
            FechaFallecimiento = fechaFallecimiento;
        }
    }
}
