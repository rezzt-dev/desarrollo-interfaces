using DataGridPersonas.persistence;
using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace gestproJuanGarcia.persistence.manages
{
  /// <summary>
  /// clase de manejador de proyectoEmpleado
  /// </summary>
  public class ProyectoEmpleadoManager
    {
    /// <summary>
    /// The data table
    /// </summary>
    private DataTable dataTable;
    /// <summary>
    /// The list proyecto empleado
    /// </summary>
    private List<ProyectoEmpleado> listProyectoEmpleado;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProyectoEmpleadoManager"/> class.
    /// </summary>
    public ProyectoEmpleadoManager()
        {
            dataTable = new DataTable();
            listProyectoEmpleado = new List<ProyectoEmpleado>();
        }

    /// <summary>
    /// Leers the lista proyecto empleado.
    /// </summary>
    /// <returns></returns>
    public List<ProyectoEmpleado> leerListaProyectoEmpleado()
        {
            ProyectoEmpleado proyectoEmpleado;
            List<Object> list = DBBroker.obtenerAgente().leer("SELECT HORAS, COSTES, FECHA, IDPROYECTO, IDEMPLEADO FROM proyectoempleado.proyectoempleado;");

            foreach (List<Object> aux in list)
            {
                proyectoEmpleado = new ProyectoEmpleado(
                    Convert.ToInt32(aux[0]),
                    Convert.ToDecimal(aux[1]),
                    Convert.ToDateTime(aux[2]),
                    Convert.ToInt32(aux[3]),
                    Convert.ToInt32(aux[4])
                );

                listProyectoEmpleado.Add(proyectoEmpleado);
            }

            return listProyectoEmpleado;
        }

    /// <summary>
    /// Insertars the proyecto empleado.
    /// </summary>
    /// <param name="inputProyectoEmpleado">The input proyecto empleado.</param>
    public void insertarProyectoEmpleado(ProyectoEmpleado inputProyectoEmpleado)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO proyectoempleado.proyectoempleado (HORAS, COSTES, FECHA, IDPROYECTO, IDEMPLEADO) VALUES ("
                + inputProyectoEmpleado.NumHoras + ", " + inputProyectoEmpleado.Costes + ", '"
                + inputProyectoEmpleado.Fecha.ToString("yyyy-MM-dd") + "', " + inputProyectoEmpleado.IdProyecto + ", " + inputProyectoEmpleado.IdEmpleado + ");";

            dbBroker.modificar(query);
        }

    /// <summary>
    /// Modificars the proyecto empleado.
    /// </summary>
    /// <param name="inputProyectoEmpleado">The input proyecto empleado.</param>
    public void modificarProyectoEmpleado(ProyectoEmpleado inputProyectoEmpleado)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            string query = $"UPDATE proyectoempleado.proyectoempleado SET HORAS = " + inputProyectoEmpleado.NumHoras + ", COSTES = " + inputProyectoEmpleado.Costes +
                " WHERE FECHA = '" + inputProyectoEmpleado.Fecha.ToString("yyyy-MM-dd") + "' AND IDPROYECTO = " + inputProyectoEmpleado.IdProyecto + " AND IDEMPLEADO = " + inputProyectoEmpleado.IdEmpleado + ";";

            dbBroker.modificar(query);
        }

    /// <summary>
    /// Eliminars the proyecto empleado.
    /// </summary>
    /// <param name="inputProyectoEmpleado">The input proyecto empleado.</param>
    public void eliminarProyectoEmpleado(ProyectoEmpleado inputProyectoEmpleado)
        {
            DBBroker dbBroker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM proyectoempleado.proyectoempleado WHERE FECHA = '" + inputProyectoEmpleado.Fecha.ToString("yyyy-MM-dd") + "' AND IDPROYECTO = " + inputProyectoEmpleado.IdProyecto + " AND IDEMPLEADO = " + inputProyectoEmpleado.IdEmpleado + ";";

            dbBroker.modificar(query);
        }
    }
}
