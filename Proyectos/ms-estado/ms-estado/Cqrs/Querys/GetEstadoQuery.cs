using MediatR;
using ms_estado.Modelo;

namespace ms_estado.Cqrs.Querys
{
    public class GetEstadoQuery : IRequest<Estado>
    {
        public int CodEstado { get; set; }
    }
}
