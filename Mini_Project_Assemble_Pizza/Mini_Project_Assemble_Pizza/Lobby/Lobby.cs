namespace Mini_Project_Assemble_Pizza.Lobby
{
    using System;
    using Mini_Project_Assemble_Pizza.FieldInfoPerson;
    using Mini_Project_Assemble_Pizza.GameLogic;
    using Mini_Project_Assemble_Pizza.Learboard;

    public class LobbyGame
    {
        public void Registration()
        {
            const int DEFAULT_VALUE = 0;
            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");
            string userInputName = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            int userInputAge = Int32.Parse(Console.ReadLine());

            InfoPerson infoPerson = new InfoPerson(userInputName, userInputAge, DEFAULT_VALUE);
            BeginOfGame(infoPerson);
        }

        private void BeginOfGame(InfoPerson infoPerson)
        {
            Console.Clear();
            Game game = new Game();

            Console.WriteLine("Lobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t)");
            string userInputChoice = Console.ReadLine();

            switch (userInputChoice)
            {
                case "y": game.ChoiceLevel(infoPerson); break;

                case "t":
                    LeadboardGame leadboard = new LeadboardGame();
                    leadboard.MainLeadboard();
                    break;

                default: break;
            }
        }
    }
}
