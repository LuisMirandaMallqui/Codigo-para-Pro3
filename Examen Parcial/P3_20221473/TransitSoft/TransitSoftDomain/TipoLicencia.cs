using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftDomain
{
    public class TipoLicencia
    {
        public int TipoLicenciaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoLicencia(int tipoLicenciaId, string nombre, string descripcion)
        {
            TipoLicenciaId = tipoLicenciaId;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public TipoLicencia()
        {
            TipoLicenciaId = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

    }
}
