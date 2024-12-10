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
  /// Interaction logic for coolDrinksPage.xaml
  /// </summary>
  public partial class coolDrinksPage : Page
  {
    private Producto refresco = new Producto();

    public coolDrinksPage()
    {
      InitializeComponent();
    }

    private void btnAguaMineral_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 4);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnCocaCola_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 6);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnFantaNaranja_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 33);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnAguaGas_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 30);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnBatidoFresa_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 28);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnBatidoPlatano_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 31);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnLimonada_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 29);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnTonica_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 32);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }

    private void btnZumoNaranja_Click(object sender, RoutedEventArgs e)
    {
      refresco = new Producto().getProductoList().Find(c => c.Id == 5);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == refresco.Id).Cantidad++;
      }
      else
      {
        refresco.Cantidad++;
        TPVWindow.listaProductosPedido.Add(refresco);
      }
    }
  }
}
