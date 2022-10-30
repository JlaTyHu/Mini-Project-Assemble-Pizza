namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;

    public class AuthorizationService : IAuthorizationService
    {
        public Entities.User RegisterUser(string name, int age)
        {
            name = name ?? throw new ArgumentNullException(nameof(name));

            if (age <= 0)
            {
                throw new Exception("User age can`t be less than 1 year.");
            }

            return new Entities.User
            {
                UserName = name,
                UserAge = age
            };
        }
    }
}
