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
            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");

            string name = Console.ReadLine();

            Console.WriteLine("Enter your age:");

            int age = Int32.Parse(Console.ReadLine());
            InfoPerson infoPerson = new InfoPerson(name, age, 0);
            BeginOfGame(infoPerson);
        }

        private void BeginOfGame(InfoPerson infoPerson)
        {
            Console.Clear();

            Game game = new Game();
            Console.WriteLine("Lobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t)");

            char userChoice = Char.Parse(Console.ReadLine());

            if (userChoice == 'y')
            {
                game.ChoiceLevel(infoPerson);
            }

            else if (userChoice == 't')
            {
                Console.Clear();
                LeadboardGame leadboard = new LeadboardGame();
                leadboard.MainLeadboard();
                BackToLobby(infoPerson);
            }
        }

        private void BackToLobby(InfoPerson infoPerson)
        {
            Console.WriteLine("<= Back (Press b)");

            char back = Char.Parse(Console.ReadLine());

            switch(back)
            {
                case 'b': BeginOfGame(infoPerson);  break;
                default: Console.WriteLine("There is no such option!");
                    break;
            }
        }
    }
}
