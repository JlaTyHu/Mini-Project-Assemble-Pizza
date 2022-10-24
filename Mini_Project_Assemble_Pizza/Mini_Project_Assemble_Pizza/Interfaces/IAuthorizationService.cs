namespace Mini_Project_Assemble_Pizza.Interfaces
{
    using Entity = Mini_Project_Assemble_Pizza.Entities;

    public interface IAuthorizationService
    {
        Entity.User RegisterUser(string name, int age);
    }
}
