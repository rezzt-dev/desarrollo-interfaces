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

namespace ejercicioFondoColores
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    int contador = 0;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      tbCopia.Text = tbBase.GetLineText(0);
    }

    private void btnPulsar_Click(object sender, RoutedEventArgs e)
    {
      lblPulsaciones.Content = "Pulsaciones: " + contador++;
    }

    private void btnAzul_Click(object sender, RoutedEventArgs e)
    {
      this.Background = new SolidColorBrush(Colors.Blue);
    }

    private void btnRojo_Click(object sender, RoutedEventArgs e)
    {
      this.Background = new SolidColorBrush(Colors.Red);
    }

    private void btnVerde_Click(object sender, RoutedEventArgs e)
    {
      this.Background = new SolidColorBrush(Colors.Green);
    }

    private void btnAmarillo_Click(object sender, RoutedEventArgs e)
    {
      this.Background = new SolidColorBrush(Colors.Yellow);
    }
  }
}
