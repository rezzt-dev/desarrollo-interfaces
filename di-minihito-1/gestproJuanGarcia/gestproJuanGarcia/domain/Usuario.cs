using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de usuario
  /// </summary>
  public class Usuario
  {
    /// <summary>
    /// The identifier usuario
    /// </summary>
    private int _idUsuario;
    /// <summary>
    /// The nombre usuario
    /// </summary>
    private string _nombreUsuario;
    /// <summary>
    /// The pass usuario
    /// </summary>
    private string _passUsuario;

    /// <summary>
    /// The usuario list
    /// </summary>
    private List<Usuario> _usuarioList;
    /// <summary>
    /// The um
    /// </summary>
    public UsuarioManager um;

    /// <summary>
    /// Initializes a new instance of the <see cref="Usuario"/> class.
    /// </summary>
    public Usuario() => um = new UsuarioManager();

    /// <summary>
    /// Initializes a new instance of the <see cref="Usuario"/> class.
    /// </summary>
    /// <param name="nombreUsuario">The nombre usuario.</param>
    /// <param name="passUsuario">The pass usuario.</param>
    public Usuario(string nombreUsuario, string passUsuario)
    {
      um = new UsuarioManager();
      _idUsuario = um.getLastId(this);

      _nombreUsuario = nombreUsuario;
      _passUsuario = passUsuario;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Usuario"/> class.
    /// </summary>
    /// <param name="idUsuario">The identifier usuario.</param>
    /// <param name="nombreUsuario">The nombre usuario.</param>
    /// <param name="passUsuario">The pass usuario.</param>
    public Usuario(int idUsuario, string nombreUsuario, string passUsuario)
    {
      um = new UsuarioManager();

      _idUsuario = idUsuario;
      _nombreUsuario = nombreUsuario;
      _passUsuario = passUsuario;
    }

    // Getters y Setters
    /// <summary>
    /// Gets or sets the identifier usuario.
    /// </summary>
    /// <value>
    /// The identifier usuario.
    /// </value>
    public int IdUsuario
    {
      get => _idUsuario;
      set => _idUsuario = value;
    }

    /// <summary>
    /// Gets or sets the nombre usuario.
    /// </summary>
    /// <value>
    /// The nombre usuario.
    /// </value>
    public string NombreUsuario
    {
      get => _nombreUsuario;
      set => _nombreUsuario = value;
    }

    /// <summary>
    /// Gets or sets the pass usuario.
    /// </summary>
    /// <value>
    /// The pass usuario.
    /// </value>
    public string PassUsuario
    {
      get => _passUsuario;
      set => _passUsuario = value;
    }

    /// <summary>
    /// Gets the usuario list.
    /// </summary>
    /// <returns></returns>
    public List<Usuario> getUsuarioList()
    {
      _usuarioList = um.leerUsuarios();
      return _usuarioList;
    }

    /// <summary>
    /// Insertars this instance.
    /// </summary>
    public void insertar()
    {
      um.insertarUsuario(this);
    }

    /// <summary>
    /// Modificars this instance.
    /// </summary>
    public void modificar()
    {
      um.modificarUsuario(this);
    }

    /// <summary>
    /// Eliminars this instance.
    /// </summary>
    public void eliminar()
    {
      um.eliminarUsuario(this);
    }

    /// <summary>
    /// Gens the usuario.
    /// </summary>
    public void genUsuario()
    {
      this._idUsuario = um.getLastId(this);

      this._nombreUsuario = "Usuario_" + new Random().Next(1000, 9999);
      this._passUsuario = "Pass_" + new Random().Next(1000, 9999);
    }
  }
}
