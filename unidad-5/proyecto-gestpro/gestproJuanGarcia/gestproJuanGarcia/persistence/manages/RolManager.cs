using DataGridPersonas.persistence;
using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace gestproJuanGarcia.persistence.manages
{
  public class RolManager
  {
    private DataTable dataTable;
    private List<Rol> listRoles;
    private int lastId;

    public RolManager()
    {
      dataTable = new DataTable();
      listRoles = new List<Rol>();
    }

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

    public int getLastId(Rol inputRol)
    {
      List<Object> listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(IDROL), 0) FROM proyectoempleado.rol;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.rol (IDROL, NOMBREROL, DESCROL) values (" +
          inputRol.IdRol + ", '" +
          inputRol.NombreRol + "', '" +
          inputRol.DescRol + "');");
    }

    public void modificarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.rol SET NOMBREROL = '" +
          inputRol.NombreRol + "', DESCROL = '" +
          inputRol.DescRol + "' WHERE IDROL = " + inputRol.IdRol + ";");
    }

    public void eliminarRol(Rol inputRol)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.rol WHERE IDROL = " + inputRol.IdRol + ";");
    }
  }
}

