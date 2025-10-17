package pe.edu.pucp.softinv.proyectostrategy.estrategia;

import java.util.List;
import pe.edu.pucp.softinv.proyectostrategy.modelo.VehiculoConductor;
import pe.edu.pucp.softinv.proyectostrategy.modelo.RegistroInfraccion;

public class Estrategia3 implements Estrategia{
    
    @Override
    public int calcularPuntos(VehiculoConductor vc, List<RegistroInfraccion> registros){
        Estrategia base = new Estrategia2();
        int puntos = base.calcularPuntos(vc, registros);
        return puntos / 2;
    }
}
