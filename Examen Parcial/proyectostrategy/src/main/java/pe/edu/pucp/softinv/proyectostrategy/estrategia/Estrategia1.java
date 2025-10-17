package pe.edu.pucp.softinv.proyectostrategy.estrategia;

import java.util.List;
import pe.edu.pucp.softinv.proyectostrategy.modelo.VehiculoConductor;
import pe.edu.pucp.softinv.proyectostrategy.modelo.RegistroInfraccion;

public class Estrategia1 implements Estrategia{
    
    @Override
    public int calcularPuntos(VehiculoConductor vc, List<RegistroInfraccion> registros){
        int puntos = 0;
        for(RegistroInfraccion r: registros){
            if(r.getVehiculo().equals(vc.getVehiculo())){
                puntos += r.getInfraccion().getPuntos();
            }
        }
        return puntos;
    }
}
