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
    public class VehiculoDAOImpl : BaseDAOImpl<Vehiculo>, VehiculoDAO
    {
        protected override MySqlCommand CommandoInsertar(MySqlConnection conn, Vehiculo vehiculo)
        {
            string sql = @"
        INSERT INTO EX1_VEHICULOS (PLACA, MARCA, MODELO, ANHO) 
        VALUES (@Placa, @Marca, @Modelo, @Anho);
        SET @VehiculoId = LAST_INSERT_ID();  -- Captura el último ID insertado
    ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            // Parámetros para insertar el vehículo
            cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
            cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
            cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            cmd.Parameters.AddWithValue("@Anho", vehiculo.Anho);

            // Parámetro para recuperar el ID del vehículo insertado
            cmd.Parameters.Add("@VehiculoId", MySqlDbType.Int32).Direction = ParameterDirection.Output;

            return cmd;
        }

        protected override MySqlCommand CommandoModificar(MySqlConnection conn, Vehiculo vehiculo)
        {
            string sql = @"
                UPDATE EX1_VEHICULOS
                SET 
                    PLACA = @Placa,
                    MARCA = @Marca,
                    MODELO = @Modelo,
                    ANHO = @Anho
                WHERE VEHICULO_ID = @VehiculoId;
            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@VehiculoId", vehiculo.VehiculoId);
            cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
            cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
            cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
            cmd.Parameters.AddWithValue("@Anho", vehiculo.Anho);

            return cmd;
        }

        protected override MySqlCommand CommandoEliminar(MySqlConnection conn, int id)
        {
            string sql = @"DELETE FROM EX1_VEHICULOS WHERE VEHICULO_ID = @VehiculoId;";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@VehiculoId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoBuscar(MySqlConnection conn, int id)
        {
            string sql = @"
                SELECT * 
                FROM EX1_VEHICULOS
                WHERE VEHICULO_ID = @VehiculoId;
            ";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@VehiculoId", id);

            return cmd;
        }

        protected override MySqlCommand CommandoListar(MySqlConnection conn)
        {
            string sql = @"SELECT VEHICULO_ID,PLACA,MARCA,MODELO,ANHO FROM EX1_VEHICULOS;";

            return new MySqlCommand(sql, conn);
        }

        protected override Vehiculo MapearDesdeReader(MySqlDataReader reader)
        {
            Vehiculo vehiculo = new Vehiculo();

            vehiculo.VehiculoId = reader.GetInt32("VEHICULO_ID");

            if (!reader.IsDBNull(reader.GetOrdinal("PLACA")))
                vehiculo.Placa = reader.GetString("PLACA");

            if (!reader.IsDBNull(reader.GetOrdinal("MARCA")))
                vehiculo.Marca = reader.GetString("MARCA");

            if (!reader.IsDBNull(reader.GetOrdinal("MODELO")))
                vehiculo.Modelo = reader.GetString("MODELO");

            if (!reader.IsDBNull(reader.GetOrdinal("ANHO")))
                vehiculo.Anho = reader.GetInt32("ANHO");

            return vehiculo;
        }

        protected override void SetId(Vehiculo vehiculo, MySqlCommand cmd)
        {
            if (cmd.Parameters["@VehiculoId"].Value != DBNull.Value)
            {
                vehiculo.VehiculoId = Convert.ToInt32(cmd.Parameters["@VehiculoId"].Value);
            }
        }

        public List<Vehiculo> ListarPorMarcaModelo(string marca_modelo)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            using (MySqlConnection conn = DBManager.Instance.Connection)
            {
                using (MySqlCommand cmd = new MySqlCommand("VEHICULO_LISTAR_X_MARCA_MODELO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_busqueda", marca_modelo ?? "");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*Vehiculo vehiculo = new Vehiculo
                            {
                                VehiculoId = reader.GetInt32("VEHICULO_ID"),
                                Placa = reader.GetString("PLACA"),
                                Marca = reader.GetString("MARCA"),
                                Modelo = reader.GetString("MODELO"),
                                Anho = reader.GetInt32("ANHO")
                            };*/
                            listaVehiculos.Add(MapearDesdeReader(reader));
                        }
                    }
                }
            }

            return listaVehiculos;
        }

        public List<string> ObtenerMarcas()
        {
            List<string> marcas = new List<string>();

            string query = "SELECT DISTINCT MARCA FROM EX1_VEHICULOS ORDER BY MARCA;";

            using (MySqlConnection conn = DBManager.Instance.Connection)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marcas.Add(reader.GetString("MARCA"));
                        }
                    }
                }
            }

            return marcas;
        }

    }
}
