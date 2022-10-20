namespace Mini_Project_Assemble_Pizza.Lobby
{
    using System;
    using Mini_Project_Assemble_Pizza.FieldInfoPerson;
    using Mini_Project_Assemble_Pizza.GameLogic;
    using Mini_Project_Assemble_Pizza.Learboard;
    using Mini_Project_Assemble_Pizza.ValidationService;

    public class LobbyGame
    {
        public void Registration()
        {
            ValidationCount validation = new ValidationCount();
            const int DEFAULT_USER_SCORE_VALUE = 0;

            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");
            string userInputName = validation.ValidationUserInputIngredients(Console.ReadLine());

            Console.WriteLine("Enter your age:");
            int userInputAge = validation.ValidationUserInputAge(Int32.Parse(Console.ReadLine()));

            InfoPerson infoPerson = new InfoPerson(userInputName, userInputAge, DEFAULT_USER_SCORE_VALUE);
            BeginOfGame(infoPerson);
        }

        public void BeginOfGame(InfoPerson infoPerson)
        {
            Console.Clear();

            Game game = new Game();

            Console.WriteLine("Lobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t)");

            var userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);

            switch (userInputChoice)
            {
                case 'y' : game.ChoiceLevel(infoPerson); 
                    break;
                case 't':
                    Console.Clear();
                    LeadboardGame leadboard = new LeadboardGame();
                    leadboard.MainLeadboard();
                    BackToLobby(infoPerson);
                    break;
                default: Console.WriteLine("There is no such option!");  
                    break;
            }
        }

        private void BackToLobby(InfoPerson infoPerson)
        {
            Console.WriteLine("<= Back (Press b)");

            var userInputChoice = Char.ToLower(Console.ReadKey().KeyChar);

            switch (userInputChoice)
            {
                case 'b': BeginOfGame(infoPerson);  
                    break;
                default: Console.WriteLine("There is no such option!");
                    break;
            }
        }
    }
}
