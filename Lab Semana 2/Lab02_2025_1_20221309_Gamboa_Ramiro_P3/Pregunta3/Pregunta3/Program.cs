using System;

namespace Pregunta3
{
    public class Principal
    {
        static void Main(string[] args)
        {
            Comprobante comprobante = new Comprobante();
            comprobante.AgregarDetalle("Polo azul", 2, 56.99);
            comprobante.AgregarDetalle("Blue Jean", 1, 99.45);
            Console.WriteLine(comprobante);

            comprobante = new Factura("10236786549", "Asociación Programación 3");
            comprobante.AgregarDetalle("Polo azul", 2, 56.99);
            comprobante.AgregarDetalle("Blue Jean", 1, 99.45);
            Console.WriteLine(comprobante);
        }
    }
}