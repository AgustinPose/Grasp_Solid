using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
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

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }

        // La clase Recipe cumple con el principio SRP al tener una única razón para cambiar,
        // que es calcular el costo total de producción. Esta responsabilidad está encapsulada
        // en el método CalcularCostoProduccion(), lo que facilita el mantenimiento y la
        // comprensión del código al separar esta funcionalidad específica en su propia función.
        public double CalcularCostoProduccion()
        {
            double costoTotal = 0;

            foreach (Step step in this.steps)
            {
                double costoInsumos = step.Quantity * step.Input.UnitCost;
                costoTotal += costoInsumos;

                double costoEquipamiento = step.Time / 60 * step.Equipment.HourlyCost;
                costoTotal += costoEquipamiento;
            }

            return costoTotal;
        }

        public void ImprimirReceta()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step paso in this.steps)
            {
                Console.WriteLine($" {paso.Quantity} de '{paso.Input.Description}' " +
                    $"usando '{paso.Equipment.Description}' durante {paso.Time} segundos");
            }

            double costoProduccion = CalcularCostoProduccion();
        }

    }
}
