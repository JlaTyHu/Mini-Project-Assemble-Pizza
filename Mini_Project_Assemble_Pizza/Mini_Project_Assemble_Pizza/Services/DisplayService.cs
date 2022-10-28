namespace Mini_Project_Assemble_Pizza.Services
{
    using System;
    using Mini_Project_Assemble_Pizza.Interfaces;

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
    }
}
