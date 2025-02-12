using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase que maneja los datos para el informe costes proyecto
  /// </summary>
  internal class CostesProyecto
  {
    /// <summary>
    /// The codigo proyecto
    /// </summary>
    private String codigoProyecto;
    /// <summary>
    /// The fecha proyecto
    /// </summary>
    private String fechaProyecto;
    /// <summary>
    /// The coste total
    /// </summary>
    private int costeTotal;

    /// <summary>
    /// Initializes a new instance of the <see cref="CostesProyecto"/> class.
    /// </summary>
    /// <param name="codigoProyecto">The codigo proyecto.</param>
    /// <param name="fechaProyecto">The fecha proyecto.</param>
    /// <param name="costeTotal">The coste total.</param>
    public CostesProyecto(string codigoProyecto, string fechaProyecto, int costeTotal)
    {
      this.codigoProyecto = codigoProyecto;
      this.fechaProyecto = fechaProyecto;
      this.costeTotal = costeTotal;
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
    /// Gets or sets the coste total.
    /// </summary>
    /// <value>
    /// The coste total.
    /// </value>
    public int CosteTotal { get => costeTotal; set => costeTotal = value; }
  }
}
