using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftPersistance
{
    public interface BaseDAO<T>
    {
        bool Agregar(T modelo);
        T Obtener(int id);
        bool Actualizar(T modelo);
        bool Eliminar(int id);
        List<T> ListarTodos();
    }
}
