using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base_de_Datos.DB;
namespace ms_estado.Modelo
{
    public class Estado
    {
        public int CodEstado { get; set; }
        public string DescripcionEstado { get; set; }
        public string CodTipoGalar { get; set; }
    }
}
