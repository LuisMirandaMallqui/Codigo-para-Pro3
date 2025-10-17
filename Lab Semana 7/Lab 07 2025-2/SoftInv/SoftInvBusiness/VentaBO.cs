using SoftInvModel;
using SoftInvPersistance.DAO;
using SoftInvPersistance.DAOImpl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvBusiness
{
    public class VentaBO
    {
        private VentaDAO ventaDAO;

        public VentaBO()
        {
            this.ventaDAO = new VentaDAOImpl();
        }

        public int Insertar(int idCliente, int idPelicula, int idSucursal, DateTime fechaVenta, int cantidadAsientos, double totalVenta)
        {
            VentasDTO ventasDTO = new VentasDTO();
            ventasDTO.Cliente = new ClientesDTO();
            ventasDTO.Cliente.IdCliente = idCliente;
            ventasDTO.Pelicula = new PeliculasDTO();
            ventasDTO.Pelicula.IdPelicula = idPelicula;
            ventasDTO.Sucursal = new SucursalesDTO();
            ventasDTO.Sucursal.IdSucursal = idSucursal;
            ventasDTO.FechaVenta = fechaVenta;
            ventasDTO.CantidadAsientos = cantidadAsientos;
            ventasDTO.TotalVenta = totalVenta;
            return this.ventaDAO.Insertar(ventasDTO);
        }

        public int Eliminar(int idVenta)
        {
            VentasDTO ventasDTO = new VentasDTO();
            ventasDTO.IdVenta = idVenta;
            return this.ventaDAO.Eliminar(ventasDTO);
        }

        public int Modificar(int idVenta, int idCliente, int idPelicula, int idSucursal, DateTime fechaVenta, int cantidadAsientos, double totalVenta)
        {
            VentasDTO ventasDTO = new VentasDTO();
            ventasDTO.IdVenta = idVenta;
            ventasDTO.Cliente = new ClientesDTO();
            ventasDTO.Cliente.IdCliente = idCliente;
            ventasDTO.Pelicula = new PeliculasDTO();
            ventasDTO.Pelicula.IdPelicula = idPelicula;
            ventasDTO.Sucursal = new SucursalesDTO();
            ventasDTO.Sucursal.IdSucursal = idSucursal;
            ventasDTO.FechaVenta = fechaVenta;
            ventasDTO.CantidadAsientos = cantidadAsientos;
            ventasDTO.TotalVenta = totalVenta;
            return this.ventaDAO.Modificar(ventasDTO);
        }

        public VentasDTO ObtenerPorId(int idVenta)
        {
            return this.ventaDAO.ObtenerPorId(idVenta);
        }

        public BindingList<VentasDTO> ListarTodos()
        {
            return this.ventaDAO.ListarTodos();
        }
    }
}
