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
  /// Interaction logic for aperitivosPage.xaml
  /// </summary>
  public partial class aperitivosPage : Page
  {
    private Producto aperitivoFood = new Producto();

    public aperitivosPage()
    {
      InitializeComponent();
    }

    private void btnAceitunas_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 58);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }

    private void btnAlmendras_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 59);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }

    private void btnCalamares_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 62);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }

    private void btnMiniSandwich_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 63);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }

    private void btnQueso_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 61);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }

    private void btnTortillaPatatas_Click(object sender, RoutedEventArgs e)
    {
      aperitivoFood = new Producto().getProductoList().Find(c => c.Id == 60);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == aperitivoFood.Id).Cantidad++;
      }
      else
      {
        aperitivoFood.Cantidad++;
        TPVWindow.listaProductosPedido.Add(aperitivoFood);
      }
    }
  }
}
