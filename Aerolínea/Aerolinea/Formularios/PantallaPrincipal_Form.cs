using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;
using System.Globalization;


namespace Aerolinea
{
    public partial class PantallaPrincipal_Form : Form
    {
        public static bool compraConfirmada;
        public PantallaPrincipal_Form()
        {
            InitializeComponent();
        }

        public void Usuario_DataGridView()
        {
            Usuario usuario = new Usuario();
            DataTable usuario_select_tabla = usuario.RetornaTablaUsuario_BD();
            usuarios_Tabla_UsuariosRegistrados.DataSource = usuario_select_tabla;
        }

        private void botonTiquetes_Click(object sender, EventArgs e)
        {
            panelTiquetes.Visible = true;
            panelCheckIn.Visible = false;
            panelHistorial.Visible = false;
            panelUsuarios.Visible = false;
        }

        private void botonCheckIn_Click(object sender, EventArgs e)
        {
            panelCheckIn.Visible = true;
            panelTiquetes.Visible = false;
            panelHistorial.Visible = false;
            panelUsuarios.Visible = false;
        }

        private void botonHistorial_Click(object sender, EventArgs e)
        {
            panelHistorial.Visible = true;
            panelCheckIn.Visible = false;
            panelTiquetes.Visible = false;
            panelUsuarios.Visible = false;
        }

        private void botonUsuarios_Click(object sender, EventArgs e)
        {
            panelUsuarios.Visible = true;
            panelCheckIn.Visible = false;
            panelTiquetes.Visible = false;
            panelHistorial.Visible = false;

            Usuario_DataGridView();
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PopularTablaVuelos()
        {
            Vuelo vuelo = new Vuelo();
            tiquetes_Table_VuelosDisponibles.DataSource = vuelo.RetornaTablaVuelos_BD().Tables[0];
            tiquetes_Table_VuelosDisponibles.CurrentCell = null;
        }

        private void PopularTablaHistorial() 
        {
            Historial historial = new Historial();
            historial_Table_TiquetesHistorial.DataSource = historial.RetornaTablaHistorial_BD();
        }

        private void PopularTablaCheckIn()
        {
            CheckIn checkIn = new CheckIn();
            checkIn_Tabla_TiquetesSinRegistro.DataSource = checkIn.RetornaTablaCheckIn_BD();
            tiquetes_Table_VuelosDisponibles.CurrentCell = null;
        }

        private void PantallaPrincipal_Form_Load(object sender, EventArgs e)
        {
            PopularTablaVuelos();
            PopularTablaCheckIn();
            PopularTablaHistorial();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void slogan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCheckIn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fondoMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkIn_FlowLayout_DatosUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkIn_Label_ID_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkIn_RadioButton_OpcionTarjeta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkIn_TextBox_NumDeTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkIn_FlowLayout_DatosUsuario_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void reservaciones_Label_Titulo_Vuelos_Click(object sender, EventArgs e)
        {

        }

        private void reservaciones_Table_VuelosDisponibles_CLick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reservaciones_Label_Total_Click(object sender, EventArgs e)
        {

        }

        private void tiquetes_Button_ElegirAsiento(object sender, EventArgs e)
        {
            compraConfirmada = false;
            if (String.IsNullOrWhiteSpace(tiquetes_TextBox_ID.Text) || String.IsNullOrWhiteSpace(tiquetes_TextBox_Nombre.Text) ||
                String.IsNullOrWhiteSpace(tiquetes_TextBox_PrimerApellido.Text) || String.IsNullOrWhiteSpace(tiquetes_TextBox_SegundoApellido.Text) ||
                String.IsNullOrWhiteSpace(tiquetes_TextBox_FechaNacimiento.Text) || String.IsNullOrWhiteSpace(tiquetes_TextBox_NumDeTel.Text) ||
                tiquetes_Table_VuelosDisponibles.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se pueden elegir asientos si no se completa el formulario de datos personales, o si no se selecciona un vuelo", "Error");
            } else
            {
                try
                {
                    string fechaNacimiento = DateTime.ParseExact(tiquetes_TextBox_FechaNacimiento.Text.Trim(), "d", CultureInfo.CreateSpecificCulture("es-ES")).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("El formato de fecha debe ser DD/MM/YYYY.", "Error en fecha de nacimiento");
                    return;
                }

                Usuario usuario = new Usuario(tiquetes_TextBox_Nombre.Text,
                    tiquetes_TextBox_PrimerApellido.Text,
                    tiquetes_TextBox_SegundoApellido.Text,
                    tiquetes_TextBox_ID.Text,
                    tiquetes_TextBox_FechaNacimiento.Text,
                    tiquetes_TextBox_NumDeTel.Text);

                Vuelo vuelo = new Vuelo(
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[0].Value.ToString(),
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[1].Value.ToString(),
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[2].Value.ToString(),
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[3].Value.ToString(),
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[4].Value.ToString().Replace('-', '/'),
                    tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[5].Value.ToString(),
                    int.Parse(tiquetes_Table_VuelosDisponibles.Rows[tiquetes_Table_VuelosDisponibles.SelectedRows[0].Index].Cells[6].Value.ToString())
                    );

                if (!usuario.UsuarioExiste_BD(usuario.Cedula))
                {
                    EleccionAsientos_Form eleccionAsientosForm = new EleccionAsientos_Form(vuelo, false, usuario, tiquetes_TextBox_Descripcion.Text);
                    eleccionAsientosForm.ShowDialog();
                } else
                {
                    Conexion objetoConexion = new Conexion();
                    SqlConnection conexion = objetoConexion.RecibirConexion();

                    string[] arregloSeparacion = usuario.FechaNacimiento.Split('/', 10);
                    string fechaParaRevision = arregloSeparacion[2] + arregloSeparacion[1] + arregloSeparacion[0];

                    bool existe = usuario.RegistroExisteEnBD_BD(usuario.Cedula, usuario.Nombre, usuario.PrimerApellido, usuario.SegundoApellido, fechaParaRevision, usuario.NumeroTelefono, conexion);

                    if (existe)
                    {
                        EleccionAsientos_Form eleccionAsientosForm = new EleccionAsientos_Form(vuelo, true, usuario, tiquetes_TextBox_Descripcion.Text);
                        eleccionAsientosForm.ShowDialog();
                    } else
                    {
                        MessageBox.Show("La cédula del usuario existe en la base de datos, pero sus datos han sido modificados en la entrada de datos. Favor revisar nuevamente, o presionar 'Buscar Cliente' para repopular la información del usuario", "Usuarios discordantes", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }  
                }
            }
            if (compraConfirmada)
            {
                tiquetes_TextBox_ID.Text = "";
                tiquetes_TextBox_Nombre.Text = "";
                tiquetes_TextBox_PrimerApellido.Text = "";
                tiquetes_TextBox_SegundoApellido.Text = "";
                tiquetes_TextBox_FechaNacimiento.Text = "";
                tiquetes_TextBox_NumDeTel.Text = "";
                tiquetes_TextBox_Descripcion.Text = "";
            }
            PopularTablaCheckIn();
            PopularTablaHistorial();
        }

        private void usuarios_Label_Titulo_Click(object sender, EventArgs e)
        {

        }

        private void checkIn_FlowLayout_Busqueda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reservaciones_RadioButton_OpcionEfectivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tiquetes_Button_BuscarClientes_Click(object sender, EventArgs e) 
        {
            Usuario usuario = new Usuario();
            DataSet setDeDatos = usuario.BuscarUsuario_BD(tiquetes_TextBox_ID.Text);

            if (setDeDatos.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("El número de identificación no existe en el sistema.");
            }
            else
            {
                tiquetes_TextBox_Nombre.Text = setDeDatos.Tables[0].Rows[0]["NOMBRE"].ToString();
                tiquetes_TextBox_PrimerApellido.Text = setDeDatos.Tables[0].Rows[0]["PRIMERAPELLIDO"].ToString();
                tiquetes_TextBox_SegundoApellido.Text = setDeDatos.Tables[0].Rows[0]["SEGUNDOAPELLIDO"].ToString();
                tiquetes_TextBox_FechaNacimiento.Text = setDeDatos.Tables[0].Rows[0]["FECHANACIMIENTO"].ToString();
                tiquetes_TextBox_NumDeTel.Text = setDeDatos.Tables[0].Rows[0]["NUMERODETELEFONO"].ToString();
            }
        }

        private void checkIn_Button_BuscarTiquetes_Click(object sender, EventArgs e)
        {
            Tiquete tiquete = new Tiquete();

            if (checkIn_ComboBox_BusquedaPor.Text == "" || checkIn_TextBox_ElementoABuscar.Text == "") 
            {
                MessageBox.Show("Debe Seleccionar un filtro e ingresar un elemento a buscar");

            }
            else if (checkIn_ComboBox_BusquedaPor.Text == "Número de Tiquete")
            {
                try
                {
                    int numeroDeTiquete = int.Parse(checkIn_TextBox_ElementoABuscar.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de tiquete debe ser un valor numérico", "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                checkIn_Tabla_TiquetesSinRegistro.DataSource = tiquete.BuscaTiquetePorNumeroDeTiquete_BD(Convert.ToInt32(checkIn_TextBox_ElementoABuscar.Text), 1).Tables[0];
            }
            else if (checkIn_ComboBox_BusquedaPor.Text == "Cédula")
            {
                checkIn_Tabla_TiquetesSinRegistro.DataSource = tiquete.BuscaTiquetePorCedula_BD(checkIn_TextBox_ElementoABuscar.Text, 1).Tables[0];
            }
            else if (checkIn_ComboBox_BusquedaPor.Text == "Nombre")
            {
                checkIn_Tabla_TiquetesSinRegistro.DataSource = tiquete.BuscaTiquetePorNombre_BD(checkIn_TextBox_ElementoABuscar.Text, 1).Tables[0];
            }
            else if (checkIn_ComboBox_BusquedaPor.Text == "Primer Apellido")
            {
                
                checkIn_Tabla_TiquetesSinRegistro.DataSource = tiquete.BuscaTiquetePorPrimerApellido_BD(checkIn_TextBox_ElementoABuscar.Text, 1).Tables[0];
            }
            else //Segundo Apellido
            {
                checkIn_Tabla_TiquetesSinRegistro.DataSource = tiquete.BuscaTiquetePorSegundoApellido_BD(checkIn_TextBox_ElementoABuscar.Text, 1).Tables[0];
            }
        }

        private void checkIn_Button_MostrarTodo_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();
            checkIn_Tabla_TiquetesSinRegistro.DataSource = checkIn.RetornaTablaCheckIn_BD();
        }

        private void checkIn_Button_CheckIn_Click(object sender, EventArgs e)
        {
            PantallaCheckIn_Form pantallaCheckIn_Form = new PantallaCheckIn_Form(
                Convert.ToDecimal(checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[13].Value.ToString()),
                Convert.ToInt32(checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[1].Value.ToString())
                );
            pantallaCheckIn_Form.ShowDialog();

            PopularTablaCheckIn();
            PopularTablaHistorial();
        }

        private void checkin_Button_Modificar_Click(object sender, EventArgs e)
        {
            EleccionAsientosMod_Form eleccionAsientosMod_Form = new EleccionAsientosMod_Form(
                checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[6].Value.ToString(),
                checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[1].Value.ToString(),
                Convert.ToDecimal(checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[14].Value.ToString()),
                Convert.ToDecimal(checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[13].Value.ToString()),
                checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[8].Value.ToString()
                );
            eleccionAsientosMod_Form.ShowDialog();
            PopularTablaCheckIn();
            PopularTablaHistorial();
        }

        private void checkIn_Button_Anular_Click(object sender, EventArgs e)
        {
            if(checkIn_Tabla_TiquetesSinRegistro.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un tiquete a anular de la tabla de compras no registradas.", "Error al anular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Seguro que desea anular el tiquete # "+ checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[1].Value.ToString()+"? Esta acción no puede revertirse; Presione YES para Sí, NO para no.", "Advertencia de Anulación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado.ToString().Trim() == "Yes")
            {
                Tiquete tiquete = new Tiquete();

                int numeroDeTiquete = int.Parse(checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[1].Value.ToString());
                string nombreDeRuta = checkIn_Tabla_TiquetesSinRegistro.Rows[checkIn_Tabla_TiquetesSinRegistro.SelectedRows[0].Index].Cells[6].Value.ToString();

                tiquete.AnulaTiquete_BD(numeroDeTiquete, nombreDeRuta);

                MessageBox.Show($"La anulación del tiquete # {numeroDeTiquete} ha sido exitosa.", "Confirmación de anulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
            else
            {
                MessageBox.Show("Anulación abortada.", "Anulación abortada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            PopularTablaCheckIn();
            PopularTablaHistorial();
        }

        private void panelCheckIn_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void historial_Button_MostrarTodo_Click(object sender, EventArgs e)
        {
            PopularTablaHistorial();
        }

        private void historial_Button_BuscarTiquete_Click(object sender, EventArgs e)
        {
            Tiquete tiquete = new Tiquete();
            if (historial_ComboBox_BusquedaPor.Text == "" || historial_ComboBox_BusquedaPor.Text == "")
            {
                MessageBox.Show("Debe Seleccionar un filtro e ingresar un elemento a buscar");

            }
            else if (historial_ComboBox_BusquedaPor.Text == "Número de Tiquete")
            {
                try
                {
                    int numeroDeTiquete = int.Parse(historial_TextBox_ElementoABuscar.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de tiquete debe ser un valor numérico", "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                historial_Table_TiquetesHistorial.DataSource = tiquete.BuscaTiquetePorNumeroDeTiquete_BD(Convert.ToInt32(historial_TextBox_ElementoABuscar.Text), 2).Tables[0];

            }
            else if (historial_ComboBox_BusquedaPor.Text == "Cédula")
            {
                historial_Table_TiquetesHistorial.DataSource = tiquete.BuscaTiquetePorCedula_BD(historial_TextBox_ElementoABuscar.Text, 2).Tables[0];
            }
            else if (historial_ComboBox_BusquedaPor.Text == "Nombre")
            {
                historial_Table_TiquetesHistorial.DataSource = tiquete.BuscaTiquetePorNombre_BD(historial_TextBox_ElementoABuscar.Text, 2).Tables[0];;
            }
            else if (historial_ComboBox_BusquedaPor.Text == "Primer Apellido")
            {
                historial_Table_TiquetesHistorial.DataSource = tiquete.BuscaTiquetePorPrimerApellido_BD(historial_TextBox_ElementoABuscar.Text, 2).Tables[0];
            }
            else //Segundo Apellido
            {
                historial_Table_TiquetesHistorial.DataSource = tiquete.BuscaTiquetePorSegundoApellido_BD(historial_TextBox_ElementoABuscar.Text, 2).Tables[0];
            }
        }

        private void usuarios_Button_RegistrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            try
            {
                if (String.IsNullOrWhiteSpace(usuarios_TextBox_ID.Text) || String.IsNullOrWhiteSpace(usuarios_TextBox_Nombre.Text) || String.IsNullOrWhiteSpace(usuarios_TextBox_Primer_Apellido.Text) || String.IsNullOrWhiteSpace(usuarios_TextBox_Segundo_Apellido.Text) || String.IsNullOrWhiteSpace(usuarios_TextBox_Fecha_Nacimiento.Text) || String.IsNullOrWhiteSpace(usuarios_TextBox_NumDeTel.Text))
                {
                    MessageBox.Show("Por favor completar todos los espacios solicitados.");
                }
                else
                {
                    try
                    {
                        string fechaNacimiento = DateTime.ParseExact(usuarios_TextBox_Fecha_Nacimiento.Text.Trim(), "d", CultureInfo.CreateSpecificCulture("es-ES")).ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El formato de fecha debe ser DD/MM/YYYY.", "Error en fecha de nacimiento");
                        return;
                    }
                    if (usuario.UsuarioExiste_BD(usuarios_TextBox_ID.Text) == true)
                    {
                        MessageBox.Show("El ID ya está asignado a un usuario existente.");
                        return;
                    }
                    else
                    {
                        usuario.IngresarUsuario_BD(usuarios_TextBox_Nombre.Text, usuarios_TextBox_Primer_Apellido.Text, usuarios_TextBox_Segundo_Apellido.Text, usuarios_TextBox_ID.Text, usuarios_TextBox_Fecha_Nacimiento.Text, usuarios_TextBox_NumDeTel.Text);
                        MessageBox.Show("Nuevo usuario agregado al programa de millas.");
                        Usuario_DataGridView();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error no determinado.");
            }
        }

        private void usuarios_Button_BuscarUsuarios_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            string Usuario_btnBuscar_SqlCommand = "Sin Comando Asignado"; try
            {
                if (usuarios_ComboBox_BusquedaPor.SelectedItem == "Nombre" || usuarios_ComboBox_BusquedaPor.SelectedItem == "Cédula" || usuarios_ComboBox_BusquedaPor.SelectedItem == "Primer Apellido" || usuarios_ComboBox_BusquedaPor.SelectedItem == "Segundo Apellido")
                {
                    Usuario_btnBuscar_SqlCommand = usuario.BuscarPor_BD(Convert.ToString(usuarios_ComboBox_BusquedaPor.SelectedItem), usuarios_TextBox_ElementoABuscar.Text);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una opción de Búsqueda Por.");
                    return;
                }
                if (usuario.UsuarioExiste_BuscarPor_BD(Usuario_btnBuscar_SqlCommand) == true)
                {
                    DataTable usuario_select_tabla = usuario.PopularTablaUsuario_UsuarioUnico_BD(Usuario_btnBuscar_SqlCommand);
                    usuarios_Tabla_UsuariosRegistrados.DataSource = usuario_select_tabla;
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                    Usuario_DataGridView();
                    return;
                }
            }
            catch //En caso de ocurrir un error inesperado en el proceso
            {
                MessageBox.Show("Error no determinado.");
            }


        }

        private void usuarios_Button_ModificarUsuario_Click(object sender, EventArgs e)
        {
            if (usuarios_Tabla_UsuariosRegistrados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario para se modificado.");
                return;
            }
            else
            {
                PantallaModificarUsuario_Form pantallaModificarUsuario_Form = new PantallaModificarUsuario_Form();

                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_ID.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[3].Value.ToString());
                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_Nombre.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[0].Value.ToString());
                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_PrimerApellido.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[1].Value.ToString());
                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_SegundoApellido.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[2].Value.ToString());
                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_FechaDeNacimiento.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[4].Value.ToString());
                pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_NumeroTelefono.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[5].Value.ToString());

                if (Convert.ToBoolean(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[6].Value) == true)
                {
                    pantallaModificarUsuario_Form.pantallaModificarUsuario_CheckBox_ProgramaMillas.Checked = true;
                    pantallaModificarUsuario_Form.pantallaModificarUsuario_TextBox_MillasAcumuladas.Text = Convert.ToString(usuarios_Tabla_UsuariosRegistrados.Rows[usuarios_Tabla_UsuariosRegistrados.SelectedRows[0].Index].Cells[7].Value);
                    pantallaModificarUsuario_Form.perteneceProgramaMillas = true;
                }
                else
                {
                    pantallaModificarUsuario_Form.pantallaModificarUsuario_CheckBox_ProgramaMillas.Checked = false;
                }

                pantallaModificarUsuario_Form.ShowDialog();
                Usuario_DataGridView();
            }
        }

        private void usuarios_Button_MostrarTodo_Click(object sender, EventArgs e)
        {
            Usuario_DataGridView();
        }

        private void historial_Table_TiquetesHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarFilaHistorial_Form mostrarFilaHistorial_Form = new MostrarFilaHistorial_Form();

            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_FechaTramite.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[0].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_NumeroTiquete.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[1].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_Cedula.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[2].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_Nombre.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[3].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_PrimerApellido.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[4].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_SegundoApellido.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[5].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_NombreRuta.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[6].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_NumeroVuelo.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[7].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_NumeroAsiento.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[8].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_PuntoDeSalida.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[9].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_PuntoDeLlegada.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[10].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_FechaVuelo.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[11].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_HoraVuelo.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[12].Value.ToString());

            if (Convert.ToBoolean(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[13].Value) == true)
            {
                mostrarFilaHistorial_Form.MostrarFilaHistorial_CheckBox_RegistradoParaAbordaje.Checked = true;
            }
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_Descuento.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[14].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_PesoTotalMaletas.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[15].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_CargosPorSobrepeso.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[16].Value.ToString());
            mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_CostoFinalPorEquipaje.Text = Convert.ToString(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[17].Value.ToString());

            Tiquete tiqueteTemporal = new Tiquete();
            string descripcionTiquete = tiqueteTemporal.ObtenerDescripcionTiquete_BD(int.Parse(historial_Table_TiquetesHistorial.Rows[historial_Table_TiquetesHistorial.SelectedRows[0].Index].Cells[1].Value.ToString()));

            if (String.IsNullOrEmpty(descripcionTiquete) || String.IsNullOrWhiteSpace(descripcionTiquete))
            {
                mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_Descripcion.Text = "No posee descripción.";
            }
            else
            {
                mostrarFilaHistorial_Form.MostrarFilaHistorial_Label_Descripcion.Text = descripcionTiquete.Trim();
            }

            mostrarFilaHistorial_Form.ShowDialog();
        }

        private void botonContacto_Click(object sender, EventArgs e)
        {
            Conexion_XML conexion_XML = new Conexion_XML();
            conexion_XML.InformacionContacto_XML();
        }
    }
}
