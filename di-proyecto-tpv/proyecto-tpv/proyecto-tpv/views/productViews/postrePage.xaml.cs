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
  /// Interaction logic for postrePage.xaml
  /// </summary>
  public partial class postrePage : Page
  {
    private Producto postre = new Producto();
    public postrePage()
    {
      InitializeComponent();
    }

    private void btnCremaCatalana_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 46);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }

    private void btnCupcakeVainilla_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 51);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }

    private void btnFlanCaramelo_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 49);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }

    private void btnGelatina_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 48);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }

    private void btnMousseChocolate_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 47);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }

    private void btnPastelZanahoria_Click(object sender, RoutedEventArgs e)
    {
      postre = new Producto().getProductoList().Find(c => c.Id == 50);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == postre.Id).Cantidad++;
      }
      else
      {
        postre.Cantidad++;
        TPVWindow.listaProductosPedido.Add(postre);
      }
    }
  }
}
