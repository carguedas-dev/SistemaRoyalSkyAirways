using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    class Equipaje
    {
        Conexion objetoConexion;
        public Equipaje()
        {
            objetoConexion = new Conexion();
        }

        public void ActualizarEquipaje_BD(int numeroDeTiquete, double pesoMaleta1, double pesoMaleta2, double pesoMaleta3, double pesoTotal, decimal precioSobrePeso, decimal costoTotal)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE equipaje SET pesoMaleta1 = @pesoMaleta1, pesoMaleta2 = @pesoMaleta2, pesoMaleta3 = @pesoMaleta3, pesoTotal = @pesoTotal, cargoPorSobrepeso = @cargoPorSobrepeso, costoFinal = @costoFinal where numeroDeTiquete = @numeroDeTiquete", conexion);
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            comando.Parameters.AddWithValue("@pesoMaleta1", SqlDbType.Decimal).Value = pesoMaleta1;
            comando.Parameters.AddWithValue("@pesoMaleta2", SqlDbType.Decimal).Value = pesoMaleta2;
            comando.Parameters.AddWithValue("@pesoMaleta3", SqlDbType.Decimal).Value = pesoMaleta3;
            comando.Parameters.AddWithValue("@pesoTotal", SqlDbType.Decimal).Value = pesoTotal;
            comando.Parameters.AddWithValue("@cargoPorSobrepeso", SqlDbType.Decimal).Value = precioSobrePeso;
            comando.Parameters.AddWithValue("@costoFinal", SqlDbType.Decimal).Value = costoTotal;
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void InsertarEquipajeVacio_BD(int numeroDeTiquete)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("INSERT INTO Equipaje values (@numeroDeTiquete, 0,0,0,0,0,0)", conexion);
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
