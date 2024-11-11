using gestproJuanGarcia.domain;
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
    }

     // metodo | "cleanData" | limpia los campos
    private void cleanData ()
    {
      txtCodigoProyectoInput.Text = "";
      txtNombreProyectoInput.Text = "";
      txtFechaInicioInput.Text = "";
      txtFechaFinInput.Text = "";
    }

    private void btnAgregarProyecto_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("¿Quieres agregar un proyecto?", "Comfirmacion", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        listProyectos.Add(new Proyecto(Int32.Parse(txtCodigoProyectoInput.Text), txtNombreProyectoInput.Text, txtFechaInicioInput.Text, txtFechaFinInput.Text));
        dataProyectos.Items.Refresh();
        cleanData();
      }
    }

    private void btnModificarProyecto_Click(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;
      txtCodigoProyectoInput.Text = selectProyecto.Codigo.ToString();
      txtNombreProyectoInput.Text = selectProyecto.Nombre;
      txtFechaInicioInput.Text = selectProyecto.FechaInicio;
      txtFechaFinInput.Text = selectProyecto.FechaFin;

      if (MessageBox.Show("¿Quieres modificar el proyecto?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        listProyectos.Remove(selectProyecto);
        listProyectos.Add(new Proyecto(Int32.Parse(txtCodigoProyectoInput.Text), txtNombreProyectoInput.Text, txtFechaInicioInput.Text, txtFechaFinInput.Text));
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
