namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System.Collections.Generic;
    using System;

    public class IngredientsService : IIngredientsService
    {
        private static List<string> _ingredients { get; set; }

        public Dictionary<string, int> RandomIngredients(int numberOfIngredientsToRemember)
        {
            Random rnd = new Random();
            Dictionary<string, int> randomIngredientsToRemember = new Dictionary<string, int>();
            AddIngredients();

            int randomIngredient;
            int randomPiece;

            for (int i = 0; i < numberOfIngredientsToRemember; i++)
            {
                randomIngredient = rnd.Next(0, _ingredients.Count);
                randomPiece = rnd.Next(1, 5);

                Console.WriteLine($"Ingredient: {_ingredients[randomIngredient]}, piece: {randomPiece}");

                randomIngredientsToRemember.Add(_ingredients[randomIngredient], randomPiece);
                _ingredients.Remove(_ingredients[randomIngredient]);

                Console.Beep(37, 1000);
            }

            SetTimer(timeInSeconds: 5);

            return randomIngredientsToRemember;
        }

        public void DisplayIngredientsAsTable()
        {
            AddIngredients();
            for (int elementsInLine = 1; elementsInLine-1 < _ingredients.Count; elementsInLine++)
            {
                string displayMessage = elementsInLine % 2 == 0 ? $"{_ingredients[elementsInLine - 1]}" : $"\n{_ingredients[elementsInLine - 1]}\t\t";

                Console.Write(displayMessage);
            }
        }

        private void SetTimer(int timeInSeconds)
        {
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Game will start in {timeInSeconds - i}");
                Console.Beep(37, 1000);
            }

            Console.Clear();
        }

        private List<string> AddIngredients()
        {
            _ingredients = new List<string>();
            string[] ingredients = { "Cheese", "Tomato", "Sausage", "Mushrooms","Meat", "Pineapple", "Ketchup", "Mayonnaise", "Bacon", "Onion", "Olives", "Pepper" };

            _ingredients.AddRange(ingredients);

            return _ingredients;
        }
    }
}
