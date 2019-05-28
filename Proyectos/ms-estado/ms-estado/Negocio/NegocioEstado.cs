using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_estado.Modelo;
using Base_de_Datos.DB;
using AutoMapper;
using MediatR;
using ms_estado.Cqrs.Querys;

namespace ms_estado.Negocio
{
    public class NegocioEstado : INegocioEstado
    {
        private readonly IMediator _mediator;
        public NegocioEstado(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void BorrarEstado(int codEstado)
        {
            throw new NotImplementedException();
        }

        public void CrearEstado(Estado estado)
        {
            throw new NotImplementedException();
        }

        public async Task<Estado> GetEstado(int codEstado)
        {
            return await _mediator.Send(new GetEstadoQuery {CodEstado = codEstado });   //return _mapper.Map<Estado>(_db.TblEstados.FirstOrDefault(c => c.CodEstado == codEstado));
        }

        public string GetEstados()
        {
            // return _mapper.Map<List<Estado>>(_db.TblEstados.ToList());
            return "";
        }

        public void ModificarEstado(int codEstado, Estado estado)
        {
            throw new NotImplementedException();
        }
    }
}
