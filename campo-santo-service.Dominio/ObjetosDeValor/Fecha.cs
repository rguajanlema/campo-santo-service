using campo_santo_service.Dominio.Excepciones;

namespace campo_santo_service.Dominio.ObjetosDeValor
{
    
    public record Fecha
    {
        public DateTime Valor { get; }
        public Fecha(DateTime fechaNacimiento)
        {
            if (DateTime.UtcNow.Date < fechaNacimiento.Date)
            {
                throw new ExcepcionDeReglaDeNegocio($"La {nameof(fechaNacimiento)} es mayor que la fecha actual");
            }
            if (DateTime.UtcNow.Date == fechaNacimiento.Date)
            {
                throw new ExcepcionDeReglaDeNegocio($"La {nameof(fechaNacimiento)} no puede ser igual a la actual");
            }

            Valor = fechaNacimiento;
        }
    }
}
