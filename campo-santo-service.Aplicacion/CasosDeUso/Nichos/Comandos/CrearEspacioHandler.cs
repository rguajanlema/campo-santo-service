using campo_santo_service.Aplicacion.CasosDeUso.Nichos.Dtos;
using campo_santo_service.Aplicacion.Contratos.Persistencia;
using campo_santo_service.Dominio.Entidades;
using campo_santo_service.Dominio.Enums;
using campo_santo_service.Dominio.ObjetosDeValor;
using campo_santo_service.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace campo_santo_service.Aplicacion.CasosDeUso.Nichos.Comandos
{
    public class CrearEspacioHandler
    {
        private readonly IEspacioRepository repository;
        private readonly IUnidadDeTrabajo uow;

        public CrearEspacioHandler(IEspacioRepository repository, IUnidadDeTrabajo uow)
        {
            this.repository = repository;
            this.uow = uow;
        }
        public async Task<Guid> Ejecutar(CrearEspacioDto dto)
        {
            var espacio = Espacio.Crear(
                new CodigoContrato(dto.Codigo),
                Enum.Parse<EstadoTipo>(dto.Tipo),
                Enum.Parse<NivelesPiso>(dto.Piso),
                dto.Ubicacion
            );

            await repository.Agregar(espacio);

            await uow.CommitAsync();

            return espacio.Id;
        }
    }
}
