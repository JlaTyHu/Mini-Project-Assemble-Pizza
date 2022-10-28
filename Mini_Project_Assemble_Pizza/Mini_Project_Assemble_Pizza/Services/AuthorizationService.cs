namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Interfaces;

    using System;
    using Entity = Mini_Project_Assemble_Pizza.Entities;

    public class AuthorizationService : IAuthorizationService
    {
        public Entity.User RegisterUser(string name, int age)
        {
            name = name ?? throw new ArgumentNullException(nameof(name));

            if (age <= 0)
            {
                throw new Exception("User age can`t be less than 1 year.");
            }

            return new Entity.User
            {
                UserName = name,
                UserAge = age
            };
        }
    }
}
