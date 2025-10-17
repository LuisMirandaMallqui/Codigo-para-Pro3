using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftDomain
{
    public class Infraccion
    {

        public int InfraccionId { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoMulta { get; set; }
        public Gravedad Gravedad { get; set; }
        public int Puntos { get; set; }

        public Infraccion(int InfraccionId, string descripcion, decimal montoMulta, Gravedad gravedad, int puntos)
        {
            this.InfraccionId = InfraccionId;
            Descripcion = descripcion;
            MontoMulta = montoMulta;
            Gravedad = gravedad;
            Puntos = puntos;
        }
        public Infraccion()
        {
            InfraccionId = 0;
            Descripcion = string.Empty;
            MontoMulta = 0;
            Gravedad = Gravedad.LEVE;
            Puntos = 0;
        }
    }

    public enum Gravedad
    {
        LEVE,
        GRAVE,
        MUY_GRAVE
    }


}
