package pe.edu.pucp.transitsoft.model;

public class VehiculoPropietario {
    private Integer id;
    private Vehiculo vehiculo;
    private Propietario propietario;

    public VehiculoPropietario() {
    }

    public VehiculoPropietario(Integer id, Vehiculo vehiculo, Propietario propietario) {
        this.id = id;
        this.vehiculo = vehiculo;
        this.propietario = propietario;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
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
}
