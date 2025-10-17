using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using IncidenciasDBManager;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;

namespace TransitSoftPersistance.DAOImpl
{
    public class ConductorDAOImpl : BaseDAOImpl<Conductor>, ConductorDAO
    {

        protected override MySqlCommand CommandoInsertar(MySqlConnection conn, Conductor conductor)
        {
            string sql = @"
                        INSERT INTO EX1_CONDUCTORES (PATERNO, MATERNO, NOMBRES, NUM_LICENCIA, TIPO_LICENCIA_ID, PUNTOS_ACUMULADOS) 
                        VALUES (@Paterno, @Materno, @Nombres, @NumLicencia, @TipoLicenciaId, @PuntosAcumulados);
                        SET @ConductorId = LAST_INSERT_ID();
                    ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Paterno", conductor.Paterno);
            cmd.Parameters.AddWithValue("@Materno", conductor.Materno);
            cmd.Parameters.AddWithValue("@Nombres", conductor.Nombres);
            cmd.Parameters.AddWithValue("@NumLicencia", conductor.NumLicencia);
            cmd.Parameters.AddWithValue("@TipoLicenciaId", conductor.TipoLicencia.TipoLicenciaId);
            cmd.Parameters.AddWithValue("@PuntosAcumulados", conductor.PuntosAcumulados);

            cmd.Parameters.Add("@ConductorId", MySqlDbType.Int32).Direction = ParameterDirection.Output;

            return cmd;

        }
        protected override MySqlCommand CommandoModificar(MySqlConnection conn, Conductor conductor)
        {
            string sql = @"
                                UPDATE EX1_CONDUCTORES 
                                SET 
                                    PATERNO = @Paterno,
                                    MATERNO = @Materno,
                                    NOMBRES = @Nombres,
                                    NUM_LICENCIA = @NumLicencia,
                                    TIPO_LICENCIA_ID = @TipoLicenciaId,
                                    PUNTOS_ACUMULADOS = @PuntosAcumulados
                                WHERE CONDUCTOR_ID = @ConductorId;
                            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ConductorId", conductor.ConductorId);
            cmd.Parameters.AddWithValue("@Paterno", conductor.Paterno);
            cmd.Parameters.AddWithValue("@Materno", conductor.Materno);
            cmd.Parameters.AddWithValue("@Nombres", conductor.Nombres);
            cmd.Parameters.AddWithValue("@NumLicencia", conductor.NumLicencia);
            cmd.Parameters.AddWithValue("@TipoLicenciaId", conductor.TipoLicencia.TipoLicenciaId);
            cmd.Parameters.AddWithValue("@PuntosAcumulados", conductor.PuntosAcumulados);

            return cmd;
        }

        protected override MySqlCommand CommandoEliminar(MySqlConnection conn, int id)
        {
            string sql = @"DELETE FROM EX1_CONDUCTORES WHERE CONDUCTOR_ID = @ConductorId;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ConductorId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoBuscar(MySqlConnection conn, int id)
        {
            string sql = @"
                                SELECT * 
                                FROM EX1_CONDUCTORES
                                WHERE CONDUCTOR_ID = @ConductorId;
                            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ConductorId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoListar(MySqlConnection conn)
        {
            string sql = @"
        SELECT 
            C.CONDUCTOR_ID, 
            C.PATERNO, 
            C.MATERNO, 
            C.NOMBRES, 
            C.NUM_LICENCIA, 
            C.TIPO_LICENCIA_ID, 
            C.PUNTOS_ACUMULADOS,
            TL.NOMBRE AS NOMBRE_LICENCIA,
            TL.DESCRIPCION AS DESCRIPCION_LICENCIA
        FROM EX1_CONDUCTORES C
        LEFT JOIN EX1_TIPOS_LICENCIAS TL ON C.TIPO_LICENCIA_ID = TL.TIPO_LICENCIA_ID;
    ";

            return new MySqlCommand(sql, conn);
        }

        protected override Conductor MapearDesdeReader(MySqlDataReader reader)
        {
            Conductor conductor = new Conductor();

            conductor.ConductorId = reader.GetInt32("CONDUCTOR_ID");

            if (!reader.IsDBNull(reader.GetOrdinal("PATERNO")))
                conductor.Paterno = reader.GetString("PATERNO");

            if (!reader.IsDBNull(reader.GetOrdinal("MATERNO")))
                conductor.Materno = reader.GetString("MATERNO");

            if (!reader.IsDBNull(reader.GetOrdinal("NOMBRES")))
                conductor.Nombres = reader.GetString("NOMBRES");

            if (!reader.IsDBNull(reader.GetOrdinal("NUM_LICENCIA")))
                conductor.NumLicencia = reader.GetString("NUM_LICENCIA");

            // Aseguramos que TipoLicencia no sea null
            if (conductor.TipoLicencia == null)
                conductor.TipoLicencia = new TipoLicencia();

            if (!reader.IsDBNull(reader.GetOrdinal("TIPO_LICENCIA_ID")))
                conductor.TipoLicencia.TipoLicenciaId = reader.GetInt32("TIPO_LICENCIA_ID");

            // Agregamos mapeo del nombre de licencia
            if (!reader.IsDBNull(reader.GetOrdinal("NOMBRE_LICENCIA")))
                conductor.TipoLicencia.Nombre = reader.GetString("NOMBRE_LICENCIA");

            // Agregamos mapeo de descripción si es necesario
            if (!reader.IsDBNull(reader.GetOrdinal("DESCRIPCION_LICENCIA")))
                conductor.TipoLicencia.Descripcion = reader.GetString("DESCRIPCION_LICENCIA");

            if (!reader.IsDBNull(reader.GetOrdinal("PUNTOS_ACUMULADOS")))
                conductor.PuntosAcumulados = reader.GetInt32("PUNTOS_ACUMULADOS");

            return conductor;
        }

        protected override void SetId(Conductor conductor, MySqlCommand cmd)
        {
            if (cmd.Parameters["@ConductorId"].Value != DBNull.Value)
            {
                conductor.ConductorId = Convert.ToInt32(cmd.Parameters["@ConductorId"].Value);
            }
        }

        public List<Conductor> ListarPorNombreLicencia(string nombre_licencia)
        {
            List<Conductor> condutores = new List<Conductor>();

            using (MySqlConnection conn = DBManager.Instance.Connection)
            {
                using (MySqlCommand cmd = new MySqlCommand("CONDUCTOR_LISTAR_X_NOMBRE_LICENCIA", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_busqueda", nombre_licencia);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            condutores.Add(MapearDesdeReader(reader));
                        }
                    }
                }
            }

            return condutores;
        }
    }
}
