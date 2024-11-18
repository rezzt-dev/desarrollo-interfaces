using System;
using System.Collections.Generic;

namespace DataGridPersonas.persistence
{
  public class DBBroker
  {
    private static DBBroker _instancia;
    private static MySql.Data.MySqlClient.MySqlConnection conexion;
    private const String cadenaConexion = "server=localhost;database=mydb;uid=rezzt;pwd=root";

    private DBBroker()
    {
      DBBroker.conexion = new MySql.Data.MySqlClient.MySqlConnection(DBBroker.cadenaConexion);

    }

    public static DBBroker obtenerAgente()
    {
      if (DBBroker._instancia == null)
      {
        DBBroker._instancia = new DBBroker();
      }
      return DBBroker._instancia;
    }

    public List<Object> leer(String sql)
    {
      List<Object> resultado = new List<object>();
      List<Object> fila;
      int i;
      MySql.Data.MySqlClient.MySqlDataReader reader;
      MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.conexion);

      conectar();
      reader = com.ExecuteReader();
      while (reader.Read())
      {
        fila = new List<object>();
        for (i = 0; i <= reader.FieldCount - 1; i++)
        {
          fila.Add(reader[i].ToString());

        }
        resultado.Add(fila);
      }
      desconectar();
      return resultado;
    }
    public int modificar(String sql)
    {
      MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.conexion);
      int resultado;
      conectar();
      resultado = com.ExecuteNonQuery();
      desconectar();
      return resultado;
    }
    public int ObtenerContador(string nombre)
    {
      string sql = $"SELECT Valor FROM mydb.contador WHERE Nombre = '{nombre}'";
      List<object> resultado = leer(sql);

      if (resultado.Count > 0 && resultado[0] is List<object> fila && fila.Count > 0)
      {
        return int.Parse(fila[0].ToString());
      }

      throw new Exception("No se encontró el contador especificado en la tabla Contador.");
    }

    public void IncrementarContador(string nombre)
    {
      string sql = $"UPDATE mydb.contador SET Valor = Valor + 1 WHERE Nombre = '{nombre}'";
      int filasAfectadas = modificar(sql);

      if (filasAfectadas == 0)
      {
        throw new Exception("No se pudo incrementar el contador. Verifica que exista en la tabla Contador.");
      }
    }
    private void conectar()
    {
      if (DBBroker.conexion.State == System.Data.ConnectionState.Closed)
      {
        DBBroker.conexion.Open();
      }
    }
    private void desconectar()
    {
      if (DBBroker.conexion.State == System.Data.ConnectionState.Open)
      {
        DBBroker.conexion.Close();
      }
    }
  }
}
