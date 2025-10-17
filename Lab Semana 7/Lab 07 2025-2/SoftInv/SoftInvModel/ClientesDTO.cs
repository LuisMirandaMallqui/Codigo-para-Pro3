using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftInvModel
{
    public class ClientesDTO
    {
        private int? idCliente;
        private string nombreCliente;
        private string apellidoCliente;
        private string emailCliente;

        public ClientesDTO()
        {
            this.IdCliente = null;
            this.NombreCliente = null;
            this.ApellidoCliente = null;
            this.EmailCliente = null;
        }

        public ClientesDTO(int? idCliente, string nombreCliente, string apellidoCliente, string emailCliente)
        {
            this.IdCliente = idCliente;
            this.NombreCliente = nombreCliente;
            this.ApellidoCliente = apellidoCliente;
            this.EmailCliente = emailCliente;
        }

        public int? IdCliente { get => idCliente; set => idCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidoCliente { get => apellidoCliente; set => apellidoCliente = value; }
        public string EmailCliente { get => emailCliente; set => emailCliente = value; }
    }
}
