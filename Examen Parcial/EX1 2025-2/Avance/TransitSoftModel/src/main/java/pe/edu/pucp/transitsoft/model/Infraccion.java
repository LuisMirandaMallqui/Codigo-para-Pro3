package pe.edu.pucp.transitsoft.model;

import java.util.Date;

public class Infraccion {
    private Integer id;
    private Double limite;
    private Double exceso;
    private Vehiculo vehiculo;
    private Propietario propietario;
    private Camara camara;
    private Captura captura;
    private Double monto;
    private Date fecha_registro;

    public Infraccion() {
    }

    public Infraccion(Integer id, Double limite, Double exceso, Vehiculo vehiculo, Propietario propietario, Camara camara, Captura captura, Double monto, Date fecha_registro) {
        this.id = id;
        this.limite = limite;
        this.exceso = exceso;
        this.vehiculo = vehiculo;
        this.propietario = propietario;
        this.camara = camara;
        this.captura = captura;
        this.monto = monto;
        this.fecha_registro = fecha_registro;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Double getLimite() {
        return limite;
    }

    public void setLimite(Double limite) {
        this.limite = limite;
    }

    public Double getExceso() {
        return exceso;
    }

    public void setExceso(Double exceso) {
        this.exceso = exceso;
    }

    public Vehiculo getVehiculo() {
        return vehiculo;
    }

    public void setVehiculo(Vehiculo vehiculo) {
        this.vehiculo = vehiculo;
    }

    public Propietario getPropietario() {
        return propietario;
    }

    public void setPropietario(Propietario propietario) {
        this.propietario = propietario;
    }

    public Camara getCamara() {
        return camara;
    }

    public void setCamara(Camara camara) {
        this.camara = camara;
    }

    public Captura getCaptura() {
        return captura;
    }

    public void setCaptura(Captura captura) {
        this.captura = captura;
    }

    public Double getMonto() {
        return monto;
    }

    public void setMonto(Double monto) {
        this.monto = monto;
    }

    public Date getFecha_registro() {
        return fecha_registro;
    }

    public void setFecha_registro(Date fecha_registro) {
        this.fecha_registro = fecha_registro;
    }
}
