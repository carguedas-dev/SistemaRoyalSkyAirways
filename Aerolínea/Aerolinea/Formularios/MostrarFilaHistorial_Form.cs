using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class MostrarFilaHistorial_Form : Form
    {
        public MostrarFilaHistorial_Form()
        {
            InitializeComponent();
        }

        private void MostrarFilaHistorial_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void MostrarFilaHistorial_Label_PrimerApellido_Click(object sender, EventArgs e)
        {

        }

        private void MostrarFilaHistorial_CheckBox_RegistradoParaAbordaje_Click(object sender, EventArgs e)
        {
            if (MostrarFilaHistorial_CheckBox_RegistradoParaAbordaje.Checked)
            {
                MostrarFilaHistorial_CheckBox_RegistradoParaAbordaje.Checked = false;
            } else
            {
                MostrarFilaHistorial_CheckBox_RegistradoParaAbordaje.Checked = true;
            }
        }
    }
}
