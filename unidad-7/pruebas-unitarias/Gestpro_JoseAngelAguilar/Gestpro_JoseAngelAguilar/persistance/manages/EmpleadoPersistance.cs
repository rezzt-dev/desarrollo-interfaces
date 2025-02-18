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
    internal class EmpleadoPersistance
    {
        /// <summary>
        /// Gets or sets the empleado list.
        /// </summary>
        /// <value>
        /// The empleado list.
        /// </value>
        public List<Empleado> empleadoList { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmpleadoPersistance"/> class.
        /// </summary>
        public EmpleadoPersistance()
        {
            empleadoList = new List<Empleado>();
        }

        /// <summary>
        /// Reads the empleado.
        /// </summary>
        public void readEmpleado()
        {
            Empleado e = null;
            List<Object> lempleados;
            lempleados = DBBroker.obtenerAgente().leer("select * from employ");
            foreach (List<Object> aux in lempleados)
            {
                e = new Empleado();
                e.id = Convert.ToInt32(aux[0]);
                e.nameEmpleado = aux[1].ToString();
                e.lastnameEmpleado = aux[2].ToString();
                e.csr= (float)Convert.ToDouble(aux[3]);
                e.rol = Convert.ToInt32(aux[5]);
                e.rolName = rolIdToName(e.rol);
                e.idUser = Convert.ToInt32(aux[4]);
                e._userName = userIdToName(e.idUser);
                this.empleadoList.Add(e);
            }
        }

        private string userIdToName(int idUser)
        {
            return DBBroker.obtenerAgente().leerUser("select UserName from User where idUser = " + idUser);
        }

        /// <summary>
        /// Rols the name of the identifier to.
        /// </summary>
        /// <param name="rol">The rol.</param>
        /// <returns></returns>
        private string rolIdToName(int rol)
        {
            string name="No asignado";
            switch (rol)
            {
                case 1:
                    name = "Programador Junior";
                    break;

                case 2:
                    name = "Programador";
                    break;

                case 3:
                    name = "Programador Senior";
                    break;

                case 4:
                    name = "Jefe Proyecto";
                    break;
            }
            return name;
        }

        /// <summary>
        /// Inserts the empleado.
        /// </summary>
        /// <param name="e">The e.</param>
        public void insertEmpleado(Empleado e)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Insert into Employ (employName,employLastname,CSR,User_idUser,idRol) values " +
                "('" + e.nameEmpleado + "','" + e.lastnameEmpleado + "','" + e.csr + "'," + e.idUser + ","+e.rol+")");
            //MessageBox.Show("Insert into Proyect (CodProyecto,ProyectName,StartDate,EndDate) values " +
            //    "('" + p.codProyecto + "','" + p.nombre + "','" + p.FechaInicio.ToString("yyyy-MM-dd") + "','" + p.FechaFin.ToString("yyyy-MM-dd") + "')");
        }

        /// <summary>
        /// Deletes the empleado.
        /// </summary>
        /// <param name="e">The e.</param>
        public void deleteEmpleado(Empleado e)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Delete from employ where idEmploy = " + e.id);
        }

        /// <summary>
        /// Modifies the empleado.
        /// </summary>
        /// <param name="e">The e.</param>
        public void modifyEmpleado(Empleado e)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Update Employ set employName = '" + e.nameEmpleado + "', employLastname= '" + e.lastnameEmpleado + "'" +
                ", CSR= " + e.csr + ", User_idUser = " + e.idUser + ", idRol = "+e.rol+" where idEmploy = " + e.id);
        }

    }
}

