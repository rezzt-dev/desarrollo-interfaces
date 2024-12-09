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
using proyecto_tpv.views.productViews;

namespace proyecto_tpv.views
{
  /// <summary>
  /// Interaction logic for TPVWindow.xaml
  /// </summary>
  public partial class TPVWindow : Window
  {
    public TPVWindow()
    {
      InitializeComponent();
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
    }

    private void btnAlcohol_Click(object sender, RoutedEventArgs e)
    {
      contenidoProductos.Navigate(new alcoholicDrinksPage());
    }
  }
}
