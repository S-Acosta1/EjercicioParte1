//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe                             // El error que existia en esta clase era que se encargaba de almacenar los pasos y tambien de imprimirlos en pantalla
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }
        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public ArrayList Steps                      // Agregamos este ArrayList Steps para que se use de manera publica y las otras clases puedan acceder a el sin modificar su contenido.
        {
            get { return steps; }
        }
        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            double precioFinal=0;
            foreach (Step step in this.steps)                                                           // Este foreach itera los pasos que dicta la receta y los imprime uno a uno
            {
                double costoStep = step.Input.UnitCost + (step.Equipment.HourlyCost/3600*step.Time);    //Aqui se calcula el precio por paso ejecutado
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
                precioFinal += costoStep;                                                               // Aqui acumulamos el resultado de la suma de costo por paso
            }
            Console.WriteLine($"El precio final es: {RecipeCost.Cost(this)}");                          // Por ultimo imprimimos el precio final.
        }
    }
}
