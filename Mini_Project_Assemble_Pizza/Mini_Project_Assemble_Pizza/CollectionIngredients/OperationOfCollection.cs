﻿namespace Mini_Project_Assemble_Pizza.CollectionIngredients
{
    using System;
    using System.Collections.Generic;

    public class OperationOfCollection
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

        public Dictionary<string, int> RandomIngredients(int numberOfIngredientsToRemember)
        {
            Random rnd = new Random();
            Dictionary<string, int> ingredientsToRemember = new Dictionary<string, int>();
            int tempIngredient;
            int tempPiece;

            for (int i = 0; i < numberOfIngredientsToRemember; i++)
            {
                tempIngredient = rnd.Next(0, 12);
                tempPiece = rnd.Next(1, 5);
                Console.WriteLine($"Ingredient: {this.Ingredients[tempIngredient]}, piece: {tempPiece}");

                ingredientsToRemember.Add(this.Ingredients[tempIngredient], tempPiece);
                System.Threading.Thread.Sleep(1000);
            }

            SetTimer();
            return ingredientsToRemember;
        }

        private void SetTimer()
        {
            int defaultTimer = 5;

            Console.WriteLine();

            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Game will start in {defaultTimer - i}");
                System.Threading.Thread.Sleep(1000);
            }

            Console.Clear();
        }
    }
}
