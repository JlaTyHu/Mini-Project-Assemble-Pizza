using System;
using Mini_Project_Assemble_Pizza.FieldInfoPerson;

namespace Mini_Project_Assemble_Pizza.Lobby
{
     class Lobby
    {
        InfoPerson infoPerson = new InfoPerson();
        void Registration()
        {
            
            Console.WriteLine("Registration");

            Console.WriteLine("Enter your name:");

            infoPerson.Name = Console.ReadLine();

            Console.WriteLine("Enter your age:");

            infoPerson.Age = Int32.Parse(Console.ReadLine());
        }

        void BeginOfGame()
        {
            Console.WriteLine("Lobby");

            Console.WriteLine("Begin game (Press y) \t Leadboeard(Press t)");

            char userChoice = Char.Parse(Console.ReadLine());
            
            if (userChoice == 'y')
            {
                
            }

            else if( userChoice == 't')
            {
                Leadboard leadboard = new Leadboard();
                leadboard.MainLeadboard();
            }
        }
     }
}
