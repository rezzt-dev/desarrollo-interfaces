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
  /// Interaction logic for platoPrincipalPage.xaml
  /// </summary>
  public partial class platoPrincipalPage : Page
  {
    private Producto platoPrincipal = new Producto();
    public platoPrincipalPage()
    {
      InitializeComponent();
    }

    private void btnCostillasBBQ_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 45);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }

    private void btnFilete_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 42);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }

    private void btnLasagna_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 41);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }

    private void btnPizzaMargarita_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 40);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }

    private void btnRisotto_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 43);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }

    private void btnTacosPollo_Click(object sender, RoutedEventArgs e)
    {
      platoPrincipal = new Producto().getProductoList().Find(c => c.Id == 44);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == platoPrincipal.Id).Cantidad++;
      }
      else
      {
        platoPrincipal.Cantidad++;
        TPVWindow.listaProductosPedido.Add(platoPrincipal);
      }
      TPVWindow.listaProductosPedido.Add(platoPrincipal);
    }
  }
}
