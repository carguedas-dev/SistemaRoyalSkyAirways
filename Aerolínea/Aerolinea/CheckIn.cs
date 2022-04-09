using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    class CheckIn
    {
        Conexion objetoConexion;

        public CheckIn()
        {
            objetoConexion = new Conexion();
        }

        public DataTable RetornaTablaCheckIn_BD()
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();
            SqlCommand checkin_select_comando = new SqlCommand("spChekinn", conexion);
            checkin_select_comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter checkin_select_adaptador = new SqlDataAdapter();
            checkin_select_adaptador.SelectCommand = checkin_select_comando;
            DataTable checkin_select_tabla = new DataTable();
            checkin_select_adaptador.Fill(checkin_select_tabla);
            conexion.Close();

            return checkin_select_tabla;
        }
    }
}
