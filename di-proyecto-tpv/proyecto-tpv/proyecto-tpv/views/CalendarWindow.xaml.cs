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

namespace proyecto_tpv.views
{
  /// <summary>
  /// Interaction logic for CalendarWindow.xaml
  /// </summary>
  public partial class CalendarWindow : Window
  {
    public CalendarWindow()
    {
      InitializeComponent();
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
  }
}
