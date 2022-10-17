namespace Mini_Project_Assemble_Pizza.ValidationService
{
    using System;
    using System.Collections.Generic;

    public class ValidationCount
    {
        public int ValidationNumberToRemember(int count)
        {
            return count = count <= 5 ? count : 5;
        }

        public int ValidationUserChoiceLvl(int userChoiceLvl)
        {
            return userChoiceLvl = (userChoiceLvl < 0 || userChoiceLvl > 13) ? 
                throw new Exception("Level cannot be lower than 1 and higher than 12!"): userChoiceLvl;
        }

        public double ValidationUserScore(double score, int lvl, int attemp)
        {
            return score += lvl == 1 ? (10 / attemp) : ((10 + lvl) / attemp);
        }

        public string ValidationUserInputIngredients(string userIngredient)
        {
            return userIngredient = string.IsNullOrEmpty(userIngredient) || userIngredient.Contains(" ") ?
                throw new Exception("The name cannot be empty or space!") : userIngredient;
        }        

        public int ValidationUserInputNumberOfPiecesForIngredients(int userPieces)
        {
            return userPieces = userPieces > 5 ? throw new Exception("The name cannot be empty or space!") : userPieces;
        }
    }
}
