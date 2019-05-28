using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_estado.Modelo;

namespace ms_estado.Negocio
{
    public interface INegocioEstado
    {
        string GetEstados();
        Task<Estado> GetEstado(int codEstado);
        void CrearEstado(Estado estado);
        void BorrarEstado(int codEstado);
        void ModificarEstado(int codEstado, Estado estado);
    }
}
