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
  /// <summary>
  /// clase de manejador de rol
  /// </summary>
  public class RolManager
  {
    /// <summary>
    /// The data table
    /// </summary>
    private DataTable dataTable;
    /// <summary>
    /// The list roles
    /// </summary>
    private List<Rol> listRoles;
    /// <summary>
    /// The last identifier
    /// </summary>
    private int lastId;

    /// <summary>
    /// Initializes a new instance of the <see cref="RolManager"/> class.
    /// </summary>
    public RolManager()
    {
      dataTable = new DataTable();
      listRoles = new List<Rol>();
    }

    /// <summary>
    /// Leers the roles.
    /// </summary>
    /// <returns></returns>
    public List<Rol> leerRoles()
    {
      Rol rol = new Rol();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.rol;");

      foreach (List<Object> aux in list)
      {
        rol = new Rol(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString());
        listRoles.Add(rol);
      }

      return listRoles;
    }

    /// <summary>
    /// Gets the last identifier.
    /// </summary>
    /// <param name="inputRol">The input rol.</param>
    /// <returns></returns>
    public int getLastId(Rol inputRol)
    {
      List<Object> listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(IDROL), 0) FROM proyectoempleado.rol;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    /// <summary>
    /// Insertars the rol.
    /// </summary>
    /// <param name="inputRol">The input rol.</param>
    public void insertarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.rol (IDROL, NOMBREROL, DESCROL) values (" +
          inputRol.IdRol + ", '" +
          inputRol.NombreRol + "', '" +
          inputRol.DescRol + "');");
    }

    /// <summary>
    /// Modificars the rol.
    /// </summary>
    /// <param name="inputRol">The input rol.</param>
    public void modificarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.rol SET NOMBREROL = '" +
          inputRol.NombreRol + "', DESCROL = '" +
          inputRol.DescRol + "' WHERE IDROL = " + inputRol.IdRol + ";");
    }

    /// <summary>
    /// Eliminars the rol.
    /// </summary>
    /// <param name="inputRol">The input rol.</param>
    public void eliminarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.rol WHERE IDROL = " + inputRol.IdRol + ";");
    }
  }
}
