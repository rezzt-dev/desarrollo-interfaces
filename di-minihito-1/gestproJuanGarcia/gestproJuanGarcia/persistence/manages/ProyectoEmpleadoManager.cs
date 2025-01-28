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
  public class ProyectoEmpleadoManager
  {
    private DataTable dataTable;
    private List<ProyectoEmpleado> listProyectoEmpleado;
    private int lastId;

    public ProyectoEmpleadoManager ()
    {
      dataTable = new DataTable();
      listProyectoEmpleado = new List<ProyectoEmpleado> ();
    }

    public List<ProyectoEmpleado> leerListaProyectoEmpleado()
    {
      ProyectoEmpleado proyectoEmpleado = new ProyectoEmpleado();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.empleado;");

      foreach (List<Object> aux in list)
      {
        proyectoEmpleado = new ProyectoEmpleado(Convert.ToInt32(aux[0]), Convert.ToDecimal(aux[1]), Convert.ToDateTime(aux[2]), Convert.ToInt32(aux[3]), Convert.ToInt32(aux[4]));
        listProyectoEmpleado.Add(proyectoEmpleado);
      }

      return listProyectoEmpleado;
    }

    public void insertarProyectoEmpleado(ProyectoEmpleado inputProyectoEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.proyectoempleado (HORAS, COSTES, FECHA, IDPROYECTO, IDEMPLEADO) values (" +
        inputProyectoEmpleado.NumHoras + ", " + inputProyectoEmpleado.Costes + ", '" + inputProyectoEmpleado.Fecha + "', " +
        inputProyectoEmpleado.IdProyecto + ", " + inputProyectoEmpleado.IdEmpleado + ");");
    }

    public void modificarProyectoEmpleado(ProyectoEmpleado inputProyectoEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.proyectoempleado SET HORAS = " + inputProyectoEmpleado.NumHoras + ", COSTES = " + inputProyectoEmpleado.Costes + 
        " WHERE FECHA = '" + inputProyectoEmpleado.Fecha + "', IDPROYECTO = " + inputProyectoEmpleado.IdProyecto + ", IDEMPLEADO = " + inputProyectoEmpleado.IdEmpleado + ";");
    }

    public void eliminarProyectoEmpleado (ProyectoEmpleado inputProyectoEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar(" DELETE FROM proyectoempleado.proyectoempleado WHERE FECHA = '" + inputProyectoEmpleado.Fecha + "', IDPROYECTO = " + inputProyectoEmpleado.IdProyecto +
        ", IDEMPLEADO = " + inputProyectoEmpleado.IdEmpleado + ";");
    }
  }
}
