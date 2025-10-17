using IncidenciasDBManager;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransitSoftPersistance
{
    public abstract class BaseDAOImpl<T> : BaseDAO<T>
    {
        protected abstract MySqlCommand CommandoInsertar(MySqlConnection conn, T modelo);
        protected abstract MySqlCommand CommandoModificar(MySqlConnection conn, T modelo);
        protected abstract MySqlCommand CommandoEliminar(MySqlConnection conn, int id);
        protected abstract MySqlCommand CommandoBuscar(MySqlConnection conn, int id);
        protected abstract MySqlCommand CommandoListar(MySqlConnection conn);
        protected abstract T MapearDesdeReader(MySqlDataReader reader);
        protected abstract void SetId(T modelo, MySqlCommand cmd);

        public virtual bool Agregar(T modelo)
        {
            try
            {
                bool ejecutado = false;
                using (MySqlConnection conn = DBManager.Instance.Connection)
                using (MySqlCommand cmd = CommandoInsertar(conn, modelo))
                {
                    ejecutado = cmd.ExecuteNonQuery() > 0;
                    if (ejecutado)
                    {
                        // Asignar el ID generado al modelo
                        SetId(modelo, cmd);
                    }
                }
                return ejecutado;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("No se pudo insertar el registro.", e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error inesperado al insertar el registro.", e);
            }
        }

        public bool Actualizar(T modelo)
        {
            try
            {
                bool ejecutado = false;
                using (MySqlConnection conn = DBManager.Instance.Connection)
                using (MySqlCommand cmd = this.CommandoModificar(conn, modelo))
                {
                    ejecutado = cmd.ExecuteNonQuery() > 0;
                }
                return ejecutado;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("No se pudo modificar el registro.", e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error inesperado al modificar el registro.", e);
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                bool ejecutado = false;
                using (MySqlConnection conn = DBManager.Instance.Connection)
                using (MySqlCommand cmd = this.CommandoEliminar(conn, id))
                {
                    ejecutado = cmd.ExecuteNonQuery() > 0;
                }
                return ejecutado;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("No se pudo eliminar el registro.", e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error inesperado al eliminar el registro.", e);
            }
        }

        public T Obtener(int id)
        {
            try
            {
                T modelo = default;
                using (MySqlConnection conn = DBManager.Instance.Connection)
                using (MySqlCommand cmd = this.CommandoBuscar(conn, id))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.Error.WriteLine("No se encontro el registro con id: " + id);
                    }
                    else
                    {
                        reader.Read();
                        modelo = MapearDesdeReader(reader);
                    }
                }
                return modelo;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("No se pudo buscar el registro.", e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error inesperado al buscar el registro.", e);
            }
        }

        public List<T> ListarTodos()
        {
            try
            {
                List<T> modelos = new List<T>();
                using (MySqlConnection conn = DBManager.Instance.Connection)
                using (MySqlCommand cmd = this.CommandoListar(conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        modelos.Add(MapearDesdeReader(reader));
                    }
                }
                return modelos;
            }
            catch (SqlException e)
            {
                throw new InvalidOperationException("No se pudo buscar el registro.", e);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Error inesperado al buscar el registro.", e);
            }
        }

    }
}
