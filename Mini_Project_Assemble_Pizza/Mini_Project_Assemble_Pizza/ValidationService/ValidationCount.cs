namespace Mini_Project_Assemble_Pizza.ValidationService
{
    using System;

    public class ValidationCount
    {
        public int ValidationNumberToRemember(int count)
        {
            return count <= 5 ? count : 5;
        }

        public int ValidationUserChoiceLvl(int userChoiceLvl)
        {
            while (userChoiceLvl < 0 || userChoiceLvl > 13)
            {
                Console.WriteLine("Level cannot be lower than 1 and higher than 12!");
                Console.WriteLine("Try again: ");
                userChoiceLvl = ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            }

            return userChoiceLvl;
        }

        public double ValidationUserScore(double score, int lvl, int attemp)
        {
            return lvl == 1 ? ((10 / attemp) + score ): (((10 + lvl) / attemp) + score);
        }

        public string ValidationUserInputIngredients(string userIngredient)
        {
            while (string.IsNullOrEmpty(userIngredient) || userIngredient.Contains(" "))
            {
                Console.WriteLine("The name cannot be empty or space!");
                Console.WriteLine("Try again: ");
                userIngredient = ValidationUserInputIngredients(Console.ReadLine());
            }

            return userIngredient;
        }        

        public int ValidationUserInputNumberOfPiecesForIngredients(int userPieces)
        {
            while (userPieces < 1 && userPieces > 5)
            {
                Console.WriteLine("The number cannot be less than 1 or greater than 5!");
                Console.WriteLine("Try again: ");
                userPieces = ValidationUserInputNumberOfPiecesForIngredients(Int32.Parse(Console.ReadLine()));
            }

            return userPieces;
        }

        public string ValidationUserInputChoiseStayOrExit(string userInputChoice)
        {
            while (!userInputChoice.Contains("yes") && !userInputChoice.Contains("no"))
            {
                Console.WriteLine("Uncorrect input! Try again: [continue] playing or [exit]?");
                userInputChoice = Console.ReadLine(); ;
            }

            return userInputChoice;
        }

        public int ValidationUserInputAge(int userAge)
        {
            while (!(userAge > 1 && userAge < 100))
            {
                Console.WriteLine("Uncorrect age! Try again.");
                userAge = Int32.Parse(Console.ReadLine());
            }

            return userAge;
        }
    }
}
