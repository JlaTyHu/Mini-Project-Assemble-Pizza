namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using Mini_Project_Assemble_Pizza.ValidationService;

    public class Lobby
    {
        ValidationCount validation = new ValidationCount();

        Dictionary<string, int> people = new Dictionary<string, int>();
        public void Registration()
        {
            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");

            string userName = Console.ReadLine();

            Console.WriteLine("Enter your age:");

            int ageUser = Int32.Parse(Console.ReadLine());

            Console.WriteLine(new string('-', 50));

        }

        public void BeginOfGame()
        {
            Console.WriteLine("Lobby");

            bool error = true;

            while (error)
            {
                Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t)");

                char userChoice = Char.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 'y':
                        error = false;
                        break;
                    case 't':
                        error = false;
                        break;
                    default:
                        error = true;
                        Console.WriteLine("No such option exist");
                        break;
                }
            }
        }     

        private void StartGame(int gameLvl = 1)
        {
            double userScore = 0;
            int attemp;

            while (gameLvl <= 12)
            {              
                attemp = 1;

                DisplayMessageBeforeLvl(lvl: gameLvl, score: userScore);

                attemp = CheckingTheIngredientAndItsQuantity(lvl: gameLvl, attemp: attemp);
                userScore = this.validation.ValidationUserScore(score: userScore, lvl: gameLvl, attemp: attemp);

                DisplayMessageAfterLvl(lvl: gameLvl, score: userScore, attemp: attemp);
            }

            Console.WriteLine($"Game ended! Youre total score = {userScore}");
        }

        public void ChoiceLevel()
        {
            Console.WriteLine("Select level from 1 to 12: ");
            int choiseLevelUser = this.validation.ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            
            StartGame(choiseLevelUser);
        }

        private int CheckingTheIngredientAndItsQuantity(int lvl, int attemp)
        {
            OperationOfCollection ingredientsDefault = new OperationOfCollection();
            Dictionary<string, int> ingredientsToRemember = ingredientsDefault.
                    RandomIngredients(this.validation.ValidationNumberToRemember(lvl));

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

            Console.Clear();

            return attemp;
        }

        private void DisplayMessageBeforeLvl(int lvl, double score)
        {
            Console.WriteLine($"Current game level: {lvl}\t\t\tUser score: {score}\n");
            Console.WriteLine("You have 5 attempts to guess the ingredient and its quantity, " +
                "otherwise you won't get any points!\n");
        }

        private void DisplayMessageAfterLvl(int lvl, double score, int attemp)
        {
            string messageAfterLvl = attemp != 5 ? $"You have won level: {lvl}!" : $"You have lost level: {lvl}!";
            Console.WriteLine(messageAfterLvl + $"\t\t\tCurrent score: {score}");

            lvl++;

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        void AddToLeadboard(string userName, int record)
        {
            this.people.Add(userName, record);
        }
    }
}
