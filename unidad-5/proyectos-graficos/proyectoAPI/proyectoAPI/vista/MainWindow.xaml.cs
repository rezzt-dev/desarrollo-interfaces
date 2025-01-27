using Newtonsoft.Json;
using proyectoAPI.controlador;
using proyectoAPI.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyectoAPI
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Controlador controlador;
    private List<ApiObject> objects;
    private ApiObject objeto;

    public MainWindow()
    {
      InitializeComponent();
      controlador = new Controlador();
    }

    private async void btnListar_ClickAsync(object sender, RoutedEventArgs e)
    {
      try
      {
        objects = await controlador.ListarObjetosAsync();
        lstResultado.Items.Clear();
        foreach (var obj in objects)
        {
          lstResultado.Items.Add($"ID: {obj.Id}, Name: {obj.Name}");
        }
      } catch (Exception ex) { 
        lstRespuesta.Text = ex.Message;
      }


    }

    private async void btnCargar_ClickAsync(object sender, RoutedEventArgs e)
    {
      try
      {
        await controlador.agregarNuevo();
        lstRespuesta.Text = "Objeto añadido con éxito.";
        btnListar_ClickAsync(null, null);
      } catch (Exception ex)
      {
        lstRespuesta.Text = ex.Message;
      }
    }

    private async void btnEliminar_ClickAsync(object sender, RoutedEventArgs e)
    {
      if (lstResultado.SelectedItem == null)
      {
        MessageBox.Show("Seleccione un objeto para borrar.");
        return;
      }

      // Obtener el ID del objeto seleccionado
      string selectedItem = lstResultado.SelectedItem.ToString();
      int id;
      try
      {
        id = int.Parse(selectedItem.Split(',')[0].Split(':')[1].Trim());
      }
      catch
      {
        MessageBox.Show("No se pudo obtener el ID del objeto seleccionado.");
        return;
      }

      try
      {
        await controlador.BorrarObjecto(id);
        MessageBox.Show("Objeto borrado con éxito.");
        btnListar_ClickAsync(null, null); // Recargar la lista
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error al borrar el objeto: {ex.Message}");
      }
    }
  }
}
