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
    internal class UsuarioPersistance
    {
        /// <summary>
        /// Gets or sets the user list.
        /// </summary>
        /// <value>
        /// The user list.
        /// </value>
        public List<Usuario> userList { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioPersistance"/> class.
        /// </summary>
        public UsuarioPersistance()
        {
            userList = new List<Usuario>();
        }
        /// <summary>
        /// Reads the usuario.
        /// </summary>
        public void readUsuario()
        {
            Usuario u = null;
            List<Object> lusuario;
            lusuario = DBBroker.obtenerAgente().leer("select * from user");
            foreach (List<Object> aux in lusuario)
            {
                u = new Usuario();
                u.id = Convert.ToInt32(aux[0]);
                u.username = aux[1].ToString();
                u.password = aux[2].ToString();
                this.userList.Add(u);
            }
        }

        /// <summary>
        /// Inserts the usuario.
        /// </summary>
        /// <param name="u">The u.</param>
        public void insertUsuario(Usuario u)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Insert into user (UserName,UserPass) values " +
                "('" + u.username + "','" + u.password+ "')");
            //MessageBox.Show("Insert into user (CodProyecto,ProyectName,StartDate,EndDate) values " +
            //    "('" + p.codProyecto + "','" + p.nombre + "','" + p.FechaInicio.ToString("yyyy-MM-dd") + "','" + p.FechaFin.ToString("yyyy-MM-dd") + "')");
        }

        /// <summary>
        /// Deletes the usuario.
        /// </summary>
        /// <param name="u">The u.</param>
        public void deleteUsuario(Usuario u)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Delete from user where idUser = '" + u.id + "'");
        }

        /// <summary>
        /// Modifies the usuario.
        /// </summary>
        /// <param name="u">The u.</param>
        public void modifyUsuario(Usuario u)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            broker.modifier("Update user set UserPass = '" + u.password + "' where UserName = '"+ u.username+"'");
            // ResultSet claveGenerada = statement.getGeneratedKeys();
            //    ", StartDate= '" + p.FechaInicio.ToString("yyyy-MM-dd") + "', EndDate = '" + p.FechaFin.ToString("yyyy-MM-dd") + "' where idProyect = " + p.id);
        }

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal int findById(string name)
        {
            int id = -1;
            id= DBBroker.obtenerAgente().leerID("select idUser from user WHERE UserName = '"+name+"'");
            return id;
        }
    }
}
