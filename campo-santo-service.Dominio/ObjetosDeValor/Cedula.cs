using campo_santo_service.Dominio.Excepciones;
using System;
using System.Collections.Generic;
namespace campo_santo_service.Dominio.ObjetosDeValor
{
    public record Cedula
    {
        public string Valor { get; } = null!;
        public Cedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(cedula)} es obligatorio");
            }
            if (!cedula.Contains("-"))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(cedula)} no es valido");
            }
            if(cedula.Length>11 || cedula.Length < 11)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(cedula)} no es valido");
            }
            Valor = cedula;
        }
    }
}
