using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.Excepciones;
using campo_santo_service.Dominio.ObjetosDeValor;

namespace campo_santo_service.Dominio.Entidades
{
    public sealed class Espacio
    {
        public Guid Id { get; private set; }
        public CodigoContrato Codigo { get; private set; } = null!;
        public TipoEspacio Tipo { get; private set; }
        public NivelPiso Piso { get; private set; }
        public EstadoEspacio Estado { get; private set; }
        public string Ubicacion { get; private set; } = null!;

        internal Espacio(
            Guid id, 
            CodigoContrato codigo, 
            TipoEspacio tipo,
            NivelPiso piso, 
            EstadoEspacio estado, 
            string ubicacion
            ) { 
            if(codigo.Valor == null)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(codigo)} es obligatorio");
            }
            if (string.IsNullOrWhiteSpace(ubicacion))
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(ubicacion)} es obligatorio");
            }

            Id = id;
            Codigo = codigo;
            Ubicacion = ubicacion;
            Piso = piso;
            Estado = estado;
            Tipo = tipo;
        }
        public void AgregarPiso()
        {
            if (Piso == NivelPiso.TercerPiso)
                throw new ExcepcionDeReglaDeNegocio("No se puede agregar un cuarto piso");

            Piso = Piso switch
            {
                NivelPiso.SubSuelo => NivelPiso.PlantaBaja,
                NivelPiso.PlantaBaja => NivelPiso.PrimerPiso,
                NivelPiso.PrimerPiso => NivelPiso.SegundoPiso,
                NivelPiso.SegundoPiso => NivelPiso.TercerPiso,
                _ => Piso
            };
            
            Estado = EstadoEspacio.Disponible;
        }
        public void Ocupar()
        {
            if (Estado == EstadoEspacio.Ocupado)
                throw new ExcepcionDeReglaDeNegocio("El nicho ya está ocupado");

            Estado = EstadoEspacio.Ocupado;
        }
        public static Espacio Crear(
            CodigoContrato codigo, 
            TipoEspacio tipo, 
            NivelPiso piso, 
            string ubicacion
            )
        {
            return new Espacio(
                Guid.CreateVersion7(), 
                codigo, 
                tipo,
                piso, 
                EstadoEspacio.Disponible, 
                ubicacion
                );
        }
        public static Espacio Crear(CodigoContrato codigo)
        {
            return new Espacio(
                Guid.CreateVersion7(), 
                codigo, 
                TipoEspacio.Nicho, 
                NivelPiso.PlantaBaja, 
                EstadoEspacio.Reservado, 
                "En tramite"
                );
        }

        public static Espacio Rehidratar(
            Guid id, 
            CodigoContrato codigo, 
            TipoEspacio tipo,
            NivelPiso piso, 
            EstadoEspacio estado, 
            string ubicacion
            )
        {
            return new Espacio(
                id, 
                codigo, 
                tipo,
                piso, 
                estado, 
                ubicacion
                );
        }

    }
}
