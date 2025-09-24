package pe.com.citasvet.dao;

import pe.com.citasvet.modelo.CitaMedica;
import java.util.ArrayList;

public interface ICitaMedicaDAO {
    public int insertar(CitaMedica cita);
    public boolean modificar(CitaMedica cita);
    public boolean eliminar(int id);
    public CitaMedica obtenerPorId(int id);
    public ArrayList<CitaMedica> listar();
	
	public ArrayList<CitaMedica> listarPorPaciente(int id);
}
