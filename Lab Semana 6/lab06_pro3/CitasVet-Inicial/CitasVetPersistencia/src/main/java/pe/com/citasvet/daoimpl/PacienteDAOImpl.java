package pe.com.citasvet.daoimpl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import pe.com.citasvet.config.DBManager;
import pe.com.citasvet.dao.IPacienteDAO;
import pe.com.citasvet.daoimpl.util.Columna;
import pe.com.citasvet.modelo.Paciente;

public class PacienteDAOImpl extends BaseDAOImpl implements IPacienteDAO {
    
    private Paciente paciente;
    
    public PacienteDAOImpl(){
        super("paciente");
        this.paciente = null;
        this.retornarLlavePrimaria = true;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idTutor",true,true));
        this.listaColumnas.add(new Columna("nombre",false,false));
        this.listaColumnas.add(new Columna("especie",false,false));
        this.listaColumnas.add(new Columna("raza",false,false));
        this.listaColumnas.add(new Columna("edad",false,false));
        this.listaColumnas.add(new Columna("estado",false,false));
    }
    
    @Override
    public int insertar(Paciente paciente) {
        //String sql = ""
        //        + "insert into paciente("
        //        +   "idTutor, "
        //        +   "nombre, "
        //        +   "especie, "
        //        +   "raza, "
        //        +   "edad, "
        //        +   "estado) "
        //        + "values"
        //        +   "(?, ?, ?, ?, ?, ?)";
        String sql = this.generarSQLParaInsercion();
        
        try (Connection conn = DBManager.getInstance().getConnection();
            PreparedStatement ps = conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS)) {
            
            ps.setInt(1, paciente.getTutor().getId());
            ps.setString(2, paciente.getNombre());
            ps.setString(3, paciente.getEspecie());
            ps.setString(4, paciente.getRaza());
            ps.setInt(5, paciente.getEdad());
            ps.setString(6, paciente.getEstado());
            
            if (ps.executeUpdate() == 0) {
                System.err.println("El registro no se inserto.");
                return 0;
            }
            
            try (ResultSet rs = ps.getGeneratedKeys()) {
                return rs.next() ? rs.getInt(1) : -1;
            }
        }
        catch (SQLException e) {
            System.err.println("Error SQL durante la insercion: " + e.getMessage());
            throw new RuntimeException("No se pudo insertar el registro.", e);
        }
        catch (Exception e) {
            System.err.println("Error inpesperado: " + e.getMessage());
            throw new RuntimeException("Error inesperado al insertar el registro.", e);
        }
    }

    @Override
    public boolean modificar(Paciente paciente) {
        //String sql = ""
        //        + "update paciente "
        //        + "set idTutor = ?, "
        //            + "nombre = ?, "
        //            + "especie = ?, "
        //            + "raza = ?, "
        //            + "edad = ?, "
        //            + "estado = ? "
        //        + "where id = ?";
        String sql = this.generarSQLParaModificacion();
        try (Connection conn = DBManager.getInstance().getConnection();
            PreparedStatement cmd = conn.prepareStatement(sql)) {
            
            cmd.setInt(1, paciente.getTutor().getId());
            cmd.setString(2, paciente.getNombre());
            cmd.setString(3, paciente.getEspecie());
            cmd.setString(4, paciente.getRaza());
            cmd.setInt(5, paciente.getEdad());
            cmd.setString(6, paciente.getEstado());
            cmd.setInt(7, paciente.getId());
            
            return cmd.executeUpdate() > 0;
        }
        catch (SQLException e) {
            System.err.println("Error SQL durante la modificacion: " + e.getMessage());
            throw new RuntimeException("No se pudo modificar el registro.", e);
        }
        catch (Exception e) {
            System.err.println("Error inpesperado: " + e.getMessage());
            throw new RuntimeException("Error inesperado al modificar el registro.", e);
        }
    }

    @Override
    public boolean eliminar(int id) {
        //String sql = "delete from paciente where id = ?";
        String sql = this.generarSQLParaEliminacion();
        try (Connection conn = DBManager.getInstance().getConnection();
            PreparedStatement cmd = conn.prepareStatement(sql)) {
            
            cmd.setInt(1, id);
            
            return cmd.executeUpdate() > 0;
        }
        catch (SQLException e) {
            System.err.println("Error SQL durante la eliminacion: " + e.getMessage());
            throw new RuntimeException("No se pudo eliminar el registro.", e);
        }
        catch (Exception e) {
            System.err.println("Error inpesperado: " + e.getMessage());
            throw new RuntimeException("Error inesperado al eliminar el registro.", e);
        }
    }

    @Override
    public Paciente buscar(int id) {
        //String sql = "select * from paciente where id = ?";
        String sql = this.generarSQLParaObtenerPorId();
        try (Connection conn = DBManager.getInstance().getConnection();
            PreparedStatement cmd = conn.prepareStatement(sql)) {
            
            cmd.setInt(1, id);
            
            try (ResultSet rs = cmd.executeQuery()) {
                if (!rs.next()) {
                    System.err.println("No se encontro el empleado con id: " + id);
                    return null;
                }

                Paciente paciente = new Paciente();
                paciente.setId(rs.getInt("id"));
                paciente.setTutor(new TutorDAOImpl().buscar(rs.getInt("idTutor")));
                paciente.setNombre(rs.getString("nombre"));
                paciente.setEspecie(rs.getString("especie"));
                paciente.setRaza(rs.getString("raza"));
                paciente.setEdad(rs.getInt("edad"));
                paciente.setEstado(rs.getString("estado"));

                return paciente;
            }
        }
        catch (SQLException e) {
            System.err.println("Error SQL durante la busqueda: " + e.getMessage());
            throw new RuntimeException("No se pudo buscar el registro.", e);
        }
        catch (Exception e) {
            System.err.println("Error inpesperado: " + e.getMessage());
            throw new RuntimeException("Error inesperado al buscar el registro.", e);
        }
    }

    @Override
    public List<Paciente> listar() {
        //String sql = "select * from paciente";
        String sql = this.generarSQLParaListarTodos();
        try (Connection conn = DBManager.getInstance().getConnection();
            PreparedStatement cmd = conn.prepareStatement(sql);
            ResultSet rs = cmd.executeQuery()) {
            
            List<Paciente> pacientes = new ArrayList<>();
            while (rs.next()) {
                Paciente paciente = new Paciente();
                paciente.setId(rs.getInt("id"));
                paciente.setTutor(new TutorDAOImpl().buscar(rs.getInt("idTutor")));
                paciente.setEspecie(rs.getString("especie"));
                paciente.setRaza(rs.getString("raza"));
                paciente.setEdad(rs.getInt("edad"));
                paciente.setEstado(rs.getString("estado"));
                
                pacientes.add(paciente);
            }
            
            return pacientes;
        }
        catch (SQLException e) {
            System.err.println("Error SQL durante el listado: " + e.getMessage());
            throw new RuntimeException("No se pudo listar el registro.", e);
        }
        catch (Exception e) {
            System.err.println("Error inpesperado: " + e.getMessage());
            throw new RuntimeException("Error inesperado al listar los registros.", e);
        }
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException {
        this.statement.setInt(1, this.paciente.getTutor().getId());
        this.statement.setString(2, this.paciente.getNombre());
        this.statement.setString(3, this.paciente.getEspecie());
        this.statement.setString(4, this.paciente.getRaza());
        this.statement.setInt(5, this.paciente.getEdad());
        this.statement.setString(6, this.paciente.getEstado());
    }

    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException {
        this.statement.setInt(1, this.paciente.getTutor().getId());
        this.statement.setString(2, this.paciente.getNombre());
        this.statement.setString(3, this.paciente.getEspecie());
        this.statement.setString(4, this.paciente.getRaza());
        this.statement.setInt(5, this.paciente.getEdad());
        this.statement.setString(6, this.paciente.getEstado());
        this.statement.setInt(7, this.paciente.getId());
    }

    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException {
        this.statement.setInt(1, this.paciente.getId());
    }

    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.paciente.getId());
    }

    @Override
    protected void incluirValorDeParametrosParaListarTodos() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
