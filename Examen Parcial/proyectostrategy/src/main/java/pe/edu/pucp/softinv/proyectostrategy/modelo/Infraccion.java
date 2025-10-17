package pe.edu.pucp.softinv.proyectostrategy.modelo;

public class Infraccion {
    private Integer infraccionId;
    private String descripcion;
    private Double montoMulta;
    private Gravedad gravedad;
    private Integer puntos;

    public Integer getInfraccionId() {
        return infraccionId;
    }

    public void setInfraccionId(Integer infraccionId) {
        this.infraccionId = infraccionId;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public Double getMontoMulta() {
        return montoMulta;
    }

    public void setMontoMulta(Double montoMulta) {
        this.montoMulta = montoMulta;
    }

    public Gravedad getGravedad() {
        return gravedad;
    }

    public void setGravedad(Gravedad gravedad) {
        this.gravedad = gravedad;
    }

    public Integer getPuntos() {
        return puntos;
    }

    public void setPuntos(Integer puntos) {
        this.puntos = puntos;
    }
}
