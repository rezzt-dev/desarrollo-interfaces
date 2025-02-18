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
    internal class ProyectoPersistance
    {
        /// <summary>
        /// Gets or sets the proyect list.
        /// </summary>
        /// <value>
        /// The proyect list.
        /// </value>
        public List<Proyecto> proyectList {get; set;}
        /// <summary>
        /// Initializes a new instance of the <see cref="ProyectoPersistance"/> class.
        /// </summary>
        public ProyectoPersistance()
        {
            proyectList = new List<Proyecto>();
        }

        /// <summary>
        /// Reads the proyecto.
        /// </summary>
        public void readProyecto()
        {
            Proyecto p = null;
            List<Object> lproyecto;
            lproyecto = DBBroker.obtenerAgente().leer("select * from proyect");
            foreach (List<Object> aux in lproyecto)
            {
                p = new Proyecto();
                p.id= Convert.ToInt32(aux[0]);
                p.codProyecto = aux[6].ToString();
                p.nombre = aux[1].ToString();
                if (aux[2] != DBNull.Value)
                {
                    p.FechaInicio = DateTime.Parse(aux[2].ToString());
                }
                if (aux[3] != DBNull.Value)
                {
                    p.FechaFin = DateTime.Parse(aux[3].ToString());
                }
                this.proyectList.Add(p);
            }
        }

        /// <summary>
        /// Inserts the proyect.
        /// </summary>
        /// <param name="p">The p.</param>
        public void insertProyect(Proyecto p)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Insert into Proyect (CodProyecto,ProyectName,StartDate,EndDate) values " +
                "('" + p.codProyecto + "','" + p.nombre + "','" + p.FechaInicio.ToString("yyyy-MM-dd") + "','" + p.FechaFin.ToString("yyyy-MM-dd") + "')");
            MessageBox.Show("Insert into Proyect (CodProyecto,ProyectName,StartDate,EndDate) values " +
                "('" + p.codProyecto + "','" + p.nombre + "','" + p.FechaInicio.ToString("yyyy-MM-dd") + "','" + p.FechaFin.ToString("yyyy-MM-dd") + "')");
        }

        /// <summary>
        /// Deletes the proyect.
        /// </summary>
        /// <param name="p">The p.</param>
        public void deleteProyect(Proyecto p)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Delete from proyect where CodProyecto = '"+ p.codProyecto+"'");
        }

        /// <summary>
        /// Modifies the proyect.
        /// </summary>
        /// <param name="p">The p.</param>
        public void modifyProyect(Proyecto p)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Update proyect set CodProyecto = '" + p.codProyecto + "', ProyectName= '" + p.nombre + "'" +
                ", StartDate= '"+p.FechaInicio.ToString("yyyy-MM-dd") + "', EndDate = '"+p.FechaFin.ToString("yyyy-MM-dd") +"' where idProyect = " + p.id);
        }

        /// <summary>
        /// Gets the identifier from code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public int getIdFromCode(string code) {
            int codigo = -1;

            codigo=DBBroker.obtenerAgente().leerID("select idProyect from proyect where CodProyecto = '"+code+"'");

            return codigo;
        }

        /// <summary>
        /// Gets the coste total.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal int getCosteTotal(int id)
        {
            int horas=0;
            int csr = 0;
            List<Object> lproyecto;
            int total = 0;
            lproyecto = DBBroker.obtenerAgente().leer("select sum(pe.hours), e.csr " +
                "from Proyect_Employ pe, Employ e where pe.idProyect ="+id+" AND pe.idEmploy = e.idEmploy group by e.idEmploy;");
            foreach (List<Object> aux in lproyecto)
            {
                horas = Convert.ToInt32(aux[0]);
                csr = Convert.ToInt32(aux[1]);
                total = total + (horas * csr);
            }
            return total;
        }

        /// <summary>
        /// Gets the total personas rol.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        internal object getTotalPersonasRol(int id, int i)
        {
            int total = 0;
            List<Object> lproyecto;
            lproyecto = DBBroker.obtenerAgente().leer("select count(DISTINCT e.idEmploy) from Proyect_Employ pe, Employ e, " +
                "Rol r where pe.idProyect = "+id+" AND pe.idEmploy = e.idEmploy AND e.idRol = r.idRol AND r.idRol = "+i+";");
            foreach (List<Object> aux in lproyecto)
            {
                total = Convert.ToInt32(aux[0]);
            }
            return total;
        }
    }
}
