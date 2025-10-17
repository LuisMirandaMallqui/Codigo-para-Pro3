using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvModel
{
    public class SucursalesDTO
    {
        private int? idSucursal;
        private string nombreSucursal;

        public SucursalesDTO() { 
            this.IdSucursal = null;
            this.NombreSucursal = null;
        }

        public SucursalesDTO(int? idSucursal, string nombreSucursal)
        {
            this.IdSucursal = idSucursal;
            this.NombreSucursal = nombreSucursal;
        }

        public int? IdSucursal { get => idSucursal; set => idSucursal = value; }
        public string NombreSucursal { get => nombreSucursal; set => nombreSucursal = value; }
    }
}
