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
  public class EmpleadoManager
  {
    private DataTable dataTable;
    private List<Empleado> listEmpleados;
    private int lastId;

    public EmpleadoManager ()
    {
      dataTable = new DataTable ();
      listEmpleados = new List<Empleado> ();
    }

    public List<Empleado> leerEmpleados ()
    {
      Empleado empleado = new Empleado();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM proyectoempleado.empleado;");

      foreach (List<Object> aux in list)
      {
        empleado = new Empleado(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString(), Convert.ToInt32(aux[3]), Convert.ToInt32(aux[4]), Convert.ToInt32(aux[5]));
        listEmpleados.Add(empleado);
      }

      return listEmpleados;
    }

    public int getLastId(Empleado inputEmpleado)
    {
      List<Object> listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(IDROL), 0) FROM proyectoempleado.empleado;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarEmpleado(Empleado inputEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO proyectoempleado.empleado (IDEMPLEADO, NOMBREEMP, APELLIDOSEMP, CSR, IDUSUARIO, IDROL) values (" + 
        inputEmpleado.IdEmpleado + ", '" + inputEmpleado.NombreEmpleado + "', '" + inputEmpleado.ApellidosEmpleado + "', " + 
        inputEmpleado.CsrEmpleado + ", " + inputEmpleado.IdUsuario + ", " + inputEmpleado.IdRol + ");");
    }

    public void modificarEmpleado (Empleado inputEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE proyectoempleado.empleado SET NOMBREEMP = '" + inputEmpleado.NombreEmpleado  + "', APELLIDOSEMP = '" + 
        inputEmpleado.ApellidosEmpleado + "', CSR = " + inputEmpleado.CsrEmpleado + ", IDUSUARIO = " + inputEmpleado.IdUsuario + ", " +
        "IDROL = " + inputEmpleado.IdRol + " WHERE IDEMPLEADO = " + inputEmpleado.IdEmpleado + ";");
    }

    public void eliminarEmpleado (Empleado inputEmpleado)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM proyectoempleado.empleado WHERE IDEMPLEADO = " + inputEmpleado.IdEmpleado + ";");
    }
  }
}
