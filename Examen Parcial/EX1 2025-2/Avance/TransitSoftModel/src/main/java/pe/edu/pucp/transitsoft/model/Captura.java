package pe.edu.pucp.transitsoft.model;

import java.util.Date;

public class Captura {
    private Integer id;
    private Camara camara;
    private Vehiculo vehiculo;
    private Double velocidad;
    private Date fechaCaptura;
    private String estado;

    public Captura() {
    }

    public Captura(Integer id, Camara camara, Vehiculo vehiculo, Double velocidad, Date fechaCaptura, String estado) {
        this.id = id;
        this.camara = camara;
        this.vehiculo = vehiculo;
        this.velocidad = velocidad;
        this.fechaCaptura = fechaCaptura;
        this.estado = estado;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Camara getCamara() {
        return camara;
    }

    public void setCamara(Camara camara) {
        this.camara = camara;
    }

    public Vehiculo getVehiculo() {
        return vehiculo;
    }

    public void setVehiculo(Vehiculo vehiculo) {
        this.vehiculo = vehiculo;
    }

    public Double getVelocidad() {
        return velocidad;
    }

    public void setVelocidad(Double velocidad) {
        this.velocidad = velocidad;
    }

    public Date getFechaCaptura() {
        return fechaCaptura;
    }

    public void setFechaCaptura(Date fechaCaptura) {
        this.fechaCaptura = fechaCaptura;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }
}
