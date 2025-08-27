using System;

namespace Pregunta1{
	public class Postulante{
		//Atributos
		private string paterno;
		private string materno;
		private string nombre;
		private string dni;
		
		// Propiedades
		public string Paterno{
			get {return paterno;}
			set {paterno = value;}
		}
		
		public string Materno{
			get {return materno;}
			set {materno = value;}
		}
		
		public string Nombre{
			get {return nombre;}
			set {nombre = value;}
		}
		
		public string Dni{
			get {return dni;}
			set {dni = value;}
		}
		
		//Constructor con parametro
		public Postulante(string paterno, string materno, string nombre, string dni){
			this.paterno = paterno;
			this.materno = materno;
			this.nombre = nombre;
			this.dni = dni;
		}
		
		//Constructor sin parametro
		public Postulante(){
			
		}
		
		//Constructor copia
		public Postulante(Postulante other){
			this.paterno = other.paterno;
			this.materno = other.materno;
			this.nombre = other.nombre;
			this.dni = other.dni;
		}
		
		//Sobreescribir metodo ToString
		public override string ToString(){
			return string.Format("{0} {1}, {2} ({3})", paterno, materno, nombre, dni);
		}
	}
}