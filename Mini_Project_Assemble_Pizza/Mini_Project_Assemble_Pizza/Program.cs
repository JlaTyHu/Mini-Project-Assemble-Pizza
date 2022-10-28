namespace Mini_Project_Assemble_Pizza
{
    using System;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.Services;

    public class Program
    {
        static void Main(string[] args)
        {
            AuthorizationService authorizationService = new AuthorizationService();
            AuthorizationOfUserInput authorizationOfUserInput = new AuthorizationOfUserInput(authorizationService);

            authorizationOfUserInput.EnterUserInfo();

            IngredientsService ingredientsService = new IngredientsService();
            CreateGame createGame = new CreateGame(ingredientsService);

            createGame.EnterUserMenu();
        }
    }
}
