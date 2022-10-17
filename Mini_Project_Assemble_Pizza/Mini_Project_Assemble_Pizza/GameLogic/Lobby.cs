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
            OperationOfCollection ingredientsDefault = new OperationOfCollection();
            double userScore = 0;

            while (gameLvl <= 12)
            {
                Dictionary<string, int> ingredientsToRemember = ingredientsDefault.
                    RandomIngredients(this.validation.ValidationNumberToRemember(gameLvl));

                int attemp = 1;
                string messageAfterLvl;

                Console.WriteLine($"Current game level: {gameLvl}\t\t\tUser score: {userScore}\n");
                Console.WriteLine("You have 5 attempts to guess the ingredient and its quantity, otherwise you won't get any points!\n");

                while (ingredientsToRemember.Count != 0)
                {
                    Console.Write("Enter Ingredient: ");
                    string userInputIngredients = Console.ReadLine();

                    Console.Write("Enter number of pieces for ingredients: ");
                    int numberOfPiecesForIngredients = Int32.Parse(Console.ReadLine());

                    if (ingredientsToRemember.ContainsKey(userInputIngredients) &&
                        ingredientsToRemember[userInputIngredients] == numberOfPiecesForIngredients)
                    {
                        Console.WriteLine($"\nYou guessed! Ingredient: {userInputIngredients} " +
                            $"have {numberOfPiecesForIngredients} pieces!\n");

                        ingredientsToRemember.Remove(userInputIngredients);
                    }
                    else if (ingredientsToRemember.ContainsKey(userInputIngredients) &&
                        ingredientsToRemember[userInputIngredients] != numberOfPiecesForIngredients)
                    {
                        Console.WriteLine($"\nYou are mistaken! Ingredient: {userInputIngredients} " +
                            $"does not have {numberOfPiecesForIngredients} pieces!\n");
                        attemp++;
                    }
                    else
                    {
                        Console.WriteLine($"\nWrong ingredient!\n");
                        attemp++;
                    }

                    if (attemp == 5)
                    {
                        Console.WriteLine("You've run out of attempts!");
                        break;
                    }
                }

                Console.Clear();
                userScore = this.validation.ValidationUserScore(score: userScore, lvl: gameLvl, attemp: attemp);

                messageAfterLvl = attemp != 5 ? $"You have won level: {gameLvl}!" : $"You have lost level: {gameLvl}!";
                Console.WriteLine(messageAfterLvl + $"\t\t\tCurrent score: {userScore}");

                gameLvl++;

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine($"Game ended! Youre total score = {userScore}");
        }

        public void ChoiceLevel()
        {
            Console.WriteLine("Select level from 1 to 12.");
            int choiseLevelUser = this.validation.ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            StartGame(choiseLevelUser);
        }

        void AddToLeadboard(string userName, int record)
        {
            this.people.Add(userName, record);
        }
    }
}
