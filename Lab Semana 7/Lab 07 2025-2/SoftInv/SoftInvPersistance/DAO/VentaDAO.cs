using SoftInvModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvPersistance.DAO
{
    public interface VentaDAO
    {
        int Insertar(VentasDTO venta);

        VentasDTO ObtenerPorId(int idVenta);

        BindingList<VentasDTO> ListarTodos();

        int Modificar(VentasDTO venta);

        int Eliminar(VentasDTO venta);
    }
}
