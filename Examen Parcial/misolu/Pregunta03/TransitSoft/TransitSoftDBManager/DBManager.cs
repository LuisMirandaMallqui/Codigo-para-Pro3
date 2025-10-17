using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace IncidenciasDBManager
{
    public class DBManager
    {
        private static DBManager instance;
        private static readonly object padlock = new object();
        private string connectionString;

        private DBManager()
        {
            try
            {
                // Obtener configuración de base de datos
                NameValueCollection dbSettings =
                    (NameValueCollection)ConfigurationManager.GetSection("databaseSettings");

                // Decodificar la contraseña desde Base64
                string passwordBase64 = dbSettings["password"];
                string decodedPassword = Encoding.UTF8.GetString(
                    Convert.FromBase64String(passwordBase64));

                // Construir cadena de conexión con la contraseña decodificada
                connectionString = $"server={dbSettings["host"]};" +
                                   $"port={dbSettings["port"]};" +
                                   $"database={dbSettings["database"]};" +
                                   $"user={dbSettings["user"]};" +
                                   $"password={decodedPassword};" + // Usar contraseña decodificada
                                   $"Pooling=true;" +
                                   $"Min Pool Size={dbSettings["minPoolSize"]};" +
                                   $"Max Pool Size={dbSettings["maxPoolSize"]};" +
                                   $"Connection Timeout={dbSettings["connectionTimeout"]};";
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("La contraseña no está correctamente codificada en Base64", ex);
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new InvalidOperationException("Error al leer la configuración de la base de datos", ex);
            }
        }

        public MySqlConnection Connection
        {
            get
            {
                // Crear una nueva conexión cada vez que se acceda a esta propiedad
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                return conn;
            }
        }

        public static DBManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBManager();
                    }
                }
                return instance;
            }
        }
    }
}