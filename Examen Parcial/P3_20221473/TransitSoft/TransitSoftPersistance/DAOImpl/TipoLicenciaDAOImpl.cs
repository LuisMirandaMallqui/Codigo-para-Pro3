using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;
using MySql.Data.MySqlClient;

namespace TransitSoftPersistance.DAOImpl
{
    public class TipoLicenciaDAOImpl : BaseDAOImpl<TipoLicencia>, TipoLicenciaDAO
    {
        protected override MySqlCommand CommandoInsertar(MySqlConnection conn, TipoLicencia tipoLicencia)
        {
            string sql = @"
                    INSERT INTO EX1_TIPOS_LICENCIAS (TIPO_LICENCIA_ID, NOMBRE, DESCRIPCION) 
                    VALUES (@TipoLicenciaId, @Nombre, @Descripcion);
                ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TipoLicenciaId", tipoLicencia.TipoLicenciaId);
            cmd.Parameters.AddWithValue("@Nombre", tipoLicencia.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", tipoLicencia.Descripcion);

            return cmd;
        }


        protected override MySqlCommand CommandoModificar(MySqlConnection conn, TipoLicencia tipoLicencia)
        {
            string sql = @"
                    UPDATE EX1_TIPOS_LICENCIAS
                    SET 
                        NOMBRE = @Nombre,
                        DESCRIPCION = @Descripcion
                    WHERE TIPO_LICENCIA_ID = @TipoLicenciaId;
                ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@TipoLicenciaId", tipoLicencia.TipoLicenciaId);
            cmd.Parameters.AddWithValue("@Nombre", tipoLicencia.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", tipoLicencia.Descripcion);

            return cmd;
        }

        protected override MySqlCommand CommandoEliminar(MySqlConnection conn, int id)
        {
            string sql = @"DELETE FROM EX1_TIPOS_LICENCIAS WHERE TIPO_LICENCIA_ID = @TipoLicenciaId;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TipoLicenciaId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoBuscar(MySqlConnection conn, int id)
        {
            string sql = @"
                    SELECT * 
                    FROM EX1_TIPOS_LICENCIAS
                    WHERE TIPO_LICENCIA_ID = @TipoLicenciaId;
                ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TipoLicenciaId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoListar(MySqlConnection conn)
        {
            string sql = @"SELECT * FROM EX1_TIPOS_LICENCIAS;";

            return new MySqlCommand(sql, conn);
        }

        protected override TipoLicencia MapearDesdeReader(MySqlDataReader reader)
        {
            TipoLicencia tipoLicencia = new TipoLicencia();

            tipoLicencia.TipoLicenciaId = reader.GetInt32("TIPO_LICENCIA_ID");

            if (!reader.IsDBNull(reader.GetOrdinal("NOMBRE")))
                tipoLicencia.Nombre = reader.GetString("NOMBRE");

            if (!reader.IsDBNull(reader.GetOrdinal("DESCRIPCION")))
                tipoLicencia.Descripcion = reader.GetString("DESCRIPCION");

            return tipoLicencia;
        }

        protected override void SetId(TipoLicencia tipoLicencia, MySqlCommand cmd)
        {
            if (cmd.Parameters["@TipoLicenciaId"].Value != DBNull.Value)
            {
                tipoLicencia.TipoLicenciaId = Convert.ToInt32(cmd.Parameters["@TipoLicenciaId"].Value);
            }
        }

    }
}
