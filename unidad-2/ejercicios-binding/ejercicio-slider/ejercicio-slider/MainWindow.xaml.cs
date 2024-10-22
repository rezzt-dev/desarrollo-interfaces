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

namespace ejercicio_slider
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      sliderInput.Value = 24;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.sliderInput.Value = 10;
    }
    private void btnNormal_Click(object sender, RoutedEventArgs e)
    {
      this.sliderInput.Value = 24;
    }

    private void btnGrande_Click(object sender, RoutedEventArgs e)
    {
      this.sliderInput.Value = 34;
    }

    private void TxtbTamanioExacto_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (double.TryParse(txtbTamanioExacto.Text, out double size))
      {
        // Asegurarse de que el valor esté dentro del rango del slider
        size = Math.Max(sliderInput.Minimum, Math.Min(sliderInput.Maximum, size));
        sliderInput.Value = size;
      }
    }

    // Método para manejar el cambio de valor del slider
    private void SliderInput_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (txtbTamanioExacto != null)
      {
        txtbTamanioExacto.Text = sliderInput.Value.ToString("F2");
      }
    }

    private void listColores_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (listColores.SelectedItem != null)
      {
        ListViewItem selectedItem = (ListViewItem)listColores.SelectedItem;
        string selectedColor = selectedItem.Content.ToString();

        // Cambiar el color del texto basado en la selección
        switch (selectedColor.ToLower())
        {
          case "green":
            ChangeTextColor(Brushes.Green);
            break;
          case "blue":
            ChangeTextColor(Brushes.Blue);
            break;
          case "red":
            ChangeTextColor(Brushes.Red);
            break;
          case "black":
            ChangeTextColor(Brushes.Black);
            break;
          default:
            ChangeTextColor(Brushes.Purple);
            break;
        }
      }
    }

    private void ChangeTextColor(Brush color)
    {
      foreach (ListViewItem item in listColores.Items)
      {
        item.Foreground = color;
      }
    }
  }
}
