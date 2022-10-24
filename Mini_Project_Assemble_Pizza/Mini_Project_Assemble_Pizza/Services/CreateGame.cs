namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;

    public class CreateGame
    {
        private readonly IIngredientsService _ingredientsService;

        private const int _attemps = 5;

        public CreateGame(IIngredientsService ingredientsService)
        {
            this._ingredientsService = ingredientsService;
        }

        public void BuildGame()
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


        public double UserScore(double score, int lvl, int attemp)
        {
            return lvl == 1 ? ((10 / attemp) + score) : (((10 + lvl) / attemp) + score);
        }
    }
}
