using System;
using Mini_Project_Assemble_Pizza.FieldInfoPerson;

namespace Mini_Project_Assemble_Pizza.Lobby
{
    internal class Lobby
    {
         void Registration()
        {
            InfoPerson infoPerson = new InfoPerson();
            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");

            infoPerson.Name = Console.ReadLine();

            Console.WriteLine("Enter your age:");

            infoPerson.Age = Int32.Parse(Console.ReadLine());

            
        }

        void BeginOfGame()
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
