using System.Data;
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
using proyectoPersonas.domain;
using proyectoPersonas.reports;

namespace proyectoPersonas
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Persona> listPersonas;
    private Persona persona;
    DataTable tablaInforme;

    public MainWindow()
    {
      InitializeComponent();
      listPersonas = new List<Persona>();
      persona = new Persona();
      listPersonas = persona.genListaPersonas();
      dgvPersonas.ItemsSource = listPersonas;
      start();

      tablaInforme = new DataTable("DataTable1");

      this.Loaded += (s, e) => cargarInforme();
    }

    private void start()
    {
      txtNombre.Text = "";
      txtApellido.Text = "";
      txtEdad.Text = "";

      dgvPersonas.SelectedItems.Clear();
      btnAgregar.IsEnabled = true;
      btnModificar.IsEnabled = false;
      btnEliminar.IsEnabled = false;
    }

    private void cargarInforme ()
    {
      if (reportViewer == null)
      {
        MessageBox.Show("El visor reportViewer no ha sido inicializado.");
        return;
      }

      tablaInforme.Columns.Add("Nombre");
      tablaInforme.Columns.Add("Apellidos");
      tablaInforme.Columns.Add("Edad");

      foreach (Persona persona in listPersonas)
      {
        DataRow row = tablaInforme.NewRow();
        row["Nombre"] = persona.Nombre;
        row["Apellidos"] = persona.Apellido;
        row["Edad"] = persona.Edad;
        tablaInforme.Rows.Add(row);
      }

      CrystalReport1 report = new CrystalReport1();

      // Verificar si la tabla está disponible en el reporte
      if (report.Database.Tables["DataTable1"] == null)
      {
        MessageBox.Show("Error: La tabla 'DataTable1' no existe en el informe.");
        return;
      }

      report.Database.Tables["DataTable1"].SetDataSource(tablaInforme);

      // 🔴 Verificar si ViewerCore es null antes de asignar el reporte
      if (reportViewer.ViewerCore != null)
      {
        reportViewer.ViewerCore.ReportSource = report;
      }
      else
      {
      }
    }

      private void dgvPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dgvPersonas.SelectedItems.Count > 0)
      {
        Persona persona = (Persona)dgvPersonas.SelectedItems[0];
        txtNombre.Text = persona.Nombre;
        txtApellido.Text = persona.Apellido;
        txtEdad.Text = persona.Edad.ToString();
        btnAgregar.IsEnabled = true;
        btnModificar.IsEnabled = true;
        btnEliminar.IsEnabled = true;
      }
    }

    private void btnAgregar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        // Crea una nueva persona y la guarda en la base de datos
        Persona nuevaPersona = new Persona(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text));
        nuevaPersona.insertar();

        // Actualiza la lista y el DataGrid
        listPersonas.Add(nuevaPersona);
        dgvPersonas.Items.Refresh();

        // Limpia los campos
        start();
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Ocurrió un error al agregar la persona: {ex.Message}");
      }
    }

    private void btnModificar_Click(object sender, RoutedEventArgs e)
    {
      Persona personaSeleccionada = (Persona)dgvPersonas.SelectedItem;

      if (personaSeleccionada != null)
      {
        // Actualiza las propiedades directamente
        personaSeleccionada.Nombre = txtNombre.Text;
        personaSeleccionada.Apellido = txtApellido.Text;
        personaSeleccionada.Edad = int.Parse(txtEdad.Text);

        // Actualiza la base de datos
        personaSeleccionada.modificar();

        // Refresca el DataGrid
        dgvPersonas.Items.Refresh();
        start();
      }
      else
      {
        MessageBox.Show("Seleccione una persona para modificar.");
      }
    }

    private void btnEliminar_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        Persona personaSeleccionada = (Persona)dgvPersonas.SelectedItem;

        if (personaSeleccionada != null &&
          MessageBox.Show("¿Quiere eliminar esta persona?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          // Elimina de la base de datos
          personaSeleccionada.eliminar();

          // Actualiza la lista y el DataGrid
          listPersonas.Remove(personaSeleccionada);
          dgvPersonas.Items.Refresh();

          // Limpia los campos
          start();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Ocurrió un error al eliminar la persona: {ex.Message}");
      }
    }
  }
}