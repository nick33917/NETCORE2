using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Base_de_Datos.DB;
using MediatR;
using ms_estado.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ms_estado.Cqrs.Querys
{
    public class GetEstadoHandler : IRequestHandler<GetEstadoQuery, Estado>
    {
        private readonly RRHHContext _db;
        private readonly IMapper _mapper;

        public GetEstadoHandler(RRHHContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Estado> Handle(GetEstadoQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<Estado>(await _db.TblEstados.FirstOrDefaultAsync(c => c.CodEstado == request.CodEstado));
        }
    }
}
