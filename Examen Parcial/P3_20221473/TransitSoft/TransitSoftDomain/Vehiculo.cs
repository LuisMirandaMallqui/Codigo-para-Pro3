using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftDomain
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anho { get; set; }

        public Vehiculo(string placa, string marca, string modelo, int anho)
        {

            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anho = anho;
        }
        public Vehiculo()
        {
            VehiculoId = 0;
            Placa = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            Anho = 0;
        }
        public override string ToString()
        {
            return $"{Marca} {Modelo} - Placa: {Placa} - Año: {Anho}";
        }
    }
}
