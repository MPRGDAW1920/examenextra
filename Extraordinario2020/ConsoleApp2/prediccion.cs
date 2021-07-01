using System;
using System.Collections.Generic;


namespace PrediccionNS  // MPRG2021ok4 fin El primer paso debe ser añadir aquí vuestras iniciales
{
    ///<summary>Se han renombrado variables para hacerlas explicitas</summary>
    ///<summary>Encapsulado campo para que fueran privados</summary>
    ///<summary>Se han dado los valores aprovechando set de máxima, mínima </summary>
    ///<summary>Hecho metodo que he creado calcularTemperaturasDiarias sirva para los tres días</summary>
    ///<summary>Creado fichero de prueba</summary>

    ///<summary> Clase para obtener la predicción de la temperatura a partir de las observaciones de los tres días previos
    /// La clase calcula la predicción tanto en grados celsius como farenheit 
    /// </summary>


    public class prediccion
    {
        private double temperaturaCelsius;
        private double temperaturaFarenheit;
        private double temperaturaMaxima;
        private double temperaturaMinima;

        public double TemperaturaCelsius 
        { 
            get => temperaturaCelsius; 
            set => temperaturaCelsius = value; }

        public double TemperaturaFarenheit 
        {
            get => temperaturaFarenheit; 
            set => temperaturaFarenheit = value; }

        public double TemperaturaMaxima
        {   get => temperaturaMaxima;
            set => temperaturaMaxima = +1000;
        }

        public double TemperaturaMinima 
        {   get => temperaturaMinima;
            set => temperaturaMinima = -1000;
        }

        ///<summary> La siguiente función obtiene la temperatura promedio de cada uno 
        /// de los días que se pasan como parámetro basada en una fórmula.
        ///</summary> 
        ///<returns>devuelve una estimación  </returns>
   
        ///<param name="obsdia1"></param>
        ///<param name="obsdia2"></param>
        ///<param name=obsdia3"></param>
        ///<summary>contienen las observaciones de los días anteriores</summary>
        ///<returns> La función retorna true si se ha podido obtener la predicción, false si ha ocurrido un error</returns>

        public bool ObtenerPrediccion(List<double> obsdia1, List<double> obsdia2, List<double> obsdia3)
        {
            int contador;
            double temperaturamedia1 = 0;
            double temperaturamedia2 = 0;
            double temperaturamedia3 = 0;

        ///<summary>Incluimos valor en propiedades 
        ///        TemperaturaMaxima = +1000; 
        ///         TemperaturaMinima = -1000;
        ///</summary >

        ///<summary>Para cada día obtenemos la suma de temperaturas</summary>
        ///<remarks>Tenemos que tener al menos una observación </remarks>
            if (obsdia1.Count <= 0)
            {
               
                return false;
            }

            contador = CalcularTemperaturasDiarias(obsdia1, ref temperaturamedia1);

        ///<exception cref="obsdia2">Tenemos que tener al menos una observación</exception>
        
            if (obsdia2.Count <= 0)
            {
                return false;  // 
            }
            contador = CalcularTemperaturasDiarias(obsdia2, ref temperaturamedia2);

            temperaturamedia2 = temperaturamedia2 / obsdia2.Count;

         ///<exception cref="obsdia3">Tenemos que tener al menos una observación</exception>
  
            if (obsdia3.Count <= 0)
            {
                return false;  
            }

            contador = CalcularTemperaturasDiarias(obsdia2, ref temperaturamedia2);
       
            temperaturamedia3 = temperaturamedia3 / obsdia3.Count;

            ///<summary> Finalmente calculamos la temperatura media total, dándo más peso 		
            /// al último día que al primero</summary>
            
            TemperaturaCelsius = 0.2 * temperaturamedia1 + 0.35 * temperaturamedia2 + 0.45 * temperaturamedia3;

            ///<summary> calculamos también la temperatura en grados farenheit</summary>
           
            TemperaturaFarenheit = (TemperaturaCelsius * 1.8) + 32;

            return true;
        }

        private int CalcularTemperaturasDiarias(List<double> obsdia1, ref double temperaturamedia1)
        {
            int contador;
            for (contador = 0; contador < obsdia1.Count; contador++)
            {
                temperaturamedia1 = temperaturamedia1 + obsdia1[contador];
                if (TemperaturaMinima > obsdia1[contador])
                {
                    TemperaturaMinima = obsdia1[contador];
                }
                if (TemperaturaMaxima < obsdia1[contador])
                {
                    TemperaturaMaxima = obsdia1[contador];
                }

            }

            temperaturamedia1 = temperaturamedia1 / obsdia1.Count;
            return contador;
        }
    }
}

