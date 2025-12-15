using campo_santo_service.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Dominio.ObjetosDeValor
{
    public record Telefono
    {
        public string Valor { get; } = null!;
        public Telefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(telefono)} es obligatorio");
            }
            if (telefono.Length > 10 || telefono.Length < 10)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(telefono)} no es valido");
            }
            Valor = telefono;
        }
    }
}
