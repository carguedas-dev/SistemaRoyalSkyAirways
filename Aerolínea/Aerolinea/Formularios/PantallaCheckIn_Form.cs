using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class PantallaCheckIn_Form : Form
    {
        decimal precioTiquete;
        int numeroDeTiquete;
        public PantallaCheckIn_Form(decimal precioTiquete, int numeroDeTiquete)
        {
            this.precioTiquete = precioTiquete;
            this.numeroDeTiquete = numeroDeTiquete;
            InitializeComponent();
        }

        private void PantallaCheckIn_Load(object sender, EventArgs e)
        {
            pantallaCheckIn_Label_PesoMaleta1.Visible = false;
            pantallaCheckIn_Label_PesoMaleta2.Visible = false;
            pantallaCheckIn_Label_PesoMaleta3.Visible = false;
            pantallaCheckIn_TextBox_PesoMaleta1.Visible = false;
            pantallaCheckIn_TextBox_PesoMaleta2.Visible = false;
            pantallaCheckIn_TextBox_PesoMaleta3.Visible = false; 
        }

        private void pantallaCheckIn_ComboBox_MaletasARegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "0")
            {
                pantallaCheckIn_Label_PesoMaleta1.Visible = false;
                pantallaCheckIn_Label_PesoMaleta2.Visible = false;
                pantallaCheckIn_Label_PesoMaleta3.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta1.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta2.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta3.Visible = false;

            }
            else if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "1")
            {
                pantallaCheckIn_Label_PesoMaleta1.Visible = true;
                pantallaCheckIn_Label_PesoMaleta2.Visible = false;
                pantallaCheckIn_Label_PesoMaleta3.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta1.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta2.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta3.Visible = false;
            }
            else if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "2")
            {
                pantallaCheckIn_Label_PesoMaleta1.Visible = true;
                pantallaCheckIn_Label_PesoMaleta2.Visible = true;
                pantallaCheckIn_Label_PesoMaleta3.Visible = false;
                pantallaCheckIn_TextBox_PesoMaleta1.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta2.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta3.Visible = false;
            }
            else // 3 maletas
            {
                pantallaCheckIn_Label_PesoMaleta1.Visible = true;
                pantallaCheckIn_Label_PesoMaleta2.Visible = true;
                pantallaCheckIn_Label_PesoMaleta3.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta1.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta2.Visible = true;
                pantallaCheckIn_TextBox_PesoMaleta3.Visible = true;
            }
        }

        private void pantallaCheckIn_Button_Registrar_Click(object sender, EventArgs e)
        {
            double pesoMaleta1 = 0, pesoMaleta2 = 0, pesoMaleta3 = 0;
            int revision = RevisarEntradas(ref pesoMaleta1, ref pesoMaleta2, ref pesoMaleta3);
            if (revision == 0)
            {
                return;
            }

            CalculosEquipaje calculosEquipaje = new CalculosEquipaje(precioTiquete, pantallaCheckIn_ComboBox_MaletasARegistrar.Text);

            decimal precioMaletas = calculosEquipaje.CalcularPrecioMaletas();
            double pesoTotal = calculosEquipaje.CalcularPeso(pesoMaleta1, pesoMaleta2, pesoMaleta3);
            decimal precioSobrePeso = calculosEquipaje.CalcularPrecioSobrepeso(pesoTotal);
            decimal costoFinal = calculosEquipaje.CalcularPrecioTotal(precioSobrePeso, precioMaletas);
            decimal costoFinalConTiquete = calculosEquipaje.CalcularPrecioTotalConTiquete(precioSobrePeso, precioMaletas);

            DialogResult result = MessageBox.Show("A continuación, se llevará a cabo el trámite de registro. Considere que después de registrarse, no se podrán realizar cambios " +
                "a su reserva. Seleccione OK para continuar, o CANCEL para cancelar", "Advertencia", MessageBoxButtons.OKCancel);

            if (result.ToString().ToUpper() == "OK")
            {
                Tiquete tiquete = new Tiquete();
                Vuelo vuelo = new Vuelo();
                Equipaje equipaje = new Equipaje(); 

                equipaje.ActualizarEquipaje_BD(numeroDeTiquete, pesoMaleta1, pesoMaleta2, pesoMaleta3, pesoTotal, precioSobrePeso, costoFinal);
                vuelo.PasarAsientoAOcupado_BD(numeroDeTiquete);
                tiquete.ActualizarPrecioTiquete_BD(numeroDeTiquete, costoFinalConTiquete);

                MessageBox.Show($"El tiquete número {numeroDeTiquete} ha sido registrado para abordaje.", "Confirmación");
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Registro abortado", "Registro abortado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public int RevisarEntradas(ref double pesoMaleta1, ref double pesoMaleta2, ref double pesoMaleta3)
        {
            if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "")
            {
                MessageBox.Show("Debe seleccionar la cantidad de maletas a registrar", "Error de registro");
                return 0;
            }
            else
            {
                try
                {
                    if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "1")
                    {
                        if (pantallaCheckIn_TextBox_PesoMaleta1.Text == "")
                        {
                            MessageBox.Show("Debe rellenar los pesos de las maletas indicadas.", "Falta información");
                            return 0;
                        }
                        pesoMaleta1 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta1.Text);
                        pesoMaleta2 = 0;
                        pesoMaleta3 = 0;
                    }
                    else if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "2")
                    {
                        if (pantallaCheckIn_TextBox_PesoMaleta1.Text == "" || pantallaCheckIn_TextBox_PesoMaleta2.Text == "")
                        {
                            MessageBox.Show("Debe rellenar los pesos de las maletas indicadas.", "Falta información");
                            return 0;
                        }
                        pesoMaleta1 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta1.Text);
                        pesoMaleta2 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta2.Text);
                        pesoMaleta3 = 0;
                    }
                    else if (pantallaCheckIn_ComboBox_MaletasARegistrar.Text == "3")
                    {
                        if (pantallaCheckIn_TextBox_PesoMaleta1.Text == "" || pantallaCheckIn_TextBox_PesoMaleta2.Text == "" || pantallaCheckIn_TextBox_PesoMaleta3.Text == "")
                        {
                            MessageBox.Show("Debe rellenar los pesos de las maletas indicadas.", "Falta información");
                            return 0;
                        }
                        pesoMaleta1 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta1.Text);
                        pesoMaleta2 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta2.Text);
                        pesoMaleta3 = double.Parse(pantallaCheckIn_TextBox_PesoMaleta3.Text);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Los pesos deben indicarse en kilogramos, y con valores numéricos.");
                }
            }
            return 1;
        }

        private void pantallaCheckIn_Button_Calcular_Click(object sender, EventArgs e)
        {
            double pesoMaleta1 = 0, pesoMaleta2 = 0, pesoMaleta3 = 0;
            
            int revision = RevisarEntradas(ref pesoMaleta1, ref pesoMaleta2, ref pesoMaleta3);
            if (revision == 0)
            {
                return;
            }
            
            CalculosEquipaje calculosEquipaje = new CalculosEquipaje(precioTiquete, pantallaCheckIn_ComboBox_MaletasARegistrar.Text);
            
            decimal precioMaletas = calculosEquipaje.CalcularPrecioMaletas();
            double pesoTotal = calculosEquipaje.CalcularPeso(pesoMaleta1, pesoMaleta2, pesoMaleta3);
            decimal precioSobrePeso = calculosEquipaje.CalcularPrecioSobrepeso(pesoTotal);

            pantallaCheckIn_Label_PesoTotalValor.Text = pesoTotal.ToString();
            pantallaCheckIn_Label_PrecioXSobrepesoValor.Text = precioSobrePeso.ToString();
            pantallaCheckIn_Label_PrecioFinalValor.Text = calculosEquipaje.CalcularPrecioTotal(precioSobrePeso, precioMaletas).ToString();

        }
    }
}