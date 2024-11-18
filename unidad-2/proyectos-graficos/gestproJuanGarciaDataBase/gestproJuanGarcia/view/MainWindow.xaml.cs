using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace gestproJuanGarcia
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Proyecto> listProyectos;

    public MainWindow()
    {
      InitializeComponent();
      listProyectos = new List<Proyecto>();
      Proyecto proyecto = new Proyecto();

      listProyectos = proyecto.genListProyecto();
      dataProyectos.ItemsSource = listProyectos;

      btnAgregarProyecto.IsEnabled = true;
      btnEliminarProyecto.IsEnabled = true;
      btnModificarProyecto.IsEnabled = true;
    }

     // metodo | "cleanData" | limpia los campos
    private void cleanData ()
    {
      txtCodigoProyectoInput.Text = "";
      txtNombreProyectoInput.Text = "";
      txtDescripcionProyectoInput.Text = "";
      txtPresupuestoProyecto.Text = "";

      dataProyectos.SelectedItems.Clear();
    }

    private void dataProyectos_SelectionChanged (object sender, SelectionChangedEventArgs e)
    {
      if (dataProyectos.SelectedItems.Count > 0)
      {
        Proyecto proyecto = (Proyecto) dataProyectos.SelectedItems[0];

        txtCodigoProyectoInput.Text = proyecto.Codigo;
        txtNombreProyectoInput.Text = proyecto.Nombre;
        txtDescripcionProyectoInput.Text = proyecto.Descripcion;
        txtPresupuestoProyecto.Text = proyecto.Presupuesto.ToString();
        
        btnAgregarProyecto.IsEnabled = true;
        btnEliminarProyecto.IsEnabled = true;
        btnModificarProyecto.IsEnabled = true;
      }
    }

    private void btnAgregarProyecto_Click(object sender, RoutedEventArgs e)
    {
      if (Double.TryParse(txtPresupuestoProyecto.Text, out double presupuestoProyecto))
      {
        if (MessageBox.Show("¿Quieres agregar un proyecto?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          try
          {
            Proyecto nuevoProyecto = new Proyecto (
              txtCodigoProyectoInput.Text,
              txtNombreProyectoInput.Text,
              txtDescripcionProyectoInput.Text,
              presupuestoProyecto
            );

            nuevoProyecto.insertar();
            listProyectos.Add(nuevoProyecto);

            dataProyectos.Items.Refresh();
            cleanData();
          }
          catch (Exception ex)
          {
            MessageBox.Show($"Error al crear el proyecto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          }
        }
      }
      else
      {
        MessageBox.Show("El presupuesto del proyecto debe ser un decimal (0.0) válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void btnModificarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;

      if (selectProyecto != null)
      {
        if (MessageBox.Show("¿Quieres modificar el proyecto?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          selectProyecto.Codigo = txtCodigoProyectoInput.Text;
          selectProyecto.Nombre = txtNombreProyectoInput.Text;
          selectProyecto.Descripcion = txtDescripcionProyectoInput.Text;
          selectProyecto.Presupuesto = Double.Parse(txtPresupuestoProyecto.Text);

          selectProyecto.modificar();

          dataProyectos.Items.Refresh();
          cleanData();
        }
      }
    }

    private void btnEliminarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectedProyecto = (Proyecto)dataProyectos.SelectedItem;

      if (MessageBox.Show("¿Quieres eliminar el proyecto?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (selectedProyecto != null)
        {
          selectedProyecto.eliminar();
          listProyectos.Remove(selectedProyecto);
        }
        dataProyectos.Items.Refresh();
        cleanData();
      }
    }

    private void dataProyectos_Selected(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto) dataProyectos.SelectedItem;
      txtCodigoProyectoInput.Text = selectProyecto?.Codigo;
      txtNombreProyectoInput.Text = selectProyecto?.Nombre;
      txtDescripcionProyectoInput.Text = selectProyecto?.Descripcion;
      txtPresupuestoProyecto.Text = selectProyecto?.Presupuesto.ToString();
    }

    private void tboxBusqueda_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        RealizarBusqueda();
      }
    }

    private void tboxBusqueda_TextChanged(object sender, TextChangedEventArgs e)
    {
      RealizarBusqueda();
    }

    private void RealizarBusqueda ()
    {
      string searchText = tboxBusqueda.Text.Trim().ToLower();

      if (listProyectos == null)
      {
        return;
      }

      if (string.IsNullOrEmpty(searchText))
      {
        dataProyectos.ItemsSource = listProyectos;
      }
      else
      {
        var filteredList = listProyectos.Where(proyecto =>
            proyecto != null && (
            proyecto.Codigo.ToString().ToLower().Contains(searchText) ||
            (proyecto.Nombre != null && proyecto.Nombre.ToLower().Contains(searchText)) ||
            (proyecto.Descripcion != null && proyecto.Descripcion.ToLower().Contains(searchText))
            )).ToList();

        dataProyectos.ItemsSource = filteredList;
      }

      dataProyectos.Items.Refresh();
    }

    private void btnProyectos_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiProyecto;
    }

    private void btnEmpleados_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiEmpleados;
    }

    private void btnGEconomica_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiGEconomica;
    }

    private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiEstadisticas;
    }

    private void btnUsuarios_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiUsuarios;
    }
  }
}
