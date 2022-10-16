namespace Mini_Project_Assemble_Pizza.CollectionIngredients
{
    using System;
    using System.Collections.Generic;

    internal class OperationOfCollection
    {
        List<string> Ingredients { get; set; }

        public OperationOfCollection()
        {
            this.Ingredients = new List<string>
            {
                "Cheese",
                "Tomato",
                "Mushrooms",
                "Sausage",
                "Meat",
                "Pineapple",
                "Mayonnaise",
                "Ketchup",
                "Bacon",
                "Onion",
                "Olives",
                "Pepper"
            };
        }

        public void DisplayIngredients()
        {
            for (int i = 0; i < this.Ingredients.Count; i++)
            {
                if (i % 2 == 0)
                    Console.Write($"\n{this.Ingredients[i]}\t\t");
                else
                    Console.Write($"{this.Ingredients[i]}\t\t");
            }
        }
    }
}
