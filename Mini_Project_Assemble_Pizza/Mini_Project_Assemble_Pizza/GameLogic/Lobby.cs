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

        private void StartGame(int userChoiceLvl = 1)
        {
            OperationOfCollection ingredientsDefault = new OperationOfCollection();
            double userScore = 0;

            while (userChoiceLvl <= 12)
            {
                Dictionary<string, int> ingredientsToRemember = ingredientsDefault.
                    RandomIngredients(validation.ValidationNumberToRemember(userChoiceLvl));

                int attemp = 1;

                Console.WriteLine($"Current game level: {userChoiceLvl}\n");

                while (ingredientsToRemember.Count != 0)
                {
                    Console.Write("Enter Ingredient: ");
                    string userInputIngredients = Console.ReadLine();
                    Console.WriteLine("\n");

                    Console.Write("Enter number of pieces for ingredients: ");
                    int numberOfPiecesForIngredients = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("\n");

                    if (ingredientsToRemember[userInputIngredients] == numberOfPiecesForIngredients)
                    {
                        userScore += 10;
                        ingredientsToRemember.Remove(userInputIngredients);
                    }
                    else
                    {
                        attemp++;
                    }
                }

                Console.WriteLine($"You completed the level: {userChoiceLvl}!");
                userChoiceLvl++;
                userScore = userScore / attemp;
            }

            Console.WriteLine($"Game ended! Youre total score = {userScore}");
        }

        public void ChoiceLevel()
        {
            Console.WriteLine("Select level from 1 to 12.");
            int choiseLevelUser = validation.ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            StartGame(choiseLevelUser);
        }

        void AddToLeadboard(string userName, int record)
        {
            people.Add(userName, record);
        }
    }
}
