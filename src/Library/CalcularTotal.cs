using System;
using System.Collections;
using System.Net.Security;

namespace Full_GRASP_And_SOLID.Library
{
    public class RecipeCost //Esta clase se encarga de calcular el precio de nuestras recetas
    {
        public static double Cost(Recipe recipe)
        {
            double finalPrice = 0; //Inicializamos el valor del precio final
            foreach (Step step in recipe.Steps) //Aqui recorremos el costo de los pasos que debamos ejecutar y los sumamos entre si para obtener su precio final
            {
                double stepCost = (step.Equipment.HourlyCost / 3600 * step.Time) + step.Input.UnitCost; //En esta linea llamamos al costo por hora del equipo a utilizar, pasamos su precio
                                                                                                        //a segundos y luego lo multiplicamos por la cantidad de segundos que lo utilizemos
                                                                                                        //luego le sumamos el producto que utilizamos para realizar este paso, por ej. cafe
                finalPrice += stepCost; //Aqui acumulamos el valor de los pasos realizados
            }
            return finalPrice;
        }
    }
}
