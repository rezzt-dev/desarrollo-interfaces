using DataGridPersonas.persistence;
using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.persistence.manages
{
  public class UsuarioManager
  {
    private DataTable dataTable;
    private List<Usuario> listUsuarios;
    private int lastId;

    public UsuarioManager()
    {
      dataTable = new DataTable();
      listUsuarios = new List<Usuario>();
    }

    public List<Usuario> leerUsuarios()
    {
      Usuario usuario = new Usuario();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.usuario;");

      foreach (List<Object> aux in list)
      {
        usuario = new Usuario(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString());
        listUsuarios.Add(usuario);
      }

      return listUsuarios;
    }

    public int getLastId(Usuario inputUsuario)
    {
      List<Object> listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(IDUSUARIO), 0) FROM proyectoempleado.usuario;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarUsuario(Usuario inputUsuario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.usuario (IDUSUARIO, NOMBREUSUARIO, PASSUSUARIO) values (" +
          inputUsuario.IdUsuario + ", '" +
          inputUsuario.NombreUsuario + "', '" +
          inputUsuario.PassUsuario + "');");
    }

    public void modificarUsuario(Usuario inputUsuario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.usuario SET NOMBREUSUARIO = '" +
          inputUsuario.NombreUsuario + "', PASSUSUARIO = '" +
          inputUsuario.PassUsuario + "' WHERE IDUSUARIO = " + inputUsuario.IdUsuario + ";");
    }

    public void eliminarUsuario(Usuario inputUsuario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.usuario WHERE IDUSUARIO = " + inputUsuario.IdUsuario + ";");
    }
  }
}
