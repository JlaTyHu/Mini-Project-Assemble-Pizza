namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System.Collections.Generic;
    using Entity = Entities;
    using System;

    public class CreateGame : DisplayService
    {
        private readonly IIngredientsService _ingredientsService;
       
        public CreateGame(IIngredientsService ingredientsService) 
        {
            this._ingredientsService = ingredientsService;
        }

        protected void BeginGame(int gameLevel)
        {
            double userScore = 0;
            bool isExit = true;
            CreateAGame(gameLevel, userScore);

            for (int i = gameLevel; i <= 12 && isExit == true; i++)
            {
                DisplayMessageBeforeLvl(gameLevel, userScore);

                var ingredientsToRemember = _ingredientsService.RandomIngredients(CountOfIngredients(i));

                userScore = GuessTheIngredient(ingredientsToRemember, userScore, i);

                MessageAfterLvl(i, userScore);

                isExit = UserChoiceStayOrExit();
            }
        }

        private double GuessTheIngredient(Dictionary<string, int> ingredients, double userScore, int gameLevel)
        {
            while (ingredients.Count != 0)
            {
                DisplayMessageBeforeLvl(gameLevel, userScore);

                Console.Write("Enter Ingredient: ");
                string userInputIngredients = Console.ReadLine();

                Console.Write("Enter number of pieces for ingredients: ");
                int userInputNumberOfIngredients = Convert.ToInt32(Console.ReadLine());

                if (ingredients.ContainsKey(userInputIngredients) && (ingredients[userInputIngredients] == userInputNumberOfIngredients))
                {
                    Console.WriteLine($"\nYou guessed! Ingredient: {userInputIngredients} have {ingredients[userInputIngredients]} pieces!\n");

                    ingredients.Remove(userInputIngredients);
                }
                else
                {
                    throw new Exception("Input Error! You didn't guess the ingredient or quantity!");
                }
            }
            
            return UserScore(userScore, gameLevel); ;
        }

        private void CreateAGame(int gameLevel, double userScore)
        {
            if (gameLevel < 0 || gameLevel >= 12)
            {
                DisplayMessageBeforeLvl(gameLevel, userScore);
                DisplayGamePause();
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
            return new Entity.User
            {
                UserScore = score,
            };
        }

        private int CountOfIngredients(int gameLvl)
        {
            return gameLvl <= 5 ? gameLvl : 5;
        }

        
        public void EnterUserMenu()
        {
            _ingredientsService.DisplayIngredientsAsTable();
            
            Console.WriteLine("\n\nLobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t) \t Close(Press x)");
            char userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);

            MenuGame(userInputChoice);
        }

        public void MenuGame(char userInputChoice)
        {
            switch (userInputChoice)
            {
                case 'y': SelectLevelGame(); break;
                case 't': ShowToUserLeadboard(); break;
                case 'x': Console.WriteLine("Game over!"); break;
                default: throw new Exception("Invalid value!");
            }
            Console.Clear();
        }
        public void ShowToUserLeadboard()
        {
            Leadboard leadboard = new Leadboard();
            leadboard.SortingList();
            leadboard.DisplayList();
            BackToMenuUser();
        }
        public void SelectLevelGame()
        {
            Console.WriteLine("\nSelect level from 1 to 12: ");
            int gameLevel = Int32.Parse(Console.ReadLine());
            BeginGame(gameLevel);
        }

        private void MessageAfterLvl(int lvl, double score)
        {
            Console.WriteLine($"You won {lvl} lvl!\t\tCurrent score: {score}");

            DisplayGamePause();
            Console.Clear();
        }

        private void BackToMenuUser()
        {
            Console.WriteLine("<= Back (Press b)");

            char userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);

            BackToMenu(userInputChoice);
        }
        public void BackToMenu(char userInputChoice)
        {
            if (userInputChoice == ' ' || userInputChoice != 'b')
            {
                throw new Exception("No such option!");
            }
            EnterUserMenu();
        }

        private bool UserChoiceStayOrExit()
        {
            Console.WriteLine("Do you want to continue playing or no? (y / n)");
            char userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);
            switch (userInputChoice)
            {
                case 'y': break;
                case 'n': EnterUserMenu();break;
                default: break;
            }

            return userInputChoice.Equals('y') ? true : false;
        }
    }
}
