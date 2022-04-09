using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Aerolinea.BaseDeDatos;
using System.Data;

namespace Aerolinea
{
    public class CalculosEquipaje
    {
        Conexion objetoConexion;
        public CalculosEquipaje (decimal PrecioTiquete, string cant_Maletas) {
            precioTiquete = PrecioTiquete;
            cantidadMaletas = cant_Maletas;
            objetoConexion = new Conexion();
        }

        public CalculosEquipaje()
        {
            objetoConexion = new Conexion();
        }

        decimal precioTiquete;

        string cantidadMaletas;

        const decimal precioMaleta1 = 60;
        const decimal precioMaleta2 = 75;
        const decimal precioMaleta3 = 225;

        public decimal CalcularPrecioMaletas()
        {
            decimal precioMaletas = 0;

            switch (cantidadMaletas)
            {
                case "1":
                    precioMaletas = precioMaleta1;
                    break;
                case "2":
                    precioMaletas = precioMaleta1 + precioMaleta2;
                    break;
                case "3":
                    precioMaletas = precioMaleta1 + precioMaleta2 + precioMaleta3;
                    break;
                default:
                    precioMaletas = 0;
                    break;
            }

            return precioMaletas;
        }
        public decimal CalcularPrecioSobrepeso(double pesoMaletas) {
            const double maximo = 70.00;

            double pesoTotal = pesoMaletas;
            double diferenciaPeso = maximo - pesoTotal; 

            decimal aCobrar = 0;
            
            if (diferenciaPeso < 0)
            {
                diferenciaPeso *= -1;
                aCobrar = ((decimal)diferenciaPeso) * 10; //Cada kilo que se pase cobra $10.
            } 

            return aCobrar;
        }

        public decimal CalcularPrecioTotal(decimal precioSobrePeso, decimal precioMaletas)
        {
            return precioSobrePeso + precioMaletas;
        }

        public decimal CalcularPrecioTotalConTiquete(decimal precioSobrePeso, decimal precioMaletas)
        {
            return precioTiquete + precioSobrePeso + precioMaletas;
        }

        public double CalcularPeso(double pesoMaleta1, double pesoMaleta2, double pesoMaleta3)
        {
            return pesoMaleta1 + pesoMaleta2 + pesoMaleta3;
        }
    }
}