using System;

namespace Pregunta3
{
    public class ComprobanteDetalle
    {
        public int Numero { get; }
        public string Descripcion { get; }
        public int Cantidad { get; }
        public double Precio { get; }
        public double IGV => 0.18; // 18% fijo
        public double SubTotal => Cantidad * Precio * (1 + IGV);

        public ComprobanteDetalle(int numero, string descripcion, int cantidad, double precio)
        {
            Numero = numero;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{Numero:D2} {Descripcion,-12} {Cantidad:D2} {Precio,6:F2} {IGV:P1} {SubTotal,8:F2}";
        }
    }
}
