namespace Mini_Project_Assemble_Pizza.Interfaces
{
    using System.Collections.Generic;

    public interface IIngredientsService
    {
        Dictionary<string, int> RandomIngredients(int numberOfIngredientsToRemember);

        void DisplayIngredientsAsTable();
    }
}
