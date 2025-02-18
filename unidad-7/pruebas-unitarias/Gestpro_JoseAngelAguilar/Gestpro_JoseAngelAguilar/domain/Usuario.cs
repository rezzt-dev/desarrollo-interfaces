using Gestpro_JoseAngelAguilar.persistance.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestpro_JoseAngelAguilar.domain
{
    /// <summary>
    /// 
    /// </summary>
    internal class Usuario
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private int _id;
        /// <summary>
        /// The username
        /// </summary>
        private string _username;
        /// <summary>
        /// The password
        /// </summary>
        private string _password;

        /// <summary>
        /// Gets or sets the persistance.
        /// </summary>
        /// <value>
        /// The persistance.
        /// </value>
        public UsuarioPersistance persistance { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Usuario"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        public Usuario(string userName, string password)
        {
            this._username = userName;
            this._password = encriptarMD5(password);  
            this.persistance = new UsuarioPersistance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Usuario"/> class.
        /// </summary>
        public Usuario() { persistance = new UsuarioPersistance(); }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get => _id; set => _id = value; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string username { get => _username; set => _username = value; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string password { get => _password; set => _password = value; }

        /// <summary>
        /// Reads the users.
        /// </summary>
        public void readUsers()
        {
            persistance.readUsuario();
        }

        /// <summary>
        /// Gets the list usuarios.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> getListUsuarios()
        {
            return persistance.userList;
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            persistance.insertUsuario(this);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void delete()
        {
            persistance.deleteUsuario(this);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void update()
        {
            persistance.modifyUsuario(this);
        }

        /// <summary>
        /// Encriptars the m d5.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private string encriptarMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Recuperar el id de un usuario usando su nombre de usuario
        /// <summary>
        /// Finds the identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal int findID(string name)
        {
            return persistance.findById(name);
        }
        
    }
}
