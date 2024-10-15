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

namespace ejercicioAvanzado
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnAgregar_Click(object sender, RoutedEventArgs e)
    {
      cmbPeliculas.Items.Add(tbTituloIpt.Text);
      tbTituloIpt.Text = "";
    }

    private void cmbPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ltbPeliculas.Items.Add(cmbPeliculas.SelectedValue);
    }
  }
}
