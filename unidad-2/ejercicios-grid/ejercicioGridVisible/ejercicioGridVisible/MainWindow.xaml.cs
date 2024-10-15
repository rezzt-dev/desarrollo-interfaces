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

namespace ejercicioGridVisible
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      for (int i = 0; i < 14; i++)
      {
        for (int j = 0; j < 14; j++)
        {
          Label etiqueta = new Label();
          etiqueta.Content = i + "," + j;

          etiqueta.HorizontalAlignment = HorizontalAlignment.Center;
          etiqueta.VerticalAlignment = VerticalAlignment.Center;

          Grid.SetColumn(etiqueta, i);
          Grid.SetRow(etiqueta, j);
          contenedor.Children.Add(etiqueta);
        }
      }
    }
  }
}
