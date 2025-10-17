using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class CamarasDTO
    {
        private int? id;
        private string modelo;
        private string codigo_serie;
        private int? latitud;
        private int? longitud;

        public CamarasDTO()
        {
            this.Id = null;
            this.Modelo = null;
            this.Codigo_serie = null;
            this.Latitud = null;
            this.Longitud = null;
        }

        public CamarasDTO(int? id, string modelo, string codigo_serie, int? latitud, int? longitud)
        {
            this.Id = id;
            this.Modelo = modelo;
            this.Codigo_serie = codigo_serie;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        public int? Id { get => id; set => id = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Codigo_serie { get => codigo_serie; set => codigo_serie = value; }
        public int? Latitud { get => latitud; set => latitud = value; }
        public int? Longitud { get => longitud; set => longitud = value; }
    }
}
