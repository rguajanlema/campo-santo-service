using campo_santo_service.Dominio.Excepciones;

namespace campo_santo_service.Dominio.Entidades
{
    public sealed class Servicio
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; } = null!;
        public decimal Precio { get; private set; }

        internal Servicio(Guid id, string nombre, decimal precio) 
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(nombre)} es obligatorio");
            }
            if(precio < 0)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(precio)} no puede ser menor a cero");
            }
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public static Servicio Crear(string nombre, decimal precio)
        {
            return new Servicio(Guid.CreateVersion7(), nombre, precio);
        }

        public static Servicio Actualizar(Guid id, string nombre, decimal precio)
        {
            return new Servicio(id, nombre, precio);
        }
        public static Servicio Rehidratar(Guid id, string nombre, decimal precio)
        {
            return new Servicio(id, nombre, precio);
        }
    }
}
