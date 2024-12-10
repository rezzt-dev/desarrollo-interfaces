using System.Text;
using System.Windows;
using System.Windows.Controls;
using proyecto_tpv.domain;
using proyecto_tpv.views.productViews;

namespace proyecto_tpv.views
{
  /// <summary>
  /// Interaction logic for TPVWindow.xaml
  /// </summary>
  public partial class TPVWindow : Window
  {
    public static List<Producto> listaProductosPedido;

    private double _value = 0;
    private string _operation = "";
    private bool _operationPressed = false;

    public TPVWindow()
    {
      InitializeComponent();
      listaProductosPedido = new List<Producto>();
      startData();
    }
    private void startData()
    {
      dataListaProductos.ItemsSource = listaProductosPedido;
      dataListaProductos.Items.Refresh();
    }

    private void optExit_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void optCalendar_Click(object sender, RoutedEventArgs e)
    {
      InventoryWindow inventoryWindow = new InventoryWindow();
      inventoryWindow.Show();
      this.Close();
    }

    private void optSettings_Click(object sender, RoutedEventArgs e)
    {
      SettingsWindow settingsWindow = new SettingsWindow();
      settingsWindow.Show();
      this.Close();
    }

    private void btnRefrescos_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new coolDrinksPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnAlcohol_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new alcoholicDrinksPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnCafeTe_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new hotDrinksPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnAperitivo_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new aperitivosPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnEntrante_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new entrantesPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnPrincipal_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new platoPrincipalPage());
      dataListaProductos.Items.Refresh();
    }

    private void btnCPostre_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new postrePage());
      dataListaProductos.Items.Refresh();
    }

    private void dataListaProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dataListaProductos.SelectedItems.Count > 0)
      {
        Producto auxProducto = (Producto)dataListaProductos.SelectedItems[0];
      }
    }

    private void btnEliminarProducto_Click(object sender, RoutedEventArgs e)
    {
      Producto selectedProduct = (Producto)dataListaProductos.SelectedItem;

      if (MessageBox.Show("¿Quieres eliminar el producto del pedido?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (dataListaProductos.SelectedItem != null)
        {
          if (listaProductosPedido.Find(c => c.Id == selectedProduct.Id).Cantidad == 1)
          {
            listaProductosPedido.Remove(selectedProduct);
          }
          else
          {
            listaProductosPedido.Find(c => c.Id == selectedProduct.Id).Cantidad--;
          }
        }
        dataListaProductos.Items.Refresh();
      }
    }

    private void btnConfirmarPedido_Click(object sender, RoutedEventArgs e)
    {
      decimal precioFinalPedido = 0;
      DetallesPedido dePedido = new DetallesPedido();
      Pedido newPedido = new Pedido(Convert.ToInt32(inputNumMesa.Text));
      newPedido.insertar();

      foreach (Producto auxProduct in listaProductosPedido)
      {
        dePedido = new DetallesPedido(newPedido.Id, auxProduct.Id, auxProduct.Cantidad, (auxProduct.Precio * auxProduct.Cantidad));
        precioFinalPedido += (auxProduct.Precio * auxProduct.Cantidad);
        dePedido.insertar();
      }

      precioFinalPedido = Math.Round(precioFinalPedido, 2);
      generarTicketFromPedido(newPedido, precioFinalPedido);
      txtResultPrecio.Text = precioFinalPedido.ToString();
      listaProductosPedido.Clear();
      dataListaProductos.Items.Refresh();
    }

    private void generarTicketFromPedido(Pedido inputPedido, decimal precioTotal)
    {
      StringBuilder ticketText = new StringBuilder();
      ticketText.AppendLine($"Fecha: {inputPedido.FechaHora:G} | Mesa: {inputPedido.IdMesa}")
              .AppendLine(new string('-', 40))  // Línea separadora más corta
              .AppendLine($"{"CANT",-5} {"CONCEPTO",-15} {"PRECIO",-7} {"IMPORTE",-7}")
              .AppendLine(new string('-', 40));

      List<DetallesPedido> listaFiltrada = new DetallesPedido().getDetallesPedido().FindAll(d => d.IdPedido == inputPedido.Id);
      
      foreach (DetallesPedido aux in listaFiltrada)
      {
        Producto auxProduct = new Producto().getProductoList().Find(p => p.Id == aux.IdProducto);
        ticketText.AppendLine(
                $"{aux.Cantidad,-5} {auxProduct.Nombre,-15} {auxProduct.Precio,7:C} {aux.Subtotal,7:C}"
            );
      }

      ticketText.AppendLine(new string('-', 32))
              .AppendLine($"{"Total:",20} {precioTotal,7:C}")  // Total alineado con menos espacio
              .AppendLine(new string('-', 32))
              .AppendLine("   ¡Gracias por su visita!");

      txtContenedorTicket.Text = ticketText.ToString();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------
    // funciones de la calculadora
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if ((txtResultPrecio.Text == "0") || _operationPressed)
        txtResultPrecio.Text = "";

      _operationPressed = false;
      Button button = (Button)sender;
      txtResultPrecio.Text += button.Content.ToString();
    }

    private void Operation_Click(object sender, RoutedEventArgs e)
    {
      Button button = (Button)sender;
      _operation = button.Content.ToString();
      _value = double.Parse(txtResultPrecio.Text);
      _operationPressed = true;
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
      txtResultPrecio.Text = "0";
      _value = 0;
      _operation = "";
    }

    private void Equals_Click(object sender, RoutedEventArgs e)
    {
      double secondValue = double.Parse(txtResultPrecio.Text);

      switch (_operation)
      {
        case "+":
          txtResultPrecio.Text = (_value + secondValue).ToString();
          break;
        case "-":
          txtResultPrecio.Text = (_value - secondValue).ToString();
          break;
        case "*":
          txtResultPrecio.Text = (_value * secondValue).ToString();
          break;
        case "/":
          if (secondValue != 0)
            txtResultPrecio.Text = (_value / secondValue).ToString();
          else
            txtResultPrecio.Text = "Error";
          break;
      }
    }

    private void Percentage_Click(object sender, RoutedEventArgs e)
    {
      double currentValue = double.Parse(txtResultPrecio.Text);
      txtResultPrecio.Text = (_value * currentValue / 100).ToString();
      _operationPressed = true;
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
      if (txtResultPrecio.Text.Length > 0)
      {
        // Elimina el último carácter
        txtResultPrecio.Text = txtResultPrecio.Text.Substring(0, txtResultPrecio.Text.Length - 1);
      }

      // Si el campo queda vacío después de borrar, muestra 0
      if (string.IsNullOrEmpty(txtResultPrecio.Text))
      {
        txtResultPrecio.Text = "0";
      }
    }
  }
}
