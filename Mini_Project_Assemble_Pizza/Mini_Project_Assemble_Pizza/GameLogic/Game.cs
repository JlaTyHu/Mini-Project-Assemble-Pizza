namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using Mini_Project_Assemble_Pizza.ValidationService;
    public class Game
    {
        ValidationCount validation = new ValidationCount();
        DisplayGameInformation display = new DisplayGameInformation();

        public void ChoiceLevel()
        {
            Console.WriteLine("Select level from 1 to 12.");
            int choiseLevelUser = this.validation.ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            StartGame(choiseLevelUser);
        }

        private void StartGame(int gameLvl)
        {
            double userScore = 0;
            int attemp;

            while (gameLvl <= 12)
            {
                attemp = 1;

                attemp = CheckingTheIngredientAndItsQuantity(lvl: gameLvl, score: userScore, attemp: attemp);
                userScore = this.validation.ValidationUserScore(score: userScore, lvl: gameLvl, attemp: attemp);

                this.display.DisplayMessageAfterLvl(lvl: gameLvl, score: userScore, attemp: attemp);

                gameLvl++;
            }

            Console.WriteLine($"Game ended! Youre total score = {userScore}");
        }

        private int CheckingTheIngredientAndItsQuantity(int lvl, double score, int attemp)
        {
            Console.Clear();
            this.display.DisplayMessageBeforeLvl(lvl: lvl, score: score);

            this.display.PressAnyKeyToContinue();

            OperationOfCollection ingredientsDefault = new OperationOfCollection();
            Dictionary<string, int> ingredientsToRemember = ingredientsDefault.
                    RandomIngredients(this.validation.ValidationNumberToRemember(count: lvl));

            Console.WriteLine("");

            this.display.DisplayMessageBeforeLvl(lvl: lvl, score: score);

            while (ingredientsToRemember.Count != 0 && attemp != 5)
            {
                Console.Write("Enter Ingredient: ");
                string userInputIngredients = this.validation.ValidationUserInputIngredients(Console.ReadLine());

                Console.Write("Enter number of pieces for ingredients: ");
                int userInputnumberOfPiecesForIngredients = this.validation.
                    ValidationUserInputNumberOfPiecesForIngredients(Int32.Parse(Console.ReadLine()));

                if (ingredientsToRemember.ContainsKey(userInputIngredients) &&
                    ingredientsToRemember[userInputIngredients] == userInputnumberOfPiecesForIngredients)
                {
                    Console.WriteLine($"\nYou guessed! Ingredient: {userInputIngredients} " +
                        $"have {userInputnumberOfPiecesForIngredients} pieces!\n");

                    ingredientsToRemember.Remove(userInputIngredients);
                }
                else if (ingredientsToRemember.ContainsKey(userInputIngredients) &&
                    ingredientsToRemember[userInputIngredients] != userInputnumberOfPiecesForIngredients)
                {
                    Console.WriteLine($"\nYou are mistaken! Ingredient: {userInputIngredients} " +
                        $"does not have {userInputnumberOfPiecesForIngredients} pieces!\n");

                    attemp++;
                }
                else
                {
                    Console.WriteLine($"\nWrong ingredient!\n");

                    attemp++;
                }
            }

            return attemp;
        }
    }
}
