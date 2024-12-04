using DataGridPersonas.persistence;
using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.persistence.manages
{
  internal class ProyectoManager
  {
    private DataTable dataTable;
    private List<Proyecto> listProyectos;
    int lastId;

    public ProyectoManager ()
    {
      dataTable = new DataTable ();
      listProyectos = new List<Proyecto> ();
    }

    public List<Proyecto> leerProyectos()
    {
      Proyecto proyecto = new Proyecto ();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.proyecto;");

      foreach (List<Object> aux in list)
      {
        proyecto = new Proyecto(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString(), aux[3].ToString(), Convert.ToDouble(aux[4]));
        listProyectos.Add(proyecto);
      }

      return listProyectos;
    }

    public int getLastId (Proyecto inputProyecto)
    {
      List<Object> listAux;
      listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(IDPROYECTO), 0) FROM proyectoempleado.proyecto;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    

    public void insertarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.proyecto (IDPROYECTO, CODIGOPROY, NOMBREPROY, DESCPROY, PRESUPUESTO) values (" +
        inputProyecto.Id + ", '" +
        inputProyecto.Codigo + "', '" +
        inputProyecto.Nombre + "', '" +
        inputProyecto.Descripcion + "', " + 
        inputProyecto.Presupuesto + ");");
    }

    public void modificarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.proyecto SET CODIGOPROY = '" +
        inputProyecto.Codigo + "', NOMBREPROY = '" +
        inputProyecto.Nombre + "', DESCPROY = " +
        inputProyecto.Descripcion + "' PRESUPUESTO = " +
        inputProyecto.Presupuesto + " WHERE IDPROYECTO = " + inputProyecto.Id + ";");
    }

    public void eliminarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.proyecto WHERE IDPROYECTO = " + inputProyecto.Id + ";");
    }
  }
}
