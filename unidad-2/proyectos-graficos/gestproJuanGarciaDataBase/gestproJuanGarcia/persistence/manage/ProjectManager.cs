using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas.persistence;
using gestproJuanGarcia.domain;

namespace gestproJuanGarcia.persistence.manage
{
  internal class ProjectManager
  {
    private DataTable dataTable;
    private List<Proyecto> listProyecto;
    int lastId;

    public ProjectManager()
    {
      dataTable = new DataTable();
      listProyecto = new List<Proyecto>();
    }

    public List<Proyecto> leerProyectos ()
    {
      Proyecto proyecto = new Proyecto();
      List<Object> listAux = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.proyecto;");

      foreach (List<Object> auxProject in listAux)
      {
        proyecto = new Proyecto(Convert.ToInt32(auxProject[0]), auxProject[1].ToString(), auxProject[2].ToString(), auxProject[3].ToString(), Convert.ToDouble(auxProject[4]));
        listProyecto.Add(proyecto);
      }

      return listProyecto;
    }

    public int getLastId (Proyecto inputProyecto)
    {
      List<Object> listAux;
      listAux = DBBroker.obtenerAgente().leer("SELECT MAX(IDPROYECTO) FROM proyectoempleado.proyecto;");

      foreach (List<Object> auxProject in listAux)
      {
        lastId = Convert.ToInt32(auxProject[0]) + 1;
      }

      return lastId;
    }

    public void insertarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.proyecto values (IDPROYECTO, '" + 
        inputProyecto.Codigo + "', '" +
        inputProyecto.Nombre + "', '" + 
        inputProyecto.Descripcion + "', " + 
        inputProyecto.Presupuesto + ");");
    }
    public void modificarProyecto(Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.proyecto SET CODIGOPROY = '" +
        inputProyecto.Codigo + "', NOMBREPROY = '" +
        inputProyecto.Nombre + "', DESCPROY = '" +
        inputProyecto.Descripcion + "', PRESUPUESTO = " +
        inputProyecto.Presupuesto + " WHERE IDPROYECTO = " +
        inputProyecto.Id + ";");
    }

    public void eliminarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.proyecto WHERE IDPROYECTO = " + inputProyecto.Id + ";");
    }
  }
}
