using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitSoftModel;

namespace TransitSoftPersistance.DAO
{
    public interface InfraccionDAO
    {
        int Insertar(InfraccionesDTO infraccion);

        InfraccionesDTO ObtenerPorId(int infraccionId);

        BindingList<InfraccionesDTO> ListarTodos();

        int Modificar(InfraccionesDTO infraccion);

        int Eliminar(InfraccionesDTO infraccion);
    }
}
