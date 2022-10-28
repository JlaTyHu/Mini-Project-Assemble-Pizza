namespace Mini_Project_Assemble_Pizza.Interfaces
{
    using Entity = Entities;

    public interface IAuthorizationService
    {
        Entity.User RegisterUser(string name, int age);
    }
}
