namespace Mini_Project_Assemble_Pizza.FieldInfoPerson
{
    public class InfoPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double UserScore { get; set; }

        public InfoPerson(string name, int age, double userScore)
        {
            this.Name = name;
            this.Age = age;
            this.UserScore = userScore;
        }    
    }
}
