using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;

namespace TransitSoftPersistance.DAOImpl
{
    public class ReporteInfraccionDAOImpl : BaseDAOImpl<ReporteInfraccion>, ReporteInfraccionDAO
    {
        public bool agregarRegistroInformacion(ReporteInfraccion reporte)
        {
            throw new NotImplementedException();
        }

        protected override MySqlCommand CommandoBuscar(MySqlConnection conn, int id)
        {
            throw new NotImplementedException();
        }

        protected override MySqlCommand CommandoEliminar(MySqlConnection conn, int id)
        {
            throw new NotImplementedException();
        }

        protected override MySqlCommand CommandoInsertar(MySqlConnection conn, ReporteInfraccion reporte)
        {
            MySqlCommand cmd = new MySqlCommand("INSERTAR_REGISTRO_INFRACCION", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@_REPORTE_ID", MySqlDbType.Int32).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@_CONDUCTOR_ID", reporte.ConductorId);
            cmd.Parameters.AddWithValue("@_PATERNO", reporte.Paterno    );
            cmd.Parameters.AddWithValue("@_MATERNO", reporte.Materno);
            cmd.Parameters.AddWithValue("@_NOMBRES", reporte.Nombres);
            cmd.Parameters.AddWithValue("@_VEHICULO_ID", reporte.VehiculoId);
            cmd.Parameters.AddWithValue("@_PLACA", reporte.Placa);
            cmd.Parameters.AddWithValue("@_MARCA", reporte.Marca);
            cmd.Parameters.AddWithValue("@_MODELO", reporte.Modelo);
            cmd.Parameters.AddWithValue("@_ANHO", reporte.Anho);
            cmd.Parameters.AddWithValue("@_INFRACCION_ID", reporte.InfraccionId);
            cmd.Parameters.AddWithValue("@_DESCRIPCION", reporte.Descripcion);
            cmd.Parameters.AddWithValue("@_MONTO", reporte.Monto);
            cmd.Parameters.AddWithValue("@_GRAVEDAD", reporte.Gravedad.ToString());
   
            return cmd;
        }

        protected override MySqlCommand CommandoListar(MySqlConnection conn)
        {
            throw new NotImplementedException();
        }

        protected override MySqlCommand CommandoModificar(MySqlConnection conn, ReporteInfraccion modelo)
        {
            throw new NotImplementedException();
        }

        protected override ReporteInfraccion MapearDesdeReader(MySqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        protected override void SetId(ReporteInfraccion modelo, MySqlCommand cmd)
        {
            if (cmd.Parameters["@_REPORTE_ID"].Value != DBNull.Value)
            {
                modelo.ReporteId = Convert.ToInt32(cmd.Parameters["@_REPORTE_ID"].Value);
            }
        }
    }
}
