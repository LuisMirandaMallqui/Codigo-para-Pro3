using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class PropietariosDTO
    {
        private int? id;
        private string dni;
        private string nombres;
        private string apellidos;
        private string direccion;

        public PropietariosDTO()
        {
            this.Id = null;
            this.Dni = null;
            this.Nombres = null;
            this.Apellidos = null;
            this.Direccion = null;
        }

        public PropietariosDTO(int? id, string dni, string nombres, string apellidos, string direccion)
        {
            this.Id = id;
            this.Dni = dni;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Direccion = direccion;
        }

        public int? Id { get => id; set => id = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
