namespace Mini_Project_Assemble_Pizza.Lobby
{
    using System;
    using System.Collections.Generic;
    public class Lobby
    {
      
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

        public void ChoiceLevel()
        {
            Console.WriteLine("Select level from 1 to 12.");
            bool error = true;

            while (error)
            {
                int choiseLevelUser = Int32.Parse(Console.ReadLine());

                switch (choiseLevelUser)
                {
                    case 1: 
                        error = false; 
                        break;
                    case 2: 
                        error = false;  
                        break;
                    case 3: 
                        error = false; 
                        break;
                    case 4: 
                        error = false;
                        break;
                    case 5: 
                        error = false;
                        break;
                    case 6: 
                        error = false;
                        break;
                    case 7: 
                        error = false;
                        break;
                    case 8: 
                        error = false;
                        break;
                    case 9: 
                        error = false;
                        break;
                    case 10: 
                        error = false;
                        break;
                    case 11: 
                        error = false;
                        break;
                    case 12: 
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
            people.Add(userName, record);
        }
    }
}
