namespace Mini_Project_Assemble_Pizza.Interfaces
{
    public interface IAuthorizationService
    {
        Entities.User RegisterUser(string name, int age);
    }
}
