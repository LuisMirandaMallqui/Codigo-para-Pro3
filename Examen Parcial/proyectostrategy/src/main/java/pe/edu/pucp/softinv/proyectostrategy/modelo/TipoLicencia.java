package pe.edu.pucp.softinv.proyectostrategy.modelo;

public class TipoLicencia {
    private Integer tipoLicenciaId;
    private String nombre;
    private String descripcion;

    public Integer getTipoLicenciaId() {
        return tipoLicenciaId;
    }

    public void setTipoLicenciaId(Integer tipoLicenciaId) {
        this.tipoLicenciaId = tipoLicenciaId;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    
    
}
