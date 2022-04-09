using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; 

namespace Aerolinea.BaseDeDatos
{
    class Conexion
    {
        SqlConnection conexion; 

        public Conexion()
        {
            conexion = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\OneDrive - ULACIT ED CR\\ULACIT\\4 - IIICO2021\\Diseño de Aplicaciones de Software\\ProyectoFinal\\Código\\AerolineaFinal\\Aerolínea\\Aerolinea\\BaseDeDatos\\Aerolinea.mdf; Integrated Security=True");
        }

        public SqlConnection RecibirConexion()
        {
            return conexion; 
        }
    }
}
