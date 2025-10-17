using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;
using TransitSoftPersistance.DAOImpl;

namespace TransitSoftBusiness
{
    public class TipoLicenciaService
    {
        private readonly TipoLicenciaDAO tipoLicenciaDAO;

        public TipoLicenciaService()
        {
            tipoLicenciaDAO = new TipoLicenciaDAOImpl();
        }

        public bool Insertar(TipoLicencia tipoLicencia)
        {
            ValidarTipoLicencia(tipoLicencia);
            return tipoLicenciaDAO.Agregar(tipoLicencia);
        }

        public bool Modificar(TipoLicencia tipoLicencia)
        {
            ValidarTipoLicencia(tipoLicencia);
            return tipoLicenciaDAO.Actualizar(tipoLicencia);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del tipo de licencia no puede ser menor o igual a cero");

            return tipoLicenciaDAO.Eliminar(id);
        }

        public TipoLicencia Obtener(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del tipo de licencia no puede ser menor o igual a cero");

            return tipoLicenciaDAO.Obtener(id);
        }

        public List<TipoLicencia> ListarTodos()
        {
            return tipoLicenciaDAO.ListarTodos();
        }

        private void ValidarTipoLicencia(TipoLicencia tipoLicencia)
        {
            if (tipoLicencia == null)
                throw new ArgumentNullException(nameof(tipoLicencia));

            if (tipoLicencia.TipoLicenciaId <= 0)
                throw new ArgumentException("El ID del tipo de licencia debe ser mayor que cero");

            if (string.IsNullOrWhiteSpace(tipoLicencia.Nombre))
                throw new ArgumentException("El nombre del tipo de licencia es requerido");

            if (tipoLicencia.Nombre.Length > 45)
                throw new ArgumentException("El nombre del tipo de licencia no puede exceder los 45 caracteres");

            if (!string.IsNullOrWhiteSpace(tipoLicencia.Descripcion) && tipoLicencia.Descripcion.Length > 255)
                throw new ArgumentException("La descripción del tipo de licencia no puede exceder los 255 caracteres");
        }
    }

}
