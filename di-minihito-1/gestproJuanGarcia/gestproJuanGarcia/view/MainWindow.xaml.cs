﻿using gestproJuanGarcia.domain;
using gestproJuanGarcia.persistence;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
  public partial class MainWindow : Window
  {
    private List<Proyecto> listProyectos;
    private Proyecto proyecto;

    private List<Usuario> listUsarios;
    private Usuario usuario;

    private List<Rol> listRol;
    private Rol rol;

    private List<Empleado> listEmpleado;
    private Empleado empleado;

    private List<ProyectoEmpleado> listProyectoEmpleado;
    private ProyectoEmpleado proyectoEmpleado;

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

    private void tboxBusquedaEmpleados_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        realizarBusquedaEmpleados();
      }
    }

    private void tboxBusquedaEmpleados_TextChanged(object sender, TextChangedEventArgs e)
    {
      realizarBusquedaEmpleados();
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

    private string encryptPassMD5(string inputRawPassword)
    {
      MD5 md5 = MD5.Create();
      byte[] inputBytes = Encoding.UTF8.GetBytes(inputRawPassword);
      byte[] hashBytes = md5.ComputeHash(inputBytes);
      return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
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

    private List<String> cargarNombresRoles()
    {
      List<String> roles = new List<String>();
      roles = listRol.Select(aux => aux.NombreRol).ToList();
      return roles;
    }

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
  }
}
