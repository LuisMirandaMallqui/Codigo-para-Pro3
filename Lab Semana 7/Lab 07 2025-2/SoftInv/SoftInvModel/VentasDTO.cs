using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvModel
{
    public class VentasDTO
    {
        private int? idVenta;
        private ClientesDTO cliente;
        private PeliculasDTO pelicula;
        private SucursalesDTO sucursal;
        private DateTime? fechaVenta;
        private int? cantidadAsientos;
        private double? totalVenta;

        public VentasDTO() { 
            this.IdVenta = null;
            this.Cliente = null;
            this.Pelicula = null;
            this.Sucursal = null;
            this.FechaVenta = null;
            this.CantidadAsientos = null;
            this.TotalVenta = null;
        }

        public VentasDTO(int? idVenta, ClientesDTO cliente, PeliculasDTO pelicula, SucursalesDTO sucursal, DateTime? fechaVenta, int? cantidadAsientos, double? totalVenta)
        {
            this.IdVenta = idVenta;
            this.Cliente = cliente;
            this.Pelicula = pelicula;
            this.Sucursal = sucursal;
            this.FechaVenta = fechaVenta;
            this.CantidadAsientos = cantidadAsientos;
            this.TotalVenta = totalVenta;
        }

        public int? IdVenta { get => idVenta; set => idVenta = value; }
        public ClientesDTO Cliente { get => cliente; set => cliente = value; }
        public PeliculasDTO Pelicula { get => pelicula; set => pelicula = value; }
        public SucursalesDTO Sucursal { get => sucursal; set => sucursal = value; }
        public DateTime? FechaVenta { get => fechaVenta; set => fechaVenta = value; }
        public int? CantidadAsientos { get => cantidadAsientos; set => cantidadAsientos = value; }
        public double? TotalVenta { get => totalVenta; set => totalVenta = value; }
    }
}
