namespace Mini_Project_Assemble_Pizza.ValidationService
{
    using System;

    public class ValidationCount
    {
        public int ValidationNumberToRemember(int count)
        {
            int result = count <= 5 ? count : 5;
            return result;
        }

        public int ValidationUserChoiceLvl(int userChoiceLvl)
        {
            if (userChoiceLvl < 0 || userChoiceLvl > 13)
            {
                throw new Exception("Level cannot be lower than 1 and higher than 12!");
            }

            return userChoiceLvl;
        }

        public double ValidationUserScore(double score, int lvl, int attemp)
        {
            return score += lvl == 1 ? (10 / attemp) : ((10 + lvl) / attemp);
        }
    }
}
