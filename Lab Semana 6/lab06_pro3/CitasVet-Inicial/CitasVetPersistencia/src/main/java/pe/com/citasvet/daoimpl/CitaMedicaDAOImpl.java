package pe.com.citasvet.dao.impl;

import pe.com.citasvet.dao.ICitaMedicaDAO;
import pe.com.citasvet.modelo.CitaMedica;

import java.sql.*;
import java.util.ArrayList;

public class CitaMedicaDAOImpl extends BaseDAOImpl implements ICitaMedicaDAO {

    @Override
    public int insertar(CitaMedica cita) {
        String sql = "INSERT INTO cita_medica (paciente_id, fecha, motivo) VALUES (?, ?, ?)";
        try (Connection conexion = obtenerConexion();
             PreparedStatement statement = conexion.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS)) {

            statement.setInt(1, cita.getPaciente().getId());
            statement.setDate(2, Date.valueOf(cita.getFecha()));
            statement.setString(3, cita.getMotivo());

            int filas = statement.executeUpdate();

            if (filas > 0) {
                try (ResultSet rs = statement.getGeneratedKeys()) {
                    if (rs.next()) {
                        return rs.getInt(1); // retorna el ID generado
                    }
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return -1; // si falla
    }

    @Override
    public boolean modificar(CitaMedica cita) {
        String sql = "UPDATE cita_medica SET paciente_id=?, fecha=?, motivo=? WHERE id=?";
        try (Connection conexion = obtenerConexion();
             PreparedStatement statement = conexion.prepareStatement(sql)) {

            statement.setInt(1, cita.getPaciente().getId());
            statement.setDate(2, Date.valueOf(cita.getFecha()));
            statement.setString(3, cita.getMotivo());
            statement.setInt(4, cita.getId());

            return statement.executeUpdate() > 0;

        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    @Override
    public boolean eliminar(int id) {
        String sql = "DELETE FROM cita_medica WHERE id=?";
        try (Connection conexion = obtenerConexion();
             PreparedStatement statement = conexion.prepareStatement(sql)) {

            statement.setInt(1, id);
            return statement.executeUpdate() > 0;

        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }

    @Override
    public CitaMedica obtenerPorId(int id) {
        String sql = "SELECT * FROM cita_medica WHERE id=?";
        try (Connection conexion = obtenerConexion();
             PreparedStatement statement = conexion.prepareStatement(sql)) {

            statement.setInt(1, id);
            try (ResultSet rs = statement.executeQuery()) {
                if (rs.next()) {
                    return new CitaMedica(
                        rs.getInt("id"),
                        rs.getInt("paciente_id"), // ojo: aquí puede ir un objeto Paciente si lo mapeas
                        rs.getDate("fecha").toLocalDate(),
                        rs.getString("motivo")
                    );
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public ArrayList<CitaMedica> listar() {
        ArrayList<CitaMedica> citas = new ArrayList<>();
        String sql = "SELECT * FROM cita_medica";
        try (Connection conexion = obtenerConexion();
             Statement statement = conexion.createStatement();
             ResultSet rs = statement.executeQuery(sql)) {

            while (rs.next()) {
                citas.add(new CitaMedica(
                    rs.getInt("id"),
                    rs.getInt("paciente_id"),
                    rs.getDate("fecha").toLocalDate(),
                    rs.getString("motivo")
                ));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return citas;
    }
	
	@Override
    public ArrayList<CitaMedica> listarPorPaciente(int pacienteId) {
        ArrayList<CitaMedica> citas = new ArrayList<>();
        String sql = "SELECT * FROM cita_medica WHERE paciente_id = ?";

        try (Connection conexion = obtenerConexion();
             PreparedStatement statement = conexion.prepareStatement(sql)) {

            statement.setInt(1, pacienteId);

            try (ResultSet rs = statement.executeQuery()) {
                while (rs.next()) {
                    citas.add(new CitaMedica(
                        rs.getInt("id"),
                        rs.getInt("paciente_id"),
                        rs.getDate("fecha").toLocalDate(),
                        rs.getString("motivo")
                    ));
                }
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }

        return citas;
    }
}
