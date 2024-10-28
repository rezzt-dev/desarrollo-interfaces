using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_acceso_usuarios.dto
{
  internal class Usuario
  {
    public String Login { get; set; }
    public String Password { get; set; }

    public Usuario(String login, String passw)
    {
      this.Login = login;
      this.Password = passw;
    }

    public override String ToString()
    {
      return Login + " " + Password;
    }
  }
}
