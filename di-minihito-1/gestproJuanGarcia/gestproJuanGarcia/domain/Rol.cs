using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de rol
  /// </summary>
  public class Rol
  {
    /// <summary>
    /// The identifier rol
    /// </summary>
    private int _idRol;
    /// <summary>
    /// The nombre rol
    /// </summary>
    private string _nombreRol;
    /// <summary>
    /// The desc rol
    /// </summary>
    private string _descRol;

    /// <summary>
    /// The rol list
    /// </summary>
    private List<Rol> _rolList;
    /// <summary>
    /// The rm
    /// </summary>
    public RolManager rm;

    /// <summary>
    /// Initializes a new instance of the <see cref="Rol"/> class.
    /// </summary>
    public Rol() => rm = new RolManager();

    /// <summary>
    /// Initializes a new instance of the <see cref="Rol"/> class.
    /// </summary>
    /// <param name="nombreRol">The nombre rol.</param>
    /// <param name="descRol">The desc rol.</param>
    public Rol(string nombreRol, string descRol)
    {
      rm = new RolManager();
      _idRol = rm.getLastId(this);

      _nombreRol = nombreRol;
      _descRol = descRol;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rol"/> class.
    /// </summary>
    /// <param name="idRol">The identifier rol.</param>
    /// <param name="nombreRol">The nombre rol.</param>
    /// <param name="descRol">The desc rol.</param>
    public Rol(int idRol, string nombreRol, string descRol)
    {
      rm = new RolManager();

      _idRol = idRol;
      _nombreRol = nombreRol;
      _descRol = descRol;
    }

    // Getters y Setters
    /// <summary>
    /// Gets or sets the identifier rol.
    /// </summary>
    /// <value>
    /// The identifier rol.
    /// </value>
    public int IdRol
    {
      get => _idRol;
      set => _idRol = value;
    }

    /// <summary>
    /// Gets or sets the nombre rol.
    /// </summary>
    /// <value>
    /// The nombre rol.
    /// </value>
    public string NombreRol
    {
      get => _nombreRol;
      set => _nombreRol = value;
    }

    /// <summary>
    /// Gets or sets the desc rol.
    /// </summary>
    /// <value>
    /// The desc rol.
    /// </value>
    public string DescRol
    {
      get => _descRol;
      set => _descRol = value;
    }

    /// <summary>
    /// Gets the rol list.
    /// </summary>
    /// <returns></returns>
    public List<Rol> getRolList()
    {
      _rolList = rm.leerRoles();
      return _rolList;
    }

    /// <summary>
    /// Insertars this instance.
    /// </summary>
    public void insertar()
    {
      rm.insertarRol(this);
    }

    /// <summary>
    /// Modificars this instance.
    /// </summary>
    public void modificar()
    {
      rm.modificarRol(this);
    }

    /// <summary>
    /// Eliminars this instance.
    /// </summary>
    public void eliminar()
    {
      rm.eliminarRol(this);
    }

    /// <summary>
    /// Gens the rol.
    /// </summary>
    public void genRol()
    {
      this._idRol = rm.getLastId(this);

      this._nombreRol = "Rol_" + new Random().Next(1000, 9999);
      this._descRol = "Descripción del rol: " + _nombreRol;
    }
  }
}
