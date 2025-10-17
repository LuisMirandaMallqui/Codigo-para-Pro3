using System;
using System.Collections.Generic;


using TransitSoftDomain;
using TransitSoftPersistance.DAO;
using TransitSoftPersistance.DAOImpl;

namespace TransitSoftBusiness
{
    public class InfraccionService
    {
        private readonly InfraccionDAO infraccionDAO;

        public InfraccionService()
        {
            infraccionDAO = new InfraccionDAOImpl();
        }

        public bool Insertar(Infraccion infraccion)
        {
            ValidarInfraccion(infraccion, esNuevo: true);
            return infraccionDAO.Agregar(infraccion);
        }

        public bool Modificar(Infraccion infraccion)
        {
            ValidarInfraccion(infraccion, esNuevo: false);
            return infraccionDAO.Actualizar(infraccion);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la infracción no puede ser menor o igual a cero");

            return infraccionDAO.Eliminar(id);
        }

        public Infraccion Obtener(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la infracción no puede ser menor o igual a cero");

            return infraccionDAO.Obtener(id);
        }

        public List<Infraccion> ListarTodos()
        {
            return infraccionDAO.ListarTodos();
        }

        private void ValidarInfraccion(Infraccion infraccion, bool esNuevo)
        {
            if (infraccion == null)
                throw new ArgumentNullException(nameof(infraccion));

            if (infraccion.InfraccionId <= 0)
                throw new ArgumentException("El ID de la infracción debe ser mayor que cero.");

            // Si es nuevo, opcionalmente verificar que no exista ya ese ID
            if (esNuevo)
            {
                var existente = infraccionDAO.Obtener(infraccion.InfraccionId);
                if (existente != null)
                    throw new ArgumentException($"Ya existe una infracción con ID {infraccion.InfraccionId}.");
            }

            if (string.IsNullOrWhiteSpace(infraccion.Descripcion))
                throw new ArgumentException("La descripción de la infracción es requerida");

            if (infraccion.Descripcion.Length > 45)
                throw new ArgumentException("La descripción no puede exceder los 45 caracteres");

            if (infraccion.MontoMulta < 0)
                throw new ArgumentException("El monto de la multa no puede ser negativo");

            if (!Enum.IsDefined(typeof(Gravedad), infraccion.Gravedad))
                throw new ArgumentException("La gravedad de la infracción es inválida");

            if (infraccion.Puntos < 0)
                throw new ArgumentException("Los puntos de la infracción no pueden ser negativos");
        }

       
    }
}
