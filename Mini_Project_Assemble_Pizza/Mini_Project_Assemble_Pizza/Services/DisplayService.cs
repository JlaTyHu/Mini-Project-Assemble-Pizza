namespace Mini_Project_Assemble_Pizza.Services
{
    using System;

    public class DisplayService
    {
        protected void DisplayMessageBeforeLvl(int lvl, double score)
        {
            Console.WriteLine($"Current game level: {lvl}\t\t\tUser score: {score}\n");
        }

        protected void DisplayGamePause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        protected void DisplayMessageAfterLvl(int lvl, double score)
        {
            Console.WriteLine($"You won {lvl} lvl!\t\tCurrent score: {score}");

            DisplayGamePause();
            Console.Clear();
        }

        protected bool DisplayUserChoiceStayOrExit()
        {
            Console.WriteLine("Do you want to continue playing or no? (yes / no)");
            string userInputChoice = Console.ReadLine();

            return userInputChoice.Equals("yes") ? true : false;
        }
    }
}
