using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Aerolinea
{
    public partial class EleccionAsientos_Form : Form
    {
        public List<System.Windows.Forms.Label> asientos;
        Vuelo vueloDeInteres; 
        bool usuarioExisteEnBD;
        Usuario datosUsuario;
        string descripcion;
        public static bool compraConfirmada = false;
        public EleccionAsientos_Form(Vuelo vuelo, bool usuarioExiste, Usuario usuario, string descripcion)
        {
            this.vueloDeInteres = vuelo;
            this.usuarioExisteEnBD = usuarioExiste;
            datosUsuario = usuario;
            this.descripcion = descripcion;
            InitializeComponent();

            if (usuarioExiste)
            {
                if (!usuario.PerteneceProgramaMillas_BD(usuario.Cedula))
                {
                    EleccionAsientos_Label_AplicarDescuento.Visible = false;
                    EleccionAsientos_Panel_AplicarDescuento.Visible = false;
                }
            } else
            {
                EleccionAsientos_Label_AplicarDescuento.Visible = false;
                EleccionAsientos_Panel_AplicarDescuento.Visible = false;
            }
            
        }

        private void TransparenciaAsientos()
        {
            #region Clase Ejecutiva
            A1.Parent = eleccionAsientos_PictureBox_Esquema;
            A1.BackColor = Color.Transparent;
            A2.Parent = eleccionAsientos_PictureBox_Esquema;
            A2.BackColor = Color.Transparent;
            A3.Parent = eleccionAsientos_PictureBox_Esquema;
            A3.BackColor = Color.Transparent;
            A4.Parent = eleccionAsientos_PictureBox_Esquema;
            A4.BackColor = Color.Transparent;
            B1.Parent = eleccionAsientos_PictureBox_Esquema;
            B1.BackColor = Color.Transparent;
            B2.Parent = eleccionAsientos_PictureBox_Esquema;
            B2.BackColor = Color.Transparent;
            B3.Parent = eleccionAsientos_PictureBox_Esquema;
            B3.BackColor = Color.Transparent;
            B4.Parent = eleccionAsientos_PictureBox_Esquema;
            B4.BackColor = Color.Transparent;
            C1.Parent = eleccionAsientos_PictureBox_Esquema;
            C1.BackColor = Color.Transparent;
            C2.Parent = eleccionAsientos_PictureBox_Esquema;
            C2.BackColor = Color.Transparent;
            C3.Parent = eleccionAsientos_PictureBox_Esquema;
            C3.BackColor = Color.Transparent;
            C4.Parent = eleccionAsientos_PictureBox_Esquema;
            C4.BackColor = Color.Transparent;
            D1.Parent = eleccionAsientos_PictureBox_Esquema;
            D1.BackColor = Color.Transparent;
            D2.Parent = eleccionAsientos_PictureBox_Esquema;
            D2.BackColor = Color.Transparent;
            D3.Parent = eleccionAsientos_PictureBox_Esquema;
            D3.BackColor = Color.Transparent;
            D4.Parent = eleccionAsientos_PictureBox_Esquema;
            D4.BackColor = Color.Transparent;
            E1.Parent = eleccionAsientos_PictureBox_Esquema;
            E1.BackColor = Color.Transparent;
            E2.Parent = eleccionAsientos_PictureBox_Esquema;
            E2.BackColor = Color.Transparent;
            E3.Parent = eleccionAsientos_PictureBox_Esquema;
            E3.BackColor = Color.Transparent;
            E4.Parent = eleccionAsientos_PictureBox_Esquema;
            E4.BackColor = Color.Transparent;
            F1.Parent = eleccionAsientos_PictureBox_Esquema;
            F1.BackColor = Color.Transparent;
            F2.Parent = eleccionAsientos_PictureBox_Esquema;
            F2.BackColor = Color.Transparent;
            F3.Parent = eleccionAsientos_PictureBox_Esquema;
            F3.BackColor = Color.Transparent;
            F4.Parent = eleccionAsientos_PictureBox_Esquema;
            F4.BackColor = Color.Transparent;
            #endregion

            #region Clase Económica
            H1.Parent = eleccionAsientos_PictureBox_Esquema;
            H1.BackColor = Color.Transparent;
            H2.Parent = eleccionAsientos_PictureBox_Esquema;
            H2.BackColor = Color.Transparent;
            H3.Parent = eleccionAsientos_PictureBox_Esquema;
            H3.BackColor = Color.Transparent;
            H4.Parent = eleccionAsientos_PictureBox_Esquema;
            H4.BackColor = Color.Transparent;
            H5.Parent = eleccionAsientos_PictureBox_Esquema;
            H5.BackColor = Color.Transparent;
            H6.Parent = eleccionAsientos_PictureBox_Esquema;
            H6.BackColor = Color.Transparent;
            H7.Parent = eleccionAsientos_PictureBox_Esquema;
            H7.BackColor = Color.Transparent;
            I1.Parent = eleccionAsientos_PictureBox_Esquema;
            I1.BackColor = Color.Transparent;
            I2.Parent = eleccionAsientos_PictureBox_Esquema;
            I2.BackColor = Color.Transparent;
            I3.Parent = eleccionAsientos_PictureBox_Esquema;
            I3.BackColor = Color.Transparent;
            I4.Parent = eleccionAsientos_PictureBox_Esquema;
            I4.BackColor = Color.Transparent;
            I5.Parent = eleccionAsientos_PictureBox_Esquema;
            I5.BackColor = Color.Transparent;
            I6.Parent = eleccionAsientos_PictureBox_Esquema;
            I6.BackColor = Color.Transparent;
            I7.Parent = eleccionAsientos_PictureBox_Esquema;
            I7.BackColor = Color.Transparent;
            J1.Parent = eleccionAsientos_PictureBox_Esquema;
            J1.BackColor = Color.Transparent;
            J2.Parent = eleccionAsientos_PictureBox_Esquema;
            J2.BackColor = Color.Transparent;
            J3.Parent = eleccionAsientos_PictureBox_Esquema;
            J3.BackColor = Color.Transparent;
            J4.Parent = eleccionAsientos_PictureBox_Esquema;
            J4.BackColor = Color.Transparent;
            J5.Parent = eleccionAsientos_PictureBox_Esquema;
            J5.BackColor = Color.Transparent;
            J6.Parent = eleccionAsientos_PictureBox_Esquema;
            J6.BackColor = Color.Transparent;
            J7.Parent = eleccionAsientos_PictureBox_Esquema;
            J7.BackColor = Color.Transparent;
            K1.Parent = eleccionAsientos_PictureBox_Esquema;
            K1.BackColor = Color.Transparent;
            K2.Parent = eleccionAsientos_PictureBox_Esquema;
            K2.BackColor = Color.Transparent;
            K3.Parent = eleccionAsientos_PictureBox_Esquema;
            K3.BackColor = Color.Transparent;
            K4.Parent = eleccionAsientos_PictureBox_Esquema;
            K4.BackColor = Color.Transparent;
            K5.Parent = eleccionAsientos_PictureBox_Esquema;
            K5.BackColor = Color.Transparent;
            K6.Parent = eleccionAsientos_PictureBox_Esquema;
            K6.BackColor = Color.Transparent;
            K7.Parent = eleccionAsientos_PictureBox_Esquema;
            K7.BackColor = Color.Transparent;
            L1.Parent = eleccionAsientos_PictureBox_Esquema;
            L1.BackColor = Color.Transparent;
            L2.Parent = eleccionAsientos_PictureBox_Esquema;
            L2.BackColor = Color.Transparent;
            L3.Parent = eleccionAsientos_PictureBox_Esquema;
            L3.BackColor = Color.Transparent;
            L4.Parent = eleccionAsientos_PictureBox_Esquema;
            L4.BackColor = Color.Transparent;
            L5.Parent = eleccionAsientos_PictureBox_Esquema;
            L5.BackColor = Color.Transparent;
            L6.Parent = eleccionAsientos_PictureBox_Esquema;
            L6.BackColor = Color.Transparent;
            L7.Parent = eleccionAsientos_PictureBox_Esquema;
            L7.BackColor = Color.Transparent;
            M1.Parent = eleccionAsientos_PictureBox_Esquema;
            M1.BackColor = Color.Transparent;
            M2.Parent = eleccionAsientos_PictureBox_Esquema;
            M2.BackColor = Color.Transparent;
            M3.Parent = eleccionAsientos_PictureBox_Esquema;
            M3.BackColor = Color.Transparent;
            M4.Parent = eleccionAsientos_PictureBox_Esquema;
            M4.BackColor = Color.Transparent;
            M5.Parent = eleccionAsientos_PictureBox_Esquema;
            M5.BackColor = Color.Transparent;
            M6.Parent = eleccionAsientos_PictureBox_Esquema;
            M6.BackColor = Color.Transparent;
            M7.Parent = eleccionAsientos_PictureBox_Esquema;
            M7.BackColor = Color.Transparent;
            N1.Parent = eleccionAsientos_PictureBox_Esquema;
            N1.BackColor = Color.Transparent;
            N2.Parent = eleccionAsientos_PictureBox_Esquema;
            N2.BackColor = Color.Transparent;
            N3.Parent = eleccionAsientos_PictureBox_Esquema;
            N3.BackColor = Color.Transparent;
            N4.Parent = eleccionAsientos_PictureBox_Esquema;
            N4.BackColor = Color.Transparent;
            N5.Parent = eleccionAsientos_PictureBox_Esquema;
            N5.BackColor = Color.Transparent;
            N6.Parent = eleccionAsientos_PictureBox_Esquema;
            N6.BackColor = Color.Transparent;
            N7.Parent = eleccionAsientos_PictureBox_Esquema;
            N7.BackColor = Color.Transparent;
            O1.Parent = eleccionAsientos_PictureBox_Esquema;
            O1.BackColor = Color.Transparent;
            O2.Parent = eleccionAsientos_PictureBox_Esquema;
            O2.BackColor = Color.Transparent;
            O3.Parent = eleccionAsientos_PictureBox_Esquema;
            O3.BackColor = Color.Transparent;
            O4.Parent = eleccionAsientos_PictureBox_Esquema;
            O4.BackColor = Color.Transparent;
            O5.Parent = eleccionAsientos_PictureBox_Esquema;
            O5.BackColor = Color.Transparent;
            O6.Parent = eleccionAsientos_PictureBox_Esquema;
            O6.BackColor = Color.Transparent;
            O7.Parent = eleccionAsientos_PictureBox_Esquema;
            O7.BackColor = Color.Transparent;
            P1.Parent = eleccionAsientos_PictureBox_Esquema;
            P1.BackColor = Color.Transparent;
            P2.Parent = eleccionAsientos_PictureBox_Esquema;
            P2.BackColor = Color.Transparent;
            P3.Parent = eleccionAsientos_PictureBox_Esquema;
            P3.BackColor = Color.Transparent;
            P4.Parent = eleccionAsientos_PictureBox_Esquema;
            P4.BackColor = Color.Transparent;
            P5.Parent = eleccionAsientos_PictureBox_Esquema;
            P5.BackColor = Color.Transparent;
            P6.Parent = eleccionAsientos_PictureBox_Esquema;
            P6.BackColor = Color.Transparent;
            P7.Parent = eleccionAsientos_PictureBox_Esquema;
            P7.BackColor = Color.Transparent;
            Q1.Parent = eleccionAsientos_PictureBox_Esquema;
            Q1.BackColor = Color.Transparent;
            Q2.Parent = eleccionAsientos_PictureBox_Esquema;
            Q2.BackColor = Color.Transparent;
            Q3.Parent = eleccionAsientos_PictureBox_Esquema;
            Q3.BackColor = Color.Transparent;
            Q4.Parent = eleccionAsientos_PictureBox_Esquema;
            Q4.BackColor = Color.Transparent;
            Q5.Parent = eleccionAsientos_PictureBox_Esquema;
            Q5.BackColor = Color.Transparent;
            Q6.Parent = eleccionAsientos_PictureBox_Esquema;
            Q6.BackColor = Color.Transparent;
            Q7.Parent = eleccionAsientos_PictureBox_Esquema;
            Q7.BackColor = Color.Transparent;
            R1.Parent = eleccionAsientos_PictureBox_Esquema;
            R1.BackColor = Color.Transparent;
            R2.Parent = eleccionAsientos_PictureBox_Esquema;
            R2.BackColor = Color.Transparent;
            R3.Parent = eleccionAsientos_PictureBox_Esquema;
            R3.BackColor = Color.Transparent;
            R4.Parent = eleccionAsientos_PictureBox_Esquema;
            R4.BackColor = Color.Transparent;
            R5.Parent = eleccionAsientos_PictureBox_Esquema;
            R5.BackColor = Color.Transparent;
            R6.Parent = eleccionAsientos_PictureBox_Esquema;
            R6.BackColor = Color.Transparent;
            R7.Parent = eleccionAsientos_PictureBox_Esquema;
            R7.BackColor = Color.Transparent;
            S1.Parent = eleccionAsientos_PictureBox_Esquema;
            S1.BackColor = Color.Transparent;
            S2.Parent = eleccionAsientos_PictureBox_Esquema;
            S2.BackColor = Color.Transparent;
            S3.Parent = eleccionAsientos_PictureBox_Esquema;
            S3.BackColor = Color.Transparent;
            S4.Parent = eleccionAsientos_PictureBox_Esquema;
            S4.BackColor = Color.Transparent;
            S5.Parent = eleccionAsientos_PictureBox_Esquema;
            S5.BackColor = Color.Transparent;
            S6.Parent = eleccionAsientos_PictureBox_Esquema;
            S6.BackColor = Color.Transparent;
            S7.Parent = eleccionAsientos_PictureBox_Esquema;
            S7.BackColor = Color.Transparent;
            #endregion

        }

        private void AdicionALista_TotalAsientos()
        {
            asientos = new List<Label>();
            asientos.Add(A1);
            asientos.Add(A2);
            asientos.Add(A3);
            asientos.Add(A4);
            asientos.Add(B1);
            asientos.Add(B2);
            asientos.Add(B3);
            asientos.Add(B4);
            asientos.Add(C1);
            asientos.Add(C2);
            asientos.Add(C3);
            asientos.Add(C4);
            asientos.Add(D1);
            asientos.Add(D2);
            asientos.Add(D3);
            asientos.Add(D4);
            asientos.Add(E1);
            asientos.Add(E2);
            asientos.Add(E3);
            asientos.Add(E4);
            asientos.Add(F1);
            asientos.Add(F2);
            asientos.Add(F3);
            asientos.Add(F4);
            asientos.Add(H1);
            asientos.Add(H2);
            asientos.Add(H3);
            asientos.Add(H4);
            asientos.Add(H5);
            asientos.Add(H6);
            asientos.Add(H7);
            asientos.Add(I1);
            asientos.Add(I2);
            asientos.Add(I3);
            asientos.Add(I4);
            asientos.Add(I5);
            asientos.Add(I6);
            asientos.Add(I7);
            asientos.Add(J1);
            asientos.Add(J2);
            asientos.Add(J3);
            asientos.Add(J4);
            asientos.Add(J5);
            asientos.Add(J6);
            asientos.Add(J7);
            asientos.Add(K1);
            asientos.Add(K2);
            asientos.Add(K3);
            asientos.Add(K4);
            asientos.Add(K5);
            asientos.Add(K6);
            asientos.Add(K7);
            asientos.Add(L1);
            asientos.Add(L2);
            asientos.Add(L3);
            asientos.Add(L4);
            asientos.Add(L5);
            asientos.Add(L6);
            asientos.Add(L7);
            asientos.Add(M1);
            asientos.Add(M2);
            asientos.Add(M3);
            asientos.Add(M4);
            asientos.Add(M5);
            asientos.Add(M6);
            asientos.Add(M7);
            asientos.Add(N1);
            asientos.Add(N2);
            asientos.Add(N3);
            asientos.Add(N4);
            asientos.Add(N5);
            asientos.Add(N6);
            asientos.Add(N7);
            asientos.Add(O1);
            asientos.Add(O2);
            asientos.Add(O3);
            asientos.Add(O4);
            asientos.Add(O5);
            asientos.Add(O6);
            asientos.Add(O7);
            asientos.Add(P1);
            asientos.Add(P2);
            asientos.Add(P3);
            asientos.Add(P4);
            asientos.Add(P5);
            asientos.Add(P6);
            asientos.Add(P7);
            asientos.Add(Q1);
            asientos.Add(Q2);
            asientos.Add(Q3);
            asientos.Add(Q4);
            asientos.Add(Q5);
            asientos.Add(Q6);
            asientos.Add(Q7);
            asientos.Add(R1);
            asientos.Add(R2);
            asientos.Add(R3);
            asientos.Add(R4);
            asientos.Add(R5);
            asientos.Add(R6);
            asientos.Add(R7);
            asientos.Add(S1);
            asientos.Add(S2);
            asientos.Add(S3);
            asientos.Add(S4);
            asientos.Add(S5);
            asientos.Add(S6);
            asientos.Add(S7);
        }
        private void EleccionAsientos_Form_Load(object sender, EventArgs e)
        {
            TransparenciaAsientos();
            AdicionALista_TotalAsientos();

            Vuelo vuelo = new Vuelo();
            vuelo.AsignaAsientosOcupadosEnLista_BD(vueloDeInteres.NombreDeRuta, asientos);

            if (datosUsuario.ProgramaMillas)
            {
                eleccionAsientos_Label_CantidadMillasValor.Text = datosUsuario.MillasAcumuladas.ToString();
            }
        }

        private void Click_General(Label l)
        {
            if (l.BackColor.Name == "Red")
            {
                MessageBox.Show("El asiento se encuentra ocupado", "Asiento ocupado");
            }
            else
            {
                if (l.BackColor.Name == "Transparent")
                {
                    foreach (var label in asientos)
                    {
                        string asiento = label.Text.Trim();
                        if (!asiento.Equals(l.Text.Trim()))
                        {
                            label.BackColor = Color.Transparent;
                            label.Refresh();
                        }
                    }
                    l.BackColor = Color.Green;
                    eleccionAsientos_Label_Asiento.Text = l.Text.Trim();
                }
            }
            eleccionAsientos_Button_Continuar.Enabled = true;
            eleccionAsientos_Button_Continuar.Text = "Continuar";
        }

        private void A1_Click(object sender, EventArgs e)
        {
            Click_General(A1);
        }

        private void A2_Click(object sender, EventArgs e)
        {
            Click_General(A2);
        }

        private void A3_Click(object sender, EventArgs e)
        {
            Click_General(A3);
        }

        private void A4_Click(object sender, EventArgs e)
        {
            Click_General(A4);
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Click_General(B1);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Click_General(B2);
        }

        private void B3_Click(object sender, EventArgs e)
        {
            Click_General(B3);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            Click_General(B4);
        }

        private void C1_Click(object sender, EventArgs e)
        {
            Click_General(C1);
        }

        private void C2_Click(object sender, EventArgs e)
        {
            Click_General(C2);
        }

        private void C3_Click(object sender, EventArgs e)
        {
            Click_General(C3);
        }

        private void C4_Click(object sender, EventArgs e)
        {
            Click_General(C4);
        }

        private void D1_Click(object sender, EventArgs e)
        {
            Click_General(D1);
        }

        private void D2_Click(object sender, EventArgs e)
        {
            Click_General(D2);
        }

        private void D3_Click(object sender, EventArgs e)
        {
            Click_General(D3);
        }

        private void D4_Click(object sender, EventArgs e)
        {
            Click_General(D4);
        }

        private void E1_Click(object sender, EventArgs e)
        {
            Click_General(E1);
        }

        private void E2_Click(object sender, EventArgs e)
        {
            Click_General(E2);
        }

        private void E3_Click(object sender, EventArgs e)
        {
            Click_General(E3);
        }

        private void E4_Click(object sender, EventArgs e)
        {
            Click_General(E4);
        }

        private void F1_Click(object sender, EventArgs e)
        {
            Click_General(F1);
        }

        private void F2_Click(object sender, EventArgs e)
        {
            Click_General(F2);
        }

        private void F3_Click(object sender, EventArgs e)
        {
            Click_General(F3);
        }

        private void F4_Click(object sender, EventArgs e)
        {
            Click_General(F4);
        }

        private void H1_Click(object sender, EventArgs e)
        {
            Click_General(H1);
        }

        private void H2_Click(object sender, EventArgs e)
        {
            Click_General(H2);
        }

        private void H3_Click(object sender, EventArgs e)
        {
            Click_General(H3);
        }

        private void H4_Click(object sender, EventArgs e)
        {
            Click_General(H4);
        }

        private void H5_Click(object sender, EventArgs e)
        {
            Click_General(H5);
        }

        private void H6_Click(object sender, EventArgs e)
        {
            Click_General(H6);
        }

        private void H7_Click(object sender, EventArgs e)
        {
            Click_General(H7);
        }

        private void I1_Click(object sender, EventArgs e)
        {
            Click_General(I1);
        }

        private void I2_Click(object sender, EventArgs e)
        {
            Click_General(I2);
        }

        private void I3_Click(object sender, EventArgs e)
        {
            Click_General(I3);
        }

        private void I4_Click(object sender, EventArgs e)
        {
            Click_General(I4);
        }

        private void I5_Click(object sender, EventArgs e)
        {
            Click_General(I5);
        }

        private void I6_Click(object sender, EventArgs e)
        {
            Click_General(I6);
        }

        private void I7_Click(object sender, EventArgs e)
        {
            Click_General(I7);
        }

        private void J1_Click(object sender, EventArgs e)
        {
            Click_General(J1);
        }

        private void J2_Click(object sender, EventArgs e)
        {
            Click_General(J2);
        }

        private void J3_Click(object sender, EventArgs e)
        {
            Click_General(J3);
        }

        private void J4_Click(object sender, EventArgs e)
        {
            Click_General(J4);
        }

        private void J5_Click(object sender, EventArgs e)
        {
            Click_General(J5);
        }

        private void J6_Click(object sender, EventArgs e)
        {
            Click_General(J6);
        }

        private void J7_Click(object sender, EventArgs e)
        {
            Click_General(J7);
        }

        private void K1_Click(object sender, EventArgs e)
        {
            Click_General(K1);
        }

        private void K2_Click(object sender, EventArgs e)
        {
            Click_General(K2);
        }

        private void K3_Click(object sender, EventArgs e)
        {
            Click_General(K3);
        }

        private void K4_Click(object sender, EventArgs e)
        {
            Click_General(K4);
        }

        private void K5_Click(object sender, EventArgs e)
        {
            Click_General(K5);
        }

        private void K6_Click(object sender, EventArgs e)
        {
            Click_General(K6);
        }

        private void K7_Click(object sender, EventArgs e)
        {
            Click_General(K7);
        }

        private void L1_Click(object sender, EventArgs e)
        {
            Click_General(L1);
        }

        private void L2_Click(object sender, EventArgs e)
        {
            Click_General(L2);
        }

        private void L3_Click(object sender, EventArgs e)
        {
            Click_General(L3);
        }

        private void L4_Click(object sender, EventArgs e)
        {
            Click_General(L4);
        }

        private void L5_Click(object sender, EventArgs e)
        {
            Click_General(L5);
        }

        private void L6_Click(object sender, EventArgs e)
        {
            Click_General(L6);
        }

        private void L7_Click(object sender, EventArgs e)
        {
            Click_General(L7);
        }

        private void M1_Click(object sender, EventArgs e)
        {
            Click_General(M1);
        }

        private void M2_Click(object sender, EventArgs e)
        {
            Click_General(M2);
        }

        private void M3_Click(object sender, EventArgs e)
        {
            Click_General(M3);
        }

        private void M4_Click(object sender, EventArgs e)
        {
            Click_General(M4);
        }

        private void M5_Click(object sender, EventArgs e)
        {
            Click_General(M5);
        }

        private void M6_Click(object sender, EventArgs e)
        {
            Click_General(M6);
        }

        private void M7_Click(object sender, EventArgs e)
        {
            Click_General(M7);
        }

        private void N1_Click(object sender, EventArgs e)
        {
            Click_General(N1);
        }

        private void N2_Click(object sender, EventArgs e)
        {
            Click_General(N2);
        }

        private void N3_Click(object sender, EventArgs e)
        {
            Click_General(N3);
        }

        private void N4_Click(object sender, EventArgs e)
        {
            Click_General(N4);
        }

        private void N5_Click(object sender, EventArgs e)
        {
            Click_General(N5);
        }

        private void N6_Click(object sender, EventArgs e)
        {
            Click_General(N6);
        }

        private void N7_Click(object sender, EventArgs e)
        {
            Click_General(N7);
        }

        private void O1_Click(object sender, EventArgs e)
        {
            Click_General(O1);
        }

        private void O2_Click(object sender, EventArgs e)
        {
            Click_General(O2);
        }

        private void O3_Click(object sender, EventArgs e)
        {
            Click_General(O3);
        }

        private void O4_Click(object sender, EventArgs e)
        {
            Click_General(O4);
        }

        private void O5_Click(object sender, EventArgs e)
        {
            Click_General(O5);
        }

        private void O6_Click(object sender, EventArgs e)
        {
            Click_General(O6);
        }

        private void O7_Click(object sender, EventArgs e)
        {
            Click_General(O7);
        }

        private void P1_Click(object sender, EventArgs e)
        {
            Click_General(P1);
        }

        private void P2_Click(object sender, EventArgs e)
        {
            Click_General(P2);
        }

        private void P3_Click(object sender, EventArgs e)
        {
            Click_General(P3);
        }

        private void P4_Click(object sender, EventArgs e)
        {
            Click_General(P4);
        }

        private void P5_Click(object sender, EventArgs e)
        {
            Click_General(P5);
        }

        private void P6_Click(object sender, EventArgs e)
        {
            Click_General(P6);
        }

        private void P7_Click(object sender, EventArgs e)
        {
            Click_General(P7);
        }

        private void Q1_Click(object sender, EventArgs e)
        {
            Click_General(Q1);
        }

        private void Q2_Click(object sender, EventArgs e)
        {
            Click_General(Q2);
        }

        private void Q3_Click(object sender, EventArgs e)
        {
            Click_General(Q3);
        }

        private void Q4_Click(object sender, EventArgs e)
        {
            Click_General(Q4);
        }

        private void Q5_Click(object sender, EventArgs e)
        {
            Click_General(Q5);
        }

        private void Q6_Click(object sender, EventArgs e)
        {
            Click_General(Q6);
        }

        private void Q7_Click(object sender, EventArgs e)
        {
            Click_General(Q7);
        }

        private void R1_Click(object sender, EventArgs e)
        {
            Click_General(R1);
        }

        private void R2_Click(object sender, EventArgs e)
        {
            Click_General(R2);
        }

        private void R3_Click(object sender, EventArgs e)
        {
            Click_General(R3);
        }

        private void R4_Click(object sender, EventArgs e)
        {
            Click_General(R4);
        }

        private void R5_Click(object sender, EventArgs e)
        {
            Click_General(R5);
        }

        private void R6_Click(object sender, EventArgs e)
        {
            Click_General(R6);
        }

        private void R7_Click(object sender, EventArgs e)
        {
            Click_General(R7);
        }

        private void S1_Click(object sender, EventArgs e)
        {
            Click_General(S1);
        }

        private void S2_Click(object sender, EventArgs e)
        {
            Click_General(S2);
        }

        private void S3_Click(object sender, EventArgs e)
        {
            Click_General(S3);
        }

        private void S4_Click(object sender, EventArgs e)
        {
            Click_General(S4);
        }

        private void S5_Click(object sender, EventArgs e)
        {
            Click_General(S5);
        }

        private void S6_Click(object sender, EventArgs e)
        {
            Click_General(S6);
        }

        private void S7_Click(object sender, EventArgs e)
        {
            Click_General(S7);
        }

        private void eleccionAsientos_Button_Continuar_Click(object sender, EventArgs e)
        {
            Usuario objetoUsuario = new Usuario();
            if (objetoUsuario.PerteneceProgramaMillas_BD(datosUsuario.Cedula))
            {

                if (((!eleccionAsientos_RadioButton_Efectivo.Checked) && (!eleccionAsientos_RadioButton_Tarjeta.Checked)) || 
                    ((!eleccionAsientos_RadioButton_SI.Checked) && (!eleccionAsientos_RadioButton_NO.Checked))) 
                {
                    MessageBox.Show("Se debe seleccionar un método de pago y si se desea aplicar descuento", "Rellene todos los campos");
                } else
                {
                    if (eleccionAsientos_RadioButton_SI.Checked && !eleccionAsientos_RadioButton_NO.Checked)
                    {
                        if (String.IsNullOrWhiteSpace(eleccionAsientos_TextBox_MillasAUsar.Text))
                        {
                            MessageBox.Show("Debe especificar la cantidad de millas que desea invertir, con un máximo de "+datosUsuario.MillasAcumuladas+".", "Especificar cantidad de millas");
                        } else
                        {
                            int millasAUsar = 0;
                            try
                            {
                                millasAUsar = int.Parse(eleccionAsientos_TextBox_MillasAUsar.Text.Trim());
                            }
                            catch (FormatException fe)
                            {
                                MessageBox.Show("El valor de millas no es válido. Revisar que el dato haya sido introducido correctamente.", "Error");
                                return;
                            }
                            if (int.Parse(eleccionAsientos_TextBox_MillasAUsar.Text) > datosUsuario.MillasAcumuladas)
                            {
                                MessageBox.Show("La cantidad de millas especificada supera el máximo almacenado por el usuario. Cantidad acumulada: " + datosUsuario.MillasAcumuladas + ", Cantidad solicitada: " + eleccionAsientos_TextBox_MillasAUsar.Text + ".", "Cantidad de millas inválida.");
                                return;
                            }
                            string metodoDePago = "";

                            if (eleccionAsientos_RadioButton_Efectivo.Checked)
                            {
                                metodoDePago = eleccionAsientos_RadioButton_Efectivo.Text;

                            }
                            else if (eleccionAsientos_RadioButton_Tarjeta.Checked)
                            {
                                metodoDePago = eleccionAsientos_RadioButton_Tarjeta.Text;
                            }
                            
                            
                            
                            Tiquete tiquete = new Tiquete(vueloDeInteres.NumeroDeVuelo, eleccionAsientos_Label_Asiento.Text, DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")), datosUsuario.Cedula, metodoDePago, descripcion);

                            tiquete.CalcularDescuentoTiquete(int.Parse(eleccionAsientos_TextBox_MillasAUsar.Text));
                            tiquete.CalcularPrecioFinal();
                            ConfirmacionFinal_Form confirmacionForm = new ConfirmacionFinal_Form(tiquete, datosUsuario, vueloDeInteres, usuarioExisteEnBD, int.Parse(eleccionAsientos_TextBox_MillasAUsar.Text)); 
                            confirmacionForm.ShowDialog();

                            if (compraConfirmada)
                            {
                                PantallaPrincipal_Form.compraConfirmada = true;
                                this.Close();
                            }
                        }
                    } else if (!eleccionAsientos_RadioButton_SI.Checked && eleccionAsientos_RadioButton_NO.Checked)
                    {
                        string metodoDePago = "";

                        if (eleccionAsientos_RadioButton_Efectivo.Checked)
                        {
                            metodoDePago = eleccionAsientos_RadioButton_Efectivo.Text;

                        }
                        else if (eleccionAsientos_RadioButton_Tarjeta.Checked)
                        {
                            metodoDePago = eleccionAsientos_RadioButton_Tarjeta.Text;
                        }

                        Tiquete tiquete = new Tiquete(vueloDeInteres.NumeroDeVuelo, eleccionAsientos_Label_Asiento.Text, DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")), datosUsuario.Cedula, metodoDePago, descripcion);
                        tiquete.CalcularPrecioFinal();
                        ConfirmacionFinal_Form confirmacionForm = new ConfirmacionFinal_Form(tiquete, datosUsuario, vueloDeInteres, usuarioExisteEnBD);
                        confirmacionForm.ShowDialog();
                        if (compraConfirmada)
                        {
                            PantallaPrincipal_Form.compraConfirmada = true;
                            this.Close();
                        }
                    }
                }
            } else if ((!eleccionAsientos_RadioButton_Tarjeta.Checked) && (!eleccionAsientos_RadioButton_Efectivo.Checked))
            {
                MessageBox.Show("Se debe seleccionar un método de pago", "Seleccionar método de pago"); 
            } else
            {
                string metodoDePago = "";

                if (eleccionAsientos_RadioButton_Efectivo.Checked)
                {
                    metodoDePago = eleccionAsientos_RadioButton_Efectivo.Text;

                }
                else if (eleccionAsientos_RadioButton_Tarjeta.Checked)
                {
                    metodoDePago = eleccionAsientos_RadioButton_Tarjeta.Text;
                }

                Tiquete tiquete = new Tiquete(vueloDeInteres.NumeroDeVuelo, eleccionAsientos_Label_Asiento.Text, DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("es-ES")), datosUsuario.Cedula, metodoDePago, descripcion);
                tiquete.CalcularPrecioFinal();
                ConfirmacionFinal_Form confirmacionForm = new ConfirmacionFinal_Form(tiquete, datosUsuario, vueloDeInteres, usuarioExisteEnBD);
                confirmacionForm.ShowDialog();
                if (compraConfirmada)
                {
                    PantallaPrincipal_Form.compraConfirmada = true;
                    this.Close();
                }
            }
        }

        private void eleccionAsientos_PictureBox_Esquema_Click(object sender, EventArgs e)
        {

        }

        private void eleccionAsientos_RadioButton_SI_CheckedChanged(object sender, EventArgs e)
        {
            eleccionAsiento_Label_MillasAUsar.Visible = true;
            eleccionAsientos_TextBox_MillasAUsar.Visible = true;
            eleccionAsientos_Label_CantidadDeMillasDisponibles.Visible = true;
            eleccionAsientos_Label_CantidadMillasValor.Visible = true; 
        }

        private void eleccionAsientos_RadioButton_NO_CheckedChanged(object sender, EventArgs e)
        {
            eleccionAsiento_Label_MillasAUsar.Visible = false;
            eleccionAsientos_TextBox_MillasAUsar.Visible = false;
            eleccionAsientos_Label_CantidadDeMillasDisponibles.Visible = false;
            eleccionAsientos_Label_CantidadMillasValor.Visible = false;
        }

    }
}
