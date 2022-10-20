namespace Mini_Project_Assemble_Pizza.GameLogic
{
    using System;
    using Mini_Project_Assemble_Pizza.ValidationService;

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

            DisplayGamePause();
            Console.Clear();
        }

        public void DisplayGamePause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public bool DisplayUserChoiceStayOrExit()
        {
            ValidationCount validation = new ValidationCount();

            Console.WriteLine("Do you want to continue playing or no? (yes / no)");
            string userInputChoice = validation.ValidationUserInputChoiseStayOrExit(Console.ReadLine());

            return userInputChoice.Contains("yes") ? true : false ;
        }
    }
}
