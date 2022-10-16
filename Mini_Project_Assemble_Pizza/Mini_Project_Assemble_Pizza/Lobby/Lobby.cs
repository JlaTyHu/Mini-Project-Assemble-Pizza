namespace Mini_Project_Assemble_Pizza.Lobby
{
    using System;
    public class Lobby
    {
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
    }
}
