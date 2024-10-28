using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ejercicioManejoPersonas.domain;

namespace ejercicioManejoPersonas
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Persona> listPersonas;
    public MainWindow()
    {
      InitializeComponent();
      listPersonas = new List<Persona>();
      dgvPersonas.ItemsSource = listPersonas;
    }

    private void limpiar ()
    {
      txtNombre.Text = "";
      txtApellidos.Text = "";
      txtEdad.Text = "";
    }

    private void btnAgregar_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Quieres agregar una persona?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        listPersonas.Add(new Persona(txtNombre.Text, txtApellidos.Text, int.Parse(txtEdad.Text)));
        dgvPersonas.Items.Refresh();
        limpiar();
      }
    }

    private void btnModificar_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Quieres modificar una persona?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        btnAgregar.IsEnabled = false;
        btnEliminar.IsEnabled = false;

        Persona persElegida = (Persona) dgvPersonas.SelectedItem;
        txtNombre.Text = persElegida.Nombre;
        txtApellidos.Text = persElegida.Apellidos;
        txtEdad.Text = persElegida.Edad.ToString();
      }
    }
    private void btnEliminar_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("Quieres eliminar una persona?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        listPersonas.Remove((Persona) dgvPersonas.SelectedItem);
        dgvPersonas.Items.Refresh();
        limpiar();
      }
    }
  }
}