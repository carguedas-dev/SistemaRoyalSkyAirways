using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Aerolinea.BaseDeDatos;

namespace Aerolinea
{
    public class Tiquete
    {
        Conexion objetoConexion = new Conexion();
        SqlConnection conexion;
        public Tiquete(string numeroDeVuelo, string numeroDeAsiento, string fechaTramite, string idUsuario, string metodoDePago, string descripcion)
        {

            NumeroTiquete = CalcularNumeroTiquete_BD(RealizarConexion_BD());
            NumeroDeVuelo = numeroDeVuelo;
            NumeroDeAsiento = numeroDeAsiento;
            FechaTramite = fechaTramite;
            IDUsuario = idUsuario;
            Registrado = false;
            MetodoDePago = metodoDePago;
            Precio = CalcularPrecioConImpuestosTiquete(NumeroDeAsiento);
            Descuento = 0;
            Descripcion = descripcion;
        }

        public Tiquete()
        {
            conexion = objetoConexion.RecibirConexion();
        }

        public int NumeroTiquete { set; get; }
        public string NumeroDeVuelo { get; set; }
        public string NumeroDeAsiento { get; set; }
        public string FechaTramite { set; get; }
        public string IDUsuario { get; set; }
        public bool Registrado { set; get; }
        public string MetodoDePago { set; get; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal PrecioFinal { get; set; }

        public void CalcularPrecioFinal() {
            PrecioFinal = Precio - Descuento;
        }

        public decimal CalcularPrecioFinal(decimal precioTiquete, decimal descuento)
        {
            return precioTiquete - descuento;
        }
        public Decimal CalcularPrecioConImpuestosTiquete(string numeroDeAsiento)
        {
            if (numeroDeAsiento[0] == 'A' ||
                numeroDeAsiento[0] == 'B' ||
                numeroDeAsiento[0] == 'C' ||
                numeroDeAsiento[0] == 'D' ||
                numeroDeAsiento[0] == 'E' ||
                numeroDeAsiento[0] == 'F')
            {
                Precio = 2500 + (2500 * 0.05m) + (2500*0.13m);
            } else if (numeroDeAsiento[0] == 'H' ||
                       numeroDeAsiento[0] == 'I' ||
                       numeroDeAsiento[0] == 'J' ||
                       numeroDeAsiento[0] == 'K' ||
                       numeroDeAsiento[0] == 'L' ||
                       numeroDeAsiento[0] == 'M' ||
                       numeroDeAsiento[0] == 'N' ||
                       numeroDeAsiento[0] == 'O' ||
                       numeroDeAsiento[0] == 'P' ||
                       numeroDeAsiento[0] == 'Q' ||
                       numeroDeAsiento[0] == 'R' ||
                       numeroDeAsiento[0] == 'S')
            {
                Precio = 800 + (800 * 0.05m) + (800 * 0.13m);
            }
            return Precio;
        }

        public void CalcularDescuentoTiquete(int cantidadDeMillasAUsar)
        {
            int descuentoPorMilla = 3;
            Descuento = descuentoPorMilla * cantidadDeMillasAUsar;
            
            if (Descuento > Precio)
            {
                Descuento = Precio;
            }
        }

        public SqlConnection RealizarConexion_BD()
        {
            conexion = objetoConexion.RecibirConexion();
            return conexion;
        }

        public int CalcularNumeroTiquete_BD(SqlConnection conexion)
        {
            int numeroDeTiquete = -1;
            bool numeroEncontrado = false;
            Random random = new Random();
            conexion.Open();

            while (!numeroEncontrado)
            {
                numeroDeTiquete = random.Next(100, 2147483646);
                
                SqlCommand comando = new SqlCommand("Select * from Tiquetes where numeroDeTiquete = "+numeroDeTiquete+";", conexion);
                SqlDataReader dataReader = comando.ExecuteReader(); 

                if (!dataReader.HasRows)
                {
                    numeroEncontrado = true;
                } else
                {
                    continue;
                }
            }
            conexion.Close();

            return numeroDeTiquete;
        }

        public decimal CalcularDiferenciaEntreTiquetes(decimal precioTiquete1, decimal precioTiquete2)
        {
            return precioTiquete1 - precioTiquete2;
        }
        
        public decimal CalcularPrecioCambioAsiento(decimal precioAnterior, decimal descuentoPrevio, string numeroDeAsientoNuevo)
        {
            decimal precioConAsientoNuevo = CalcularPrecioConImpuestosTiquete(numeroDeAsientoNuevo);

            return (precioAnterior + descuentoPrevio) - precioConAsientoNuevo;
        }

        public DataSet BuscaTiquetePorNumeroDeTiquete_BD(int numeroDeTiquete, int mode)
        {
            string consulta = "";

            if (mode == 1)
            {
                consulta = "SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND numeroDeTiquete = '" + numeroDeTiquete + "';";
            } else if (mode == 2)
            {
                consulta = "SELECT fechaTramite as 'Fecha del Trámite',Tiquetes.numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo', registro as 'Registrado para abordaje', descuento as 'Descuento', pesoTotal as 'Peso Total de Maletas', cargoPorSobrepeso as 'Cargos por Sobrepeso', costoFinal as 'Costo final por equipaje', precioFinal as 'Precio Final', metodoDePago as 'Método de Pago' FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo INNER JOIN Equipaje ON Tiquetes.numeroDeTiquete = Equipaje.numeroDeTiquete where Tiquetes.numeroDeTiquete = '" + numeroDeTiquete + "';";
            }

            //Mode 1 --> Consulta para Tabla CheckIn, Mode 2 --> Consulta para Tabla Historial
            conexion.Open();
            SqlDataAdapter adaptadordatos = new SqlDataAdapter(consulta, conexion);
            DataSet setDeDatos = new DataSet();
            adaptadordatos.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }

        public DataSet BuscaTiquetePorCedula_BD(string cedula, int mode)
        {
            string consulta = "";

            if (mode == 1)
            {
                consulta = "SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND numeroDeTiquete = '" + cedula + "';";
            }
            else if (mode == 2)
            {
                consulta = "SELECT fechaTramite as 'Fecha del Trámite',Tiquetes.numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo', registro as 'Registrado para abordaje', descuento as 'Descuento', pesoTotal as 'Peso Total de Maletas', cargoPorSobrepeso as 'Cargos por Sobrepeso', costoFinal as 'Costo final por equipaje', precioFinal as 'Precio Final', metodoDePago as 'Método de Pago' FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo INNER JOIN Equipaje ON Tiquetes.numeroDeTiquete = Equipaje.numeroDeTiquete where Tiquetes.numeroDeTiquete = '" + cedula + "';";
            }

            //Mode 1 --> Consulta para Tabla CheckIn, Mode 2 --> Consulta para Tabla Historial
            conexion.Open();
            SqlDataAdapter adaptadordatos = new SqlDataAdapter("SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND cedula = '" + cedula + "';", conexion);
            DataSet setDeDatos = new DataSet();
            adaptadordatos.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }

        public DataSet BuscaTiquetePorNombre_BD(string nombre, int mode)
        {
            string consulta = "";

            if (mode == 1)
            {
                consulta = "SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND numeroDeTiquete = '" + nombre + "';";
            }
            else if (mode == 2)
            {
                consulta = "SELECT fechaTramite as 'Fecha del Trámite',Tiquetes.numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo', registro as 'Registrado para abordaje', descuento as 'Descuento', pesoTotal as 'Peso Total de Maletas', cargoPorSobrepeso as 'Cargos por Sobrepeso', costoFinal as 'Costo final por equipaje', precioFinal as 'Precio Final', metodoDePago as 'Método de Pago' FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo INNER JOIN Equipaje ON Tiquetes.numeroDeTiquete = Equipaje.numeroDeTiquete where Tiquetes.numeroDeTiquete = '" + nombre + "';";
            }

            //Mode 1 --> Consulta para Tabla CheckIn, Mode 2 --> Consulta para Tabla Historial
            conexion.Open();
            SqlDataAdapter adaptadordatos = new SqlDataAdapter("SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND nombre = '" + nombre + "';", conexion);
            DataSet setDeDatos = new DataSet();
            adaptadordatos.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }

        public DataSet BuscaTiquetePorPrimerApellido_BD(string primerApellido, int mode)
        {
            string consulta = "";

            if (mode == 1)
            {
                consulta = "SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND numeroDeTiquete = '" + primerApellido + "';";
            }
            else if (mode == 2)
            {
                consulta = "SELECT fechaTramite as 'Fecha del Trámite',Tiquetes.numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo', registro as 'Registrado para abordaje', descuento as 'Descuento', pesoTotal as 'Peso Total de Maletas', cargoPorSobrepeso as 'Cargos por Sobrepeso', costoFinal as 'Costo final por equipaje', precioFinal as 'Precio Final', metodoDePago as 'Método de Pago' FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo INNER JOIN Equipaje ON Tiquetes.numeroDeTiquete = Equipaje.numeroDeTiquete where Tiquetes.numeroDeTiquete = '" + primerApellido + "';";
            }

            //Mode 1 --> Consulta para Tabla CheckIn, Mode 2 --> Consulta para Tabla Historial
            conexion.Open();
            SqlDataAdapter adaptadordatos = new SqlDataAdapter("SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND primerApellido = '" + primerApellido + "';", conexion);
            DataSet setDeDatos = new DataSet();
            adaptadordatos.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }

        public DataSet BuscaTiquetePorSegundoApellido_BD(string segundoApellido, int mode)
        {
            string consulta = "";

            if (mode == 1)
            {
                consulta = "SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND numeroDeTiquete = '" + segundoApellido + "';";
            }
            else if (mode == 2)
            {
                consulta = "SELECT fechaTramite as 'Fecha del Trámite',Tiquetes.numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo', registro as 'Registrado para abordaje', descuento as 'Descuento', pesoTotal as 'Peso Total de Maletas', cargoPorSobrepeso as 'Cargos por Sobrepeso', costoFinal as 'Costo final por equipaje', precioFinal as 'Precio Final', metodoDePago as 'Método de Pago' FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo INNER JOIN Equipaje ON Tiquetes.numeroDeTiquete = Equipaje.numeroDeTiquete where Tiquetes.numeroDeTiquete = '" + segundoApellido + "';";
            }

            //Mode 1 --> Consulta para Tabla CheckIn, Mode 2 --> Consulta para Tabla Historial
            conexion.Open();
            SqlDataAdapter adaptadordatos = new SqlDataAdapter("SELECT FORMAT(fechaTramite, 'dd/MM/yyyy') as 'Fecha del Trámite',numeroDeTiquete as 'Número de Tiquete',cedula as 'Cédula',nombre as 'Nombre',primerApellido as 'Primer Apellido',segundoApellido as 'Segundo Apellido',nombreDeRuta as 'Nombre de Ruta',Tiquetes.numeroDeVuelo as 'Número de Vuelo',numeroDeAsiento as 'Número de Asiento',puntoDeSalida as 'Punto De Salida',puntoDeLlegada as 'Punto De Llegada',fechaDelVuelo as 'Fecha Del Vuelo', horaDelVuelo as 'Hora Del Vuelo',precio as 'Precio',descuento as 'Descuento',precioFinal as 'Precio Final',metodoDePago as 'Método de Pago'FROM Tiquetes INNER JOIN Usuarios ON Tiquetes.idUsuario = Usuarios.cedula INNER JOIN Vuelos ON Vuelos.numeroDeVuelo = Tiquetes.numeroDeVuelo WHERE registro = 0 AND segundoApellido = '" + segundoApellido + "';", conexion);
            DataSet setDeDatos = new DataSet();
            adaptadordatos.Fill(setDeDatos);
            conexion.Close();

            return setDeDatos;
        }

        public void AnulaTiquete_BD(int numeroDeTiquete, string nombreDeRuta)
        {
            conexion.Open();

            SqlCommand comando = new SqlCommand("", conexion);

            switch (nombreDeRuta)
            {
                case "Orlando -- Lisboa":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLisboa SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeTiquete = @numeroDeTiquete;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Tiquetes set anulado = 1 where numeroDeTiquete = @numeroDeTiquete2";
                    comando.Parameters.AddWithValue("@numeroDeTiquete2", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    conexion.Close();

                    break;
                case "Orlando -- Bakú":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoBaku SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeTiquete = @numeroDeTiquete;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Tiquetes set anulado = 1 where numeroDeTiquete = @numeroDeTiquete2";
                    comando.Parameters.AddWithValue("@numeroDeTiquete2", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    conexion.Close();

                    break;
                case "Orlando -- Londres":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoLondres SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeTiquete = @numeroDeTiquete;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Tiquetes set anulado = 1 where numeroDeTiquete = @numeroDeTiquete2";
                    comando.Parameters.AddWithValue("@numeroDeTiquete2", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    conexion.Close();

                    break;
                case "Orlando -- Reykjavík":
                    comando.CommandText = "UPDATE Asientos_VueloOrlandoReykjavik SET asientoOcupado = 0, numeroDeTiquete = null where numeroDeTiquete = @numeroDeTiquete;";
                    comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    comando.CommandText = "UPDATE Tiquetes set anulado = 1 where numeroDeTiquete = @numeroDeTiquete2";
                    comando.Parameters.AddWithValue("@numeroDeTiquete2", SqlDbType.NVarChar).Value = numeroDeTiquete;
                    comando.ExecuteNonQuery();

                    conexion.Close();

                    break;
            }     
        }

        public void ActualizarPrecioTiquete_BD(int numeroDeTiquete, decimal precioDelTiquete, decimal precioDeLaCompra)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes SET precio = @precioDelTiquete, precioFinal = @precioDeLaCompra where numeroDeTiquete = @numeroDeTiquete", conexion);
            comando.Parameters.AddWithValue("@precioDelTiquete", SqlDbType.Decimal).Value = precioDelTiquete;
            comando.Parameters.AddWithValue("@precioDeLaCompra", SqlDbType.Decimal).Value = precioDeLaCompra;
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarPrecioTiquete_BD(int numeroDeTiquete, decimal precioDelTiquete)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes SET precioFinal = @precioDeLaCompra where numeroDeTiquete = @numeroDeTiquete", conexion);
            comando.Parameters.AddWithValue("@precioDeLaCompra", SqlDbType.Decimal).Value = precioDelTiquete;
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void ActualizarDescuentoTiquete_BD(int numeroDeTiquete, decimal descuento)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes set descuento = @descuento where numeroDeTiquete = @numeroDeTiquete;", conexion);
            comando.Parameters.AddWithValue("@descuento", SqlDbType.Decimal).Value = descuento;
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Decimal).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        public void AdicionarDescripcionATiquete_BD(int numeroDeTiquete, string descripcionAAdicionar)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("UPDATE Tiquetes set descripcion = descripcion + CHAR(13) + CHAR(13) + @descripcionAdicional where numeroDeTiquete = @numeroDeTiquete;", conexion);
            comando.Parameters.AddWithValue("@descripcionAdicional", SqlDbType.NVarChar).Value = descripcionAAdicionar;
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void InsertarTiquete_BD(Tiquete tiquete, string cedulaUsuario)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("", conexion);

            comando.CommandText = "Insert into Tiquetes values (" + tiquete.NumeroTiquete + "," +
                        " '" + tiquete.NumeroDeVuelo + "'," +
                        " '" + tiquete.NumeroDeAsiento.Trim() + "'," +
                        " CONVERT(date,'" + tiquete.FechaTramite + "', 103)," +
                        " '" + cedulaUsuario + "'," +
                        " " + 0 + "," +
                        " '" + tiquete.MetodoDePago + "'," +
                        " '" + tiquete.Descripcion + "'," +
                        " " + tiquete.Precio + "," +
                        " " + tiquete.Descuento + "," +
                        " " + tiquete.PrecioFinal + "," +
                        " " + 0 + ");";

            comando.ExecuteNonQuery();
            conexion.Close(); 
        }

        public string ObtenerDescripcionTiquete_BD(int numeroDeTiquete)
        {
            SqlConnection conexion = objetoConexion.RecibirConexion();
            conexion.Open();

            SqlCommand comando = new SqlCommand("SELECT descripcion as 'DESC' FROM Tiquetes WHERE numeroDeTiquete = @numeroDeTiquete;", conexion);
            comando.Parameters.AddWithValue("@numeroDeTiquete", SqlDbType.Int).Value = numeroDeTiquete;
            SqlDataAdapter adaptadorDeDatos = new SqlDataAdapter();
            adaptadorDeDatos.SelectCommand = comando;

            DataSet setDeDatos = new DataSet();
            adaptadorDeDatos.Fill(setDeDatos);

            return setDeDatos.Tables[0].Rows[0]["DESC"].ToString();
        }

        public decimal ObtenerPrecioPrevioConDescuento(decimal precioPrevio, decimal descuento)
        {
            return precioPrevio - descuento;
        }
    }
}
