using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class VehiculosDTO
    {
        private int? id;
        private string placa;
        private string marca;
        private string modelo;
        private int? anho;

        public VehiculosDTO()
        {
            this.Id = null;
            this.Placa = null;
            this.Marca = null;
            this.Modelo = null;
            this.Anho = null;
        }

        public VehiculosDTO(int? id, string placa, string marca, string modelo, int? anho)
        {
            this.Id = id;
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Anho = anho;
        }

        public int? Id { get => id; set => id = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int? Anho { get => anho; set => anho = value; }
    }
}
