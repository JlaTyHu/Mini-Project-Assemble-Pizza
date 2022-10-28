namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;
    using Entity = Mini_Project_Assemble_Pizza.Entities;
    public class CreateGame
    {
        private readonly IIngredientsService _ingredientsService;

        private const int _attemps = 5;

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
                case 'y':

                    SelectLevelGame();

                    break;

                case 't':
                    
                    break;

                case 'x': break;
                default: break;
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
            CreateAGame(gameLevel);

            for (int i = 0; i <= 12; i++)
            {
                int firstAttemp = 1;

                var ingredientsToRemember = _ingredientsService.RandomIngredients(gameLevel);
            }
        }

        private void CreateAGame(int gameLevel)
        {
            if (gameLevel < 0 || gameLevel >= 12)
            {
                var defaultUserScore = 0;

                DisplayMessageBeforeLvl(gameLevel, defaultUserScore);
                DisplayGamePause();
            }
        }

        public void DisplayMessageBeforeLvl(int lvl, double score)
        {
            Console.WriteLine($"Current game level: {lvl}\t\t\tUser score: {score}\n");
            Console.WriteLine("You have 5 attempts to guess the ingredient and its quantity, " +
                "otherwise you won't get any points!\n");
        }

        public void DisplayGamePause()
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
            bool checkButtons = userInputChoice == null || userInputChoice != 'b';
            
            if(checkButtons)
            {
                throw new Exception("No such option!");
            }
        }


        public double UserScore(double score, int lvl, int attemp)
        {
            return lvl == 1 ? ((10 / attemp) + score) : (((10 + lvl) / attemp) + score);
        }
    }
}
