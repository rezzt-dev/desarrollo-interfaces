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
    internal class Proyecto
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private int _id;
        /// <summary>
        /// The cod proyecto
        /// </summary>
        private string _codProyecto;
        /// <summary>
        /// The nombre
        /// </summary>
        private string _nombre;
        /// <summary>
        /// The fecha inicio
        /// </summary>
        private DateTime _FechaInicio;
        /// <summary>
        /// The fecha fin
        /// </summary>
        private DateTime _FechaFin;
        /// <summary>
        /// Gets or sets the persistance.
        /// </summary>
        /// <value>
        /// The persistance.
        /// </value>
        public ProyectoPersistance persistance { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proyecto"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="codProyecto">The cod proyecto.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="fechaI">The fecha i.</param>
        /// <param name="fechaF">The fecha f.</param>
        public Proyecto(int id,string codProyecto, string nombre, DateTime fechaI, DateTime fechaF) {
            this._id = id;
            this._codProyecto = codProyecto;
            this._nombre = nombre;
            this._FechaFin = fechaF;
            this._FechaInicio = fechaI;
            persistance = new ProyectoPersistance();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Proyecto"/> class.
        /// </summary>
        /// <param name="codProyecto">The cod proyecto.</param>
        /// <param name="nombre">The nombre.</param>
        /// <param name="fechaI">The fecha i.</param>
        /// <param name="fechaF">The fecha f.</param>
        public Proyecto(string codProyecto, string nombre, DateTime fechaI, DateTime fechaF)
        {
            this._codProyecto = codProyecto;
            this._nombre = nombre;
            persistance = new ProyectoPersistance();
            this._FechaInicio = fechaI;
            this._FechaFin = fechaF;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Proyecto"/> class.
        /// </summary>
        /// <param name="codProyecto">The cod proyecto.</param>
        /// <param name="nombre">The nombre.</param>
        public Proyecto(string codProyecto, string nombre)
        {
            this._codProyecto=codProyecto;
            this._nombre=nombre;
            persistance = new ProyectoPersistance();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proyecto"/> class.
        /// </summary>
        public Proyecto() { persistance = new ProyectoPersistance(); }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get => _id; set => _id = value; }
        /// <summary>
        /// Gets or sets the cod proyecto.
        /// </summary>
        /// <value>
        /// The cod proyecto.
        /// </value>
        public string codProyecto { get => _codProyecto; set => _codProyecto = value; }
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string nombre { get => _nombre; set => _nombre = value; }
        /// <summary>
        /// Gets or sets the fecha inicio.
        /// </summary>
        /// <value>
        /// The fecha inicio.
        /// </value>
        public DateTime FechaInicio { get => _FechaInicio; set => _FechaInicio = value; }
        /// <summary>
        /// Gets or sets the fecha fin.
        /// </summary>
        /// <value>
        /// The fecha fin.
        /// </value>
        public DateTime FechaFin { get => _FechaFin; set => _FechaFin = value; }

        /// <summary>
        /// Reads the p.
        /// </summary>
        public void readP()
        {
            persistance.readProyecto();
        }

        /// <summary>
        /// Gets the list proyectos.
        /// </summary>
        /// <returns></returns>
        public List<Proyecto> getListProyectos()
        {
            return persistance.proyectList;
        }

        /// <summary>
        /// Inserts this instance.
        /// </summary>
        public void insert()
        {
            persistance.insertProyect(this);
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void delete()
        {
            persistance.deleteProyect(this);
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void update()
        {
            persistance.modifyProyect(this);
        }

        /// <summary>
        /// Gets the identifier from code.
        /// </summary>
        /// <param name="proyecto">The proyecto.</param>
        /// <returns></returns>
        public int getIdFromCode(string proyecto)
        {
            return persistance.getIdFromCode(proyecto);
        }

        /// <summary>
        /// Gets the coste total.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        internal int getCosteTotal(int id)
        {
            return persistance.getCosteTotal(id);
        }

        /// <summary>
        /// Gets the number personas rol.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        internal object getNumPersonasRol(int id, int i)
        {
            return persistance.getTotalPersonasRol(id, i);
        }
    }

}
