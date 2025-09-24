package pe.com.citasvet.config;

public class CadenaConexionBuilder {
    private String host;
    private int puerto;
    private String esquema;
    private boolean useSSL = false;
    private boolean allowPublicKeyRetrieval = true;

    public CadenaConexionBuilder setHost(String host) {
        this.host = host;
        return this;
    }

    public CadenaConexionBuilder setPuerto(int puerto) {
        this.puerto = puerto;
        return this;
    }

    public CadenaConexionBuilder setEsquema(String esquema) {
        this.esquema = esquema;
        return this;
    }
    
    public String build(){
        StringBuilder sb = new StringBuilder();
        sb.append("jdbc:mysql://")
          .append(host).append(":")
          .append(puerto).append("/")
          .append(esquema)
          .append("?useSSL=").append(useSSL)
          .append("&allowPublicKeyRetrieval=").append(allowPublicKeyRetrieval);
        return sb.toString();
    }
}
