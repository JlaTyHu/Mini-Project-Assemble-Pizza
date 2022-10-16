namespace Mini_Project_Assemble_Pizza.CollectionIngredients
{
    using System;
    using System.Collections.Generic;

    internal class OperationOfCollection
    {
        public List<string> FillCollection(List<string> ingredientsForPizza)
        {
            ingredientsForPizza.Add("Cheese");
            ingredientsForPizza.Add("Tomato");
            ingredientsForPizza.Add("Mushrooms");
            ingredientsForPizza.Add("Sausage");
            ingredientsForPizza.Add("Meat");
            ingredientsForPizza.Add("Pineapple");
            ingredientsForPizza.Add("Mayonnaise");
            ingredientsForPizza.Add("Ketchup");
            ingredientsForPizza.Add("Bacon");
            ingredientsForPizza.Add("Onion");
            ingredientsForPizza.Add("Olives");
            ingredientsForPizza.Add("Pepper");

            return ingredientsForPizza;
        }

        public void DisplayIngredients(List<string> ingredientsForPizza)
        {
            for (int i = 0; i < ingredientsForPizza.Count; i++)
            {
                if (i % 2 == 0)
                    Console.Write($"\n{ingredientsForPizza[i]}\t\t");
                else
                    Console.Write($"{ingredientsForPizza[i]}\t\t");
            }
        }
    }
}
