using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using proyecto_tpv.domain;

namespace proyecto_tpv.views.productViews
{
  /// <summary>
  /// Interaction logic for alcoholicDrinksPage.xaml
  /// </summary>
  public partial class alcoholicDrinksPage : Page
  {
    private Producto bebidaAlcoholica = new Producto();


    public alcoholicDrinksPage()
    {
      InitializeComponent();
    }

    private void btnVinoTinto_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 17);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      } else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnWhisky_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 18);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      };
    }

    private void btnCervezaArtesana_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 16);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnGinTonic_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 55);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnMojito_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 53);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnRonCola_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 52);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnSangria_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 56);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnTequilaSunrise_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 54);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }

    private void btnTercio_Click(object sender, RoutedEventArgs e)
    {
      bebidaAlcoholica = new Producto().getProductoList().Find(c => c.Id == 57);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaAlcoholica.Id).Cantidad++;
      }
      else
      {
        bebidaAlcoholica.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaAlcoholica);
      }
    }
  }
}
