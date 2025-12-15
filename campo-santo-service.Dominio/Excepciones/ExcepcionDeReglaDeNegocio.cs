using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Dominio.Excepciones
{
    public class ExcepcionDeReglaDeNegocio : Exception
    {
        public ExcepcionDeReglaDeNegocio(string msg) : base(msg) { }
    }
}
