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
using System.Windows.Shapes;
using proyecto_tpv.domain;
using proyecto_tpv.views.popViews;

namespace proyecto_tpv.views
{
  /// <summary>
  /// Interaction logic for CalendarWindow.xaml
  /// </summary>
  public partial class InventoryWindow : Window
  {
    private List<Producto> listaProductos;
    private Producto tempProducto;

    public InventoryWindow()
    {
      InitializeComponent();
      listaProductos = new List<Producto>();
      tempProducto = new Producto();

      windowStart();
    }
    private void windowStart()
    {
      listaProductos = tempProducto.getProductoList();
      dataInventario.ItemsSource = listaProductos;
      dataInventario.Items.Refresh();
    }

    private void optExit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void optOrder_Click(object sender, RoutedEventArgs e)
    {
      TPVWindow tpvWindow = new TPVWindow();
      tpvWindow.Show();
      this.Close();
    }

    private void optSettings_Click(object sender, RoutedEventArgs e)
    {
      SettingsWindow settingsWindow = new SettingsWindow();
      settingsWindow.Show();
      this.Close();
    }

    private void dataInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dataInventario.SelectedItems.Count > 0)
      {
        Producto auxProducto = (Producto)dataInventario.SelectedItems[0];
      }
    }

    private void btnAgregarProducto_Click(object sender, RoutedEventArgs e)
    {
      CreateProduct popCreateProduct = new CreateProduct();
      popCreateProduct.ShowDialog();
    }

    private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
    {
      Producto selectProduct = (Producto) dataInventario.SelectedItem;

      if (MessageBox.Show("¿Quieres eliminar este producto?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (dataInventario.SelectedItem != null)
        {
          selectProduct.eliminar();
          listaProductos.Remove(selectProduct);
        }

        dataInventario.Items.Refresh();
      }
    }

    private void btnProductosCriticos_Click(object sender, RoutedEventArgs e)
    {
      if (listaProductos == null)
      {
        return;
      } else
      {
        var listaFiltrada = listaProductos.Where(p => p != null && p.Stock <= 10).ToList();
        dataInventario.ItemsSource = listaFiltrada;
      }

      dataInventario.Items.Refresh();
    }

    private void btnTodosLosProductos_Click(object sender, RoutedEventArgs e)
    {
      windowStart();
    }
  }
}
