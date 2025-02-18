using Gestpro_JoseAngelAguilar.domain;
using Gestpro_JoseAngelAguilar.persistance.manages;
using Gestpro_JoseAngelAguilar.reports;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace Gestpro_JoseAngelAguilar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The number
        /// </summary>
        public static int num = 0;
        /// <summary>
        /// The lista proyectos
        /// </summary>
        private List<Proyecto> listaProyectos;
        /// <summary>
        /// The lista usuarios
        /// </summary>
        private List<Usuario> listaUsuarios;
        /// <summary>
        /// The lista empleado
        /// </summary>
        private List<Empleado> listaEmpleado;
        /// <summary>
        /// The lista registro horas
        /// </summary>
        private List<RegistroHoras> listaRegistroHoras;
        /// <summary>
        /// The random
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Proyecto proyecto = new Proyecto();
            proyecto.readP();
            tabla.ItemsSource = proyecto.getListProyectos();
            listaProyectos = (List<Proyecto>)tabla.ItemsSource;
            inicializarUsuarios();
            inicializarEmpleados();
            inicializarGEconomica();
        }

        /// <summary>
        /// Inicializars the empleados.
        /// </summary>
        private void inicializarEmpleados()
        {
            Empleado empleado = new Empleado();
            empleado.readEmpleados();
            tablaEmpleados.ItemsSource = empleado.getListUsuarios();
            listaEmpleado = (List<Empleado>) tablaEmpleados.ItemsSource;
        }

        /// <summary>
        /// Inicializars the usuarios.
        /// </summary>
        private void inicializarUsuarios()
        {
            Usuario usuario = new Usuario();
            usuario.readUsers();
            tablaUsuario.ItemsSource = usuario.getListUsuarios();
            listaUsuarios = (List<Usuario>)tablaUsuario.ItemsSource;
            List<string> listaUsersNombre = new List<string>();
            foreach (Usuario user in listaUsuarios) {
                listaUsersNombre.Add(user.username);
            }
            cboxUsers.ItemsSource = listaUsersNombre;
        }
        /// <summary>
        /// Inicializars the g economica.
        /// </summary>
        private void inicializarGEconomica()
        {
            List<String> codigoProyecto = new List<String>();
            foreach (Proyecto proy in listaProyectos) {
                codigoProyecto.Add(proy.codProyecto);
            }
            List<String> empleadosNombre = new List<String>();
            foreach (Empleado empleado in listaEmpleado)
            {
                empleadosNombre.Add(empleado.nameEmpleado);
            }
            boxNombreGEco.ItemsSource = empleadosNombre;
            boxCproyectoGEco.ItemsSource = codigoProyecto;

            RegistroHoras horas = new RegistroHoras();
            horas.readRegistroHoras();
            tablaGEco.ItemsSource = horas.getListHoras();
            listaRegistroHoras = (List<RegistroHoras>)tablaGEco.ItemsSource;
        }


        /// <summary>
        /// Handles the Click event of the btnAnadir control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAnadir_Click(object sender, RoutedEventArgs e) {
            if (btnModificar.IsEnabled == false)
            {

                if (tabla.SelectedItem != null)
                {
                    //MODIFICAR
                    Proyecto pselected = (Proyecto)tabla.SelectedItem;

                    List<Proyecto> listProyecto = (List<Proyecto>)tabla.ItemsSource;
                    listProyecto[tabla.SelectedIndex].codProyecto = boxCproyecto.Text;
                    listProyecto[tabla.SelectedIndex].nombre = boxNombre.Text;
                    listProyecto[tabla.SelectedIndex].FechaInicio = boxFechaI.SelectedDate.Value;
                    listProyecto[tabla.SelectedIndex].FechaFin = boxFechaF.SelectedDate.Value;

                    int idProyectoSelected = pselected.id;
                    string nombreP = boxNombre.Text;
                    string codP = boxCproyecto.Text;
                    DateTime fechaI = boxFechaI.SelectedDate.Value;
                    DateTime fechaF = boxFechaF.SelectedDate.Value;

                    Proyecto p = new Proyecto(idProyectoSelected, codP, nombreP, fechaI, fechaF);

                    p.update();

                    tabla.Items.Refresh();

                    btnModificar.IsEnabled = true;
                    btnEliminar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un proyecto válido para modificar.");
                    return;
                }

                //tabla.Items.Refresh();
                //listaProyectos.Add(new Proyecto(boxCproyecto.Text, boxNombre.Text));
                tabla.Items.Refresh();
                boxCproyecto.Clear();
                boxNombre.Clear();
                boxFechaI.Text = "";
                boxFechaF.Text = "";
                btnModificar.IsEnabled = true;
                btnEliminar.IsEnabled = true;
                tabla.IsHitTestVisible = true;
                btnAnadir.Content = "Añadir";
            }
            else {
                if (boxCproyecto.Text != null && boxFechaI.SelectedDate != null
                    && boxFechaF.SelectedDate != null && boxNombre != null)
                {
                    if (listaProyectos.Where(p => p.nombre.Equals(boxNombre.Text) && p.codProyecto.Equals(boxCproyecto.Text)).ToList().Any() == false)
                    {
                        //Insertar nuevo
                        DateTime fechaI = boxFechaI.SelectedDate.Value;
                        DateTime fechaF = boxFechaF.SelectedDate.Value;
                        Proyecto p = new Proyecto(boxCproyecto.Text, boxNombre.Text, fechaI, fechaF);
                        p.insert();
                        ((List<Proyecto>)tabla.ItemsSource).Add(p);
                        tabla.Items.Refresh();

                    }
                    else
                    {
                        MessageBox.Show("El proyecto que intentas agragar ya existe");
                    }
                    tabla.Items.Refresh();
                    boxCproyecto.Clear();
                    boxFechaI.Text = "";
                    boxFechaF.Text = "";
                    boxNombre.Clear();
                }
                else {
                    MessageBox.Show("Todos los campos del formulario deben contener datos validos");
                }
            }
            
        }

        /// <summary>
        /// Handles the Click event of the btnModificar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (tabla.SelectedItem != null)
            {
                Proyecto proyectoElegido = (Proyecto)tabla.SelectedItem;
                boxCproyecto.Text = proyectoElegido.codProyecto;
                boxNombre.Text = proyectoElegido.nombre;
                boxFechaI.Text = proyectoElegido.FechaInicio.ToString();
                boxFechaF.Text = proyectoElegido.FechaFin.ToString();
                btnModificar.IsEnabled = false;
                btnEliminar.IsEnabled = false;
                tabla.IsHitTestVisible = false;
                btnAnadir.Content = "Actualizar Proyecto";
            }
            else {
                MessageBox.Show("Selecciona primero un Proyecto en la tabla");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnEliminar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Proyecto p = (Proyecto)tabla.SelectedItem;

            p.delete();
            List<Proyecto> lst = (List<Proyecto>)tabla.ItemsSource;
            lst.Remove(p);
            tabla.Items.Refresh();
            tabla.ItemsSource = lst;
        }

        /// <summary>
        /// Handles the Click event of the btnProyecto control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnProyecto_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabProyecto;

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
        /// Handles the TextChanged event of the search control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            RealizarBusqueda();
        }

        //Realiza la busqeuda 
        /// <summary>
        /// Realizars the busqueda.
        /// </summary>
        private void RealizarBusqueda()
        {
            string searchText = search.Text.Trim().ToLower();

            if (listaProyectos == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(searchText))
            {
                tabla.ItemsSource = listaProyectos;
            }
            else
            {
                var filteredList = listaProyectos.Where(proyecto =>
                    proyecto != null && (
                    proyecto.id.ToString().ToLower().Contains(searchText) ||
                    (proyecto.nombre != null && proyecto.nombre.ToLower().Contains(searchText)) ||
                    (proyecto.FechaInicio != null && proyecto.FechaInicio.ToString("yyyy-MM-dd").Contains(searchText)) ||
                    (proyecto.FechaFin != null && proyecto.FechaFin.ToString("yyyy-MM-dd").Contains(searchText))
                    )
                ).ToList();

                tabla.ItemsSource = filteredList;
            }

            tabla.Items.Refresh();
        }

        /// <summary>
        /// Handles the Click event of the btnSimular control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSimular_Click(object sender, RoutedEventArgs e)
        {
            Proyecto p = null;
            int lastnum = num + 20;
            for (int i = num; i < (lastnum); i++) {
                string company = getCompany(random.Next(1, 7));
                string codigo = "MTR" + (i+1) + company + DateTime.Now.Year.ToString()[2]+ DateTime.Now.Year.ToString()[3];
                p = new Proyecto(codigo,company,DateTime.Now,DateTime.Now);
                p.insert();
                ((List<Proyecto>)tabla.ItemsSource).Add(p);
                tabla.Items.Refresh();  
            }
            num = lastnum;
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns></returns>
        private string getCompany(int num) {
            string empresa="No especificada";
            switch (num)
            {
                case 1:
                    empresa = "Allegro";
                    break;

                case 2:
                    empresa = "Velneo";
                    break;

                case 3:
                    empresa = "SAP";
                    break;

                case 4:
                    empresa = "Naturgy";
                    break;

                case 5:
                    empresa = "Santander";
                    break;

                case 6:
                    empresa = "MutuaMadrileña";
                    break;
            }
            return empresa;
            
        }

        /// <summary>
        /// Handles the Click event of the btnAnadirUsuario control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAnadirUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (btnModificarContrasena.IsEnabled == false)
            {

                if (tablaUsuario.SelectedItem is Usuario usuarioSeleccionado)
                {
                    //MODIFICAR
                    Usuario uselected = (Usuario)tablaUsuario.SelectedItem;

                    List<Usuario> listUsuario = (List<Usuario>)tablaUsuario.ItemsSource;
                    listUsuario[tablaUsuario.SelectedIndex].password = boxPassword.Text;
                    listUsuario[tablaUsuario.SelectedIndex].username = boxUsuario.Text;

                    int idUsuarioSelected = uselected.id;
                    string usernameU = boxUsuario.Text;
                    string passwordU = boxPassword.Text;

                    Usuario u = new Usuario(usernameU,passwordU);

                    u.update();
                    listUsuario[tablaUsuario.SelectedIndex].password = u.password;
                    tablaUsuario.Items.Refresh();

                    btnModificarContrasena.IsEnabled = true;
                    btnEliminarUsuarop.IsEnabled = true;
                    boxUsuario.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un usuario válido para modificar.");
                    return;
                }

                tablaUsuario.Items.Refresh();
                boxUsuario.Clear();
                boxPassword.Clear();
                btnModificarContrasena.IsEnabled = true;
                btnEliminarUsuarop.IsEnabled = true;
                boxUsuario.IsEnabled = true;
                tablaUsuario.IsHitTestVisible = true;
                btnAnadirUsuario.Content = "Dar de alta";
            }
            else
            {
                if (listaUsuarios.Where(u => u.username.Equals(boxUsuario.Text)).ToList().Any() == false)
                {
                    //Insertar nuevo
                    Usuario u = new Usuario(boxUsuario.Text, boxPassword.Text);
                    u.insert();
                    ((List<Usuario>)tablaUsuario.ItemsSource).Add(u);
                    ((List<String>)cboxUsers.ItemsSource).Add(u.username);
                    tablaUsuario.Items.Refresh();

                }
                else
                {
                    MessageBox.Show("El usuario que intentas agragar ya existe");
                }
                tablaUsuario.Items.Refresh();
                cboxUsers.Items.Refresh();
                boxUsuario.Clear();
                boxPassword.Clear();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnEliminarUsuarop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEliminarUsuarop_Click(object sender, RoutedEventArgs e)
        {
            Usuario p = (Usuario)tablaUsuario.SelectedItem;

            p.delete();
            List<Usuario> lst = (List<Usuario>)tablaUsuario.ItemsSource;
            lst.Remove(p);
            ((List<String>)cboxUsers.ItemsSource).Remove(p.username);
            cboxUsers.Items.Refresh();
            tablaUsuario.Items.Refresh();
            tablaUsuario.ItemsSource = lst;
            
        }

        /// <summary>
        /// Handles the Click event of the btnModificarContrasena control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModificarContrasena_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarioElegido = (Usuario)tablaUsuario.SelectedItem;
            boxUsuario.Text = usuarioElegido.username;
            boxPassword.Text = usuarioElegido.password;
            btnModificarContrasena.IsEnabled = false;
            btnEliminarUsuarop.IsEnabled = false;
            boxUsuario.IsEnabled = false;
            tablaUsuario.IsHitTestVisible = false;
            btnAnadirUsuario.Content = "Actualizar contraseña";
        }

        /// <summary>
        /// Handles the Click event of the btnUsuarios control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabUsuarios;
        }

        /// <summary>
        /// Handles the Click event of the btnAnadirEmpleado control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAnadirEmpleado_Click(object sender, RoutedEventArgs e)

        {
            if (btnModificarEmpleado.IsEnabled == false)
            {

                if (tablaEmpleados.SelectedItem is Empleado empleadoSeleccionado)
                {
                    //MODIFICAR
                    Empleado eselected = (Empleado)tablaEmpleados.SelectedItem;
                    Usuario user = new Usuario();
                    
                    List<Empleado> lemple = (List<Empleado>)tablaEmpleados.ItemsSource;
                    lemple[tablaEmpleados.SelectedIndex].id = eselected.id;
                    lemple[tablaEmpleados.SelectedIndex].nameEmpleado = boxNombreEmple.Text;
                    lemple[tablaEmpleados.SelectedIndex].lastnameEmpleado = boxApellidos.Text;
                    lemple[tablaEmpleados.SelectedIndex].rol = getIdRol(cboxRol.Text);
                    lemple[tablaEmpleados.SelectedIndex].csr = Convert.ToInt32(tboxCSR.Text);
                    lemple[tablaEmpleados.SelectedIndex].idUser = user.findID(cboxUsers.Text);
                    lemple[tablaEmpleados.SelectedIndex].rolName = cboxRol.Text;
                    lemple[tablaEmpleados.SelectedIndex]._userName = cboxUsers.Text;

                    lemple[tablaEmpleados.SelectedIndex].update();
                    tablaEmpleados.Items.Refresh();

                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un empleado válido para modificar.");
                    return;
                }
                tablaEmpleados.Items.Refresh();
                boxApellidos.Clear();
                boxNombreEmple.Clear();
                tboxCSR.Clear();
                cboxRol.Text = "";
                cboxUsers.Text = "";
                btnModificarEmpleado.IsEnabled = true;
                btnEliminarEmpleado.IsEnabled = true;
                tablaEmpleados.IsHitTestVisible = true;
                btnAnadirEmpleado.Content = "Añadir";
            }
            else
            {
                //Insertar nuevo
                Empleado emple = new Empleado();
                Usuario user = new Usuario();
                string name = cboxUsers.Text;
                int idUser = user.findID(name);
                if (idUser == -1) {
                    MessageBox.Show("El usuario seleccionado para este empleado no es valido o no existe");
                }

                Empleado empleinsertar = new Empleado(boxNombreEmple.Text, boxApellidos.Text, Convert.ToDouble(tboxCSR.Text), idUser ,getIdRol(cboxRol.Text), cboxRol.Text,cboxUsers.Text);

                empleinsertar.insert();
                ((List<Empleado>)tablaEmpleados.ItemsSource).Add(empleinsertar);
                tablaUsuario.Items.Refresh();

                
                tablaEmpleados.Items.Refresh();
                boxApellidos.Clear();
                boxNombreEmple.Clear();
                tboxCSR.Clear();
                cboxRol.SelectedItem = null;
                cboxUsers.SelectedItem = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnEliminarEmpleado control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado emple = (Empleado)tablaEmpleados.SelectedItem;

            emple.delete();
            List<Empleado> lst = (List<Empleado>)tablaEmpleados.ItemsSource;
            lst.Remove(emple);
            tablaEmpleados.Items.Refresh();
            tablaEmpleados.ItemsSource = lst;
        }

        /// <summary>
        /// Handles the Click event of the btnModificarEmpleado control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModificarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleElegido = (Empleado)tablaEmpleados.SelectedItem;
            boxNombreEmple.Text = empleElegido.nameEmpleado;
            boxApellidos.Text = empleElegido.lastnameEmpleado;
            tboxCSR.Text = empleElegido.csr.ToString();
            btnEliminarEmpleado.IsEnabled = false;
            btnModificarEmpleado.IsEnabled = false ;
            cboxUsers.Text = empleElegido._userName.ToString();
            //---Esto tengo que hacerlo porque si no no muestra el nombre del Rol en el combobox
            //No entiendo bien por que, ya que justo arriba lo hago mucho mas sencillo para el username y funciona
            //sin embargo aqui no funcionaba
            cboxRol.SelectedItem = cboxRol.Items.Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == empleElegido.rolName);
            //------
            tablaEmpleados.IsHitTestVisible = false;
            btnAnadirUsuario.Content = "Actualizar empleado";
        }

        /// <summary>
        /// Handles the Click event of the btnEmpleados control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabEmpleados;
        }

        /// <summary>
        /// Handles the Checked event of the checkUserEmploy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void checkUserEmploy_Checked(object sender, RoutedEventArgs e)
        {
            cboxUsers.IsEnabled = false;
            tboxUserNameEmploy.IsEnabled = true;
            tboxUserPassEmploy.IsEnabled = true;
            btnRegistrarRecargarUsers.Foreground = new SolidColorBrush(Colors.White);
            btnRegistrarRecargarUsers.IsEnabled = true;
        }

        /// <summary>
        /// Handles the Checked event of the uncheckUserEmploy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void uncheckUserEmploy_Checked(object sender, RoutedEventArgs e)
        {
            cboxUsers.IsEnabled = true;
            tboxUserNameEmploy.IsEnabled = false;
            btnRegistrarRecargarUsers.Foreground = new SolidColorBrush(Colors.DimGray);
            tboxUserPassEmploy.IsEnabled = false;
            btnRegistrarRecargarUsers.IsEnabled = false;
        }


        /// <summary>
        /// Gets the identifier rol.
        /// </summary>
        /// <param name="rol">The rol.</param>
        /// <returns></returns>
        private int getIdRol(string rol) {
            int id = 0;
            switch (rol)
            {
                case "Programador Junior":
                    id=1;
                    break;

                case "Programador":
                    id = 2;
                    break;

                case "Programador Senior":
                    id = 3;
                    break;

                case "Jefe Proyecto":
                    id = 4;
                    break;
            }
            return id;
        }

        /// <summary>
        /// Handles the Click event of the btnGEconomica control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnGEconomica_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabGEconomica;
        }

        //Pendiente de implementar algunas cosas
        /// <summary>
        /// Handles the Click event of the btnAnadirGeco control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btnAnadirGeco_Click(object sender, RoutedEventArgs e)
        {
            if (btnModificarGEco.IsEnabled == false)
            {

                if (tablaGEco.SelectedItem is RegistroHoras rhseleccionado)
                {
                    //MODIFICAR

                    RegistroHoras rhelegido = (RegistroHoras)tablaGEco.SelectedItem;

                    List<RegistroHoras> listRegistroHoras= (List<RegistroHoras>)tablaGEco.ItemsSource;

                    listRegistroHoras[tablaGEco.SelectedIndex].nombreProyecto = boxCproyectoGEco.Text;
                    listRegistroHoras[tablaGEco.SelectedIndex].nombreEmpleado = boxNombreGEco.Text;
                    listRegistroHoras[tablaGEco.SelectedIndex].fecha = DateTime.Parse(boxFechaIGEco.Text);
                    listRegistroHoras[tablaGEco.SelectedIndex].horas = Convert.ToInt32(boxHorasGEco.Text);
                    listRegistroHoras[tablaGEco.SelectedIndex].totalRegistro =
                        listRegistroHoras[tablaGEco.SelectedIndex].horas * listRegistroHoras[tablaGEco.SelectedIndex]._csr;

                    listRegistroHoras[tablaGEco.SelectedIndex].update();
                    tablaGEco.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona primero un registro.");
                    return;
                }

                tablaGEco.Items.Refresh();
                boxCproyectoGEco.SelectedIndex=-1;
                boxNombreGEco.SelectedIndex = -1;
                boxFechaIGEco.Text = "";
                btnModificarGEco.IsEnabled = true;
                btnEliminarGEco.IsEnabled = true;
                tablaGEco.IsHitTestVisible = true;
                boxCproyectoGEco.IsEnabled=true;
                boxNombreGEco.IsEnabled = true;
                boxFechaIGEco.IsEnabled = true;
                btnAnadirGEco.Content = "Añadir";
            }
            else
            {
                DateTime fecha = boxFechaIGEco.SelectedDate.Value;
                string anio = fecha.Year.ToString();
                ApiManager apiManager = new ApiManager();

                List<ApiObject> listaFestivos = await apiManager.getListaFestivos(anio);

                bool esFestivo = listaFestivos.Any(h => h.Date.Iso.Date == fecha.Date);

                if (!esFestivo)
                {
                    //Insertar nuevo

                    int horas;
                    bool esNumero = int.TryParse(boxHorasGEco.Text, out horas);
                    string proyecto = boxCproyectoGEco.Text;
                    string empleado = boxNombreGEco.Text;
                    int csr=-1;

                    Proyecto paux = new Proyecto();
                    int idProyecto = paux.getIdFromCode(proyecto);
                    int idEmpleado = -1;
                    foreach (Empleado emple in listaEmpleado)
                    {
                        if (empleado.Equals(emple.nameEmpleado))
                        {
                            idEmpleado = emple.id;
                            csr = Convert.ToInt32(emple.csr);
                        }
                    }

                    if (!esNumero)
                    {
                        MessageBox.Show("Por favor, introduce un número válido en horas.");
                        return;
                    }

                    RegistroHoras rh = new RegistroHoras(idProyecto, idEmpleado, horas, fecha,proyecto,empleado,csr);
                    rh.insert();
                    ((List<RegistroHoras>)tablaGEco.ItemsSource).Add(rh);
                    tablaGEco.Items.Refresh();

                }
                else
                {
                    MessageBox.Show("El dia que intentas introducir es festivo");
                }
                tablaGEco.Items.Refresh();
                boxCproyectoGEco.SelectedItem=null;
                boxNombreGEco.SelectedIndex=-1;
                boxFechaIGEco.Text = "";
                boxHorasGEco.Clear();

            }

        }
        /// <summary>
        /// Handles the Click event of the btnEliminarGeco control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEliminarGeco_Click(object sender, RoutedEventArgs e)
        {
            RegistroHoras rh = (RegistroHoras)tablaGEco.SelectedItem;

            rh.delete();
            List<RegistroHoras> lst = (List<RegistroHoras>)tablaGEco.ItemsSource;
            lst.Remove(rh);
            tablaGEco.Items.Refresh();
            tablaGEco.ItemsSource = lst;
        }
        //Pendiente de implementar
        /// <summary>
        /// Handles the Click event of the btnModificarGeco control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnModificarGeco_Click(object sender, RoutedEventArgs e)
        {
            RegistroHoras rhElegido = (RegistroHoras)tablaGEco.SelectedItem;
            boxNombreGEco.Text = rhElegido.nombreEmpleado;
            boxCproyectoGEco.Text=rhElegido.nombreProyecto;
            boxHorasGEco.Text = rhElegido.horas.ToString();
            boxFechaIGEco.Text = rhElegido.fecha.ToString();
            
            btnEliminarGEco.IsEnabled = false;
            btnModificarGEco.IsEnabled = false;
            boxNombreGEco.IsEnabled=false;
            boxCproyectoGEco.IsEnabled=false;
            boxFechaIGEco.IsEnabled = false;
            tablaGEco.IsHitTestVisible = false;
            btnAnadirGEco.Content = "Actualizar horas";
        }

        /// <summary>
        /// Handles the Click event of the btnEstadistica control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabEstadisticas;
        }

        /// <summary>
        /// Handles the Click event of the btnMostrarInforme control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMostrarInforme_Click(object sender, RoutedEventArgs e)
        {

            string valorCbox = cboxEstadisticas.Text;
            switch (valorCbox)
            {
                case "Costes e ingresos por proyecto":
                    calculcarInformeCosteTotal();
                    break;

                case "Perfiles por proyecto":
                    numeroPerfilesProyecto();
                    break;

            }
        }

        /// <summary>
        /// Numeroes the perfiles proyecto.
        /// </summary>
        private void numeroPerfilesProyecto()
        {
            List<String> roles = new List<String>();
            roles.Add("Programador Junior");
            roles.Add("Programador");
            roles.Add("Programador Senior");
            roles.Add("Jefe de Equipo");
            DataTable dt = new DataTable("DataTable2");
            dt.Columns.Add("Proyecto");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Perfil de Empleado");
            dt.Columns.Add("Número de personas");
            foreach (Proyecto proy in listaProyectos)
            {
                for (int i = 1; i < 5; i++) {
                    //Crear una fila de datos de la tabla creada
                    DataRow row = dt.NewRow();
                    row["Proyecto"] = proy.nombre;
                    row["Fecha"] = proy.FechaInicio.Month + "/" + proy.FechaInicio.Year;

                    //tengo que recuperar los datos de los roles de la bbdd para que esto salga bien
                    row["Perfil de Empleado"] = roles[i-1];

                    //tengo que hacerlo con un count en la base de datos
                    //select count(e.idEmploy) from Proyect_Employ pe, Employ e, Rol r where pe.idProyect = 1 AND pe.idEmploy = e.idEmploy AND e.idRol = r.idRol AND r.idRol = 3;
                    //La consulta de arriba es con la que voy a contar los miembros de cada rol
                    Proyecto paux = new Proyecto();
                    row["Número de personas"] = paux.getNumPersonasRol(proy.id, i);
                    dt.Rows.Add(row);
                }
            }
            NumPerfilesPorProyecto report1 = new NumPerfilesPorProyecto();
            report1.Database.Tables["DataTable2"].SetDataSource(dt);
            reportViewer.ViewerCore.ReportSource = report1;
        }

        /// <summary>
        /// Calculcars the informe coste total.
        /// </summary>
        private void calculcarInformeCosteTotal()
        {
            DataTable tabla1 = new DataTable("DataTable1");
            tabla1.Columns.Add("Proyecto");
            tabla1.Columns.Add("Fecha");
            tabla1.Columns.Add("Coste Total");

            foreach (Proyecto proy in listaProyectos)
            {
                //Crear una fila de datos de la tabla creada
                DataRow row = tabla1.NewRow();
                row["Proyecto"] = proy.nombre;
                row["Fecha"] = proy.FechaInicio.Month+"/"+proy.FechaInicio.Year;
                Proyecto paux = new Proyecto();
                int coste = paux.getCosteTotal(proy.id);

                row["Coste Total"] = coste.ToString();
                tabla1.Rows.Add(row);
            }
            CostesIngresosProyecto report1 = new CostesIngresosProyecto();
            report1.Database.Tables["DataTable1"].SetDataSource(tabla1);
            reportViewer.ViewerCore.ReportSource = report1;
        }

        private void btnRegistrarRecargarUsers_Click(object sender, RoutedEventArgs e)
        {

            string nombreUser = tboxUserNameEmploy.Text;
            string passUser = tboxUserPassEmploy.Text;
            Usuario usuario = new Usuario(nombreUser,passUser);

            usuario.insert();

            tboxUserNameEmploy.Clear();
            tboxUserPassEmploy.Clear();
            MessageBox.Show("Usuario nuevo creado");

            ((List<String>)cboxUsers.ItemsSource).Add(nombreUser);
            ((List<Usuario>)tablaUsuario.ItemsSource).Add(usuario);
            cboxUsers.Items.Refresh();
            tablaUsuario.Items.Refresh();

            checkUserEmploy.IsChecked = false;
        }
    }
}
