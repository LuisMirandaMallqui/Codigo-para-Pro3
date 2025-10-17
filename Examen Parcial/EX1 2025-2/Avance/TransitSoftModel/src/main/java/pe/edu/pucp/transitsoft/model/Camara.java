package pe.edu.pucp.transitsoft.model;

public class Camara {
    private Integer id;
    private String modelo;
    private String codigoSerie;
    private Integer latitud;
    private Integer longitud;

    public Camara() {
    }

    public Camara(Integer id, String modelo, String codigoSerie, Integer latitud, Integer longitud) {
        this.id = id;
        this.modelo = modelo;
        this.codigoSerie = codigoSerie;
        this.latitud = latitud;
        this.longitud = longitud;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getModelo() {
        return modelo;
    }

    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    public String getCodigoSerie() {
        return codigoSerie;
    }

    public void setCodigoSerie(String codigoSerie) {
        this.codigoSerie = codigoSerie;
    }

    public Integer getLatitud() {
        return latitud;
    }

    public void setLatitud(Integer latitud) {
        this.latitud = latitud;
    }

    public Integer getLongitud() {
        return longitud;
    }

    public void setLongitud(Integer longitud) {
        this.longitud = longitud;
    }
}
