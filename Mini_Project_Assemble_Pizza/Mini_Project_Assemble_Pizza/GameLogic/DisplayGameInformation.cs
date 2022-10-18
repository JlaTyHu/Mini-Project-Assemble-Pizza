namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;

    public class DisplayGameInformation
    {
        public void DisplayMessageBeforeLvl(int lvl, double score)
        {
            Console.WriteLine($"Current game level: {lvl}\t\t\tUser score: {score}\n");
            Console.WriteLine("You have 5 attempts to guess the ingredient and its quantity, " +
                "otherwise you won't get any points!\n");
        }

        public void DisplayMessageAfterLvl(int lvl, double score, int attemp)
        {
            string messageAfterLvl = attemp != 5 ? $"You have won level: {lvl}!" : $"You have lost level: {lvl}!";
            Console.WriteLine(messageAfterLvl + $"\t\t\tCurrent score: {score}");

            PressAnyKeyToContinue();
            Console.Clear();
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
