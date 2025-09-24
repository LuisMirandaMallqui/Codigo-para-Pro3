package pe.com.citasvet.daoimpl;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import pe.com.citasvet.config.DBManager;
import pe.com.citasvet.daoimpl.util.Columna;
import pe.com.citasvet.daoimpl.util.Tipo_Operacion;

public abstract class BaseDAOImpl {
    
    protected String nombre_tabla;
    protected ArrayList<Columna> listaColumnas;
    protected Boolean retornarLlavePrimaria;
    protected Connection conexion;
    protected PreparedStatement statement;
    protected ResultSet resultSet;
    
    public BaseDAOImpl(String nombre_tabla){
        this.nombre_tabla = nombre_tabla;
        this.retornarLlavePrimaria = false;
        this.incluirListaDeColumnas();
    }
    
    private void incluirListaDeColumnas(){
        this.listaColumnas = new ArrayList<>();
        this.configurarListaDeColumnas();
    }
    
    protected abstract void configurarListaDeColumnas();

    private Integer ejecutar_DML(Tipo_Operacion tipo_operacion){
        Integer resultado = 0;
        try {
            String sql = null;
            switch(tipo_operacion){
                case INSERTAR:
                    sql = this.generarSQLParaInsercion();
                    break;
                case MODIFICAR:
                    sql = this.generarSQLParaModificacion();
                    break;
                case ELIMINAR:
                    sql = this.generarSQLParaEliminacion();
                    break;
                case BUSCAR:
                    sql = this.generarSQLParaObtenerPorId();
                    break;
                case LISTAR:
                    sql = this.generarSQLParaListarTodos();
                    break;
            }
            try {
                conexion = DBManager.getInstance().getConnection();
                statement = conexion.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                
                switch(tipo_operacion){
                    case INSERTAR:
                        this.incluirValorDeParametrosParaInsercion();
                        break;
                    case MODIFICAR:
                        this.incluirValorDeParametrosParaModificacion();
                        break;
                    case ELIMINAR:
                        this.incluirValorDeParametrosParaEliminacion();
                        break;
                    case BUSCAR:
                        this.incluirValorDeParametrosParaObtenerPorId();
                        break;
                    case LISTAR:
                        this.incluirValorDeParametrosParaListarTodos();
                        break;
                }

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
        return resultado;
    }
    
    //Generar SQL para Insercion
    protected String generarSQLParaInsercion(){
        String sql = "INSERT INTO";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat("(");
        //Conseguir las columnas
        String sql_columnas = "";
        String sql_parametros = "";
        for(Columna columna: this.listaColumnas){
            if(!columna.getEsAutoGenerado()){
                if(!sql_columnas.isBlank()){
                    sql_columnas = sql_columnas.concat(", ");
                    sql_parametros = sql_parametros.concat(", ");
                }
                sql_columnas = sql_columnas.concat(columna.getNombre());
                sql_parametros = sql_parametros.concat("?");
            }
        }
        //Agregar columnas y parametros
        sql = sql.concat(sql_columnas);
        sql = sql.concat(") VALUES (");
        sql = sql.concat(sql_parametros);
        sql = sql.concat(")");
        
        return sql;
    }
    
    //Generar SQL para Modificar
    protected String generarSQLParaModificacion() {
        //sentencia SQL a generar es similar a 
        //UPDATE INV_ALMACENES SET NOMBRE=?, ALMACEN_CENTRAL=? WHERE ALMACEN_ID=?
        String sql = "UPDATE ";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" SET ");
        String sql_columnas = "";
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsLlavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    //no está probado
                    sql_predicado = sql_predicado.concat(" AND ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            } else {
                if (!sql_columnas.isBlank()) {
                    sql_columnas = sql_columnas.concat(", ");
                }
                sql_columnas = sql_columnas.concat(columna.getNombre());
                sql_columnas = sql_columnas.concat("=?");
            }
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" WHERE ");
        sql = sql.concat(sql_predicado);
        return sql;
    }

    //Generar SQL para Eliminacion
    protected String generarSQLParaEliminacion() {
        //sentencia SQL a generar es similar a 
        //DELETE FROM INV_ALMACENES WHERE ALMACEN_ID=?
        String sql = "DELETE FROM ";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" WHERE ");
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsLlavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    sql_predicado = sql_predicado.concat(", ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            }
        }
        sql = sql.concat(sql_predicado);
        return sql;
    }

    //Generar SQL para Obtener por id
    protected String generarSQLParaObtenerPorId() {
        //sentencia SQL a generar es similar a 
        //SELECT ALMACEN_ID, NOMBRE, ALMACEN_CENTRAL FROM INV_ALMACENES WHERE ALMACEN_ID = ?
        String sql = "SELECT ";
        String sql_columnas = "";
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsLlavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    sql_predicado = sql_predicado.concat(", ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            }
            if (!sql_columnas.isBlank()) {
                sql_columnas = sql_columnas.concat(", ");
            }
            sql_columnas = sql_columnas.concat(columna.getNombre());
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" FROM ");
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" WHERE ");
        sql = sql.concat(sql_predicado);
        return sql;
    }

    //Generar SQL para listar todos
    protected String generarSQLParaListarTodos() {
        //sentencia SQL a generar es similar a 
        //SELECT ALMACEN_ID, NOMBRE, ALMACEN_CENTRAL FROM INV_ALMACENES
        String sql = "SELECT ";
        String sql_columnas = "";
        for (Columna columna : this.listaColumnas) {
            if (!sql_columnas.isBlank()) {
                sql_columnas = sql_columnas.concat(", ");
            }
            sql_columnas = sql_columnas.concat(columna.getNombre());
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" FROM ");
        sql = sql.concat(this.nombre_tabla);
        return sql;
    }

    protected void incluirValorDeParametrosParaInsercion() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }

    protected void incluirValorDeParametrosParaModificacion() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }

    protected void incluirValorDeParametrosParaEliminacion() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }

    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }

    protected void incluirValorDeParametrosParaListarTodos() throws SQLException {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}
