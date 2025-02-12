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
  /// <summary>
  /// clase de manejador de proyecto
  /// </summary>
  public class ProyectoManager
  {
    /// <summary>
    /// The data table
    /// </summary>
    private DataTable dataTable;
    /// <summary>
    /// The list proyectos
    /// </summary>
    private List<Proyecto> listProyectos;
    /// <summary>
    /// The last identifier
    /// </summary>
    int lastId;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProyectoManager"/> class.
    /// </summary>
    public ProyectoManager ()
    {
      dataTable = new DataTable ();
      listProyectos = new List<Proyecto> ();
    }

    /// <summary>
    /// Leers the proyectos.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Gets the last identifier.
    /// </summary>
    /// <param name="inputProyecto">The input proyecto.</param>
    /// <returns></returns>
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



    /// <summary>
    /// Insertars the proyecto.
    /// </summary>
    /// <param name="inputProyecto">The input proyecto.</param>
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

    /// <summary>
    /// Modificars the proyecto.
    /// </summary>
    /// <param name="inputProyecto">The input proyecto.</param>
    public void modificarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.proyecto SET CODIGOPROY = '" +
        inputProyecto.Codigo + "', NOMBREPROY = '" +
        inputProyecto.Nombre + "', DESCPROY = " +
        inputProyecto.Descripcion + "' PRESUPUESTO = " +
        inputProyecto.Presupuesto + " WHERE IDPROYECTO = " + inputProyecto.Id + ";");
    }

    /// <summary>
    /// Eliminars the proyecto.
    /// </summary>
    /// <param name="inputProyecto">The input proyecto.</param>
    public void eliminarProyecto (Proyecto inputProyecto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.proyecto WHERE IDPROYECTO = " + inputProyecto.Id + ";");
    }
  }
}
