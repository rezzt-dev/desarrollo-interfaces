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
using Xceed.Wpf.Toolkit;

namespace gestproJuanGarcia
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Proyecto> listProyectos;
    private Proyecto proyecto;

    public MainWindow()
    {
      InitializeComponent();
      listProyectos = new List<Proyecto>();
      proyecto = new Proyecto();

      listProyectos = proyecto.getProyectList();
      dataProyectos.ItemsSource = listProyectos;
      comboBoxProyectos.ItemsSource = listProyectos.Select(aux => aux.Nombre).ToList();

      btnAgregarProyecto.IsEnabled = true;
      btnEliminarProyecto.IsEnabled = false;
      btnModificarProyecto.IsEnabled = false;
    }

    // metodo | "cleanData" | limpia los campos
    private void cleanData()
    {
      txtCodigoProyectoInput.Text = "";
      txtNombreProyectoInput.Text = "";
      txtDescripcionProyectoInput.Text = "";
      txtPresupuestoProyecto.Text = "";
    }

    private void dataProyectos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dataProyectos.SelectedItems.Count > 0)
      {
        Proyecto proyecto = (Proyecto)dataProyectos.SelectedItems[0];
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
        if (System.Windows.MessageBox.Show("¿Quieres agregar un proyecto?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
          try
          {
            Proyecto nuevoProyecto = new Proyecto(
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
            System.Windows.MessageBox.Show($"Error al crear el proyecto: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          }
        }
      }
      else
      {
        System.Windows.MessageBox.Show("El presupuesto del proyecto debe ser un numero válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    private void btnModificarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;
      Proyecto tempProyect = new Proyecto();

      if (Double.TryParse(txtPresupuestoProyecto.Text, out double presupuestoProyecto))
      {
        if (selectProyecto != null)
        {
          tempProyect.Id = selectProyecto.Id;
          tempProyect.Codigo = txtCodigoProyectoInput.Text;
          tempProyect.Nombre = txtNombreProyectoInput.Text;
          tempProyect.Descripcion = txtDescripcionProyectoInput.Text;
          tempProyect.Presupuesto = presupuestoProyecto;


          tempProyect.modificar();
          dataProyectos.Items.Refresh();
          cleanData();
        }
      }
      else
      {
        System.Windows.MessageBox.Show("El presupuesto del proyecto debe ser un numero válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }


    }

    private void btnEliminarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectedProyecto = (Proyecto)dataProyectos.SelectedItem;

      if (System.Windows.MessageBox.Show("¿Quieres eliminar el proyecto?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (dataProyectos.SelectedItem != null)
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
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;
      txtCodigoProyectoInput.Text = selectProyecto.Codigo;
      txtNombreProyectoInput.Text = selectProyecto.Nombre;
      txtDescripcionProyectoInput.Text = selectProyecto.Descripcion;
      txtPresupuestoProyecto.Text = selectProyecto.Presupuesto.ToString();
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

    private void RealizarBusqueda()
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
            proyecto.Codigo != null && proyecto.Codigo.ToLower().Contains(searchText) ||
            (proyecto.Nombre != null && proyecto.Nombre.ToLower().Contains(searchText)) ||
            (proyecto.Descripcion != null && proyecto.Descripcion.ToLower().Contains(searchText)) ||
            (proyecto.Presupuesto > 0 && proyecto.Presupuesto.ToString().Contains(searchText))
            )
        ).ToList();

        dataProyectos.ItemsSource = filteredList;
      }

      dataProyectos.Items.Refresh();
    }

    private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
    {
      for (int i = 0; i < 20; i++)
      {
        Proyecto tempProyecto = new Proyecto();
        tempProyecto.genProyecto();
        tempProyecto.insertar();
        listProyectos.Add(tempProyecto);
        dataProyectos.Items.Refresh();
      }
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

    private void btnConsultas_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiConsultas;
    }

    private void btnCargarFiltros_Click(object sender, RoutedEventArgs e)
    {
      var selectedFilters = new List<string>();
      if (cboxAllegro.IsChecked == true) selectedFilters.Add("ALLEGRO");
      if (cboxVelneo.IsChecked == true) selectedFilters.Add("VELNEO");
      if (cboxSAP.IsChecked == true) selectedFilters.Add("SAP");
      if (cboxNaturgy.IsChecked == true) selectedFilters.Add("NATURGY");
      if (cboxSantander.IsChecked == true) selectedFilters.Add("SANTANDER");
      if (cboxMutuaM.IsChecked == true) selectedFilters.Add("MUTUAMADRILEÑA");

      int presupuestoMinimo = btnSpinnerMinimo.Value ?? 0;
      int presupuestoMaximo = btnSpinnerMaximo.Value ?? int.MaxValue;

      var listaFiltrada = listProyectos.Where(p => p != null &&
        ((selectedFilters.Count == 0 && presupuestoMinimo == 0 && presupuestoMaximo == 0) ||
        (selectedFilters.Contains(p.Nombre.ToUpper()) &&
        p.Presupuesto >= presupuestoMinimo &&
        p.Presupuesto <= presupuestoMaximo))
      ).ToList();

      frameConsultas.Navigate(new view.PaginaConsultas(listaFiltrada));
    }

    private void btnNumHoras_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiNumHoras;
    }

    private void comboBoxProyectos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      String nombreSelected = (String)comboBoxProyectos.Items[comboBoxProyectos.SelectedIndex];
      Proyecto proyectoSelected = listProyectos.Where(p => p.Nombre == nombreSelected).FirstOrDefault();
    }
  }
}
