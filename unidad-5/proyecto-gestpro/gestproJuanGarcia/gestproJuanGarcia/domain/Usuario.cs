using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;

namespace gestproJuanGarcia.domain
{
  public class Usuario
  {
    private int _idUsuario;
    private string _nombreUsuario;
    private string _passUsuario;

    private List<Usuario> _usuarioList;
    public UsuarioManager um;

    public Usuario() => um = new UsuarioManager();

    public Usuario(string nombreUsuario, string passUsuario)
    {
      um = new UsuarioManager();
      _idUsuario = um.getLastId(this);

      _nombreUsuario = nombreUsuario;
      _passUsuario = passUsuario;
    }

    public Usuario(int idUsuario, string nombreUsuario, string passUsuario)
    {
      um = new UsuarioManager();

      _idUsuario = idUsuario;
      _nombreUsuario = nombreUsuario;
      _passUsuario = passUsuario;
    }

    // Getters y Setters
    public int IdUsuario
    {
      get => _idUsuario;
      set => _idUsuario = value;
    }

    public string NombreUsuario
    {
      get => _nombreUsuario;
      set => _nombreUsuario = value;
    }

    public string PassUsuario
    {
      get => _passUsuario;
      set => _passUsuario = value;
    }

    public List<Usuario> getUsuarioList()
    {
      _usuarioList = um.leerUsuarios();
      return _usuarioList;
    }

    public void insertar()
    {
      um.insertarUsuario(this);
    }

    public void modificar()
    {
      um.modificarUsuario(this);
    }

    public void eliminar()
    {
      um.eliminarUsuario(this);
    }

    public void genUsuario()
    {
      this._idUsuario = um.getLastId(this);

      this._nombreUsuario = "Usuario_" + new Random().Next(1000, 9999);
      this._passUsuario = "Pass_" + new Random().Next(1000, 9999);
    }
  }
}
