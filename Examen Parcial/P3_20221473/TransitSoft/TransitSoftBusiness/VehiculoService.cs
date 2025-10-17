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
    public class VehiculoService
    {
        private readonly VehiculoDAO vehiculoDAO;

        public VehiculoService()
        {
            vehiculoDAO = new VehiculoDAOImpl();
        }

        public bool Insertar(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);
            return vehiculoDAO.Agregar(vehiculo);
        }

        public bool Modificar(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);
            return vehiculoDAO.Actualizar(vehiculo);
        }

        public bool Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del vehículo no puede ser menor o igual a cero");

            return vehiculoDAO.Eliminar(id);
        }

        public Vehiculo Obtener(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del vehículo no puede ser menor o igual a cero");

            return vehiculoDAO.Obtener(id);
        }

        public List<Vehiculo> ListarTodos()
        {
            return vehiculoDAO.ListarTodos();
        }

        private void ValidarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
                throw new ArgumentNullException(nameof(vehiculo));

            if (string.IsNullOrWhiteSpace(vehiculo.Placa))
                throw new ArgumentException("La placa del vehículo es requerida");

            if (vehiculo.Placa.Length != 7)
                throw new ArgumentException("La placa del vehículo debe tener exactamente 7 caracteres");

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new ArgumentException("La marca del vehículo es requerida");

            if (vehiculo.Marca.Length > 45)
                throw new ArgumentException("La marca del vehículo no puede exceder los 45 caracteres");

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("El modelo del vehículo es requerido");

            if (vehiculo.Modelo.Length > 45)
                throw new ArgumentException("El modelo del vehículo no puede exceder los 45 caracteres");

            if (vehiculo.Anho <= 0)
                throw new ArgumentException("El año del vehículo debe ser mayor a cero");
        }
        public List<Vehiculo> ListarPorMarcaModelo(string marcaModelo)
        {
            if (string.IsNullOrWhiteSpace(marcaModelo))
                throw new ArgumentException("La marca o modelo no puede estar vacío");

            return vehiculoDAO.ListarPorMarcaModelo(marcaModelo);
        }
        public List<string> ObtenerMarcas()
        {
            // Aquí podrías agregar validaciones o lógica adicional si fuera necesario
            return vehiculoDAO.ObtenerMarcas();
        }
    }
}
