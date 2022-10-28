namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;

    public class AuthorizationOfUserInput
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationOfUserInput(IAuthorizationService authorizationService)
        {
            this._authorizationService = authorizationService;
        }

        public void EnterUserInfo()
        {
            Console.WriteLine("Please enter name and age: ");
            string userName = Console.ReadLine();
            int age = Convert.ToInt32(Console.ReadLine());

            _authorizationService.RegisterUser(userName, age);
        }
    }
}
