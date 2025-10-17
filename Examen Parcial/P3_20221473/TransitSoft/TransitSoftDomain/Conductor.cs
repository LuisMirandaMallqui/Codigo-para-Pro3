using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftDomain
{
    public class Conductor
    {
        public int ConductorId { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string NumLicencia { get; set; }
        public TipoLicencia TipoLicencia { get; set; }
        public int PuntosAcumulados { get; set; }

    

        public Conductor()
        {
       
            TipoLicencia = new TipoLicencia();
        }



        public Conductor(string paterno, string materno, string nombres, string numLicencia, TipoLicencia TipoLicencia)
        {

            Paterno = paterno;
            Materno = materno;
            Nombres = nombres;
            NumLicencia = numLicencia;
            this.TipoLicencia = TipoLicencia;
         
        }



        public override string ToString()
        {
            return $"{Paterno} {Materno} {Nombres} - Licencia: {NumLicencia}";
        }
    }
}
