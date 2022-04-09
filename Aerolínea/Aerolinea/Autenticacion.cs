using System;
using System.Collections.Generic;
using System.Text;
using Aerolinea.BaseDeDatos;
using System.Data.SqlClient;
using System.Data;

namespace Aerolinea
{
    class Autenticacion
    {
        Conexion objetoConexion;

        public Autenticacion()
        {
            objetoConexion = new Conexion(); 
        }

        public bool? RevisionDeCredenciales_BD(string usuario, string contrasenia) {
            
            int registros = 0;
            bool? retorno = null;

            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("select * from supervisores where nombreUsuario = '" + usuario + "' and contrasenia = '" + contrasenia + "';", conexion);
            SqlDataReader lectorDeDatos = comando.ExecuteReader();

            while (lectorDeDatos.Read())
            {
                registros++;
            }
            conexion.Close();
            lectorDeDatos.Close(); 

            if (registros == 1)
            {
                retorno = true;
            } 
            else if (registros == 0)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
