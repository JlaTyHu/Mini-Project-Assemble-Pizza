namespace Mini_Project_Assemble_Pizza.Lobby
{
    using System;
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using System.Text.Json;
    using System.IO;
    using Mini_Project_Assemble_Pizza.Field;
    public class Lobby
    {
       
        public void Registration()
        {

            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");

            string userName = Console.ReadLine();
            Console.WriteLine("Enter your age:");

            int ageUser = Int32.Parse(Console.ReadLine());

            int record = 0;

            Console.WriteLine(new string('-', 50));

            InfoPerson infoPerson = new InfoPerson(userName, ageUser, record);
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
                        DisplayLeadboard();
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

        void SaveLeadboardToFile()
        {
            InfoPerson infoPerson = new InfoPerson(name, age, record);
            string json = JsonSerializer.Serialize(infoPerson);
            File.WriteAllText(@"E:\Leadboard.json", json);
        }

        void DisplayLeadboard()
        {
            string display = File.ReadAllText(@"E:\Leadboard.json");
            Console.WriteLine(display);
        }
    }
}
