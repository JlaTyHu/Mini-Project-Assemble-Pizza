namespace Mini_Project_Assemble_Pizza
{
    using Mini_Project_Assemble_Pizza.CollectionIngredients;
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            OperationOfCollection operationOfCollection = new OperationOfCollection();
            operationOfCollection.DisplayIngredients();

        }      
    }
}
