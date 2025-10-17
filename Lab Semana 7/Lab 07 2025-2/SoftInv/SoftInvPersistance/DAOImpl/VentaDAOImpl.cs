using SoftInv.DAO;
using SoftInv.DAO.Util;
using SoftInvModel;
using SoftInvPersistance.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvPersistance.DAOImpl
{
    public class VentaDAOImpl : DAOImplBase, VentaDAO
    {
        private VentasDTO venta;

        public VentaDAOImpl() : base("venta")
        {
            this.retornarLlavePrimaria = true;
            this.venta = null;
        }

        protected override void ConfigurarListaDeColumnas()
        {
            this.listaColumnas.Add(new Columna("id_venta", true, true));
            this.listaColumnas.Add(new Columna("fid_cliente", false, false));
            this.listaColumnas.Add(new Columna("fid_pelicula", false, false));
            this.listaColumnas.Add(new Columna("fid_sucursal", false, false));
            this.listaColumnas.Add(new Columna("fecha_venta", false, false));
            this.listaColumnas.Add(new Columna("cantidad_asientos", false, false));
            this.listaColumnas.Add(new Columna("total_venta", false, false));
        }

        protected override void IncluirValorDeParametrosParaInsercion()
        {
            AgregarParametro("@fid_cliente", this.venta.Cliente.IdCliente);
            AgregarParametro("@fid_pelicula", this.venta.Pelicula.IdPelicula);
            AgregarParametro("@fid_sucursal", this.venta.Sucursal.IdSucursal);
            AgregarParametro("@fecha_venta", this.venta.FechaVenta);
            AgregarParametro("@cantidad_asientos", this.venta.CantidadAsientos);
            AgregarParametro("@total_venta", this.venta.TotalVenta);
        }

        protected override void IncluirValorDeParametrosParaModificacion()
        {
            AgregarParametro("@id_venta", this.venta.IdVenta);
            AgregarParametro("@fid_cliente", this.venta.Cliente.IdCliente);
            AgregarParametro("@fid_pelicula", this.venta.Pelicula.IdPelicula);
            AgregarParametro("@fid_sucursal", this.venta.Sucursal.IdSucursal);
            AgregarParametro("@fecha_venta", this.venta.FechaVenta);
            AgregarParametro("@cantidad_asientos", this.venta.CantidadAsientos);
            AgregarParametro("@total_venta", this.venta.TotalVenta);
        }

        protected override void IncluirValorDeParametrosParaEliminacion()
        {
            AgregarParametro("@id_venta", this.venta.IdVenta);
        }

        protected override void IncluirValorDeParametrosParaObtenerPorId()
        {
            AgregarParametro("@id_venta", this.venta.IdVenta);
        }

        protected override void InstanciarObjetoDelResultSet(DbDataReader lector)
        {
            this.venta = new VentasDTO();
            this.venta.IdVenta = this.lector.GetInt32(0);
            this.venta.Cliente = new ClientesDTO();
            this.venta.Cliente.IdCliente = this.lector.GetInt32(1);
            this.venta.Pelicula = new PeliculasDTO();
            this.venta.Pelicula.IdPelicula = this.lector.GetInt32(2);
            this.venta.Sucursal = new SucursalesDTO();
            this.venta.Sucursal.IdSucursal = this.lector.GetInt32(3);
            this.venta.FechaVenta = this.lector.GetDateTime(4);
            this.venta.CantidadAsientos = this.lector.GetInt32(5);
            this.venta.TotalVenta = this.lector.GetDouble(6);
        }

        protected override void LimpiarObjetoDelResultSet()
        {
            this.venta = null;
        }

        protected override void AgregarObjetoALaLista(BindingList<Object> lista, DbDataReader lector)
        {
            this.InstanciarObjetoDelResultSet(lector);
            lista.Add(this.venta);
        }

        //Metodos CRUD
        public int Insertar(VentasDTO venta)
        {
            this.venta = venta;
            return base.Insertar();
        }

        public int Modificar(VentasDTO venta)
        {
            this.venta = venta;
            return base.Modificar();
        }

        public int Eliminar(VentasDTO venta)
        {
            this.venta = venta;
            return base.Eliminar();
        }

        public VentasDTO ObtenerPorId(int idVenta)
        {
            this.venta = new VentasDTO();
            this.venta.IdVenta = idVenta;
            base.ObtenerPorId();
            return this.venta;
        }

        public new BindingList<VentasDTO> ListarTodos()
        {
            BindingList<Object> lista;
            lista = base.ListarTodos();
            BindingList<VentasDTO> retorno = new BindingList<VentasDTO>();
            foreach (VentasDTO objecto in lista)
            {
                retorno.Add(objecto);
            }
            return retorno;
        }
    }
}
