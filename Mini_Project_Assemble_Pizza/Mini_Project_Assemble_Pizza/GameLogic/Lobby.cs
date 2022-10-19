namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using Mini_Project_Assemble_Pizza.ValidationService;

    public class Lobby
    {
        ValidationCount validation = new ValidationCount();
        DisplayGameInformation display = new DisplayGameInformation();

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

        void AddToLeadboard(string userName, int record)
        {
            this.people.Add(userName, record);
        }
    }
}
