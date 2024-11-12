using System;
using Personas.domain;
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

namespace Personas
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private List<Persona> lstPersonas;
    private Persona persona;
    public MainWindow()
    {
      InitializeComponent();
      lstPersonas = new List<Persona>();
      // Descarmamos los valores por defecto
      persona = new Persona();
      lstPersonas = persona.gListaPersonas();
      dgvPersonas.ItemsSource = lstPersonas;
      start();


    }
    private void start()
    {
      txtNombre.Text = "";
      txtApellidos.Text = "";
      txtEdad.Text = "";
      dgvPersonas.SelectedItems.Clear();
      bntEliminar.IsEnabled = false;
      bntModificar.IsEnabled = false;
      bntAgregar.IsEnabled = true;
    }
    private void bntAgregar_Click(object sender, RoutedEventArgs e)
    {

      persona = new Persona(txtNombre.Text, txtApellidos.Text, int.Parse(txtEdad.Text));
      persona.insertar();
      lstPersonas.Add(persona);
      dgvPersonas.Items.Refresh();

    }

    private void dgvPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dgvPersonas.SelectedItems.Count > 0)
      {
        // Mostramos en los campos la persona del datagridview seleccionada
        Persona persona = (Persona)dgvPersonas.SelectedItems[0];
        txtNombre.Text = persona.Nombre;
        txtApellidos.Text = persona.Apellidos;
        txtEdad.Text = persona.Edad.ToString();
        bntAgregar.IsEnabled = false;
        bntModificar.IsEnabled = true;
        bntEliminar.IsEnabled = true;
      }

    }

    private void bntEliminar_Click(object sender, RoutedEventArgs e)
    {
      if (MessageBox.Show("¿ Quiere eliminar esta persona?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        Persona persona = (Persona)dgvPersonas.SelectedItem;
        persona.eliminar();
        List<Persona> lst = (List<Persona>)dgvPersonas.ItemsSource;
        lst.Remove(persona);
        dgvPersonas.Items.Refresh();
        dgvPersonas.ItemsSource = lst;
        start();
      }
    }

    private void bntModificar_Click(object sender, RoutedEventArgs e)
    {

      Persona persona = (Persona)dgvPersonas.SelectedItem;
      List<Persona> lst = (List<Persona>)dgvPersonas.ItemsSource;
      lst.Remove(persona);
      Persona newPersona = new Persona(txtNombre.Text, txtApellidos.Text, int.Parse(txtEdad.Text));
      newPersona.id = persona.id;
      lst.Add(newPersona);
      persona.modificar();
      dgvPersonas.Items.Refresh();
      dgvPersonas.ItemsSource = lst;
      start();
    }
  }
}
