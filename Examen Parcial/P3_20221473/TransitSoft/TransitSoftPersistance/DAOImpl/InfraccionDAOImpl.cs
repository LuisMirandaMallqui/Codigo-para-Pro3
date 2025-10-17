using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidenciasDBManager;
using TransitSoftDomain;
using TransitSoftPersistance.DAO;
using MySql.Data.MySqlClient;

namespace TransitSoftPersistance.DAOImpl
{
    public class InfraccionDAOImpl : BaseDAOImpl<Infraccion>, InfraccionDAO
    {
        public bool Existe(int idInfraccion)
        {
            using (MySqlConnection conn = DBManager.Instance.Connection)
            {
                string sql = "SELECT COUNT(1) FROM EX1_INFRACCIONES WHERE INFRACCION_ID = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idInfraccion);
                    object result = cmd.ExecuteScalar();
                    int count = Convert.ToInt32(result);
                    return count > 0;
                }
            }
        }

        protected override MySqlCommand CommandoInsertar(MySqlConnection conn, Infraccion infraccion)
        {
            string sql = @"
        INSERT INTO EX1_INFRACCIONES (INFRACCION_ID, DESCRIPCION, MONTO_MULTA, GRAVEDAD, PUNTOS) 
        VALUES (@InfraccionId, @Descripcion, @MontoMulta, @Gravedad, @Puntos);
    ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@InfraccionId", infraccion.InfraccionId); // Ahora se asigna manualmente
            cmd.Parameters.AddWithValue("@Descripcion", infraccion.Descripcion);
            cmd.Parameters.AddWithValue("@MontoMulta", infraccion.MontoMulta);
            cmd.Parameters.AddWithValue("@Gravedad", infraccion.Gravedad.ToString());
            cmd.Parameters.AddWithValue("@Puntos", infraccion.Puntos);

            return cmd;
        }

        protected override MySqlCommand CommandoModificar(MySqlConnection conn, Infraccion infraccion)
        {
            string sql = @"
                UPDATE EX1_INFRACCIONES
                SET 
                    DESCRIPCION = @Descripcion,
                    MONTO_MULTA = @MontoMulta,
                    GRAVEDAD = @Gravedad,
                    PUNTOS = @Puntos
                WHERE INFRACCION_ID = @InfraccionId;
            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@InfraccionId", infraccion.InfraccionId);
            cmd.Parameters.AddWithValue("@Descripcion", infraccion.Descripcion);
            cmd.Parameters.AddWithValue("@MontoMulta", infraccion.MontoMulta);
            cmd.Parameters.AddWithValue("@Gravedad", infraccion.Gravedad.ToString());
            cmd.Parameters.AddWithValue("@Puntos", infraccion.Puntos);

            return cmd;
        }

        protected override MySqlCommand CommandoEliminar(MySqlConnection conn, int id)
        {
            string sql = @"DELETE FROM EX1_INFRACCIONES WHERE INFRACCION_ID = @InfraccionId;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@InfraccionId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoBuscar(MySqlConnection conn, int id)
        {
            string sql = @"
                SELECT * 
                FROM EX1_INFRACCIONES
                WHERE INFRACCION_ID = @InfraccionId;
            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@InfraccionId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoListar(MySqlConnection conn)
        {
            string sql = @"SELECT * FROM EX1_INFRACCIONES;";

            return new MySqlCommand(sql, conn);
        }

        protected override Infraccion MapearDesdeReader(MySqlDataReader reader)
        {
            Infraccion infraccion = new Infraccion();

            infraccion.InfraccionId = reader.GetInt32("INFRACCION_ID");

            if (!reader.IsDBNull(reader.GetOrdinal("DESCRIPCION")))
                infraccion.Descripcion = reader.GetString("DESCRIPCION");

            if (!reader.IsDBNull(reader.GetOrdinal("MONTO_MULTA")))
                infraccion.MontoMulta = reader.GetDecimal("MONTO_MULTA");

            if (!reader.IsDBNull(reader.GetOrdinal("GRAVEDAD")))
            {
                string gravedadStr = reader.GetString("GRAVEDAD");
                if (Enum.TryParse(gravedadStr, out Gravedad gravedad))
                    infraccion.Gravedad = gravedad;
                else
                    infraccion.Gravedad = Gravedad.LEVE; // valor por defecto si no se reconoce
            }

            if (!reader.IsDBNull(reader.GetOrdinal("PUNTOS")))
                infraccion.Puntos = reader.GetInt32("PUNTOS");

            return infraccion;
        }

        protected override void SetId(Infraccion infraccion, MySqlCommand cmd)
        {
            if (cmd.Parameters["@InfraccionId"].Value != DBNull.Value)
            {
                infraccion.InfraccionId = Convert.ToInt32(cmd.Parameters["@InfraccionId"].Value);
            }
        }
    }
}
