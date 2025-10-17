using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransitSoft.DAO;
using TransitSoft.DAO.Util;
using TransitSoftModel;
using TransitSoftPersistance.DAO;
using static System.Collections.Specialized.BitVector32;

namespace SoftInv.DAO
{
    public class InfraccionDAOImpl : DAOImplBase, InfraccionDAO
    {
        private InfraccionesDTO infraccion;

        public InfraccionDAOImpl() : base("infraccion")
        {
            this.retornarLlavePrimaria = true;
            this.infraccion = null;
        }

        protected override void ConfigurarListaDeColumnas()
        {
            this.listaColumnas.Add(new Columna("id_videojuego", true, true));
            this.listaColumnas.Add(new Columna("fid_genero", false, false));
            this.listaColumnas.Add(new Columna("fid_categoria", false, false));
            this.listaColumnas.Add(new Columna("nombre_videojuego", false, false));
            this.listaColumnas.Add(new Columna("fecha_lanzamiento", false, false));
            this.listaColumnas.Add(new Columna("precio_aprox_mercado", false, false));
            this.listaColumnas.Add(new Columna("num_jugadores_mc", false, false));
        }

        protected override void IncluirValorDeParametrosParaInsercion()
        {
            AgregarParametro("@fid_genero", this.videojuego.Genero.IdGenero);
            AgregarParametro("@fid_categoria", this.videojuego.Categoria.IdCategoria);
            AgregarParametro("@nombre_videojuego", this.videojuego.NombreVideojuego);
            AgregarParametro("@fecha_lanzamiento", this.videojuego.FechaLanzamiento);
            AgregarParametro("@precio_aprox_mercado", this.videojuego.PrecioAproxMercado);
            AgregarParametro("@num_jugadores_mc", this.videojuego.NumJugadoresMc);
            //AgregarParametro("@ALMACEN_CENTRAL", (bool)this.almacen.AlmacenCentral ? 1 : 0);
        }

        protected override void IncluirValorDeParametrosParaModificacion()
        {
            AgregarParametro("@id_videojuego", this.videojuego.IdVideojuego);
            AgregarParametro("@fid_genero", this.videojuego.Genero.IdGenero);
            AgregarParametro("@fid_categoria", this.videojuego.Categoria.IdCategoria);
            AgregarParametro("@nombre_videojuego", this.videojuego.NombreVideojuego);
            AgregarParametro("@fecha_lanzamiento", this.videojuego.FechaLanzamiento);
            AgregarParametro("@precio_aprox_mercado", this.videojuego.PrecioAproxMercado);
            AgregarParametro("@num_jugadores_mc", this.videojuego.NumJugadoresMc);
        }

        protected override void IncluirValorDeParametrosParaEliminacion()
        {
            AgregarParametro("@id_videojuego", this.videojuego.IdVideojuego);
        }

        protected override void IncluirValorDeParametrosParaObtenerPorId()
        {
            AgregarParametro("@id_videojuego", this.videojuego.IdVideojuego);
        }

        protected override void InstanciarObjetoDelResultSet(DbDataReader lector)
        {
            this.videojuego = new VideojuegosDTO();
            this.videojuego.IdVideojuego = this.lector.GetInt32(0);
            this.videojuego.Genero = new GenerosDTO();
            this.videojuego.Genero.IdGenero = this.lector.GetInt32(1);
            this.videojuego.Categoria = new CategoriasDTO();
            this.videojuego.Categoria.IdCategoria = this.lector.GetChar(2);
            this.videojuego.NombreVideojuego = this.lector.GetString(3);
            this.videojuego.FechaLanzamiento = this.lector.GetDateTime(4);
            this.videojuego.PrecioAproxMercado = this.lector.GetDouble(5);
            this.videojuego.NumJugadoresMc = this.lector.GetInt32(6);
        }

        protected override void LimpiarObjetoDelResultSet()
        {
            this.videojuego = null;
        }

        protected override void AgregarObjetoALaLista(BindingList<Object> lista, DbDataReader lector)
        {
            this.InstanciarObjetoDelResultSet(lector);
            lista.Add(this.videojuego);
        }

        //Metodos CRUD
        public int Insertar(InfraccionesDTO infraccion)
        {
            this.infraccion = infraccion;
            return base.Insertar();
        }

        public int Modificar(InfraccionesDTO infraccion)
        {
            this.infraccion = infraccion;
            return base.Modificar();
        }

        public int Eliminar(InfraccionesDTO infraccion)
        {
            this.infraccion = infraccion;
            return base.Eliminar();
        }

        public InfraccionesDTO ObtenerPorId(int idInfraccion)
        {
            this.infraccion = new InfraccionesDTO();
            this.infraccion.Id = idInfraccion;
            base.ObtenerPorId();
            return this.infraccion;
        }

        public new BindingList<InfraccionesDTO> ListarTodos()
        {
            BindingList<Object> lista;
            lista = base.ListarTodos();
            BindingList<InfraccionesDTO> retorno = new BindingList<InfraccionesDTO>();
            foreach (InfraccionesDTO objecto in lista)
            {
                retorno.Add(objecto);
            }
            return retorno;
        }
    }
}
