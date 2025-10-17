using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvModel
{
    public class PeliculasDTO
    {
        private int? idPelicula;
        private string nombrePelicula;
        private string generoPelicula;

        public PeliculasDTO()
        {
            this.IdPelicula = null;
            this.NombrePelicula = null;
            this.GeneroPelicula = null;
        }

        public PeliculasDTO(int? idPelicula, string nombrePelicula, string generoPelicula)
        {
            this.IdPelicula = idPelicula;
            this.NombrePelicula = nombrePelicula;
            this.GeneroPelicula = generoPelicula;
        }

        public int? IdPelicula { get => idPelicula; set => idPelicula = value; }
        public string NombrePelicula { get => nombrePelicula; set => nombrePelicula = value; }
        public string GeneroPelicula { get => generoPelicula; set => generoPelicula = value; }
    }
}
