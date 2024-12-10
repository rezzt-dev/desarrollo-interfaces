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
  /// Interaction logic for hotDrinksPage.xaml
  /// </summary>
  public partial class hotDrinksPage : Page
  {
    private Producto bebidaCaliente = new Producto();
    public hotDrinksPage()
    {
      InitializeComponent();
    }

    private void btnChocolate_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 24);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }

    private void btnDescafeinado_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 27);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }

    private void btnExpresso_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 22);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }

    private void btnLatte_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 23);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }

    private void btnMacchiato_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 25);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }

    private void btnTeNegro_Click(object sender, RoutedEventArgs e)
    {
      bebidaCaliente = new Producto().getProductoList().Find(c => c.Id == 26);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == bebidaCaliente.Id).Cantidad++;
      }
      else
      {
        bebidaCaliente.Cantidad++;
        TPVWindow.listaProductosPedido.Add(bebidaCaliente);
      }
    }
  }
}
