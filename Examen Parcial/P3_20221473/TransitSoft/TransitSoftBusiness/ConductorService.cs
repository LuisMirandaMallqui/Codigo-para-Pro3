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
    public class ConductorService
    {
        private readonly ConductorDAO conductorDAO;

        public ConductorService()
        {
            conductorDAO = new ConductorDAOImpl();
        }

        public bool Insertar(Conductor conductor)
        {
            ValidarConductor(conductor);
            return conductorDAO.Agregar(conductor);
        }

        public bool Modificar(Conductor conductor)
        {
            ValidarConductor(conductor);
            return conductorDAO.Actualizar(conductor);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del conductor no puede ser menor o igual a cero");

            return conductorDAO.Eliminar(id);
        }

        public Conductor Obtener(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del conductor no puede ser menor o igual a cero");

            return conductorDAO.Obtener(id);
        }

        public List<Conductor> ListarTodos()
        {
            return conductorDAO.ListarTodos();
        }

        private void ValidarConductor(Conductor conductor)
        {
            if (conductor == null)
                throw new ArgumentNullException(nameof(conductor));

            if (string.IsNullOrWhiteSpace(conductor.Paterno))
                throw new ArgumentException("El apellido paterno del conductor es requerido");

            if (conductor.Paterno.Length > 45)
                throw new ArgumentException("El apellido paterno del conductor no puede exceder los 45 caracteres");

            if (string.IsNullOrWhiteSpace(conductor.Materno))
                throw new ArgumentException("El apellido materno del conductor es requerido");

            if (conductor.Materno.Length > 45)
                throw new ArgumentException("El apellido materno del conductor no puede exceder los 45 caracteres");

            if (string.IsNullOrWhiteSpace(conductor.Nombres))
                throw new ArgumentException("El nombre del conductor es requerido");

            if (conductor.Nombres.Length > 45)
                throw new ArgumentException("El nombre del conductor no puede exceder los 45 caracteres");

            if (string.IsNullOrWhiteSpace(conductor.NumLicencia))
                throw new ArgumentException("El número de licencia es requerido");

            if (conductor.NumLicencia.Length > 45)
                throw new ArgumentException("El número de licencia no puede exceder los 45 caracteres");

            if (conductor.TipoLicencia == null)
                throw new ArgumentException("El tipo de licencia es requerido");

            if (conductor.PuntosAcumulados < 0)
                throw new ArgumentException("Los puntos acumulados no pueden ser negativos");
        }

       
    }
}
