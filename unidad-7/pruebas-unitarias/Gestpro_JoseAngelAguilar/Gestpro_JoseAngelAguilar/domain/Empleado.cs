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
    internal class Empleado
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int _id;
        /// <summary>
        /// The name empleado
        /// </summary>
        public string _nameEmpleado;
        /// <summary>
        /// The lastname empleado
        /// </summary>
        public string _lastnameEmpleado;
        /// <summary>
        /// The CSR
        /// </summary>
        public float _csr;
        /// <summary>
        /// The rol
        /// </summary>
        public int _rol;
        /// <summary>
        /// The rol name
        /// </summary>
        public string _rolName;

        /// <summary>
        /// The identifier user
        /// </summary>
        public int _idUser;

        public string _userName;
        /// <summary>
        /// Gets or sets the persistance.
        /// </summary>
        /// <value>
        /// The persistance.
        /// </value>
        public EmpleadoPersistance persistance { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Empleado"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="nameEmpleado">The name empleado.</param>
        /// <param name="lastnameEmpleado">The lastname empleado.</param>
        /// <param name="csr">The CSR.</param>
        /// <param name="idUser">The identifier user.</param>
        /// <param name="rol">The rol.</param>
        public Empleado (int id, string nameEmpleado, string lastnameEmpleado, float csr, int idUser, int rol)
        {
            _id = id;
            _nameEmpleado = nameEmpleado;
            _lastnameEmpleado = lastnameEmpleado;
            _csr = csr;
            _rol = rol;
            this.idUser = idUser;
            this.persistance = new EmpleadoPersistance();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Empleado"/> class.
        /// </summary>
        /// <param name="nameEmpleado">The name empleado.</param>
        /// <param name="lastnameEmpleado">The lastname empleado.</param>
        /// <param name="csr">The CSR.</param>
        /// <param name="idUser">The identifier user.</param>
        /// <param name="rol">The rol.</param>
        /// <param name="rolName">Name of the rol.</param>
        public Empleado(string nameEmpleado, string lastnameEmpleado, double csr, int idUser, int rol,string rolName,string userName)
        {
            _nameEmpleado = nameEmpleado;
            _lastnameEmpleado = lastnameEmpleado;
            _csr = (float)csr;
            _rol = rol;
            this.idUser = idUser;
            _rolName = rolName;
            _userName = userName;
            this.persistance = new EmpleadoPersistance();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get => _id; set => _id = value; }
        /// <summary>
        /// Gets or sets the name empleado.
        /// </summary>
        /// <value>
        /// The name empleado.
        /// </value>
        public string nameEmpleado { get => _nameEmpleado; set => _nameEmpleado = value; }
        /// <summary>
        /// Gets or sets the lastname empleado.
        /// </summary>
        /// <value>
        /// The lastname empleado.
        /// </value>
        public string lastnameEmpleado { get => _lastnameEmpleado; set => _lastnameEmpleado = value; }
        /// <summary>
        /// Gets or sets the CSR.
        /// </summary>
        /// <value>
        /// The CSR.
        /// </value>
        public float csr { get => _csr; set => _csr = value; }
        /// <summary>
        /// Gets or sets the rol.
        /// </summary>
        /// <value>
        /// The rol.
        /// </value>
        public int rol { get => _rol; set => _rol = value; }
        /// <summary>
        /// Gets or sets the name of the rol.
        /// </summary>
        /// <value>
        /// The name of the rol.
        /// </value>
        public string rolName { get => _rolName; set => _rolName = value; }
        /// <summary>
        /// Gets or sets the identifier user.
        /// </summary>
        /// <value>
        /// The identifier user.
        /// </value>
        public int idUser { get => _idUser; set => _idUser = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Empleado"/> class.
        /// </summary>
        public Empleado() { 
            persistance = new EmpleadoPersistance();
        }
        /// <summary>
        /// Reads the empleados.
        /// </summary>
        public void readEmpleados()
        {
            persistance.readEmpleado();
        }

        /// <summary>
        /// Gets the list usuarios.
        /// </summary>
        /// <returns></returns>
        public List<Empleado> getListUsuarios()
        {
            return persistance.empleadoList;
        }


        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            persistance.insertEmpleado(this);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void delete()
        {
            persistance.deleteEmpleado(this);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void update()
        {
            persistance.modifyEmpleado(this);
        }

    }
}
