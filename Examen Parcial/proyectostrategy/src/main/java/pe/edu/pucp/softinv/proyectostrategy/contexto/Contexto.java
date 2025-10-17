package pe.edu.pucp.softinv.proyectostrategy.contexto;

import java.util.List;
import pe.edu.pucp.softinv.proyectostrategy.estrategia.Estrategia;
import pe.edu.pucp.softinv.proyectostrategy.modelo.RegistroInfraccion;
import pe.edu.pucp.softinv.proyectostrategy.modelo.VehiculoConductor;

public class Contexto {
    private Estrategia estrategia;

    public Contexto(Estrategia estrategia) {
        this.estrategia = estrategia;
    }

    public void setEstrategia(Estrategia estrategia) {
        this.estrategia = estrategia;
    }
    
    public int calcularPuntos(VehiculoConductor vc, List<RegistroInfraccion> registros){
        if(estrategia == null){
            throw new IllegalStateException("No hay estrategia definida");
        }
        return estrategia.calcularPuntos(vc, registros);
    }
}
