using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aerolinea;

namespace TestingAerolinea
{
    [TestClass]
    public class TestsAerolinea
    {
        [TestCategory("CompraTiquete")]
        [TestMethod]
        public void PrecioEs2950Dolares_SiAsientoEsA4()
        {
            //Arrange
            Tiquete tiquete = new Tiquete();

            //Act
            decimal precio = tiquete.CalcularPrecioConImpuestosTiquete("A4");

            //Assert 

            /*
            
            Si está de la A a la E, entonces el precio es 2500 más 5% cargo servicio, y 13% IVA. 

            Con A4 = 2500 * 1.18 = 2950

             */

            Assert.AreEqual(2950m, precio);
        }

        [TestCategory("CompraTiquete")]
        [TestMethod]
        public void PrecioEs944Dolares_SiAsientoEsS7()
        {
            //Arrange
            Tiquete tiquete = new Tiquete();

            //Act
            decimal precio = tiquete.CalcularPrecioConImpuestosTiquete("S7");

            //Assert 

            /*
            
            Si está de la A a la E, entonces el precio es 2500 más 5% cargo servicio, y 13% IVA. 

            Con A4 = 800 * 1.18 = 944

             */

            Assert.AreEqual(944m, precio);
        }

        [TestCategory("ModificacionTiquete")]
        [TestMethod]
        public void PrecioDespuesDeCambioDeAsientoEs2006Dolares_SiPrecioPrevioEs2650DolaresYDescuentoEs300DolaresYAsientoNuevoEsS6()
        {
            //Arrange
            Tiquete tiquete = new Tiquete();

            //Act
            decimal descuento = tiquete.CalcularPrecioCambioAsiento(2650, 300, "S6");

            //Assert 

            /*
            
            Funcionamiento método: 
                1) Se le suma al "precioPrevio" el descuento que se le realizó inicialmente. 
                2) Se le resta el precio del asientoNuevo.

                Resultado con inputs: 
                   
                    --> 2650 + 300 = 2950
                    --> 2950 - 944 = 2006
             */

            Assert.AreEqual(2006m, descuento);
        }

        [TestCategory("Equipaje")]
        [TestMethod]
        public void CargoPorSobrecargaEs100Dolares_SiPesoTotalDeMaletasEs80Kg()
        {
            // arrange
            CalculosEquipaje calculosEquipaje = new CalculosEquipaje();

            // act
            decimal PrecioMaletas = calculosEquipaje.CalcularPrecioSobrepeso(80.00);

            // assert
            Assert.AreEqual(100.00m, PrecioMaletas);
        }

        [TestCategory("Equipaje")]
        [TestMethod]
        public void PrecioTotalDeTiqueteEs300Dolares_SiCargoPorSobrecargaEs100DolaresYPrecioTotalDeMaletasEs200Dolares()
        {
            //arrange
            CalculosEquipaje calculosEquipaje = new CalculosEquipaje();

            //act
            decimal precioTiquete_Test = calculosEquipaje.CalcularPrecioTotalConTiquete(100.00m, 200.00m);

            //assert
            Assert.AreEqual(300.00m, precioTiquete_Test);


        }
        [TestCategory("Millas")]
        [TestMethod]
        public void MillasRestantesSon20_SiMillasAcumuladasSon24YMillasAUsarSon4() //Primera prueba Nicolas
        {
            //Arrange
            Usuario usuarioMillasTest = new Usuario();

            //Act
            usuarioMillasTest.MillasAcumuladas = 24;
            usuarioMillasTest.CalcularMillasRestantes(4);
            int pruebaMillasRestantes = usuarioMillasTest.MillasAcumuladas;

            //Assert
            Assert.AreEqual(20, pruebaMillasRestantes);
        }

        [TestCategory("CompraTiquete")]
        [TestMethod]
        public void DescuentoAAplicarEs12Dolares_SiElPrecioDelTiqueteEs560DolaresYLasMillasAUsarSon4()
        {
            //Arrange
            Tiquete tiqueteDescuetoTest = new Tiquete();

            //Act
            tiqueteDescuetoTest.Precio = 560;
            tiqueteDescuetoTest.CalcularDescuentoTiquete(4);
            decimal pruebaDescuento = tiqueteDescuetoTest.Descuento;

            //Assert
            Assert.AreEqual(12, pruebaDescuento);
        }
    } 
}