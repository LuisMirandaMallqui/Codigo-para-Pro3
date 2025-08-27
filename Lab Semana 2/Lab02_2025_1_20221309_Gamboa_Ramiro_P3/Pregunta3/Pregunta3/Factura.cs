using System;
using System.Text;

namespace Pregunta3
{
    public class Factura : Comprobante
    {
        private string ruc;
        private string razonSocial;

        public Factura(string ruc, string razonSocial)
        {
            this.ruc = ruc;
            this.razonSocial = razonSocial;
        }

        protected override string Encabezado()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("FACTURA");
            sb.AppendLine("CLIENTE:");
            sb.AppendLine($"RUC: {ruc}");
            sb.AppendLine($"Razón Social: {razonSocial}");
            return sb.ToString();
        }
    }
}