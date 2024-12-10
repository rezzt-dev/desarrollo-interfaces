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
  /// Interaction logic for entrantesPage.xaml
  /// </summary>
  public partial class entrantesPage : Page
  {
    private Producto entrante = new Producto();
    public entrantesPage()
    {
      InitializeComponent();
    }

    private void btnBruschetta_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 35);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }

    private void btnCroquetas_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 34);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }

    private void btnHummus_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 37);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }

    private void btnMejillones_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 38);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }

    private void btnRollitosPrimavera_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 36);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }

    private void btnTostadas_Click(object sender, RoutedEventArgs e)
    {
      entrante = new Producto().getProductoList().Find(c => c.Id == 39);
      if (TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id) != null)
      {
        TPVWindow.listaProductosPedido.Find(c => c.Id == entrante.Id).Cantidad++;
      }
      else
      {
        entrante.Cantidad++;
        TPVWindow.listaProductosPedido.Add(entrante);
      }
    }
  }
}
