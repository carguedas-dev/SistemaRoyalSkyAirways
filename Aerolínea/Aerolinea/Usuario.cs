using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    public class Usuario
    {
        SqlConnection conexion;
        
        #region Constructor
        public Usuario(string nombre, string primerApellido, string segundoApellido, string cedula, string fechaNacimiento, string numeroTelefono)
        {
            Cedula = cedula; 

            if (UsuarioExiste_BD(cedula))
            {
                if (PerteneceProgramaMillas_BD(cedula))
                {
                    SqlConnection conexion = RealizarConexion_BD();
                    conexion.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select millasAcumuladas as 'ACUMULADAS' from Usuarios where cedula = '"+cedula+"';", conexion);
                    DataSet setDeDatos = new DataSet();
                    dataAdapter.Fill(setDeDatos);

                    MillasAcumuladas = int.Parse(setDeDatos.Tables[0].Rows[0]["ACUMULADAS"].ToString());
                    ProgramaMillas = true;

                    Nombre = nombre;
                    PrimerApellido = primerApellido;
                    SegundoApellido = segundoApellido;
                    FechaNacimiento = fechaNacimiento;
                    NumeroTelefono = numeroTelefono; 

                } else
                {
                    Nombre = nombre;
                    PrimerApellido = primerApellido;
                    SegundoApellido = segundoApellido;
                    FechaNacimiento = fechaNacimiento;
                    NumeroTelefono = numeroTelefono;
                    ProgramaMillas = false;
                    MillasAcumuladas = 0;
                }
            } else
            {
                Nombre = nombre;
                PrimerApellido = primerApellido;
                SegundoApellido = segundoApellido;
                FechaNacimiento = fechaNacimiento;
                NumeroTelefono = numeroTelefono;
                ProgramaMillas = false;
                MillasAcumuladas = 0;
            }
        }

        public Usuario()
        {

        }
        #endregion
        #region Properties
        public string Nombre { set; get; }

        public string PrimerApellido { set; get; }

        public string SegundoApellido { set; get; }

        public string Cedula { set; get; }

        public string FechaNacimiento { set; get; }

        public string NumeroTelefono { set; get; }

        public bool ProgramaMillas { set; get; }

        public int MillasAcumuladas { set; get; } = 0;

        #endregion
        public SqlConnection RealizarConexion_BD()
        {
            Conexion objetoConexion = new Conexion();
            conexion = objetoConexion.RecibirConexion();
            return conexion;
        }
        public bool PerteneceProgramaMillas_BD(string idUsuario)
        {
            bool pertenece = false;
            conexion = RealizarConexion_BD();
            conexion.Open();

            SqlCommand comando = new SqlCommand("Select programaMillas from Usuarios where cedula ='" + idUsuario + "' and programaMillas = 1;", conexion);
            SqlDataReader dataReader = comando.ExecuteReader();

            if (dataReader.HasRows)
            {
                pertenece = true;
            }
            conexion.Close();

            return pertenece;
        }

        public bool UsuarioExiste_BD(string idUsuario)
        {
            bool existe = false;
            conexion = RealizarConexion_BD();
            conexion.Open();

            SqlCommand comando = new SqlCommand("Select * from Usuarios where cedula ='" + idUsuario + "';", conexion);
            SqlDataReader dataReader = comando.ExecuteReader();

            if (dataReader.HasRows)
            {
                existe = true;
            }
            conexion.Close();

            return existe;
        }

        public int CalcularMillasRestantes(int cantidadDeMillasUtilizadas)
        {
            MillasAcumuladas -= cantidadDeMillasUtilizadas;

            return MillasAcumuladas;
        }

        public int CalcularMillasGanadas(int distanciaDeViaje, int mode) //Por cada 100 millas de distancia de vuelo, se le dan al cliente 5. Al gastar millas, se dan más en recompensa.
        {
            //Mode 1--> 5 millas cada 100, Mode 2--> 2 millas cada 100 si no se utilizan millas
            int segmentosDeCien = distanciaDeViaje / 100;
            int millasGanadas = 0;
            if (mode == 1) //Si se gastan millas, entonces se ganan 5 por cada 100.
            {
                millasGanadas = segmentosDeCien * 5;
            } 
            else if (mode == 2) //Si no gastan millas, entonces se ganan pero no tantas; 2 por cada 100.
            {
                millasGanadas = segmentosDeCien * 2;
            }

            return millasGanadas;
        }

        public int CalcularMillasTotales_DespuesDeGane(int millasRestantes, int millasGanadas)
        {
            return millasRestantes + millasGanadas;
        }

        public int CalcularMillasTotales_DespuesDeGane(int millasGanadas)
        {
            return millasGanadas + this.MillasAcumuladas;
        }

        public bool RegistroExisteEnBD_BD(string id, string nombre, string primerApellido, string segundoApellido, string fecha, string telefono, SqlConnection conexion)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand("Select * from Usuarios where " + "cedula = @cedula and " + "nombre = @nombre and " + "primerApellido = @primerApellido and " + "segundoApellido = @segundoApellido and " + "fechaNacimiento = @fechaNacimiento and " + "numeroDeTelefono = @numeroDeTelefono" + ";", conexion);
            comando.Parameters.AddWithValue("@cedula", SqlDbType.NVarChar).Value = id;
            comando.Parameters.AddWithValue("@nombre", SqlDbType.NVarChar).Value = nombre;
            comando.Parameters.AddWithValue("@primerApellido", SqlDbType.NVarChar).Value = primerApellido;
            comando.Parameters.AddWithValue("@segundoApellido", SqlDbType.NVarChar).Value = segundoApellido;
            comando.Parameters.AddWithValue("@fechaNacimiento", SqlDbType.NVarChar).Value = fecha;
            comando.Parameters.AddWithValue("@numeroDeTelefono", SqlDbType.NVarChar).Value =telefono;

            SqlDataReader lecturaDatos;
            lecturaDatos = comando.ExecuteReader();

            if (lecturaDatos.HasRows)
            {
                conexion.Close();
                return true;
            }

            conexion.Close();
            return false;
        }

        public void InsertarUsuario_PostCompra_BD(Usuario usuario, bool adicionarProgramaMillas, int millas = 0)
        {
            int adicionarAProgramaMillas = 0;
            
            if (adicionarProgramaMillas)
            {
                adicionarAProgramaMillas = 1;
            }

            SqlConnection conexion = RealizarConexion_BD();
            conexion.Open();

            SqlCommand comando = new SqlCommand("", conexion);
            comando.CommandText = "Insert into Usuarios values (" +
                            "'" + usuario.Nombre + "'," +
                            "'" + usuario.PrimerApellido + "'," +
                            "'" + usuario.SegundoApellido + "'," +
                            "'" + usuario.Cedula + "'," +
                            "convert(date, '" + usuario.FechaNacimiento + "', 103), " +
                            "'" + usuario.NumeroTelefono + "'," +
                            "" + adicionarAProgramaMillas + "," +
                            "" + millas + "" +
                            ");";
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void ActualizarMillasUsuario_BD(string cedula, int millasAInsertar)
        {
            SqlConnection conexion = RealizarConexion_BD();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Usuarios SET millasAcumuladas = @millasAcumuladas where cedula = @cedula;", conexion);
            comando.Parameters.AddWithValue("@millasAcumuladas", SqlDbType.Int).Value = millasAInsertar;
            comando.Parameters.AddWithValue("@cedula", SqlDbType.NVarChar).Value = cedula;
            comando.ExecuteNonQuery();
            
            conexion.Close();
        }

        public DataTable RetornaTablaUsuario_BD()
        {
            conexion = RealizarConexion_BD();
            conexion.Open();
            SqlCommand usuario_select_comando = new SqlCommand("SELECT " +
                "nombre as 'Nombre', " +
                "primerApellido as 'Primer Apellido', " +
                "segundoApellido as 'Segundo Apellido', " +
                "cedula as 'Cédula', " +
                "FORMAT (fechaNacimiento, 'dd/MM/yyyy')  as 'Fecha de nacimiento', " +
                "numeroDeTelefono as 'Número Telefónico', " +
                "programaMillas as 'Programa de Millas', " +
                "millasAcumuladas as 'Millas Acumuladas' FROM Usuarios", conexion);

            SqlDataAdapter usuario_select_adaptador = new SqlDataAdapter();
            usuario_select_adaptador.SelectCommand = usuario_select_comando;
            DataTable usuario_select_tabla = new DataTable();
            usuario_select_adaptador.Fill(usuario_select_tabla);
            conexion.Close();

            return usuario_select_tabla;
        }


        public DataSet BuscarUsuario_BD(string ID_Busqueda)
        {
            PantallaPrincipal_Form pantallaPrincipal_Form = new PantallaPrincipal_Form();
            conexion = RealizarConexion_BD();
            conexion.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select nombre as 'NOMBRE', primerApellido as 'PRIMERAPELLIDO', segundoApellido as 'SEGUNDOAPELLIDO', FORMAT (fechaNacimiento, 'dd/MM/yyyy')  as 'FECHANACIMIENTO', numeroDeTelefono as 'NUMERODETELEFONO' from Usuarios where cedula = '" + ID_Busqueda + "'", conexion);
            DataSet setDeDatos = new DataSet();
            dataAdapter.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }


        public void IngresarUsuario_BD(string nombre, string primerapellido, string segundoapellido, string cedula, string fechadenacimiento, string numerodetelefono)  //No accede a los TextBox
        {
            PantallaPrincipal_Form pantallaPrincipal_Form = new PantallaPrincipal_Form();
            string query = "INSERT INTO Usuarios VALUES (@nombre, @primerapellido, @segundoapellido, @cedula, CONVERT(DATE,@fechadenacimiento, 103), @numerodetelefono, @programamillas, @millasacumuladas)";
            conexion.Open();
            SqlCommand usuario_insert_comando = new SqlCommand(query, conexion);
            usuario_insert_comando.Parameters.AddWithValue("@nombre", nombre);
            usuario_insert_comando.Parameters.AddWithValue("@primerapellido", primerapellido);
            usuario_insert_comando.Parameters.AddWithValue("@segundoapellido", segundoapellido);
            usuario_insert_comando.Parameters.AddWithValue("@cedula", cedula);
            usuario_insert_comando.Parameters.AddWithValue("@fechadenacimiento", fechadenacimiento);
            usuario_insert_comando.Parameters.AddWithValue("@numerodetelefono", numerodetelefono);
            usuario_insert_comando.Parameters.AddWithValue("@programamillas", 1);
            usuario_insert_comando.Parameters.AddWithValue("@millasacumuladas", 0);
            usuario_insert_comando.ExecuteNonQuery();
            conexion.Close();
        }


        public string BuscarPor_BD(string buscarPor, string Dato)
        {
            string Usuario_btnBuscar_SqlCommand = " ";
            string DatoValido;

            if (buscarPor == "Nombre")
            {
                Usuario_btnBuscar_SqlCommand = "SELECT * FROM Usuarios WHERE nombre = '" + Dato + "'";
            }
            else if (buscarPor == "Cédula")
            {
                Usuario_btnBuscar_SqlCommand = "SELECT* FROM Usuarios WHERE cedula = " + Dato;
            }
            else if (buscarPor == "Primer Apellido")
            {
                Usuario_btnBuscar_SqlCommand = "SELECT* FROM Usuarios WHERE primerApellido = '" + Dato + "'";
            }
            else if (buscarPor == "Segundo Apellido")
            {
                Usuario_btnBuscar_SqlCommand = "SELECT* FROM Usuarios WHERE segundoApellido = '" + Dato + "'";
            }

            return Usuario_btnBuscar_SqlCommand;
        }


        public bool UsuarioExiste_BuscarPor_BD(string SqlCommand_String)
        {
            bool existe = false;
            Usuario us = new Usuario();
            conexion = us.RealizarConexion_BD();
            conexion.Open();
            SqlCommand comando = new SqlCommand(SqlCommand_String, conexion);
            SqlDataReader dataReader = comando.ExecuteReader();

            if (dataReader.HasRows)
            {
                existe = true;
            }
            conexion.Close();

            return existe;
        }


        public DataTable PopularTablaUsuario_UsuarioUnico_BD(string Usuario_btnBuscar_SqlCommand)
        {
            conexion = RealizarConexion_BD();
            conexion.Open();
            SqlCommand usuario_select_comando = new SqlCommand(Usuario_btnBuscar_SqlCommand, conexion);
            SqlDataAdapter usuario_select_adaptador = new SqlDataAdapter();
            usuario_select_adaptador.SelectCommand = usuario_select_comando;
            DataTable usuario_select_tabla = new DataTable();
            usuario_select_adaptador.Fill(usuario_select_tabla);
            conexion.Close();

            return usuario_select_tabla;
        }

        public void ActualizarDatosUsuario_BD(string nombre, string primerApellido, string segundoApellido, string cedula, string fechaDeNacimiento, string numeroDeTelefono, bool perteneceProgramaMillas, string millasAcumuladas)
        {
            SqlConnection conexion = RealizarConexion_BD();
            conexion.Open();

            string query = "UPDATE Usuarios SET nombre = @nombre, primerApellido = @primerapellido, segundoApellido = @segundoapellido, fechaNacimiento = CONVERT(DATE,@fechadenacimiento, 103), numeroDeTelefono = @numerodetelefono, programaMillas = @programamillas, millasAcumuladas = @millasacumuladas WHERE cedula = '" + cedula + "'";

            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@primerapellido", primerApellido);
            comando.Parameters.AddWithValue("@segundoapellido", segundoApellido);
            comando.Parameters.AddWithValue("@fechadenacimiento", fechaDeNacimiento);
            comando.Parameters.AddWithValue("@numerodetelefono", numeroDeTelefono);
            comando.Parameters.AddWithValue("@programamillas", perteneceProgramaMillas);
            comando.Parameters.AddWithValue("@millasacumuladas", millasAcumuladas);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
