namespace Mini_Project_Assemble_Pizza
{
    using System;
    using Mini_Project_Assemble_Pizza.GameLogic;

    public class Program
    {
        static void Main(string[] args)
        {
            GameLogic.GameLogic lobby = new GameLogic.GameLogic();
            lobby.ChoiceLevel();
        }      
    }
}
