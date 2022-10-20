namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using Mini_Project_Assemble_Pizza.ValidationService;
    using Mini_Project_Assemble_Pizza.FieldInfoPerson;
    using Mini_Project_Assemble_Pizza.Learboard;
    using Mini_Project_Assemble_Pizza.Lobby;

    public class Game
    {    
        public void ChoiceLevel(InfoPerson infoPerson)
        {
            ValidationCount validation = new ValidationCount();

            Console.WriteLine("\nSelect level from 1 to 12.");
            int choiseLevelUser = validation.ValidationUserChoiceLvl(Int32.Parse(Console.ReadLine()));
            StartGame(infoPerson, choiseLevelUser);
        }

        private void StartGame(InfoPerson infoPerson, int gameLvl)
        {
            LeadboardGame leadboard = new LeadboardGame();
            ValidationCount validation = new ValidationCount();
            DisplayGameInformation display = new DisplayGameInformation();
            LobbyGame lobbyGame = new LobbyGame();

            double userScore = 0;
            int attemp;

            while (gameLvl <= 12)
            {
                attemp = 1;

                attemp = CheckingTheIngredientAndItsQuantity(lvl: gameLvl, score: userScore, attemp: attemp);
                userScore = validation.ValidationUserScore(score: userScore, lvl: gameLvl, attemp: attemp);
                infoPerson.UserScore = userScore;

                display.DisplayMessageAfterLvl(lvl: gameLvl, score: userScore, attemp: attemp);
              
                if (!display.DisplayUserChoiceStayOrExit())
                {
                    leadboard.SavingleadboardAfterGame(infoPerson);
                    lobbyGame.BeginOfGame(infoPerson);
                    break;
                }
                
                gameLvl++;
            }

            Console.WriteLine($"Game ended! Youre total score = {userScore}");
        }



        private int CheckingTheIngredientAndItsQuantity(int lvl, double score, int attemp)
        {
            ValidationCount validation = new ValidationCount();
            DisplayGameInformation display = new DisplayGameInformation();
            const int DEFAULT_ATTEMP_SCORE = 5;

            Console.Clear();
            display.DisplayMessageBeforeLvl(lvl: lvl, score: score);
            display.DisplayGamePause();

            OperationOfCollection ingredientsDefault = new OperationOfCollection();
            Dictionary<string, int> ingredientsToRemember = ingredientsDefault.
                    RandomIngredients(validation.ValidationNumberToRemember(count: lvl));

            Console.WriteLine("");

            display.DisplayMessageBeforeLvl(lvl: lvl, score: score);

            while (ingredientsToRemember.Count != 0 && attemp >= 1 && attemp < 6)
            {
                Console.Write("Enter Ingredient: ");
                string userInputIngredients = validation.ValidationUserInputIngredients(Console.ReadLine());

                Console.Write("Enter number of pieces for ingredients: ");
                int userInputnumberOfPiecesForIngredients = validation.ValidationUserInputNumberOfPiecesForIngredients(Int32.Parse(Console.ReadLine()));

                bool chekUserInputs = (ingredientsToRemember.ContainsKey(userInputIngredients)) &&
                    (ingredientsToRemember[userInputIngredients] == userInputnumberOfPiecesForIngredients);

                switch (chekUserInputs)
                {
                    case true:
                        Console.WriteLine($"\nYou guessed! Ingredient: {userInputIngredients} " +
                            $"have {ingredientsToRemember[userInputIngredients]} pieces!\n");

                        ingredientsToRemember.Remove(userInputIngredients);
                        
                        break;

                    default:
                        Console.WriteLine($"\nInput Error! You didn't guess the ingredient or quantity!\n");
                        Console.WriteLine($"You have {DEFAULT_ATTEMP_SCORE - attemp} attempts left");

                        attemp++;

                        break;
                }               
            }

            return attemp;
        }
    }
}
