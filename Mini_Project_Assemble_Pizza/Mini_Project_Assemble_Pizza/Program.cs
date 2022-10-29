namespace Mini_Project_Assemble_Pizza
{
    using Mini_Project_Assemble_Pizza.Services;
    using Mini_Project_Assemble_Pizza.Services;
    public class Program
    {
        static void Main(string[] args)
        {
            AuthorizationService authorizationService = new AuthorizationService();
            AuthorizationOfUserInput authorizationOfUserInput = new AuthorizationOfUserInput(authorizationService);

            authorizationOfUserInput.EnterUserInfo();

            IngredientsService ingredientsService = new IngredientsService();
            Leadboard leadboard = new Leadboard();
            CreateGame createGame = new CreateGame(ingredientsService, leadboard);
           
            createGame.EnterUserMenu();
        }
    }
}
