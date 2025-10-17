using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class InfraccionesDTO
    {
        private int? id;
        private VehiculosDTO vehiculo;
        private PropietariosDTO propietario;
        private CamarasDTO camara;
        private CapturasDTO captura;
        private double? exceso;
        private double? limite;
        private double? monto;
        private DateTime? fecha_registro;

        public InfraccionesDTO()
        {
            this.Id = null;
            this.Vehiculo = null;
            this.Propietario = null;
            this.Camara = null;
            this.Captura = null;
            this.Exceso = null;
            this.Limite = null;
            this.Monto = null;
            this.Fecha_registro = null;
        }

        public InfraccionesDTO(int? id, VehiculosDTO vehiculo, PropietariosDTO propietario, CamarasDTO camara, CapturasDTO captura, double? exceso, double? limite, double? monto, DateTime? fecha_registro)
        {
            this.Id = id;
            this.Vehiculo = vehiculo;
            this.Propietario = propietario;
            this.Camara = camara;
            this.Captura = captura;
            this.Exceso = exceso;
            this.Limite = limite;
            this.Monto = monto;
            this.Fecha_registro = fecha_registro;
        }

        public int? Id { get => id; set => id = value; }
        public VehiculosDTO Vehiculo { get => vehiculo; set => vehiculo = value; }
        public PropietariosDTO Propietario { get => propietario; set => propietario = value; }
        public CamarasDTO Camara { get => camara; set => camara = value; }
        public CapturasDTO Captura { get => captura; set => captura = value; }
        public double? Exceso { get => exceso; set => exceso = value; }
        public double? Limite { get => limite; set => limite = value; }
        public double? Monto { get => monto; set => monto = value; }
        public DateTime? Fecha_registro { get => fecha_registro; set => fecha_registro = value; }
    }
}
