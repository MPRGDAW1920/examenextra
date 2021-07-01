using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrediccionNS;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            prediccion miPrediccion = new prediccion();

            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();


            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);

            miPrediccion.ObtenerPrediccion(dia1, dia2, dia3);

            Console.WriteLine("Temperatura Celsius: " + miPrediccion.TemperaturaCelsius);
            Console.WriteLine("Temperatura Farenheit: " + miPrediccion.TemperaturaFarenheit);
            Console.WriteLine("Máxima: " + miPrediccion.TemperaturaMaxima);
            Console.WriteLine("Mínima: " + miPrediccion.TemperaturaMinima);

            Console.ReadKey();

            // Resultado final
            // Celsius: 17,155
            // Farenheit: 62,879
            // Máxima: 21
            // Mínima: 12,5
        }
    }
}
