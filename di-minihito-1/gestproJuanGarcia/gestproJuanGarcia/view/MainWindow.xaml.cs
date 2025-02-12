using gestproJuanGarcia.domain;
using gestproJuanGarcia.domain.reportsDomain;
using gestproJuanGarcia.persistence;
using gestproJuanGarcia.reports.reportCostesIngresoProyecto;
using gestproJuanGarcia.reports.reportNumPerfilProyecto;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace gestproJuanGarcia
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  /// <seealso cref="System.Windows.Window" />
  /// <seealso cref="System.Windows.Markup.IComponentConnector" />
  public partial class MainWindow : Window
  {
    /// <summary>
    /// The list proyectos
    /// </summary>
    private List<Proyecto> listProyectos;
    /// <summary>
    /// The proyecto
    /// </summary>
    private Proyecto proyecto;

    /// <summary>
    /// The list usarios
    /// </summary>
    private List<Usuario> listUsarios;
    /// <summary>
    /// The usuario
    /// </summary>
    private Usuario usuario;

    /// <summary>
    /// The list rol
    /// </summary>
    private List<Rol> listRol;
    /// <summary>
    /// The rol
    /// </summary>
    private Rol rol;

    /// <summary>
    /// The list empleado
    /// </summary>
    private List<Empleado> listEmpleado;
    /// <summary>
    /// The empleado
    /// </summary>
    private Empleado empleado;

    /// <summary>
    /// The list proyecto empleado
    /// </summary>
    private List<ProyectoEmpleado> listProyectoEmpleado;
    /// <summary>
    /// The proyecto empleado
    /// </summary>
    private ProyectoEmpleado proyectoEmpleado;

    /// <summary>
    /// The data table informes1
    /// </summary>
    private DataTable dataTableInformes1;
    /// <summary>
    /// The data table informes2
    /// </summary>
    private DataTable dataTableInformes2;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      listProyectos = new List<Proyecto>();
      proyecto = new Proyecto();

      listUsarios = new List<Usuario>();
      usuario = new Usuario();

      listRol = new List<Rol>();
      rol = new Rol();

      listEmpleado = new List<Empleado>();
      empleado = new Empleado();

      listProyectoEmpleado = new List<ProyectoEmpleado>();
      proyectoEmpleado = new ProyectoEmpleado();

      listProyectos = proyecto.getProyectList();
      dataProyectos.ItemsSource = listProyectos;

      listUsarios = usuario.getUsuarioList();
      dataUsuarios.ItemsSource = listUsarios;

      listRol = rol.getRolList();
      comboBoxRoles.ItemsSource = cargarNombresRoles();
      comboBoxRoles.SelectedIndex = 0;

      listEmpleado = empleado.getEmpleadoList();
      dataEmpleados.ItemsSource = listEmpleado;

      comboBoxUsuarios.ItemsSource = listUsarios.Select(u => u.NombreUsuario).ToList();
      comboBoxUsuarios.SelectedIndex = 0;

      listProyectoEmpleado = proyectoEmpleado.getProyectoEmpleadoList();
      dataGestionEconomica.ItemsSource = listProyectoEmpleado;
      comboBoxEmpleadosGEco.ItemsSource = listEmpleado.Select(em => em.NombreEmpleado).ToList();
      comboBoxProyectosGEco.ItemsSource = listProyectos.Select(pro => pro.Codigo).ToList();

      comboBoxProyectosGEco.SelectedIndex = 0;
      comboBoxEmpleadosGEco.SelectedIndex = 0;

      dataTableInformes1 = new DataTable("CostesProyecto");
      dataTableInformes2 = new DataTable("PerfilesProyectos");

      dataTableInformes1.Columns.Add("CodigoProyecto");
      dataTableInformes1.Columns.Add("Fecha");
      dataTableInformes1.Columns.Add("CosteTotal");

      dataTableInformes2.Columns.Add("CodigoProyecto");
      dataTableInformes2.Columns.Add("Fecha");
      dataTableInformes2.Columns.Add("PerfilEmpleado");
      dataTableInformes2.Columns.Add("NumeroPersonas");
      dataTableInformes2.Columns.Add("TotalPersonas");

      btnAgregarProyecto.IsEnabled = true;
      btnEliminarProyecto.IsEnabled = false;
      btnModificarProyecto.IsEnabled = false;

      btnDarAltaUsuario.IsEnabled = true;
      btnEliminarUsuario.IsEnabled = false;
      btnActualizarPassUsuario.IsEnabled = false;

      cboxUsuarioRegistradoSI.IsChecked = false;
      cboxUsuarioRegistradoNO.IsChecked = false;


    }

    // metodo | "cleanData" | limpia los campos
    /// <summary>
    /// Cleans the data.
    /// </summary>
    private void cleanData()
    {
      txtCodigoProyectoInput.Text = "";
      txtNombreProyectoInput.Text = "";
      txtDescripcionProyectoInput.Text = "";
      txtPresupuestoProyecto.Text = "";

      txtNombreUsuario.IsReadOnly = false;
      txtNombreUsuario.Text = "";
      txtPassUsuario.Text = "";

      txtNombreEmpleado.Text = "";
      txtApellidosEmpleado.Text = "";
      txtNombreUsuario2.Text = "";
      txtPassUsuario2.Text = "";


    }

    /// <summary>
    /// Handles the SelectionChanged event of the dataProyectos control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Click event of the btnAgregarProyecto control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Click event of the btnModificarProyecto control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Click event of the btnEliminarProyecto control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Selected event of the dataProyectos control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void dataProyectos_Selected(object sender, RoutedEventArgs e)
    {
      Proyecto selectProyecto = (Proyecto)dataProyectos.SelectedItem;
      txtCodigoProyectoInput.Text = selectProyecto.Codigo;
      txtNombreProyectoInput.Text = selectProyecto.Nombre;
      txtDescripcionProyectoInput.Text = selectProyecto.Descripcion;
      txtPresupuestoProyecto.Text = selectProyecto.Presupuesto.ToString();
    }

    /// <summary>
    /// Handles the KeyDown event of the tboxBusqueda control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    private void tboxBusqueda_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        RealizarBusqueda();
      }
    }

    /// <summary>
    /// Handles the TextChanged event of the tboxBusqueda control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
    private void tboxBusqueda_TextChanged(object sender, TextChangedEventArgs e)
    {
      RealizarBusqueda();
    }

    /// <summary>
    /// Handles the KeyDown event of the tboxBusquedaEmpleados control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    private void tboxBusquedaEmpleados_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        realizarBusquedaEmpleados();
      }
    }

    /// <summary>
    /// Handles the TextChanged event of the tboxBusquedaEmpleados control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
    private void tboxBusquedaEmpleados_TextChanged(object sender, TextChangedEventArgs e)
    {
      realizarBusquedaEmpleados();
    }

    /// <summary>
    /// Realizars the busqueda.
    /// </summary>
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

    /// <summary>
    /// Realizars the busqueda empleados.
    /// </summary>
    private void realizarBusquedaEmpleados()
    {
      string searchText = txtBusquedaEmpleado.Text.Trim().ToLower();

      if (listEmpleado == null)
      {
        return;
      }

      if (string.IsNullOrEmpty(searchText))
      {
        dataEmpleados.ItemsSource = listEmpleado;
      }
      else
      {
        var listaFiltrada = listEmpleado.Where(e => e != null && (e.NombreEmpleado.ToLower().Contains(searchText) || e.ApellidosEmpleado.ToLower().Contains(searchText))).ToList();
        dataEmpleados.ItemsSource = listaFiltrada;
      }

      dataEmpleados.Items.Refresh();
    }

    /// <summary>
    /// Handles the Click event of the btnCargarDatos control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Encrypts the pass m d5.
    /// </summary>
    /// <param name="inputRawPassword">The input raw password.</param>
    /// <returns></returns>
    private string encryptPassMD5(string inputRawPassword)
    {
      MD5 md5 = MD5.Create();
      byte[] inputBytes = Encoding.UTF8.GetBytes(inputRawPassword);
      byte[] hashBytes = md5.ComputeHash(inputBytes);
      return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Handles the Click event of the btnProyectos control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnProyectos_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiProyecto;
    }

    /// <summary>
    /// Handles the Click event of the btnEmpleados control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnEmpleados_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiEmpleados;
    }

    /// <summary>
    /// Handles the Click event of the btnGEconomica control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnGEconomica_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiGEconomica;
    }

    /// <summary>
    /// Handles the Click event of the btnEstadisticas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnEstadisticas_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiEstadisticas;
    }

    /// <summary>
    /// Handles the Click event of the btnUsuarios control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnUsuarios_Click(object sender, RoutedEventArgs e)
    {
      tbcMenu.SelectedItem = tbiUsuarios;
    }

    /// <summary>
    /// Handles the SelectionChanged event of the dataUsuarios control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
    private void dataUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (dataUsuarios.SelectedItems.Count > 0)
      {
        Usuario usuario = (Usuario)dataUsuarios.SelectedItems[0];
        txtNombreUsuario.Text = usuario.NombreUsuario;
        txtNombreUsuario.IsReadOnly = true;
        txtPassUsuario.Text = usuario.PassUsuario;

        btnDarAltaUsuario.IsEnabled = true;
        btnEliminarUsuario.IsEnabled = true;
        btnActualizarPassUsuario.IsEnabled = true;
      }
    }

    /// <summary>
    /// Handles the Click event of the btnDarAltaUsuario control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnDarAltaUsuario_Click(object sender, RoutedEventArgs e)
    {
      if (System.Windows.MessageBox.Show("¿Quieres agregar un usuario?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        try
        {
          Usuario nuevoUsuario = new Usuario(
            txtNombreUsuario.Text,
            encryptPassMD5(txtPassUsuario.Text)
          );

          nuevoUsuario.insertar();

          listUsarios.Add(nuevoUsuario);
          dataUsuarios.Items.Refresh();
          cleanData();
        }
        catch (Exception ex)
        {
          System.Windows.MessageBox.Show($"Error al crear el usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the btnEliminarUsuario control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnEliminarUsuario_Click(object sender, RoutedEventArgs e)
    {
      Usuario selectUsuario = (Usuario)dataUsuarios.SelectedItem;

      if (System.Windows.MessageBox.Show("¿Quieres eliminar el usuario?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (dataUsuarios.SelectedItem != null)
        {
          selectUsuario.eliminar();
          listUsarios.Remove(selectUsuario);
        }
        dataUsuarios.Items.Refresh();
        cleanData();
      }
    }

    /// <summary>
    /// Handles the Click event of the btnActualizarPassUsuario control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnActualizarPassUsuario_Click(object sender, RoutedEventArgs e)
    {
      Usuario selectUsuario = (Usuario)dataUsuarios.SelectedItem;
      Usuario tempUsuario = new Usuario();

      if (selectUsuario != null)
      {
        tempUsuario.IdUsuario = selectUsuario.IdUsuario;
        tempUsuario.NombreUsuario = txtNombreUsuario.Text;
        tempUsuario.PassUsuario = encryptPassMD5(txtPassUsuario.Text);

        tempUsuario.modificar();
        dataUsuarios.Items.Refresh();
        cleanData();
      }
      else
      {
        System.Windows.MessageBox.Show("El usuario debe ser válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    /// <summary>
    /// Cargars the nombres roles.
    /// </summary>
    /// <returns></returns>
    private List<String> cargarNombresRoles()
    {
      List<String> roles = new List<String>();
      roles = listRol.Select(aux => aux.NombreRol).ToList();
      return roles;
    }

    /// <summary>
    /// Handles the SelectionChanged event of the dataEmpleados control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
    private void dataEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      //      String nombreRol = (String)comboBoxRoles.Items[comboBoxRoles.SelectedIndex];
      //      Rol rolSelected = listRol.Where(r => r.NombreRol == nombreRol).FirstOrDefault();

      if (dataEmpleados.SelectedItems.Count > 0)
      {
        Empleado empleado = (Empleado)dataEmpleados.SelectedItems[0];
        txtNombreEmpleado.Text = empleado.NombreEmpleado;
        txtApellidosEmpleado.Text = empleado.ApellidosEmpleado;
        Rol tempRol = listRol.Where(aux => aux.IdRol == empleado.IdRol).FirstOrDefault();
        comboBoxRoles.SelectedItem = tempRol.NombreRol;
        btnCSREmpleado.Value = empleado.CsrEmpleado;

        if (listUsarios.Where(aux => aux.IdUsuario == empleado.IdUsuario).FirstOrDefault() != null)
        {
          cboxUsuarioRegistradoSI.IsChecked = true;
          Usuario auxUsuario = listUsarios.Where(u => u.IdUsuario == empleado.IdUsuario).FirstOrDefault();

          comboBoxUsuarios.SelectedItem = auxUsuario.NombreUsuario;
          txtNombreUsuario2.Text = auxUsuario.NombreUsuario;
          txtPassUsuario2.Text = auxUsuario.PassUsuario;
        }
        else
        {
          cboxUsuarioRegistradoNO.IsChecked = true;
        }

        btnAgregarEmpleado.IsEnabled = true;
        btnEliminarEmpleado.IsEnabled = true;
        btnModificarEmpleado.IsEnabled = true;
      }
    }

    /// <summary>
    /// Handles the Click event of the btnAgregarEmpleado control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnAgregarEmpleado_Click(object sender, RoutedEventArgs e)
    {
      if (System.Windows.MessageBox.Show("¿Quieres agregar un empleado?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        try
        {
          Rol auxRol = listRol.Where(r => r.NombreRol == (String)comboBoxRoles.SelectedItem).FirstOrDefault();
          Empleado empleado = new Empleado(txtNombreEmpleado.Text, txtApellidosEmpleado.Text, Convert.ToInt32(btnCSREmpleado.Text), auxRol.IdRol);

          empleado.insertar();

          listEmpleado.Add(empleado);
          dataEmpleados.Items.Refresh();
          cleanData();
        }
        catch (Exception ex)
        {
          System.Windows.MessageBox.Show($"Error al crear el empleado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
    }

    /// <summary>
    /// Handles the Click event of the btnModificarEmpleado control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnModificarEmpleado_Click(object sender, RoutedEventArgs e)
    {
      Empleado selectEmpleado = (Empleado)dataEmpleados.SelectedItem;

      if (selectEmpleado != null)
      {
        txtNombreEmpleado.Text = selectEmpleado.NombreEmpleado;
        txtApellidosEmpleado.Text = selectEmpleado.ApellidosEmpleado;
        Rol auxRol = listRol.Where(r => r.IdRol == selectEmpleado.IdRol).FirstOrDefault();
        comboBoxRoles.SelectedItem = auxRol.NombreRol;
        btnCSREmpleado.Text = Convert.ToString(selectEmpleado.CsrEmpleado);

        if (selectEmpleado.IdEmpleado != 1)
        {
          cboxUsuarioRegistradoSI.IsChecked = true;
          cboxUsuarioRegistradoNO.IsChecked = false;
        }
        else
        {
          cboxUsuarioRegistradoNO.IsChecked = true;
          cboxUsuarioRegistradoSI.IsChecked = false;
        }

        selectEmpleado.NombreEmpleado = txtNombreEmpleado.Text;
        selectEmpleado.ApellidosEmpleado = txtApellidosEmpleado.Text;
        selectEmpleado.IdRol = auxRol.IdRol;
        selectEmpleado.IdUsuario = listUsarios.Where(u => u.NombreUsuario == (string)comboBoxUsuarios.SelectedItem).FirstOrDefault().IdUsuario;
        selectEmpleado.CsrEmpleado = Convert.ToInt32(btnCSREmpleado.Text);

        selectEmpleado.modificar();
        dataEmpleados.Items.Refresh();
      }
      else
      {
        System.Windows.MessageBox.Show("El usuario debe ser válido.", "Error de entrada", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }

    /// <summary>
    /// Handles the Click event of the btnEliminarEmpleado control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
    {
      Empleado selectEmpleado = (Empleado)dataEmpleados.SelectedItem;

      if (System.Windows.MessageBox.Show("¿Quieres eliminar el empleado?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        if (dataEmpleados.SelectedItem != null)
        {
          selectEmpleado.eliminar();
          listEmpleado.Remove(selectEmpleado);
          dataEmpleados.Items.Refresh();
          cleanData();
        }
      }
    }

    /// <summary>
    /// Handles the SelectionChanged event of the comboBoxUsuarios control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
    private void comboBoxUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (comboBoxUsuarios.SelectedItem != null)
      {
        String nombreUsuario = (String)comboBoxUsuarios.SelectedItem;
        Usuario usuario = listUsarios.Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefault();

        txtNombreUsuario.Text = usuario.NombreUsuario;
        txtPassUsuario.Text = usuario.PassUsuario;
      }
      else
      {
        comboBoxUsuarios.ItemsSource = listUsarios.Select(u => u.NombreUsuario).ToList();
      }
    }

    /// <summary>
    /// Handles the Click event of the btnRegistarUsuarioEmpleado control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnRegistarUsuarioEmpleado_Click(object sender, RoutedEventArgs e)
    {
      Empleado empleado = (Empleado)dataEmpleados.SelectedItem;

      if (System.Windows.MessageBox.Show("¿Quieres asignar este usuario al empleado?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
      {
        try
        {
          String nombreUsuario = (String)comboBoxUsuarios.SelectedItem;
          Usuario usuario = listUsarios.Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefault();

          empleado.IdUsuario = usuario.IdUsuario;
          empleado.modificar();

          dataEmpleados.Items.Refresh();
          cleanData();
        }
        catch (Exception ex)
        {
          System.Windows.MessageBox.Show($"Error al asignar el usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
    }

    /// <summary>
    /// Handles the ClickAsync event of the btnImportarHoras control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btnImportarHoras_ClickAsync(object sender, RoutedEventArgs e)
    {
      if (!DateTime.TryParse(dateFechaGEco.Text, out DateTime fechaImport))
      {
        System.Windows.MessageBox.Show("La fecha ingresada no es válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      ControladorCalendarific controladorAnio = new ControladorCalendarific();
      try
      {
        var respuesta = await controladorAnio.ObtenerDiasFestivos("ES", fechaImport.Year);
        if (respuesta == null || respuesta.DiasFestivos == null || !respuesta.DiasFestivos.Any())
        {
          System.Windows.MessageBox.Show("No se encontraron días festivos en la API.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        else
        {
          Console.WriteLine("Días festivos obtenidos:");
          foreach (var festivo in respuesta.DiasFestivos)
          {
            Console.WriteLine($"- {festivo.Nombre}: {festivo.Fecha:yyyy-MM-dd}");
          }
        }

        bool esFestivo = respuesta?.DiasFestivos?.Any(d => d.Fecha.Date == fechaImport.Date) ?? false;
        if (esFestivo)
        {
          System.Windows.MessageBox.Show("Error, el día seleccionado es festivo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          return;
        }
      }
      catch (Exception ex)
      {
        System.Windows.MessageBox.Show($"Error al obtener días festivos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      // Obtener empleado seleccionado
      Empleado tempEmple = listEmpleado
          .FirstOrDefault(aux => aux.NombreEmpleado == (string)comboBoxEmpleadosGEco.SelectedItem);

      if (tempEmple == null)
      {
        System.Windows.MessageBox.Show("Error: No se encontró el empleado seleccionado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      // Obtener proyecto seleccionado
      Proyecto tempProyect = listProyectos
          .FirstOrDefault(aux => aux.Codigo == (string)comboBoxProyectosGEco.SelectedItem);

      if (tempProyect == null)
      {
        System.Windows.MessageBox.Show("Error: No se encontró el proyecto seleccionado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      // Validar horas ingresadas
      if (!int.TryParse(btnHorasEmple.Text, out int horasTrabajadas) || horasTrabajadas <= 0)
      {
        System.Windows.MessageBox.Show("Ingrese un número válido de horas trabajadas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }

      // Crear y guardar la entrada de trabajo
      try
      {
        ProyectoEmpleado auxProyectoEmpleado = new ProyectoEmpleado(
            horasTrabajadas,
            tempEmple.CsrEmpleado * horasTrabajadas,
            fechaImport,
            tempProyect.Id,
            tempEmple.IdEmpleado
        );

        auxProyectoEmpleado.insertar();
        listProyectoEmpleado.Add(auxProyectoEmpleado);
        dataGestionEconomica.Items.Refresh();
        cleanData();

        System.Windows.MessageBox.Show("Horas importadas correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (Exception ex)
      {
        System.Windows.MessageBox.Show($"Error al registrar las horas: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    /// <summary>
    /// Handles the ClickAsync event of the btnModificarHoras control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btnModificarHoras_ClickAsync(object sender, RoutedEventArgs e)
    {
      if (dataGestionEconomica.SelectedItem is ProyectoEmpleado seleccionado)
      {
        listProyectoEmpleado.Remove(seleccionado);
        if (!DateTime.TryParse(dateFechaGEco.Text, out DateTime fechaImport))
        {
          System.Windows.MessageBox.Show("La fecha ingresada no es válida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          return;
        }

        ControladorCalendarific controladorAnio = new ControladorCalendarific();
        try
        {
          var respuesta = await controladorAnio.ObtenerDiasFestivos("ES", fechaImport.Year);
          bool esFestivo = respuesta?.DiasFestivos?.Any(d => d.Fecha.Date == fechaImport.Date) ?? false;
          if (esFestivo)
          {
            System.Windows.MessageBox.Show("Error, el día seleccionado es festivo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
          }
        }
        catch (Exception ex)
        {
          System.Windows.MessageBox.Show($"Error al verificar días festivos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          return;
        }

        if (!int.TryParse(btnHorasEmple.Text, out int horasTrabajadas) || horasTrabajadas <= 0)
        {
          System.Windows.MessageBox.Show("Ingrese un número válido de horas trabajadas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
          return;
        }

        seleccionado.NumHoras = horasTrabajadas;
        seleccionado.Fecha = fechaImport;
        seleccionado.Costes = seleccionado.NumHoras * seleccionado.Costes;
        seleccionado.modificar();
        listProyectoEmpleado.Add(seleccionado);
        System.Windows.MessageBox.Show("Registro modificado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

      }
      else
      {
        System.Windows.MessageBox.Show("Seleccione un registro para modificar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      dataGestionEconomica.Items.Refresh();
      cleanData();
    }

    /// <summary>
    /// Handles the Click event of the btnEliminarHoras control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnEliminarHoras_Click(object sender, RoutedEventArgs e)
    {
      if (dataGestionEconomica.SelectedItem is ProyectoEmpleado seleccionado)
      {
        try
        {
          listProyectoEmpleado.Remove(seleccionado);
          seleccionado.eliminar();
          System.Windows.MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
          dataGestionEconomica.Items.Refresh();
          cleanData();
        }
        catch (Exception ex)
        {
          System.Windows.MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      }
      else
      {
        System.Windows.MessageBox.Show("Seleccione un registro para eliminar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    /// <summary>
    /// Recogers the datos informe costes proyecto.
    /// </summary>
    /// <returns></returns>
    private List<CostesProyecto> recogerDatosInformeCostesProyecto ()
    {
      List<CostesProyecto> listaCostesProyecto = new List<CostesProyecto>();
      int sumaCosteTotal = 0;


      foreach (ProyectoEmpleado auxProyectEmple in listProyectoEmpleado)
      {
        String auxFecha = auxProyectEmple.Fecha.Month + " " + auxProyectEmple.Fecha.Year;
        Proyecto auxProyect = listProyectos.Where(p => p.Id == auxProyectEmple.IdProyecto).FirstOrDefault();

        if (auxProyect != null)
        {
          foreach (Empleado auxEmple in listEmpleado)
          {
            Empleado auxEmpleado2 = listEmpleado.Where(em => em.IdEmpleado == auxProyectEmple.IdEmpleado).FirstOrDefault();
            if (auxEmpleado2 != null)
            {
              sumaCosteTotal += (auxEmpleado2.CsrEmpleado * auxProyectEmple.NumHoras);
            }
          }

          if (listaCostesProyecto.Where(lcp => lcp.CodigoProyecto.Equals(auxProyect.Codigo) && lcp.FechaProyecto.Equals(auxFecha)) != null)
          {
            CostesProyecto auxCostesProyecto = listaCostesProyecto.Where(lcp => lcp.CodigoProyecto.Equals(auxProyect.Codigo) && lcp.FechaProyecto.Equals(auxFecha)).FirstOrDefault();
            listaCostesProyecto.Remove(auxCostesProyecto);
          }

          String codigoProy = auxProyect.Codigo;
          String fechaProyec = auxProyectEmple.Fecha.Month + " " + auxProyectEmple.Fecha.Year;
          int costeTotal = sumaCosteTotal;

          CostesProyecto auxCostProy2 = new CostesProyecto(codigoProy, fechaProyec, costeTotal);
          listaCostesProyecto.Add(auxCostProy2);
        }
        sumaCosteTotal = 0;
      }

      return listaCostesProyecto;
    }

    /// <summary>Recogers the datos informe perfiles proyectos.</summary>
    /// <returns>
    ///   <br />
    /// </returns>
    private List<PerfilesProyectos> recogerDatosInformePerfilesProyectos ()
    {
      List<PerfilesProyectos> listaPerfilesProyecto = new List<PerfilesProyectos>();
      Rol helperRol = new Rol();
      int cantidadPersonas = 0;

      foreach (ProyectoEmpleado auxProyectEmple in listProyectoEmpleado)
      {
        String auxFecha = auxProyectEmple.Fecha.Month + " " + auxProyectEmple.Fecha.Year;
        Proyecto auxProyect = listProyectos.Where(p => p.Id == auxProyectEmple.IdProyecto).FirstOrDefault();

        if (auxProyect != null)
        {
          foreach (Rol auxRol in listRol)
          {
            helperRol = auxRol;
            List<Empleado> listEmpleadoForRol = listEmpleado.Where(em => em.IdRol == auxRol.IdRol).ToList();
            cantidadPersonas += listEmpleadoForRol.Count();
          }
        }

        if (listaPerfilesProyecto.Where(lpp => lpp.FechaProyecto.Equals(auxFecha)) != null)
        {
          PerfilesProyectos auxPerfilProyecto = listaPerfilesProyecto.Where(lpp => lpp.CodigoProyecto.Equals(auxProyect.Codigo) && lpp.FechaProyecto.Equals(auxFecha) && lpp.PerfilEmpleado.Equals(helperRol.NombreRol)).FirstOrDefault();
          listaPerfilesProyecto.Remove(auxPerfilProyecto);
        }

        String codProyecto = auxProyect.Codigo;
        String fechaProyec = auxProyectEmple.Fecha.Month + " " + auxProyectEmple.Fecha.Year;
        String perfilEmpleado = helperRol.NombreRol;
        int numPersonasRol = cantidadPersonas;

        PerfilesProyectos auxPerfilProyecto2 = new PerfilesProyectos(codProyecto, fechaProyec, perfilEmpleado, numPersonasRol);
        listaPerfilesProyecto.Add(auxPerfilProyecto2);
        cantidadPersonas = 0;
      }

      return listaPerfilesProyecto;
    }

    /// <summary>
    /// Handles the Click event of the btnCargarInforme control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void btnCargarInforme_Click(object sender, RoutedEventArgs e)
    {
      switch (comboxInformes.SelectedIndex)
      {
        case 1:
          List<PerfilesProyectos> perfilesProyectos = recogerDatosInformePerfilesProyectos();
          int totalPersonas = 0;

          foreach (PerfilesProyectos perf in perfilesProyectos)
          {
            totalPersonas += perf.NumPersonas;
          }

          foreach (PerfilesProyectos perf in perfilesProyectos)
          {
            DataRow row = dataTableInformes2.NewRow();
            row["CodigoProyecto"] = perf.CodigoProyecto;
            row["Fecha"] = perf.FechaProyecto;
            row["PerfilEmpleado"] = perf.PerfilEmpleado;
            row["NumeroPersonas"] = perf.NumPersonas;
            dataTableInformes2.Rows.Add(row);
          }

          DataRow row2 = dataTableInformes2.NewRow();
          row2["TotalPersonas"] = totalPersonas;

          reportPerfilesProyectos reportPerfiles = new reportPerfilesProyectos();

          if (reportPerfiles.Database.Tables["PerfilesProyectos"] == null)
          {
            System.Windows.MessageBox.Show("Error: La tabla 'DataTable1' no existe en el informe.");
            return;
          }

          reportPerfiles.Database.Tables["PerfilesProyectos"].SetDataSource(dataTableInformes2);

          if (reportViewer.ViewerCore != null)
          {
            reportViewer.ViewerCore.ReportSource = reportPerfiles;
          }
          else { }
          break;

        default:
          List<CostesProyecto> costesProyectos = recogerDatosInformeCostesProyecto();

          foreach (CostesProyecto cost in costesProyectos)
          {
            DataRow row = dataTableInformes1.NewRow();
            row["CodigoProyecto"] = cost.CodigoProyecto;
            row["Fecha"] = cost.FechaProyecto;
            row["CosteTotal"] = cost.CosteTotal;
            dataTableInformes1.Rows.Add(row);
          }

          reportCostesProyectos reportCostes = new reportCostesProyectos();

          if (reportCostes.Database.Tables["CostesProyecto"] == null)
          {
            System.Windows.MessageBox.Show("Error: La tabla 'DataTable1' no existe en el informe.");
            return;
          }

          reportCostes.Database.Tables["CostesProyecto"].SetDataSource(dataTableInformes1);

          if (reportViewer.ViewerCore != null)
          {
            reportViewer.ViewerCore.ReportSource = reportCostes;
          }
          else { }
          break;
      }
    }
  }
}
