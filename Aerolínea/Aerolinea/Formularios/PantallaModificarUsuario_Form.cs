using System;
using System.Globalization;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class PantallaModificarUsuario_Form : Form
    {
        bool mostrarMensajes = false;
        public bool perteneceProgramaMillas = false;

        public PantallaModificarUsuario_Form()
        {
            InitializeComponent();
        }

        private void PantallaModificarUsuario_Form_Load(object sender, EventArgs e)
        {
            mostrarMensajes = true;
        }

        private void pantallaModificarUsuario_Button_Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificación de los datos mínomos e ingreso a la base de datos
                if (String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_ID.Text) ||
                    String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_Nombre.Text) ||
                    String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_PrimerApellido.Text) ||
                    String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_SegundoApellido.Text) ||
                    String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_NumeroTelefono.Text) ||
                    String.IsNullOrWhiteSpace(pantallaModificarUsuario_TextBox_FechaDeNacimiento.Text))
                {
                    MessageBox.Show("Los datos mínimos son: ID, Nombre, Primer apellido, Segundo Apellido, Número de Teléfono y Fecha de Nacimiento");
                }
                else
                {
                    try
                    {
                        string fechaNacimiento = DateTime.ParseExact(pantallaModificarUsuario_TextBox_FechaDeNacimiento.Text.Trim(), "d", CultureInfo.CreateSpecificCulture("es-ES")).ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El formato de fecha debe ser DD/MM/YYYY.", "Error en fecha de nacimiento");
                        return;
                    }
                    Usuario usuarioTemporal = new Usuario();
                    usuarioTemporal.ActualizarDatosUsuario_BD(pantallaModificarUsuario_TextBox_Nombre.Text, 
                        pantallaModificarUsuario_TextBox_PrimerApellido.Text,
                        pantallaModificarUsuario_TextBox_SegundoApellido.Text,
                        pantallaModificarUsuario_TextBox_ID.Text,
                        pantallaModificarUsuario_TextBox_FechaDeNacimiento.Text,
                        pantallaModificarUsuario_TextBox_NumeroTelefono.Text,
                        pantallaModificarUsuario_CheckBox_ProgramaMillas.Checked,
                        pantallaModificarUsuario_TextBox_MillasAcumuladas.Text
                        );
                    
                    if (!perteneceProgramaMillas)
                    {
                        pantallaModificarUsuario_TextBox_MillasAcumuladas.Text = " ";
                    }
                    
                    MessageBox.Show("Usuario modificado exitosamente.");
                    this.Close();
                }
            }
            catch
            {
                throw;
            }
        }


        private void pantallaModificarUsuario_TextBox_Nombre_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void pantallaModificarUsuario_CheckBox_ProgramaMillas_CheckedChanged(object sender, EventArgs e)
        {
            string acceso = " ";

            if (mostrarMensajes) // Evita la ejecución de comprobación al momento de cargar el Form
            {
                // Determinar qué acción se realizará
                if (pantallaModificarUsuario_CheckBox_ProgramaMillas.Checked == false)
                {
                    acceso = "EliminarDeProgramaMillas";
                }
                else if (pantallaModificarUsuario_CheckBox_ProgramaMillas.Checked == true)
                {
                    acceso = "AgregarProgramaMillas";
                }

                // Ingreso o eliminación del usuario del programa de millas
                if (acceso == "EliminarDeProgramaMillas")
                {
                    DialogResult dialogResult = MessageBox.Show("¿Desea eliminar a " + pantallaModificarUsuario_TextBox_Nombre.Text + " del programa de millas?", "", MessageBoxButtons.YesNo);
                    
                    if (dialogResult == DialogResult.Yes)
                    {
                        pantallaModificarUsuario_TextBox_MillasAcumuladas.Text = " ";
                        perteneceProgramaMillas = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (acceso == "AgregarProgramaMillas")
                {
                    perteneceProgramaMillas = true;
                }
            }
        }
    }
}