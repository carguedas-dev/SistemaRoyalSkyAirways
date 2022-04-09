using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    public partial class pantallaLogin_Form : Form
    {
        public pantallaLogin_Form()
        {
            InitializeComponent();
        }

        //Validación del Main para iniciar la pantalla principal
        public static bool? login_verificado { get; set; } = false;


        private void tbx_usuario_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_contrasena_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_verificar_login_Click(object sender, EventArgs e)
        {
            Autenticacion autenticacion = new Autenticacion();

            login_verificado = autenticacion.RevisionDeCredenciales_BD(tbx_usuario_login.Text, tbx_contrasena_login.Text);

            if (login_verificado == true)
            {
                MessageBox.Show("¡Bienvenido al sistema!", "Bievenido");
                this.Close();
            } else
            {
                MessageBox.Show("Credenciales Incorrectas.", "Autenticación Fallida");
            }

        }

        private void pantallaLogin_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
