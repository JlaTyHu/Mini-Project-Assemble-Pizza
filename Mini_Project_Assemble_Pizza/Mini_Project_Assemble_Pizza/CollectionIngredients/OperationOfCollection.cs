namespace Mini_Project_Assemble_Pizza.CollectionIngredients
{
    using System;
    using System.Collections.Generic;

    public class OperationOfCollection
    {
        public Dictionary<string, int> RandomIngredients(int numberOfIngredientsToRemember)
        {
            Random rnd = new Random();
            Dictionary<string, int> randomIngredientsToRemember = new Dictionary<string, int>();
            List<string> listOfIngredients = FillTheListWithIngredients();

            int randomIngredient;
            int randomPiece;

            for (int i = 0; i < numberOfIngredientsToRemember; i++)
            {
                randomIngredient = rnd.Next(0, listOfIngredients.Count);
                randomPiece = rnd.Next(1, 5);

                Console.WriteLine($"Ingredient: {listOfIngredients[randomIngredient]}, piece: {randomPiece}");

                randomIngredientsToRemember.Add(listOfIngredients[randomIngredient], randomPiece);
                listOfIngredients.Remove(listOfIngredients[randomIngredient]);

                System.Threading.Thread.Sleep(1000);
            }

            SetTimer(timeInSeconds: 5);

            return randomIngredientsToRemember;
        }

        public void DisplayIngredientsAsTable(List<string> listOfIngredients)
        {
            string displayMessage;

            for (int numberOfElementsInLine = 0; numberOfElementsInLine < listOfIngredients.Count; numberOfElementsInLine++)
            {
                displayMessage = numberOfElementsInLine % 2 == 0 ?
                                $"\n{listOfIngredients[numberOfElementsInLine]}\t\t" : $"{listOfIngredients[numberOfElementsInLine]}\t\t";

                Console.WriteLine(displayMessage);
            }
        }

        private void SetTimer(int timeInSeconds)
        {
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Game will start in {timeInSeconds - i}");
                System.Threading.Thread.Sleep(1000);
            }

            Console.Clear();
        }

        private List<string> FillTheListWithIngredients()
        {
            return new List<string>
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
    }
}
