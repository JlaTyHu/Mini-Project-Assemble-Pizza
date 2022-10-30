namespace Mini_Project_Assemble_Pizza
{
    using Mini_Project_Assemble_Pizza.Services;
    using Mini_Project_Assemble_Pizza.Services;

    public class Program
    {
        static void Main(string[] args)
        {
            AuthorizationService authorizationService = new ();
            AuthorizationOfUserInput authorizationOfUserInput = new (authorizationService);

            authorizationOfUserInput.EnterUserInfo();

            IngredientsService ingredientsService = new ();
            Leadboard leadboard = new ();
            CreateGame createGame = new (ingredientsService, leadboard);
           
            createGame.EnterUserMenu();
        }
    }
}
