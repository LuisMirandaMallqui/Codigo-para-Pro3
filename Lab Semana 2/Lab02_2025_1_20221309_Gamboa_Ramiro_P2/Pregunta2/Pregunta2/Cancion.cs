using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta2
{
    public class Cancion
    {
        //Atributos
        private string titulo;
        private string? otroTitulo; //La mayoria no tiene
        private List<string> interpretes;
        private List<string> compositores;
        private Genero generoMusical;
        private string? album;
        private int? opus; //Solo en musica clasica
        private int? subOpus; //Solo en musica clasica
        private string? dedicatoria; //Atributo opcional

        //Propiedades (Crear con Ctrl+.)
        public string Titulo { get => titulo; set => titulo = value; }
        public string? OtroTitulo { get => otroTitulo; set => otroTitulo = value; }
        public List<string> Interpretes { get => interpretes; set => interpretes = value; }
        public List<string> Compositores { get => compositores; set => compositores = value; }
        public Genero GeneroMusical { get => generoMusical; set => generoMusical = value; }
        public string? Album { get => album; set => album = value; }
        public int? Opus { get => opus; set => opus = value; }
        public int? SubOpus { get => subOpus; set => subOpus = value; }
        public string? Dedicatoria { get => dedicatoria; set => dedicatoria = value; }

        //Constructor sin parametro
        public Cancion()
        {
            interpretes = new List<string>();
            compositores = new List<string>();
        }

        //Sobreescribir metodo ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("TITULO: {0}", titulo);
            sb.AppendLine();
            if (!string.IsNullOrEmpty(otroTitulo))
            {
                sb.AppendFormat("TAMBIEN CONOCIDA COMO: {0}", otroTitulo);
                sb.AppendLine();
            }
            if (interpretes.Count > 0) {
                sb.AppendFormat("INTERPRETADO POR: {0}", string.Join(", ", interpretes));
                sb.AppendLine();
            }
            if (compositores.Count > 0) {
                sb.AppendFormat("COMPUESTO POR: {0}", string.Join(", ", compositores));
                sb.AppendLine();
            }
            string generoTexto = generoMusical == Genero.FOLKLORE ? "Folklore" : "Clasica";
            sb.AppendFormat("TIPO: {0}", generoTexto);
            sb.AppendLine();
            if (!string.IsNullOrEmpty(album)) {
                sb.AppendFormat("ALBUM: {0}", album);
                sb.AppendLine();
            }
            if (opus != null)
            {
                sb.AppendFormat("OPUS: {0}", opus);
                if (subOpus != null) sb.AppendFormat(" SUBOPUS: {0}", subOpus);
            }
            sb.AppendLine();
            if (!string.IsNullOrEmpty(dedicatoria)) {
                sb.AppendFormat("DEDICADO A: {0}", dedicatoria);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
