namespace Mini_Project_Assemble_Pizza
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.Services;

    public class Program
    {
        static void Main(string[] args)
        {
            CreateGame createGame = new CreateGame(new Dictionary<string, int>());
        }
    }
}
