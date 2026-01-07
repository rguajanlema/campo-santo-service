using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos
{
    public class ValidadorComandoCrearEspacio : AbstractValidator<ComandoCrearEspacio>
    {
        public ValidadorComandoCrearEspacio()
        {
            RuleFor(p => p.Codigo)
                .NotEmpty().WithMessage("El campo {Codigo} es requerido");
        }
    }
}
