using Gestpro_JoseAngelAguilar.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gestpro_JoseAngelAguilar.persistance.manages
{
    /// <summary>
    /// 
    /// </summary>
    internal class RegistroHorasPersistance
    {
        /// <summary>
        /// Gets or sets the registro list.
        /// </summary>
        /// <value>
        /// The registro list.
        /// </value>
        public List<RegistroHoras> registroList { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistroHorasPersistance"/> class.
        /// </summary>
        public RegistroHorasPersistance()
        {
            registroList = new List<RegistroHoras>();
        }
        /// <summary>
        /// Reads the registro horas.
        /// </summary>
        public void readRegistroHoras()
        {
            RegistroHoras rh = null;
            List<Object> lhoras;
            lhoras = DBBroker.obtenerAgente().leer("select * from Proyect_Employ");
            foreach (List<Object> aux in lhoras)
            {
                rh = new RegistroHoras();
                rh.idProyecto = Convert.ToInt32(aux[0]);
                rh.idEmploy = Convert.ToInt32(aux[1]);
                rh.horas = Convert.ToInt32(aux[2]);
                if (aux[3] != DBNull.Value)
                {
                    rh.fecha = DateTime.Parse(aux[3].ToString());
                }
                Proyecto p = new Proyecto();
                p.readP();
                List<Proyecto> listaProyecto=p.persistance.proyectList;

                Proyecto proyectoEncontrado = listaProyecto.FirstOrDefault(proj => proj.id== rh.idProyecto);
                if (proyectoEncontrado != null)
                {
                    rh._nameProyecto = proyectoEncontrado.codProyecto;
                }

                Empleado e = new Empleado();
                e.readEmpleados();
                List<Empleado> listaEmpleados = e.persistance.empleadoList;
                Empleado empleadoEncontrado = listaEmpleados.FirstOrDefault(emp => emp.id == rh.idEmploy);
                if (proyectoEncontrado != null) { rh._nameEmploy = empleadoEncontrado._nameEmpleado; }
                if (proyectoEncontrado != null) { rh._csr = Convert.ToInt32(empleadoEncontrado.csr); }
                rh.totalRegistro = rh.horas * rh._csr;
                this.registroList.Add(rh);
            }
        }

        /// <summary>
        /// Inserts the registro.
        /// </summary>
        /// <param name="rh">The rh.</param>
        public void insertRegistro(RegistroHoras rh)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Insert into Proyect_Employ values " +
                "(" + rh.idProyecto + "," + rh.idEmploy+","+rh.horas+",'"+rh.fecha.ToString("yyyy-MM-dd") + "')");
            //MessageBox.Show("Insert into user (CodProyecto,ProyectName,StartDate,EndDate) values " +
            //    "('" + p.codProyecto + "','" + p.nombre + "','" + p.FechaInicio.ToString("yyyy-MM-dd") + "','" + p.FechaFin.ToString("yyyy-MM-dd") + "')");
        }

        /// <summary>
        /// Deletes the registro.
        /// </summary>
        /// <param name="rh">The rh.</param>
        public void deleteRegistro(RegistroHoras rh)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Delete from Proyect_Employ where idProyect = " + rh.idProyecto + " AND idEmploy = " + rh.idEmploy + " AND Fecha = '" + rh.fecha.ToString("yyyy-MM-dd")+"'");
            MessageBox.Show("Registro eliminado con exito");
        }

        /// <summary>
        /// Modifies the registro.
        /// </summary>
        /// <param name="rh">The rh.</param>
        public void modifyRegistro(RegistroHoras rh)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Update Proyect_Employ set Hours = " + rh.horas + " where idProyect = " 
                + rh.idProyecto + " AND idEmploy = " + rh.idEmploy + " AND Fecha = '" + rh.fecha.ToString("yyyy-MM-dd") + "'");
            // ResultSet claveGenerada = statement.getGeneratedKeys();
            //    ", StartDate= '" + p.FechaInicio.ToString("yyyy-MM-dd") + "', EndDate = '" + p.FechaFin.ToString("yyyy-MM-dd") + "' where idProyect = " + p.id);
        }

        //internal int findById(string name)
        //{
        //    int id = -1;
        //    id = DBBroker.obtenerAgente().leerID("select idUser from user WHERE UserName = '" + name + "'");
        //    return id;
        //}
    }
}
