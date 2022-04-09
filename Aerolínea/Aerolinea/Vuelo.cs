using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Aerolinea.BaseDeDatos;
using System.Data.SqlClient;
using System.Drawing;

namespace Aerolinea
{
    public class Vuelo
    {
        Conexion objetoConexion;

        public Vuelo(string nombreDeRuta, string numeroDeVuelo, string puntoDeSalida, string puntoDeLlegada, string fechaDelVuelo, string horaDelVuelo, int distanciaViaje)
        {
            NombreDeRuta = nombreDeRuta;
            NumeroDeVuelo = numeroDeVuelo;
            PuntoDeSalida = puntoDeSalida;
            PuntoDeLlegada = puntoDeLlegada;
            FechaDelVuelo = fechaDelVuelo;
            HoraDelVuelo = horaDelVuelo;
            DistanciaViaje = distanciaViaje;
        }

        public Vuelo()
        {
            objetoConexion = new Conexion();
        }
        public string NombreDeRuta { get; set; }
        public string NumeroDeVuelo { get; set; }
        public string PuntoDeSalida { get; set; }
        public string PuntoDeLlegada { get; set; }
        public string FechaDelVuelo { get; set; }
        public string HoraDelVuelo { get; set; }
        public int DistanciaViaje { get; set; }

        public DataSet RetornaTablaVuelos_BD()
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();
            SqlDataAdapter adptadorDatos = new SqlDataAdapter("spConsultarVuelos", conexion);
            DataSet setdeDatos = new DataSet();
            adptadorDatos.Fill(setdeDatos);
            conexion.Close();

            return setdeDatos;
        } 


        public void AsignaAsientoPreviamenteCompradoEnLista_BD(string numeroDeTiquete, string numeroDeAsientoPrevio, List<System.Windows.Forms.Label> asientosOcupados)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlDataAdapter adaptadorDatos = new SqlDataAdapter("Select numeroDeAsiento as 'NUMASIENTO' from Tiquetes where numeroDetiquete = " + numeroDeTiquete + ";", conexion);
            DataSet setDeDatos = new DataSet();
            adaptadorDatos.Fill(setDeDatos);
            

            foreach (var asientoOcupado in asientosOcupados)
            {
                if (asientoOcupado.Text.Trim() == numeroDeAsientoPrevio)
                {
                    asientoOcupado.BackColor = Color.Orange;
                }
            }
            conexion.Close(); 
        }

        public void AsignaAsientosOcupadosEnLista_BD(string nombreDeRuta, List<System.Windows.Forms.Label> asientosLibres, List<System.Windows.Forms.Label> asientosOcupados, int mode)
        {
            //Mode 1 --> Eleccion Asientos Form, Mode 2 --> Elección Asientos Mod Form
            string consulta = "";

            switch (nombreDeRuta)
            {
                case "Orlando -- Lisboa":
                    consulta = "Select numeroDeAsiento from Asientos_VueloOrlandoLisboa where asientoOcupado = 1;";
                    break;
                case "Orlando -- Bakú":
                    consulta = "Select numeroDeAsiento from Asientos_VueloOrlandoBaku where asientoOcupado = 1;";
                    break;
                case "Orlando -- Londres":
                    consulta = "Select numeroDeAsiento from Asientos_VueloOrlandoLondres where asientoOcupado = 1;";
                    break;
                case "Orlando -- Reykjavík":
                    consulta = "Select numeroDeAsiento from Asientos_VueloOrlandoReykjavik where asientoOcupado = 1;";
                    break;
            }

            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader dataReader = comando.ExecuteReader();

            while (dataReader.Read())
            {
                string asiento = dataReader.GetString(0);
                foreach (var label in asientosLibres)
                {
                    if (label.Text.Trim() == asiento)
                    {
                        label.BackColor = Color.Red;
                        asientosLibres.Remove(label);
                        if (mode == 2)
                        {
                            asientosOcupados.Add(label);
                        }
                        break;
                    }
                }
            }
            dataReader.Close();
            conexion.Close();
        }

        public void AsignaAsientosOcupadosEnLista_BD(string nombreDeRuta, List<System.Windows.Forms.Label> asientosLibres)
        {
            List<System.Windows.Forms.Label> listaPorDefecto = new List<System.Windows.Forms.Label>();

            AsignaAsientosOcupadosEnLista_BD(nombreDeRuta, asientosLibres, listaPorDefecto, 1);
        }

        public void PasarAsientoAOcupado_BD(int numeroDeTiquete)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes SET registro = 1 where numeroDeTiquete = @numeroDeTiquete", conexion);
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Bit).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarNumeroDeAsiento_BD(int numeroDeTiquete, string numeroDeAsiento)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes set numeroDeAsiento = @numeroDeAsiento where numeroDeTiquete = @numeroDeTiquete;", conexion);
            comando.Parameters.AddWithValue("@numeroDeAsiento", SqlDbType.NVarChar).Value = numeroDeAsiento;
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Decimal).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void InsertarNumeroDeAsiento_BD(string nombreDeRuta, Tiquete tiquete)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("", conexion);

            if (nombreDeRuta == "Orlando -- Londres")
            {
                comando.CommandText = "UPDATE Asientos_VueloOrlandoLondres set asientoOcupado = 1 where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
                comando.CommandText = "UPDATE Asientos_VueloOrlandoLondres set numeroDeTiquete = '" + tiquete.NumeroTiquete + "' where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();

            }
            else if (nombreDeRuta == "Orlando -- Lisboa")
            {
                comando.CommandText = "UPDATE Asientos_VueloOrlandoLisboa set asientoOcupado = 1 where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
                comando.CommandText = "UPDATE Asientos_VueloOrlandoLisboa set numeroDeTiquete = '" + tiquete.NumeroTiquete + "' where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();

            }
            else if (nombreDeRuta == "Orlando -- Bakú")
            {
                comando.CommandText = "UPDATE Asientos_VueloOrlandoBaku set asientoOcupado = 1 where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
                comando.CommandText = "UPDATE Asientos_VueloOrlandoBaku set numeroDeTiquete = '" + tiquete.NumeroTiquete + "' where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
            }
            else
            {
                comando.CommandText = "UPDATE Asientos_VueloOrlandoReykjavik set asientoOcupado = 1 where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
                comando.CommandText = "UPDATE Asientos_VueloOrlandoReykjavik set numeroDeTiquete = '" + tiquete.NumeroTiquete + "' where numeroDeAsiento = '" + tiquete.NumeroDeAsiento.Trim() + "';";
                comando.ExecuteNonQuery();
            }
        }

        public void ActualizarAsientoOcupado_BD(int numeroDeTiquete, string nombreDeRuta, string numeroDeAsientoViejo, string numeroDeAsientoNuevo)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("", conexion);

            switch (nombreDeRuta)
            {
                case "Orlando -- Lisboa":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLisboa SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeAsiento = @asientoViejo;";
                    comando.Parameters.AddWithValue("@asientoViejo", SqlDbType.NVarChar).Value = numeroDeAsientoViejo;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLisboa SET asientoOcupado = 1, numeroDeTiquete = @numeroDeTiquete where numeroDeAsiento = @asientoNuevo;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
                    comando.Parameters.AddWithValue("@asientoNuevo", SqlDbType.NVarChar).Value = numeroDeAsientoNuevo;
                    comando.ExecuteNonQuery();
                    break;
                case "Orlando -- Bakú":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoBaku SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeAsiento = @asientoViejo;";
                    comando.Parameters.AddWithValue("@asientoViejo", SqlDbType.NVarChar).Value = numeroDeAsientoViejo;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Asientos_VueloOrlandoBaku SET asientoOcupado = 1, numeroDeTiquete = @numeroDeTiquete where numeroDeAsiento = @asientoNuevo;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
                    comando.Parameters.AddWithValue("@asientoNuevo", SqlDbType.NVarChar).Value = numeroDeAsientoNuevo;
                    comando.ExecuteNonQuery();

                    break;
                case "Orlando -- Londres":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLondres SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeAsiento = @asientoViejo;";
                    comando.Parameters.AddWithValue("@asientoViejo", SqlDbType.NVarChar).Value = numeroDeAsientoViejo;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLondres SET asientoOcupado = 1, numeroDeTiquete = @numeroDeTiquete where numeroDeAsiento = @asientoNuevo;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
                    comando.Parameters.AddWithValue("@asientoNuevo", SqlDbType.NVarChar).Value = numeroDeAsientoNuevo;
                    comando.ExecuteNonQuery();
                    break;
                case "Orlando -- Reykjavík":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoReykjavik SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeAsiento = @asientoViejo;";
                    comando.Parameters.AddWithValue("@asientoViejo", SqlDbType.NVarChar).Value = numeroDeAsientoViejo;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Asientos_VueloOrlandoReykjavik SET asientoOcupado = 1, numeroDeTiquete = @numeroDeTiquete where numeroDeAsiento = @asientoNuevo;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
                    comando.Parameters.AddWithValue("@asientoNuevo", SqlDbType.NVarChar).Value = numeroDeAsientoNuevo;
                    comando.ExecuteNonQuery();
                    break;
            }
            conexion.Close();
        }
    }
}
