using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta3
{
    public class Comprobante
    {
        protected List<ComprobanteDetalle> detalles;

        public Comprobante()
        {
            detalles = new List<ComprobanteDetalle>();
        }

        public void AgregarDetalle(string descripcion, int cantidad, double precio)
        {
            int numero = detalles.Count + 1;
            detalles.Add(new ComprobanteDetalle(numero, descripcion, cantidad, precio));
        }

        protected virtual string Encabezado()
        {
            return "BOLETA DE PAGO";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Encabezado());
            sb.AppendLine("DETALLE:");
            sb.AppendLine("No Desc.         Cant. Precio  IGV   SubTotal");

            foreach (var d in detalles)
                sb.AppendLine(d.ToString());

            double total = detalles.Sum(d => d.SubTotal);
            sb.AppendLine($"TOTAL: {total:F2}");

            return sb.ToString();
        }
    }
}