using System;
using System.Collections.Generic;
using System.Text;

namespace Pregunta1{
	public class Admision{
		//Atributos
		private List<FichaEvaluacion> listaFichas;
		private int cantidad_admitidos;
		private int cantidad_postulantes;
		
		//Constructor sin parametro
		public Admision(){
			listaFichas = new List<FichaEvaluacion>();
			cantidad_admitidos = 0;
			cantidad_postulantes = 0;
		}
		
		//Agregar Ficha de Evaluacion
		public void agregarFichaDeEvaluacion(FichaEvaluacion ficha){
			if(ficha == null) return;
			
			FichaEvaluacion copia = new FichaEvaluacion(ficha);
			
			EstadoCandidato estado = copia.Estado_candidato;
			//Actualizar cantidad de postulantes
			cantidad_postulantes++; 
			//Actualizar cantidad de admitidos
			if(copia.Estado_candidato == EstadoCandidato.ADMITIDO) cantidad_admitidos++;
			
			listaFichas.Add(copia);
		}
		
		//Sobreescribir metodo ToString
		public override string ToString(){
			StringBuilder sb = new StringBuilder();
			
			sb.AppendFormat("PROCESO DE ADMISION: {0} postulantes, {1} admitidos", 
						    cantidad_postulantes, cantidad_admitidos);
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("LISTA DE ADMITIDOS:");
			
			foreach(var f in listaFichas){
				if(f.Estado_candidato == EstadoCandidato.ADMITIDO && f.Candidato != null){
					sb.AppendLine(f.Candidato.ToString());
				}
			}
			
			return sb.ToString();
		}
	}
}