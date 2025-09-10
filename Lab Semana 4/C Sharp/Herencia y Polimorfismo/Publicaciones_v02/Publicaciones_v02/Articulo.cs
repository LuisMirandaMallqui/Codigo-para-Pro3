using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones_v02
{
    public class Articulo : Publicacion
    {
        private string revista;
        private int volumen;
        private int numero;
        private string mes;

        public Articulo(string nombre, string autor,int año, string revista, int volumen, int numero, string mes) : base(nombre, autor, año)
        {
            this.Revista = revista;
            this.Volumen = volumen;
            this.Numero = numero;
            this.Mes = mes;
        }

        public string Revista { get => revista; set => revista = value; }
        public int Volumen { get => volumen; set => volumen = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Mes { get => mes; set => mes = value; }

        public Articulo(string nombre, string[] autores, int año, string revista, int volumen, int numero, string mes) : base(nombre, autores, año)
        {
            this.Revista = revista;
            this.Volumen = volumen;
            this.Numero = numero;
            this.Mes = mes;
        }

        public override string ToString()
        {
            string referencia = "[1] ";
            for (int i = 0; i < this.Cantidad_autores; i++)
            {
                if (i != 0)
                {
                    if (i == this.Cantidad_autores - 1)
                        referencia += " and ";
                    else
                        referencia += ", ";
                }
                referencia += this.Autores[i];
            }
            referencia += ". ";
            referencia += this.Nombre;
            referencia += ". ";
            referencia += this.Volumen;
            referencia += ". ";
            referencia += this.Numero;
            referencia += ". ";
            referencia += this.Mes;
            referencia += ". ";
            referencia += this.Año;
            referencia += ".";
            return referencia;
        }
    }
}
