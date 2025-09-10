using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones_v02
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] autores = new string[] { "Gamma", "Helm", "Johnson", "Vlissides" };
            //Publicacion publicacion = new Publicacion("Design Pattern: Elements of Reusable Object-Oriented Software", autores, 1994);
            //Console.WriteLine(publicacion);
            //autores[0] = "Melgar";
            //autores[1] = "Cueva";
            //Console.WriteLine(publicacion);

            Articulo articulo = new Articulo("A Relational Model of Data for Large Shared Data Banks", "Codd", 1970, "Communication of the ACM", 13, 6, "June");
            Libro libro = new Libro("Design Patterns: Elements of Reusable Object-Oriented Software", autores, 1994, "1st", "USA", "Addison-Wesley Professional");
            Tesis tesis = new Tesis("A system of logic based on ordinals", "Alan Turing", 1938, "Tesis de doctorado", "Departamento de Matemáticas", "Universidad de Princeton", "Princeton", "NJ");

            //Console.WriteLine(articulo);
            //Console.WriteLine(libro);
            //Console.WriteLine(tesis);
            articulo.Referenciar();
            libro.Referenciar();
            tesis.Referenciar();
        }
    }
}
