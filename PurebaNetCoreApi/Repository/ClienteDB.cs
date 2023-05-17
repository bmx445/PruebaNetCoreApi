using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using PurebaNetCoreApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PurebaNetCoreApi.Repository
{
    public class ClienteDB
    {
        private string connectionString = "Data Source=.;initial Catalog=Registros;Integrated Security = True";

        public List<Cliente> Get()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "select * from Usuarios order by Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();

                    cliente.id = reader.GetInt32(0);
                    cliente.nombre = reader.GetString(1);
                    cliente.apellido = reader.GetString(2);
                    cliente.edad = reader.GetInt32(3);
                    cliente.correo = reader.GetString(4);
                    clientes.Add(cliente);
                }
                reader.Close();
                connection.Close();
            }
            return clientes;
        }
        public Cliente GetById(int _id)
        {
            string query = $"select * from Usuarios where id ={_id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                Cliente cliente = new Cliente();
                while (reader.Read())
                {
                    cliente.id = reader.GetInt32(0);
                    cliente.nombre = reader.GetString(1);
                    cliente.apellido = reader.GetString(2);
                    cliente.edad = reader.GetInt32(3);
                    cliente.correo = reader.GetString(4);
                }
                reader.Close();
                connection.Close();

                return cliente;
            }
        }
        public Cliente AddCliente(Cliente _cliente)
        {
            string query = $"INSERT INTO Usuarios (Nombre, Apellido ,Edad ,Correo) Values('{_cliente.nombre}','{_cliente.apellido}','{_cliente.edad}','{_cliente.correo}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Cliente cliente = new Cliente();
                while (reader.Read())
                {
                    cliente.nombre = reader.GetString(0);
                    cliente.apellido = reader.GetString(1);
                    cliente.edad = reader.GetInt32(2);
                    cliente.correo = reader.GetString(3);
                }
                reader.Close();
                connection.Close();
                return cliente;
            }
        }
        public void ClientDelete(int _id)
        {
            string query = $"DELETE FROM Usuarios WHERE id = {_id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
        }
        public Cliente ClientUpdate(Cliente cliente)
        {

            string query = $"update usuarios Set Nombre = '{cliente.nombre}', Apellido ='{cliente.apellido}', Edad ='{cliente.edad}', Correo = '{cliente.correo}'  where id = {cliente.id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
                return cliente;

            }
        }
    }
}
