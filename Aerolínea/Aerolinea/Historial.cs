using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    class Historial
    {
        Conexion objetoConexion;

        public Historial()
        {
            objetoConexion = new Conexion();
        }

        public DataTable RetornaTablaHistorial_BD()
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();
            SqlCommand historial_select_comando = new SqlCommand("spMuestraHistorial", conexion);
            historial_select_comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter historial_select_adaptador = new SqlDataAdapter();
            historial_select_adaptador.SelectCommand = historial_select_comando;
            DataTable historial_select_tabla = new DataTable();
            historial_select_adaptador.Fill(historial_select_tabla);
            conexion.Close();

            return historial_select_tabla;
        }

    }
}
