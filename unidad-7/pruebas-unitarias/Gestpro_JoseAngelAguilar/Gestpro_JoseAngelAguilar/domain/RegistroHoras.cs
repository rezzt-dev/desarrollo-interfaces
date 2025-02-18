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
    internal class RegistroHoras
    {
        /// <summary>
        /// The identifier proyecto
        /// </summary>
        public int _idProyecto;
        public string _nameProyecto;
        /// <summary>
        /// The identifier employ
        /// </summary>
        public int _idEmploy;
        public string _nameEmploy;
        public int _totalRegistro;
        public int _csr;
        /// <summary>
        /// The horas
        /// </summary>
        public int _horas;
        /// <summary>
        /// The fecha
        /// </summary>
        public DateTime _fecha;
        /// <summary>
        /// The persistance
        /// </summary>
        public RegistroHorasPersistance persistance;
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistroHoras"/> class.
        /// </summary>
        public RegistroHoras() {
            persistance = new RegistroHorasPersistance();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistroHoras"/> class.
        /// </summary>
        /// <param name="idProyecto">The identifier proyecto.</param>
        /// <param name="idEmploy">The identifier employ.</param>
        /// <param name="horas">The horas.</param>
        /// <param name="fecha">The fecha.</param>
        public RegistroHoras(int idProyecto , int idEmploy, int horas, DateTime fecha,string nameProyecto,string nameEmple,int csr) {
            _idProyecto = idProyecto;
            _idEmploy = idEmploy;
            _horas = horas;
            _fecha = fecha;
            _nameEmploy = nameEmple;
            _nameProyecto = nameProyecto;
            _totalRegistro = csr * horas;
            persistance = new RegistroHorasPersistance();
        }
        /// <summary>
        /// Gets or sets the identifier proyecto.
        /// </summary>
        /// <value>
        /// The identifier proyecto.
        /// </value>
        public int idProyecto { get => _idProyecto; set => _idProyecto = value; }
        /// <summary>
        /// Gets or sets the identifier employ.
        /// </summary>
        /// <value>
        /// The identifier employ.
        /// </value>
        public int idEmploy { get => _idEmploy; set => _idEmploy = value; }
        /// <summary>
        /// Gets or sets the horas.
        /// </summary>
        /// <value>
        /// The horas.
        /// </value>
        public int horas { get => _horas; set => _horas = value; }
        public string nombreProyecto { get => _nameProyecto; set => _nameProyecto = value; }
        public string nombreEmpleado { get => _nameEmploy; set => _nameEmploy = value; }
        public int totalRegistro { get => _totalRegistro; set => _totalRegistro = value; }
        /// <summary>
        /// Gets or sets the fecha.
        /// </summary>
        /// <value>
        /// The fecha.
        /// </value>
        public DateTime fecha { get => _fecha; set => _fecha = value; }

        /// <summary>
        /// Reads the registro horas.
        /// </summary>
        public void readRegistroHoras()
        {
            persistance.readRegistroHoras();
        }

        /// <summary>
        /// Gets the list horas.
        /// </summary>
        /// <returns></returns>
        public List<RegistroHoras> getListHoras()
        {
            return persistance.registroList;
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            persistance.insertRegistro(this);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void delete()
        {
            persistance.deleteRegistro(this);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void update()
        {
            persistance.modifyRegistro(this);
        }
    }
}
