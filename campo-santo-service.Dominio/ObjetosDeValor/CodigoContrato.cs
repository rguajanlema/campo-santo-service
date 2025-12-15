using campo_santo_service.Dominio.Excepciones;
using System.Text.RegularExpressions;

namespace campo_santo_service.Dominio.ObjetosDeValor
{
    public sealed record CodigoContrato
    {
        private const string Patrón = @"^[A-Z]-\d{4}$";
        public string Valor { get; } = null!;
        public CodigoContrato(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(codigo)} es obligatorio");
            }
            if (!Regex.IsMatch(codigo, Patrón))
                throw new ExcepcionDeReglaDeNegocio("Formato de Código inválido. Ejemplo válido: C-0001");
            
            Valor = codigo;
        }

        public CodigoContrato GenerarSiguiente()
        {
            var partes = Valor.Split('-');
            string prefijo = partes[0];
            int numero = int.Parse(partes[1]);

            int siguiente = numero + 1;

            string nuevoCodigo = $"{prefijo}-{siguiente:0000}";

            return new CodigoContrato(nuevoCodigo);
        }

        public override string ToString() => Valor;
    }
}
