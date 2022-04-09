using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aerolinea
{
    public partial class ConfirmacionFinal_Form : Form
    {

        Usuario usuario;
        Tiquete tiquete;
        Vuelo vuelo;
        bool usuarioPreExistente;
        int millasDescontadas;
        public ConfirmacionFinal_Form(Tiquete tiquete, Usuario usuario, Vuelo vuelo, bool usuarioPreExistente, int millasDescontadas = 0)
        {
            this.usuario = usuario;
            this.tiquete = tiquete;
            this.vuelo = vuelo;
            this.usuarioPreExistente = usuarioPreExistente;
            this.millasDescontadas = millasDescontadas;
            InitializeComponent();
        }

        private void ConfirmacionFinal_Form_Load(object sender, EventArgs e)
        {
            #region DatosUsuario
            confirmacionFinal_Label_NumeroDeIdentificacionValor.Text = usuario.Cedula;
            confirmacionFinal_Label_NombreValor.Text = usuario.Nombre;
            confirmacionFinal_Label_PrimerApellidoValor.Text = usuario.PrimerApellido;
            confirmacionFinal_Label_SegundoApellidoValor.Text = usuario.SegundoApellido;
            confirmacionFinal_Label_FechaNacimientoValor.Text = usuario.FechaNacimiento;
            confirmacionFinal_Label_NumeroDeTelefonoValor.Text = usuario.NumeroTelefono;
            #endregion

            #region DatosVuelo
            confirmacionFinal_Label_NombreDeLaRutaValor.Text = vuelo.NombreDeRuta;
            confirmacionFinal_Label_NumeroDeVueloValor.Text = vuelo.NumeroDeVuelo;
            confirmacionFinal_Label_PuntoDeSalidaValor.Text = vuelo.PuntoDeSalida;
            confirmacionFinal_Label_PuntoDeLlegadaValor.Text = vuelo.PuntoDeLlegada;
            confirmacionFinal_Label_FechaDelVueloValor.Text = vuelo.FechaDelVuelo;
            confirmacionFinal_Label_HoraDelVueloValor.Text = vuelo.HoraDelVuelo;
            #endregion

            #region DatosTiquete
            confirmacionFinal_Label_FechaDeTramiteValor.Text = tiquete.FechaTramite;
            confirmacionFinal_Label_NumeroDeTiqueteValor.Text = tiquete.NumeroTiquete.ToString();
            confirmacionFinal_Label_NumeroDeAsientoValor.Text = tiquete.NumeroDeAsiento;
            confirmacionFinal_Label_MetodoDePagoValor.Text = tiquete.MetodoDePago;
            confirmacionFinal_Label_PrecioPreliminarValor.Text = tiquete.Precio.ToString();
            confirmacionFinal_Label_DescuentoAplicadoValor.Text = tiquete.Descuento.ToString();
            confirmacionFinal_Label_PrecioFinalValor.Text = tiquete.PrecioFinal.ToString();
            #endregion
        }

        private void confirmacionFinal_Button_Continuar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("A continuación se generará el pago y almacenamiento de la información a la base de datos. ¿Seguro que desea continuar? Presione CANCEL para volver a la pantalla anterior; OK para continuar", "Confirmación de Pago", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result.ToString().Trim() == "OK")
            {
                if (usuarioPreExistente)
                {
                    Tiquete tiqueteTemporal = new Tiquete();
                    Vuelo vueloTemporal = new Vuelo();
                    Equipaje equipaje = new Equipaje();

                    tiqueteTemporal.InsertarTiquete_BD(tiquete, usuario.Cedula);

                    vueloTemporal.InsertarNumeroDeAsiento_BD(vuelo.NombreDeRuta, tiquete);

                    equipaje.InsertarEquipajeVacio_BD(tiquete.NumeroTiquete);

                    if (usuario.ProgramaMillas)
                    {
                        if (millasDescontadas != 0)
                        {
                            int millasRestantes = usuario.CalcularMillasRestantes(millasDescontadas); //Calcula la cantidad de millas restantes después de descontar lo utilizado
                            int millasGanadas = usuario.CalcularMillasGanadas(vuelo.DistanciaViaje, 1); 

                            int millasFinales = usuario.CalcularMillasTotales_DespuesDeGane(millasRestantes, millasGanadas);

                            MessageBox.Show("La compra del cliente " + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + ", con cédula " + usuario.Cedula + " ha sido adicionada" +
                                "a la base de datos. Como el cliente pertenece al programa de millas:\n\n   Millas pre-descuento: " + (millasDescontadas + millasRestantes) + "\n    Millas utilizadas: " + millasDescontadas + "\n   " +
                                "Millas Ganadas por medio del programa de millas: " + millasGanadas + "\n    Millas finales post-compra: " + millasFinales, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            usuario.ActualizarMillasUsuario_BD(usuario.Cedula, millasFinales);
                            EleccionAsientos_Form.compraConfirmada = true;
                            this.Close();
                        } else
                        {
                            int millasGanadas = usuario.CalcularMillasGanadas(vuelo.DistanciaViaje, 2);
                            int millasFinales = usuario.CalcularMillasTotales_DespuesDeGane(millasGanadas);

                            MessageBox.Show("La compra del cliente " + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + ", con cédula " + usuario.Cedula + " ha sido adicionada" +
                                "a la base de datos. Como el cliente pertenece al programa de millas:\n\n   Millas pre-descuento: " + (usuario.MillasAcumuladas) + "\n    Millas utilizadas: " + millasDescontadas + "\n   " +
                                "Millas Ganadas por medio del programa de millas: " + millasGanadas + "\n    Millas finales post-compra: " + millasFinales, "¡Felicidades!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            usuario.ActualizarMillasUsuario_BD(usuario.Cedula, millasFinales);
                            EleccionAsientos_Form.compraConfirmada = true;
                            this.Close();
                        }
                    } else
                    {
                        MessageBox.Show("La compra del cliente " + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + ", con cédula " + usuario.Cedula + " ha sido adicionada" +
                                "a la base de datos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EleccionAsientos_Form.compraConfirmada = true;
                        this.Close();
                    }
                } else
                {
                    MessageBox.Show("Al momento de la compra, el cliente no estaba en la base de datos. A continuación será adicionado a esta.", "Usuario no existente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult resultado = MessageBox.Show("¿Desea adicionar al usuario al programa de millas? Presione YES para sí y NO para no", "Adicionar cliente nuevo al PM", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

                    if (resultado.ToString().Trim() == "Yes")
                    {
                        Usuario usuarioTemporal = new Usuario();
                        Tiquete tiqueteTemporal = new Tiquete();
                        Vuelo vueloTemporal = new Vuelo();
                        Equipaje equipaje = new Equipaje();

                        usuarioTemporal.InsertarUsuario_PostCompra_BD(usuario, true);

                        tiqueteTemporal.InsertarTiquete_BD(tiquete, usuario.Cedula);
 
                        vueloTemporal.InsertarNumeroDeAsiento_BD(vuelo.NombreDeRuta, tiquete);

                        equipaje.InsertarEquipajeVacio_BD(tiquete.NumeroTiquete);

                        MessageBox.Show("La compra del cliente " + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + ", con cédula " + usuario.Cedula + " ha sido adicionada" +
                                " a la base de datos. El nuevo usuario se ha adicionado al programa de millas.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EleccionAsientos_Form.compraConfirmada = true;
                        this.Close();
                    }
                    else
                    {
                        Usuario usuarioTemporal = new Usuario();
                        Tiquete tiqueteTemporal = new Tiquete();
                        Vuelo vueloTemporal = new Vuelo();
                        Equipaje equipaje = new Equipaje();

                        usuarioTemporal.InsertarUsuario_PostCompra_BD(usuario, false);

                        tiqueteTemporal.InsertarTiquete_BD(tiquete, usuario.Cedula);

                        vueloTemporal.InsertarNumeroDeAsiento_BD(vuelo.NombreDeRuta, tiquete);

                        equipaje.InsertarEquipajeVacio_BD(tiquete.NumeroTiquete);

                        MessageBox.Show("La compra del cliente " + usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido + ", con cédula " + usuario.Cedula + " ha sido adicionada" +
                                "a la base de datos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EleccionAsientos_Form.compraConfirmada = true;
                        this.Close();
                    }
                }

            } else
            {
                MessageBox.Show("Operación cancelada", "Operación cancelada");
            }
        }
    }
}
