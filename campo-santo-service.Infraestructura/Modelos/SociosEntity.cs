using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.ObjetosDeValor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace campo_santo_service.Infraestructura.Modelos
{
    [Table("socios")]
    public class SociosEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; } = null!;
        [Column("apellido")]
        public string Apellido { get; set; } = null!;
        [Column("cedula")]
        public string Cedula { get; set; } = null!;
        [Column("telefono")]
        public string Telefono { get; set; } = null!;
        [Column("correo")]
        public string Correo { get; set; } = null!;
        [Column("direccion")]
        public string Direccion { get; set; } = null!;

        public static SociosEntity FromDomain(Cliente cliente)
        {
            return new SociosEntity
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Cedula = cliente.Cedula.Valor,
                Telefono = cliente.Telefono.Valor,
                Correo = cliente.Email.Valor,
                Direccion = cliente.Direccion,
            };
        }
        public Cliente ToDomain()
        {
            return Cliente.Reidatar(
                Id,
                Nombre,
                Apellido,
                Direccion,
                new Cedula(Cedula),
                new Email(Correo),
                new Telefono(Telefono)
                );
        }
    }
}
