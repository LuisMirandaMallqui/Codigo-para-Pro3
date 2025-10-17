package pe.edu.pucp.softinv.proyectostrategy.estrategia;

import java.util.List;
import pe.edu.pucp.softinv.proyectostrategy.modelo.VehiculoConductor;
import pe.edu.pucp.softinv.proyectostrategy.modelo.RegistroInfraccion;

public class Estrategia2 implements Estrategia{
    
    @Override
    public int calcularPuntos(VehiculoConductor vc, List<RegistroInfraccion> registros){
        int puntos = 0;
        for(RegistroInfraccion r: registros){
            if(r.getVehiculo().equals(vc.getVehiculo()) &&
               r.getFecha().after(vc.getFechaAdquisicion())){
                puntos += r.getInfraccion().getPuntos();
            }
        }
        return puntos;
    }
}