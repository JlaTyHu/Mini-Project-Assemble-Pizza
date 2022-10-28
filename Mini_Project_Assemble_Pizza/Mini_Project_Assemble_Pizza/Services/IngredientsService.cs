namespace Mini_Project_Assemble_Pizza.Services
{
    using System;
    using System.Collections.Generic;

    public class IngredientsService
    {
        private static List<string> _ingredients { get; set; }

        public Dictionary<string, int> GenerateRandomIngredients(int numberOfIngredientsToRemember)
        {
            Random rnd = new Random();
            Dictionary<string, int> randomIngredientsToRemember = new Dictionary<string, int>();

            int randomIngredient;
            int randomPiece;

            for (int i = 0; i < numberOfIngredientsToRemember; i++)
            {
                randomIngredient = rnd.Next(0, _ingredients.Count);
                randomPiece = rnd.Next(1, 5);

                Console.WriteLine($"Ingredient: {_ingredients[randomIngredient]}, piece: {randomPiece}");

                randomIngredientsToRemember.Add(_ingredients[randomIngredient], randomPiece);
                _ingredients.Remove(_ingredients[randomIngredient]);

                Console.Beep(0, 1000);
            }

            // SetTimer(timeInSeconds: 5);

            return randomIngredientsToRemember;
        }

        public void DisplayIngredientsAsTable()
        {
            for (int numberOfElementsInLine = 0; numberOfElementsInLine < _ingredients.Count; numberOfElementsInLine++)
            {
                string displayMessage = numberOfElementsInLine % 2 == 0 ?
                                $"\n{_ingredients[numberOfElementsInLine]}\t\t" : 
                                $"{_ingredients[numberOfElementsInLine]}\t\t";

                Console.WriteLine(displayMessage);
            }
        }

        private List<string> AddIngredients()
        {
            string[] ingredients = { "Cheese", "Tomato", "Mushrooms", "Sausage", "Meat", "Pineapple", "Mayonnaise", "Ketchup", "Bacon", "Onion", "Olives", "Pepper" };

            _ingredients.AddRange(ingredients);

            return _ingredients;
        }
    }
}
