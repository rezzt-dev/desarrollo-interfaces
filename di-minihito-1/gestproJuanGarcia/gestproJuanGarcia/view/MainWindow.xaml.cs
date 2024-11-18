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
      dataProyectos.ItemsSource = listProyectos;

      btnAgregarProyecto.IsEnabled = true;
      btnEliminarProyecto.IsEnabled = false;
      btnModificarProyecto.IsEnabled = false;
    }

     // metodo | "cleanData" | limpia los campos
    private void cleanData ()
    {
      txtCodigoProyectoInput.Text = "";
      txtNombreProyectoInput.Text = "";
      txtFechaInicioInput.Text = "";
      txtFechaFinInput.Text = "";
    }

    private void dataProyectos_SelectionChanged (object sender, SelectionChangedEventArgs e)
    {
      if (dataProyectos.SelectedItems.Count > 0)
      {
        Proyecto proyecto = (Proyecto) dataProyectos.SelectedItems[0];
        txtCodigoProyectoInput.Text = proyecto.Codigo.ToString();
        txtNombreProyectoInput.Text = proyecto.Nombre;
        txtFechaInicioInput.Text = proyecto.FechaInicio;
        txtFechaFinInput.Text = proyecto.FechaFin;

        btnAgregarProyecto.IsEnabled = true;
        btnEliminarProyecto.IsEnabled = true;
        btnModificarProyecto.IsEnabled = true;
      }
    }

    private void btnAgregarProyecto_Click(object sender, RoutedEventArgs e)
    {
      if (Int32.TryParse(txtCodigoProyectoInput.Text, out int codigoProyecto))
      {
        if (MessageBox.Show("¿Quieres agregar un proyecto?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          try
          {
            Proyecto nuevoProyecto = new Proyecto(
                codigoProyecto,
                txtNombreProyectoInput.Text,
                txtFechaInicioInput.Text,
                txtFechaFinInput.Text
            );

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
        MessageBox.Show("El código del proyecto debe ser un número entero válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void btnModificarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;

      if (selectProyecto != null)
      {
        selectProyecto.Codigo = Int32.Parse(txtCodigoProyectoInput.Text);
        selectProyecto.Nombre = txtNombreProyectoInput.Text;
        selectProyecto.FechaInicio = txtFechaInicioInput.Text;
        selectProyecto.FechaFin = txtFechaFinInput.Text;

        dataProyectos.Items.Refresh();
        cleanData();
      }
    }

    private void btnEliminarProyecto_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("¿Quieres eliminar el proyecto?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        btnAgregarProyecto.IsEnabled = false;
        btnModificarProyecto.IsEnabled = false;

        if (dataProyectos.SelectedItem != null)
        {
          listProyectos.Remove((Proyecto)dataProyectos.SelectedItem);
        }
        dataProyectos.Items.Refresh();
        cleanData();
      }
    }

    private void dataProyectos_Selected(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;
      txtCodigoProyectoInput.Text = selectProyecto.Codigo.ToString();
      txtNombreProyectoInput.Text = selectProyecto.Nombre;
      txtFechaInicioInput.Text = selectProyecto.FechaInicio;
      txtFechaFinInput.Text = selectProyecto.FechaFin;
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
            (proyecto.FechaInicio != null && proyecto.FechaInicio.ToLower().Contains(searchText)) ||
            (proyecto.FechaFin != null && proyecto.FechaFin.ToLower().Contains(searchText))
            )
        ).ToList();

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
