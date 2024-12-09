using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace proyecto_tpv.views.popViews
{
  /// <summary>
  /// Interaction logic for CreateProduct.xaml
  /// </summary>
  public partial class CreateProduct : Window
  {
    public CreateProduct()
    {
      InitializeComponent();
    }

    private void btnCancelar_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void btnAceptar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        if (decimal.TryParse(inputPrecioProduct.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioProducto) &&
            int.TryParse(inputStockProduct.Text, out int stockProducto))
        {
          Categoria tempCategoria = new Categoria().getCategoriaList().Find(c => c.Nombre.Equals(inputCategoriaProduct.Text));
          if (tempCategoria != null)
          {
            Producto tempProducto = new Producto(inputNombreProduct.Text, precioProducto, tempCategoria.Id, tempCategoria.Nombre, stockProducto);
            tempProducto.insertar();

            List<Producto> tempList = new Producto().getProductoList();

            InventoryWindow inventoryWindow = new InventoryWindow();
            inventoryWindow.dataInventario.ItemsSource = tempList;
            inventoryWindow.dataInventario.Items.Refresh();
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error al introducir el producto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
