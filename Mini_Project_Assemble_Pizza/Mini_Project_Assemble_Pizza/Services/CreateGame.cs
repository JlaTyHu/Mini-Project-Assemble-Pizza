namespace Mini_Project_Assemble_Pizza.Services
{
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;
    using Entity = Mini_Project_Assemble_Pizza.Entities;
    using Mini_Project_Assemble_Pizza.Services;

    public class CreateGame : IngredientsService
    {
        private readonly IIngredientsService _ingredientsService;

        public CreateGame(IIngredientsService ingredientsService)
        {
            this._ingredientsService = ingredientsService;
        }

        public void EnterUserMenu()
        {
            Console.Clear();

            Console.WriteLine("Lobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t) \t Close(Press x)");
            char userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);
            MenuGame(userInputChoice);
        }

        public void MenuGame(char userInputChoice)
        {
            switch (userInputChoice)
            {
                case 'y': SelectLevelGame(); break;
                case 't': break; // TODO: need to add leadboard
                case 'x': break;
                default: throw new Exception("Invalid value!");
            }
        }

        public void SelectLevelGame()
        {
            Console.WriteLine("\nSelect level from 1 to 12: ");
            int gameLevel = Int32.Parse(Console.ReadLine());

            BeginGame(gameLevel);
        }

        private void BeginGame(int gameLevel)
        {
            double userScore = 0;

            CreateAGame(gameLevel, userScore);          

            for (int i = 0; i <= 12; i++)
            {
                var ingredientsToRemember = GenerateRandomIngredients(CountOfIngredients(gameLevel));

                userScore = GuessTheIngredient(ingredientsToRemember, userScore, gameLevel);
            }
        }

        private double GuessTheIngredient(Dictionary<string, int> ingredients, double userScore, int gameLevel)
        {
            Console.Write("Enter Ingredient: ");
            string userInputIngredients = Console.ReadLine();

            Console.Write("Enter number of pieces for ingredients: ");
            int userInputNumberOfIngredients = Convert.ToInt32(Console.ReadLine());

            if (ingredients.ContainsKey(userInputIngredients) && (ingredients[userInputIngredients] == userInputNumberOfIngredients))
            {
                Console.WriteLine($"\nYou guessed! Ingredient: {userInputIngredients} have {ingredients[userInputIngredients]} pieces!\n");

                ingredients.Remove(userInputIngredients);

                userScore = UserScore(userScore, gameLevel);
            }
            else
            {
                Console.WriteLine($"\nInput Error! You didn't guess the ingredient or quantity!\n");
            }

            return userScore;
        }

        private void CreateAGame(int gameLevel, double userScore)
        {
            if (gameLevel < 0 || gameLevel >= 12)
            {
                DisplayMessageBeforeLvl(gameLevel, userScore);
                DisplayGamePause();
            }
        }

        private void DisplayMessageBeforeLvl(int lvl, double score)
        {
            Console.WriteLine($"Current game level: {lvl}\t\t\tUser score: {score}\n");
            Console.WriteLine("You have 5 attempts to guess the ingredient and its quantity, " +
                "otherwise you won't get any points!\n");
        }

        private void DisplayGamePause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void BackToMenuUser()
        {
            Console.WriteLine("<= Back (Press b)");

            char userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);

            BackToMenu(userInputChoice);
        }

        private void BackToMenu(char userInputChoice)
        {
            if(userInputChoice == ' ' || userInputChoice != 'b')
            {
                throw new Exception("No such option!");
            }
        }

        private double UserScore(double score, int lvl)
        {
            double scoreFormul = lvl == 1 ? 10 : 10 + lvl + score;

            ScoreEntitys(scoreFormul);

            return scoreFormul;
        }

        private Entity.User ScoreEntitys(double score)
        {
            if(score == 0) // TODO
            {
                throw new Exception("You can't have 0 points.");
            }

            return new Entity.User
            {
                UserScore = score,
            };
        }

        private int CountOfIngredients(int gameLvl)
        {
            return gameLvl <= 5 ? gameLvl : 5;
        }

        private void ShowToUserLeadboard()
        {
            Leadboard leadboard = new Leadboard();
            leadboard.SortingList();
            leadboard.DisplayList();
        }
    }
}
