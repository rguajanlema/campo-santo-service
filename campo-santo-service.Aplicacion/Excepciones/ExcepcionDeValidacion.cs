using FluentValidation.Results;

namespace campo_santo_service.Aplicacion.Excepciones
{
    public class ExcepcionDeValidacion : Exception
    {
        public List<string> ErroresDeValidacion { get; set; } = [];
        public ExcepcionDeValidacion(ValidationResult validationResult)
        {
            foreach(var errorDeValidacion in validationResult.Errors)
            {
                ErroresDeValidacion.Add(errorDeValidacion.ErrorMessage);
            }
            
        }
    }
}
