using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class CapturasDTO
    {
        private int? id;
        private CamarasDTO camara;
        private string placa;
        private double? velocidad;
        private DateTime? fecha_captura;
        private string estado;

        public CapturasDTO()
        {
            this.Id = null;
            this.Camara = null;
            this.Placa = null;
            this.Velocidad = null;
            this.Fecha_captura = null;
            this.Estado = null;
        }

        public CapturasDTO(int? id, CamarasDTO camara, string placa, double? velocidad, DateTime? fecha_captura, string estado)
        {
            this.Id = id;
            this.Camara = camara;
            this.Placa = placa;
            this.Velocidad = velocidad;
            this.Fecha_captura = fecha_captura;
            this.Estado = estado;
        }

        public int? Id { get => id; set => id = value; }
        public CamarasDTO Camara { get => camara; set => camara = value; }
        public string Placa { get => placa; set => placa = value; }
        public double? Velocidad { get => velocidad; set => velocidad = value; }
        public DateTime? Fecha_captura { get => fecha_captura; set => fecha_captura = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
