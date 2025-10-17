package pe.edu.pucp.softinv.proyectostrategy.estrategia;

import java.util.List;
import pe.edu.pucp.softinv.proyectostrategy.modelo.RegistroInfraccion;
import pe.edu.pucp.softinv.proyectostrategy.modelo.VehiculoConductor;

public interface Estrategia {
    int calcularPuntos(VehiculoConductor vc,List<RegistroInfraccion> registros);
}