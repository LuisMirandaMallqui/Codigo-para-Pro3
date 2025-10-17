using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;
using TransitSoftPersistance.DAOImpl;

namespace TransitSoftBusiness
{
    public class ReporteInfraccionService
    {
        private readonly ReporteInfraccionDAO reporteInfraccionDAO;
        private readonly VehiculoService vehiculoDAO;

        public ReporteInfraccionService() {
            reporteInfraccionDAO = new ReporteInfraccionDAOImpl();
        }

        
        public void ejecutandoInsercion(List<ReporteInfraccion> Lista)
        {
            foreach (ReporteInfraccion reporte in Lista)
            {
                Insertar(reporte);
                Vehiculo vehiculo = new Vehiculo();
                vehiculo.Placa = reporte.Placa;
                vehiculo.Marca = reporte.Marca;
                vehiculo.Modelo = reporte.Modelo;
                vehiculo.Anho = reporte.Anho;
                //vehiculoDAO.Insertar(vehiculo);

            }

        }

        

        public bool Insertar(ReporteInfraccion REPO)
        {
            ValidarReporte(REPO);
            return reporteInfraccionDAO.Agregar(REPO);
        }

        private void ValidarReporte(ReporteInfraccion REPO)
        {
            if (REPO == null)
                throw new ArgumentNullException(nameof(REPO));

            if (REPO.ConductorId <= 0)
                throw new ArgumentException("El ID del tipo de licencia debe ser mayor que cero");

            if (string.IsNullOrWhiteSpace(REPO.Paterno))
                throw new ArgumentException("El paterno es requerido");
            
            if (string.IsNullOrWhiteSpace(REPO.Nombres))
                throw new ArgumentException("El nombres es requerido");
            if (REPO.VehiculoId <= 0)
                throw new ArgumentException("El ID del tipo de licencia debe ser mayor que cero");

            if (REPO.Placa.Length != 7)
                throw new ArgumentException("La placa del vehículo debe tener exactamente 7 caracteres");

            if (string.IsNullOrWhiteSpace(REPO.Marca))
                throw new ArgumentException("La marca del vehículo es requerida");

            if (REPO.Marca.Length > 45)
                throw new ArgumentException("La marca del vehículo no puede exceder los 45 caracteres");

            if (string.IsNullOrWhiteSpace(REPO.Modelo))
                throw new ArgumentException("El modelo del vehículo es requerido");

            if (REPO.Modelo.Length > 45)
                throw new ArgumentException("El modelo del vehículo no puede exceder los 45 caracteres");

            if (REPO.Anho <= 0)
                throw new ArgumentException("El año del vehículo debe ser mayor a cero");
            if (string.IsNullOrWhiteSpace(REPO.Descripcion))
                throw new ArgumentException("La descripción de la infracción es requerida");
            if (REPO.InfraccionId <= 0)
                throw new ArgumentException("El ID del tipo de licencia debe ser mayor que cero");

            if (REPO.Descripcion.Length > 45)
                throw new ArgumentException("La descripción no puede exceder los 45 caracteres");

            if (REPO.Monto < 0)
                throw new ArgumentException("El monto de la multa no puede ser negativo");

            if (string.IsNullOrWhiteSpace(REPO.Gravedad))
                throw new ArgumentException("La marca del vehículo es requerida");

        }

    }
}
