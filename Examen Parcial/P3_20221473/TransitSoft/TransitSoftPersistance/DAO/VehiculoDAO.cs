using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransitSoftDomain;

namespace TransitSoftPersistance.DAO
{
    public interface VehiculoDAO : BaseDAO<Vehiculo>
    {
        List<Vehiculo> ListarPorMarcaModelo(string marca_modelo);
        List<string> ObtenerMarcas();
    }
}
