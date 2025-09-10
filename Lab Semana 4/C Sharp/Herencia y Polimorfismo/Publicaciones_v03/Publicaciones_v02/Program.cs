using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones_v03
{
    public class Program
    {
        static void Main(string[] args)
        {
            Publicacion[] publicaciones = new Publicacion[3];
            //Publicacion articulo = new Articulo("A Relational Model of Data for Large Shared Data Banks", "Codd", 1970, "Communication of the ACM", 13, 6, "June");
            publicaciones[0] = new Articulo("A Relational Model of Data for Large Shared Data Banks", "Codd", 1970, "Communication of the ACM", 13, 6, "June");
            string[] autores = new string[] { "Gamma", "Helm", "Johnson", "Vlissides" };
            //Publicacion libro = new Libro("Design Patterns: Elements of Reusable Object-Oriented Software", autores, 1994, "1st", "USA", "Addison-Wesley Professional");
            publicaciones[1] = new Libro("Design Patterns: Elements of Reusable Object-Oriented Software", autores, 1994, "1st", "USA", "Addison-Wesley Professional");
            //Publicacion tesis = new Tesis("A system of logic based on ordinals", "Alan Turing", 1938, "Tesis de doctorado", "Departamento de Matemáticas", "Universidad de Princeton", "Princeton", "NJ");
            publicaciones[2] = new Tesis("A system of logic based on ordinals", "Alan Turing", 1938, "Tesis de doctorado", "Departamento de Matemáticas", "Universidad de Princeton", "Princeton", "NJ");

            //articulo.Referenciar();
            //libro.Referenciar();
            //tesis.Referenciar();

            //La linea siguiente no se puede implementar porque la clase es abstracta
            //Publicacion pub = new Publicacion(publicacion[0]);

            foreach(Publicacion publicacion in publicaciones)
            {
                publicacion.Referenciar();
                //Console.WriteLine(publicacion.MetodoAbstracto());
                Publicacion.orden_publicacion++;
            }
        }
    }
}
