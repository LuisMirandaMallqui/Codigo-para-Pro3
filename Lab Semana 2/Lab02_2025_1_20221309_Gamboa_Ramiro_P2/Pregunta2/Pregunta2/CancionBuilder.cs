using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta2
{
    public class CancionBuilder
    {
        //Atributos
        private string titulo;
        private string? otroTitulo;
        private List<string> interpretes;
        private List<string> compositores;
        private Genero generoMusical;
        private string? album;
        private int? opus;
        private int? subOpus;
        private string? dedicatoria;

        //Propiedades
        public string Titulo { get => titulo; set => titulo = value; }
        public string? OtroTitulo { get => otroTitulo; set => otroTitulo = value; }
        public List<string> Interpretes { get => interpretes; set => interpretes = value; }
        public List<string> Compositores { get => compositores; set => compositores = value; }
        public Genero GeneroMusical { get => generoMusical; set => generoMusical = value; }
        public string? Album { get => album; set => album = value; }
        public int? Opus { get => opus; set => opus = value; }
        public int? SubOpus { get => subOpus; set => subOpus = value; }
        public string? Dedicatoria { get => dedicatoria; set => dedicatoria = value; }

        //Constructor sin parametros
        public CancionBuilder()
        {
            interpretes = new List<string>();
            compositores = new List<string>();
        }

        //Metodos
        public CancionBuilder ConTitulo(string titulo) 
        {
            this.titulo = titulo;
            return this;
        }

        public CancionBuilder TambienConocidaComo(string otroTitulo)
        {
            this.otroTitulo = otroTitulo;
            return this;
        }

        public CancionBuilder InterpretadoPor(string interprete)
        {
            this.interpretes.Add(interprete);
            return this;
        }

        public CancionBuilder CompuestoPor(string compositor)
        {
            this.compositores.Add(compositor);
            return this;
        }

        public CancionBuilder DelGenero(Genero genero)
        {
            this.generoMusical = genero;
            return this;
        }

        public CancionBuilder EnElAlbum(string album)
        {
            this.album = album;
            return this;
        }

        public CancionBuilder IdentificadoConOpus(int opus)
        {
            this.opus = opus;
            return this;
        }

        public CancionBuilder IdentificadoConSubOpus(int subOpus)
        {
            this.subOpus = subOpus;
            return this;
        }

        public CancionBuilder DedicadoA(string dedicatoria)
        {
            this.dedicatoria = dedicatoria;
            return this;
        }

        //Metodo BuildCancion
        public Cancion BuildCancion()
        {
            return new Cancion
            {
                Titulo = this.titulo,
                OtroTitulo = this.otroTitulo,
                Interpretes = new List<string>(this.interpretes),
                Compositores = new List<string>(this.compositores),
                GeneroMusical = this.generoMusical,
                Album = this.album,
                Opus = this.opus,
                SubOpus = this.subOpus,
                Dedicatoria = this.dedicatoria
            };
        }
    }
}
