using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvModel
{
    public class VideojuegosDTO
    {
        private int? idVideojuego;
        private GenerosDTO genero;
        private CategoriasDTO categoria;
        private string nombreVideojuego;
        private DateTime? fechaLanzamiento;
        private double? precioAproxMercado;
        private int? numJugadoresMc;

        public VideojuegosDTO()
        {
            this.idVideojuego = null;
            this.genero = null;
            this.categoria = null;
            this.nombreVideojuego = null;
            this.fechaLanzamiento = null;
            this.precioAproxMercado = null;
            this.numJugadoresMc = null;
        }

        public VideojuegosDTO(int? idVideojuego, GenerosDTO genero, CategoriasDTO categoria, string nombreVideojuego, DateTime? fechaLanzamiento, double? precioAproxMercado, int? numJugadoresMc)
        {
            this.idVideojuego = idVideojuego;
            this.genero = genero;
            this.categoria = categoria;
            this.nombreVideojuego = nombreVideojuego;
            this.fechaLanzamiento = fechaLanzamiento;
            this.precioAproxMercado = precioAproxMercado;
            this.numJugadoresMc = numJugadoresMc;
        }
    }
}
