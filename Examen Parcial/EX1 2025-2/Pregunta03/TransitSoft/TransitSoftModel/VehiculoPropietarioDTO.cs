using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftModel
{
    public class VehiculoPropietarioDTO
    {
        private int? id;
        private VehiculosDTO vehiculo;
        private PropietariosDTO propietario;

        public VehiculoPropietarioDTO()
        {
            this.Id = null;
            this.Vehiculo = null;
            this.Propietario = null;
        }

        public VehiculoPropietarioDTO(int? id, VehiculosDTO vehiculo, PropietariosDTO propietario)
        {
            this.Id = id;
            this.Vehiculo = vehiculo;
            this.Propietario = propietario;
        }

        public int? Id { get => id; set => id = value; }
        public VehiculosDTO Vehiculo { get => vehiculo; set => vehiculo = value; }
        public PropietariosDTO Propietario { get => propietario; set => propietario = value; }
    }
}
