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
    public partial class EleccionAsientosMod_Form : Form
    {

        public List<Label> asientosLibres;
        public List<Label> asientosOcupados;
        string nombreDeRuta;
        string numeroDeAsientoPrevio;
        string numeroDeAsientoNuevo;
        string numeroDeTiquete;
        decimal descuentoPrevio;
        decimal precioPrevio;
        bool vieneDePrecioNegativo = false;
        public EleccionAsientosMod_Form(string nombreDeRuta, string numeroDeTiquete, decimal descuentoPrevio, decimal precioPrevio, string numeroDeAsientoPrevio)
        {
            InitializeComponent();
            this.nombreDeRuta = nombreDeRuta;
            this.numeroDeTiquete = numeroDeTiquete;
            this.descuentoPrevio = descuentoPrevio;
            this.precioPrevio = precioPrevio;
            this.numeroDeAsientoPrevio = numeroDeAsientoPrevio;
        }

        private void TransparenciaAsientos()
        {
            #region Clase Ejecutiva
            A1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            A1.BackColor = Color.Transparent;
            A2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            A2.BackColor = Color.Transparent;
            A3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            A3.BackColor = Color.Transparent;
            A4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            A4.BackColor = Color.Transparent;
            B1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            B1.BackColor = Color.Transparent;
            B2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            B2.BackColor = Color.Transparent;
            B3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            B3.BackColor = Color.Transparent;
            B4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            B4.BackColor = Color.Transparent;
            C1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            C1.BackColor = Color.Transparent;
            C2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            C2.BackColor = Color.Transparent;
            C3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            C3.BackColor = Color.Transparent;
            C4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            C4.BackColor = Color.Transparent;
            D1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            D1.BackColor = Color.Transparent;
            D2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            D2.BackColor = Color.Transparent;
            D3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            D3.BackColor = Color.Transparent;
            D4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            D4.BackColor = Color.Transparent;
            E1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            E1.BackColor = Color.Transparent;
            E2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            E2.BackColor = Color.Transparent;
            E3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            E3.BackColor = Color.Transparent;
            E4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            E4.BackColor = Color.Transparent;
            F1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            F1.BackColor = Color.Transparent;
            F2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            F2.BackColor = Color.Transparent;
            F3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            F3.BackColor = Color.Transparent;
            F4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            F4.BackColor = Color.Transparent;
            #endregion
            #region Clase Económica
            H1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H1.BackColor = Color.Transparent;
            H2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H2.BackColor = Color.Transparent;
            H3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H3.BackColor = Color.Transparent;
            H4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H4.BackColor = Color.Transparent;
            H5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H5.BackColor = Color.Transparent;
            H6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H6.BackColor = Color.Transparent;
            H7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            H7.BackColor = Color.Transparent;
            I1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I1.BackColor = Color.Transparent;
            I2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I2.BackColor = Color.Transparent;
            I3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I3.BackColor = Color.Transparent;
            I4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I4.BackColor = Color.Transparent;
            I5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I5.BackColor = Color.Transparent;
            I6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I6.BackColor = Color.Transparent;
            I7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            I7.BackColor = Color.Transparent;
            J1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J1.BackColor = Color.Transparent;
            J2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J2.BackColor = Color.Transparent;
            J3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J3.BackColor = Color.Transparent;
            J4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J4.BackColor = Color.Transparent;
            J5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J5.BackColor = Color.Transparent;
            J6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J6.BackColor = Color.Transparent;
            J7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            J7.BackColor = Color.Transparent;
            K1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K1.BackColor = Color.Transparent;
            K2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K2.BackColor = Color.Transparent;
            K3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K3.BackColor = Color.Transparent;
            K4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K4.BackColor = Color.Transparent;
            K5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K5.BackColor = Color.Transparent;
            K6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K6.BackColor = Color.Transparent;
            K7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            K7.BackColor = Color.Transparent;
            L1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L1.BackColor = Color.Transparent;
            L2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L2.BackColor = Color.Transparent;
            L3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L3.BackColor = Color.Transparent;
            L4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L4.BackColor = Color.Transparent;
            L5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L5.BackColor = Color.Transparent;
            L6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L6.BackColor = Color.Transparent;
            L7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            L7.BackColor = Color.Transparent;
            M1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M1.BackColor = Color.Transparent;
            M2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M2.BackColor = Color.Transparent;
            M3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M3.BackColor = Color.Transparent;
            M4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M4.BackColor = Color.Transparent;
            M5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M5.BackColor = Color.Transparent;
            M6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M6.BackColor = Color.Transparent;
            M7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            M7.BackColor = Color.Transparent;
            N1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N1.BackColor = Color.Transparent;
            N2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N2.BackColor = Color.Transparent;
            N3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N3.BackColor = Color.Transparent;
            N4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N4.BackColor = Color.Transparent;
            N5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N5.BackColor = Color.Transparent;
            N6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N6.BackColor = Color.Transparent;
            N7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            N7.BackColor = Color.Transparent;
            O1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O1.BackColor = Color.Transparent;
            O2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O2.BackColor = Color.Transparent;
            O3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O3.BackColor = Color.Transparent;
            O4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O4.BackColor = Color.Transparent;
            O5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O5.BackColor = Color.Transparent;
            O6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O6.BackColor = Color.Transparent;
            O7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            O7.BackColor = Color.Transparent;
            P1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P1.BackColor = Color.Transparent;
            P2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P2.BackColor = Color.Transparent;
            P3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P3.BackColor = Color.Transparent;
            P4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P4.BackColor = Color.Transparent;
            P5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P5.BackColor = Color.Transparent;
            P6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P6.BackColor = Color.Transparent;
            P7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            P7.BackColor = Color.Transparent;
            Q1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q1.BackColor = Color.Transparent;
            Q2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q2.BackColor = Color.Transparent;
            Q3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q3.BackColor = Color.Transparent;
            Q4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q4.BackColor = Color.Transparent;
            Q5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q5.BackColor = Color.Transparent;
            Q6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q6.BackColor = Color.Transparent;
            Q7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            Q7.BackColor = Color.Transparent;
            R1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R1.BackColor = Color.Transparent;
            R2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R2.BackColor = Color.Transparent;
            R3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R3.BackColor = Color.Transparent;
            R4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R4.BackColor = Color.Transparent;
            R5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R5.BackColor = Color.Transparent;
            R6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R6.BackColor = Color.Transparent;
            R7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            R7.BackColor = Color.Transparent;
            S1.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S1.BackColor = Color.Transparent;
            S2.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S2.BackColor = Color.Transparent;
            S3.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S3.BackColor = Color.Transparent;
            S4.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S4.BackColor = Color.Transparent;
            S5.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S5.BackColor = Color.Transparent;
            S6.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S6.BackColor = Color.Transparent;
            S7.Parent = eleccionAsientosMod_PictureBox_Esquema;
            S7.BackColor = Color.Transparent;
            #endregion
        }

        private void AdicionALista_TotalAsientos()
        {
            asientosLibres = new List<Label>();
            asientosLibres.Add(A1);
            asientosLibres.Add(A2);
            asientosLibres.Add(A3);
            asientosLibres.Add(A4);
            asientosLibres.Add(B1);
            asientosLibres.Add(B2);
            asientosLibres.Add(B3);
            asientosLibres.Add(B4);
            asientosLibres.Add(C1);
            asientosLibres.Add(C2);
            asientosLibres.Add(C3);
            asientosLibres.Add(C4);
            asientosLibres.Add(D1);
            asientosLibres.Add(D2);
            asientosLibres.Add(D3);
            asientosLibres.Add(D4);
            asientosLibres.Add(E1);
            asientosLibres.Add(E2);
            asientosLibres.Add(E3);
            asientosLibres.Add(E4);
            asientosLibres.Add(F1);
            asientosLibres.Add(F2);
            asientosLibres.Add(F3);
            asientosLibres.Add(F4);
            asientosLibres.Add(H1);
            asientosLibres.Add(H2);
            asientosLibres.Add(H3);
            asientosLibres.Add(H4);
            asientosLibres.Add(H5);
            asientosLibres.Add(H6);
            asientosLibres.Add(H7);
            asientosLibres.Add(I1);
            asientosLibres.Add(I2);
            asientosLibres.Add(I3);
            asientosLibres.Add(I4);
            asientosLibres.Add(I5);
            asientosLibres.Add(I6);
            asientosLibres.Add(I7);
            asientosLibres.Add(J1);
            asientosLibres.Add(J2);
            asientosLibres.Add(J3);
            asientosLibres.Add(J4);
            asientosLibres.Add(J5);
            asientosLibres.Add(J6);
            asientosLibres.Add(J7);
            asientosLibres.Add(K1);
            asientosLibres.Add(K2);
            asientosLibres.Add(K3);
            asientosLibres.Add(K4);
            asientosLibres.Add(K5);
            asientosLibres.Add(K6);
            asientosLibres.Add(K7);
            asientosLibres.Add(L1);
            asientosLibres.Add(L2);
            asientosLibres.Add(L3);
            asientosLibres.Add(L4);
            asientosLibres.Add(L5);
            asientosLibres.Add(L6);
            asientosLibres.Add(L7);
            asientosLibres.Add(M1);
            asientosLibres.Add(M2);
            asientosLibres.Add(M3);
            asientosLibres.Add(M4);
            asientosLibres.Add(M5);
            asientosLibres.Add(M6);
            asientosLibres.Add(M7);
            asientosLibres.Add(N1);
            asientosLibres.Add(N2);
            asientosLibres.Add(N3);
            asientosLibres.Add(N4);
            asientosLibres.Add(N5);
            asientosLibres.Add(N6);
            asientosLibres.Add(N7);
            asientosLibres.Add(O1);
            asientosLibres.Add(O2);
            asientosLibres.Add(O3);
            asientosLibres.Add(O4);
            asientosLibres.Add(O5);
            asientosLibres.Add(O6);
            asientosLibres.Add(O7);
            asientosLibres.Add(P1);
            asientosLibres.Add(P2);
            asientosLibres.Add(P3);
            asientosLibres.Add(P4);
            asientosLibres.Add(P5);
            asientosLibres.Add(P6);
            asientosLibres.Add(P7);
            asientosLibres.Add(Q1);
            asientosLibres.Add(Q2);
            asientosLibres.Add(Q3);
            asientosLibres.Add(Q4);
            asientosLibres.Add(Q5);
            asientosLibres.Add(Q6);
            asientosLibres.Add(Q7);
            asientosLibres.Add(R1);
            asientosLibres.Add(R2);
            asientosLibres.Add(R3);
            asientosLibres.Add(R4);
            asientosLibres.Add(R5);
            asientosLibres.Add(R6);
            asientosLibres.Add(R7);
            asientosLibres.Add(S1);
            asientosLibres.Add(S2);
            asientosLibres.Add(S3);
            asientosLibres.Add(S4);
            asientosLibres.Add(S5);
            asientosLibres.Add(S6);
            asientosLibres.Add(S7);
        }
        private void EleccionAsientosMod_Form_Load(object sender, EventArgs e)
        {
            TransparenciaAsientos();
            AdicionALista_TotalAsientos();
            eleccionAsientosMod_Label_DescuentoAFavorValor.Text = descuentoPrevio.ToString();
            asientosOcupados = new List<Label>();

            Vuelo vuelo = new Vuelo();

            vuelo.AsignaAsientosOcupadosEnLista_BD(nombreDeRuta, asientosLibres, asientosOcupados, 2);
            vuelo.AsignaAsientoPreviamenteCompradoEnLista_BD(numeroDeTiquete, numeroDeAsientoPrevio, asientosOcupados);
        }

        private void Click_General(Label l)
        {
            if (l.BackColor.Name == "Red")
            {
                MessageBox.Show("El asiento se encuentra ocupado", "Asiento ocupado");

            } else if (l.BackColor.Name == "Orange")
            {
                MessageBox.Show("El asiento es el que actualmente le pertenece al tiquete del cliente. De querer conservarlo, cerrar la ventana.", "Asiento previamente comprado");
            }
            else
            {
                if (l.BackColor.Name == "Transparent")
                {
                    foreach (var label in asientosLibres)
                    {
                        string asiento = label.Text.Trim();
                        if (!asiento.Equals(l.Text.Trim()))
                        {
                            label.BackColor = Color.Transparent;
                            label.Refresh();
                        }
                    }
                    l.BackColor = Color.Green;
                    eleccionAsientosMod_Label_Asiento.Text = l.Text.Trim();
                }
            }
            eleccionAsientosMod_Button_Continuar.Enabled = true;
            eleccionAsientosMod_Button_Continuar.Text = "Continuar";
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

        private void ModificarDatosTiquete(decimal precioDelTiquete, decimal precioFinal, int numeroDeTiquete, string numeroDeAsiento)
        {

            Tiquete tiquete = new Tiquete();
            Vuelo vuelo = new Vuelo();

            tiquete.ActualizarPrecioTiquete_BD(numeroDeTiquete, precioDelTiquete, precioFinal);
            vuelo.ActualizarNumeroDeAsiento_BD(numeroDeTiquete,  numeroDeAsiento);
        }

        private void ModificarDescuentoTiquete(decimal descuento,int numeroDeTiquete)
        {
            Tiquete tiquete = new Tiquete();
            tiquete.ActualizarDescuentoTiquete_BD(numeroDeTiquete, descuento);
        }

        private void ModificarAsientoOcupado(string numeroDeAsientoViejo, string numeroDeAsientoNuevo, int numeroDeTiquete, string nombreDeRuta)
        {
            Vuelo vuelo = new Vuelo();
            vuelo.ActualizarAsientoOcupado_BD(numeroDeTiquete, nombreDeRuta, numeroDeAsientoViejo, numeroDeAsientoNuevo);
        }

        private void AdicionarDescripcion(string mensajeAAdicionar, int numeroDeTiquete)
        {
            Tiquete tiquete = new Tiquete();
            tiquete.AdicionarDescripcionATiquete_BD(numeroDeTiquete, mensajeAAdicionar);
        }

        private void eleccionAsientosMod_Button_Continuar_Click(object sender, EventArgs e)
        {
            numeroDeAsientoNuevo = eleccionAsientosMod_Label_Asiento.Text;
            DialogResult resultado = MessageBox.Show("Cambiar el asiento " + numeroDeAsientoPrevio + " por el " + numeroDeAsientoNuevo + "? Presione YES para Sí, NO, para No.",
                "Advertencia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (resultado.ToString().Trim().ToUpper() == "YES")
            {
                Tiquete tiqueteTemporal = new Tiquete();
                //decimal precioFinal = 0;
                decimal precioNuevoDelTiquete = tiqueteTemporal.CalcularPrecioConImpuestosTiquete(numeroDeAsientoNuevo);  //El precio del asiento nuevo
                decimal precioViejoDelTiquete = precioPrevio; //El precio del asiento Viejo
                decimal precioPrevioConDescuento = tiqueteTemporal.ObtenerPrecioPrevioConDescuento(precioPrevio, descuentoPrevio);  //Precio pagado por el cliente

                if (descuentoPrevio != 0) //Si hay descuento
                {
                    if (precioNuevoDelTiquete == precioViejoDelTiquete)
                    {
                        /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                        ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                        /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                        /*ADICIONAR DESCRIPCIÓN - INICIO*/

                        string descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                            " No se da modificación en el precio.";

                        AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                        /*ADICIONAR DESCRIPCIÓN - FINAL*/

                        MessageBox.Show("Modificación realizada correctamente. El precio se mantiene, debido a que los dos tiquetes son de la misma denominación", "Alerta de desembolso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        if (precioViejoDelTiquete > precioNuevoDelTiquete) 
                        {
                            if (descuentoPrevio > precioNuevoDelTiquete)
                            {
                                descuentoPrevio = precioNuevoDelTiquete;
                                decimal precioFinal = tiqueteTemporal.CalcularPrecioFinal(precioNuevoDelTiquete, descuentoPrevio);
                                decimal precioDeReembolso = tiqueteTemporal.CalcularDiferenciaEntreTiquetes(precioPrevioConDescuento, precioNuevoDelTiquete); 

                                /*ACTUALIZAR PRECIO EN TIQUETE - INICIO*/

                                ModificarDatosTiquete(precioNuevoDelTiquete, precioFinal, int.Parse(numeroDeTiquete), numeroDeAsientoNuevo);

                                /*ACTUALIZAR PRECIO EN TIQUETE - FINAL*/

                                /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                                ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                                /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                                /*ADICIONAR DESCRIPCIÓN - INICIO*/

                                string descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                                    " Se realizará un reembolso de " + precioDeReembolso + " (precio pagado originalmente con descuento: " + precioPrevioConDescuento + ") al cliente en los próximos 3 días. El descuento previo fue mayor que " +
                                    "el valor del tiquete nuevo, por lo que la compra queda gratis.";

                                AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                                /*ADICIONAR DESCRIPCIÓN - FINAL*/

                                MessageBox.Show("Modificación realizada correctamente. Se realizará un reembolso de " + precioDeReembolso + " (precio pagado originalmente con descuento: " + precioPrevioConDescuento + ") al cliente en los próximos 3 días", "Alerta de desembolso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            } else
                            {
                                decimal precioFinal = tiqueteTemporal.CalcularPrecioFinal(precioNuevoDelTiquete, descuentoPrevio);
                                decimal precioDeReembolso = tiqueteTemporal.CalcularDiferenciaEntreTiquetes(precioPrevioConDescuento, precioNuevoDelTiquete);

                                /*ACTUALIZAR PRECIO EN TIQUETE - INICIO*/

                                ModificarDatosTiquete(precioNuevoDelTiquete, precioFinal, int.Parse(numeroDeTiquete), numeroDeAsientoNuevo);

                                /*ACTUALIZAR PRECIO EN TIQUETE - FINAL*/

                                /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                                ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                                /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                                /*ADICIONAR DESCRIPCIÓN - INICIO*/

                                string descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                                    " Se realizará un reembolso de " + precioDeReembolso + " (precio pagado originalmente con descuento: " + precioPrevioConDescuento + ") al cliente en los próximos 3 días. El descuento previo fue mayor que " +
                                    "el valor del tiquete nuevo, por lo que la compra queda gratis.";

                                AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                                /*ADICIONAR DESCRIPCIÓN - FINAL*/

                                MessageBox.Show("Modificación realizada correctamente. Se realizará un reembolso de " + precioDeReembolso + " (precio pagado originalmente con descuento: " + precioPrevioConDescuento + ") al cliente en los próximos 3 días", "Alerta de desembolso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else 
                        {
                            decimal diferenciaACobrar = tiqueteTemporal.CalcularDiferenciaEntreTiquetes(precioNuevoDelTiquete, precioPrevioConDescuento);
                            decimal precioFinal = tiqueteTemporal.CalcularPrecioFinal(precioNuevoDelTiquete, descuentoPrevio);
                            DialogResult resultado_2 = MessageBox.Show("De realizar la modificación, el cliente deberá pagar una diferencia de " + diferenciaACobrar + ". ¿Desea continuar con el cambio?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                            if (resultado_2.ToString().Trim().ToUpper() == "YES")
                            {
                                string descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                            " Precio del asiento pasa de " + precioViejoDelTiquete + " a " + precioNuevoDelTiquete + ". El cliente paga una diferencia de " + diferenciaACobrar + " para adquirir el nuevo boleto. (Pago original: " + precioPrevioConDescuento + ", Descuento original: " + descuentoPrevio + ").";

                                /*ACTUALIZAR PRECIO EN TIQUETE - INICIO*/

                                ModificarDatosTiquete(precioNuevoDelTiquete, precioFinal, int.Parse(numeroDeTiquete), numeroDeAsientoNuevo);

                                /*ACTUALIZAR PRECIO EN TIQUETE - FINAL*/

                                /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                                ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                                /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                                /*ADICIONAR DESCRIPCIÓN - INICIO*/

                                AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                                /*ADICIONAR DESCRIPCIÓN - FINAL*/

                                MessageBox.Show("Modificación realizada correctamente. El cliente paga una diferencia de " + diferenciaACobrar + " Para la adquisición del boleto. (Pago original: " + precioPrevioConDescuento + ", Descuento original: " + descuentoPrevio + ".", "Confirmación.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (resultado_2.ToString().Trim().ToUpper() == "NO")
                            {
                                MessageBox.Show("Modificación abortada.", "Modificación abortada");
                                return;
                            }
                        }
                    }
                }
                else //Si no hay descuento
                {
                    if (precioNuevoDelTiquete == precioViejoDelTiquete) //Si precio de los dos tiquetes son iguales
                    {
                        /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                        ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                        /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                        /*ADICIONAR DESCRIPCIÓN - INICIO*/

                        string descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                            " No se da modificación en el precio.";

                        AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                        /*ADICIONAR DESCRIPCIÓN - FINAL*/

                        MessageBox.Show("Modificación realizada correctamente. El precio se mantiene, debido a que los dos tiquetes son de la misma denominación", "Alerta de desembolso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else //Si precio de los tiquetes son diferentes
                    {
                        string descripcionAAdicionar;

                        if (precioViejoDelTiquete > precioNuevoDelTiquete)
                        {
                            decimal precioDeReembolso = tiqueteTemporal.CalcularDiferenciaEntreTiquetes(precioViejoDelTiquete, precioNuevoDelTiquete);
                            descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                            " Precio del asiento pasa de " + precioViejoDelTiquete + " a " + precioNuevoDelTiquete + ". Se realizará un reembolso al cliente de " + precioDeReembolso + ".";

                            /*ACTUALIZAR PRECIO EN TIQUETE - INICIO*/

                            ModificarDatosTiquete(precioNuevoDelTiquete, precioNuevoDelTiquete, int.Parse(numeroDeTiquete), numeroDeAsientoNuevo);

                            /*ACTUALIZAR PRECIO EN TIQUETE - FINAL*/

                            /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                            ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                            /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                            /*ADICIONAR DESCRIPCIÓN - INICIO*/

                            AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                            /*ADICIONAR DESCRIPCIÓN - FINAL*/

                            MessageBox.Show("Modificación realizada correctamente. El cliente deberá recibir un reembolso de " + precioDeReembolso + " en los próximos tres días.", "Alerta de desembolso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            decimal diferenciaACobrar = tiqueteTemporal.CalcularDiferenciaEntreTiquetes(precioNuevoDelTiquete, precioViejoDelTiquete);
                            DialogResult resultado_2 = MessageBox.Show("De realizar la modificación, el cliente deberá pagar una diferencia de " + diferenciaACobrar + ". ¿Desea continuar con el cambio?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                            if (resultado_2.ToString().Trim().ToUpper() == "YES")
                            {
                                descripcionAAdicionar = "MODIFICACIÓN REALIZADA - " + DateTime.Now.ToString() + " --> Asiento cambiado de " + numeroDeAsientoPrevio + " a " + numeroDeAsientoNuevo + "." +
                            " Precio del asiento pasa de " + precioViejoDelTiquete + " a " + precioNuevoDelTiquete + ". El cliente paga una diferencia de " + diferenciaACobrar + " para adquirir el nuevo boleto.";

                                /*ACTUALIZAR PRECIO EN TIQUETE - INICIO*/

                                ModificarDatosTiquete(precioNuevoDelTiquete, precioNuevoDelTiquete, int.Parse(numeroDeTiquete), numeroDeAsientoNuevo);

                                /*ACTUALIZAR PRECIO EN TIQUETE - FINAL*/

                                /*ACTUALIZAR ASIENTOS OCUPADOS - INICIO*/

                                ModificarAsientoOcupado(numeroDeAsientoPrevio, numeroDeAsientoNuevo, int.Parse(numeroDeTiquete), nombreDeRuta);

                                /*ACTUALIZAR ASIENTOS OCUPADOS - FINAL*/

                                /*ADICIONAR DESCRIPCIÓN - INICIO*/

                                AdicionarDescripcion(descripcionAAdicionar, int.Parse(numeroDeTiquete));

                                /*ADICIONAR DESCRIPCIÓN - FINAL*/

                                MessageBox.Show("Modificación realizada correctamente. El cliente paga una diferencia de " + diferenciaACobrar + " Para la adquisición del boleto.", "Confirmación.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else if (resultado_2.ToString().Trim().ToUpper() == "NO")
                            {
                                MessageBox.Show("Modificación abortada.", "Modificación abortada");
                                return;
                            }
                        }

                    }
                }
            }
        }
    }
}
