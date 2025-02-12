using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain.reportsDomain
{
  /// <summary>
  /// clase que maneja los datos para el informe perfiles por proyecto
  /// </summary>
  internal class PerfilesProyectos
  {
    /// <summary>
    /// The codigo proyecto
    /// </summary>
    private string codigoProyecto;
    /// <summary>
    /// The fecha proyecto
    /// </summary>
    private string fechaProyecto;
    /// <summary>
    /// The perfil empleado
    /// </summary>
    private string perfilEmpleado;
    /// <summary>
    /// The number personas
    /// </summary>
    private int numPersonas;

    /// <summary>
    /// Initializes a new instance of the <see cref="PerfilesProyectos"/> class.
    /// </summary>
    /// <param name="codigoProyecto">The codigo proyecto.</param>
    /// <param name="fechaProyecto">The fecha proyecto.</param>
    /// <param name="perfilEmpleado">The perfil empleado.</param>
    /// <param name="numPersonas">The number personas.</param>
    public PerfilesProyectos (string codigoProyecto, string fechaProyecto, string perfilEmpleado, int numPersonas)
    {
      this.codigoProyecto = codigoProyecto;
      this.fechaProyecto = fechaProyecto;
      this.perfilEmpleado = perfilEmpleado;
      this.numPersonas = numPersonas;
    }

    /// <summary>
    /// Gets or sets the codigo proyecto.
    /// </summary>
    /// <value>
    /// The codigo proyecto.
    /// </value>
    public string CodigoProyecto { get => codigoProyecto; set => codigoProyecto = value; }
    /// <summary>
    /// Gets or sets the fecha proyecto.
    /// </summary>
    /// <value>
    /// The fecha proyecto.
    /// </value>
    public string FechaProyecto { get => fechaProyecto; set => fechaProyecto = value; }
    /// <summary>
    /// Gets or sets the perfil empleado.
    /// </summary>
    /// <value>
    /// The perfil empleado.
    /// </value>
    public string PerfilEmpleado { get => perfilEmpleado; set => perfilEmpleado = value; }
    /// <summary>
    /// Gets or sets the number personas.
    /// </summary>
    /// <value>
    /// The number personas.
    /// </value>
    public int NumPersonas { get => numPersonas; set => numPersonas = value; }
  }
}
