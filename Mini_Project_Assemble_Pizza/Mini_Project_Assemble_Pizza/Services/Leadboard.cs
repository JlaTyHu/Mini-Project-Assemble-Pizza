namespace Mini_Project_Assemble_Pizza.Services
{
    using Mini_Project_Assemble_Pizza.Entities;
    using System.Collections.Generic;
    using Mini_Project_Assemble_Pizza.Interfaces;
    using System;

    internal class Leadboard : ILeadboard
    {
        List<User> infoPersonList = new List<User>();

        public void DisplayList()
        {
            Console.Clear();
            SortingList();

            Console.WriteLine("Name: \t Age: \t Score:");
            foreach (var person in this.infoPersonList)
            {
                Console.WriteLine($"{person.UserName} \t {person.UserAge} \t {person.UserScore}");
            }
        }

        private void SortingList()
        {
            double userScore;
            int age;
            string name;

            foreach (var person1 in this.infoPersonList)
            {
                foreach (var person2 in this.infoPersonList)
                {
                    var resultOfCompare = person1.UserScore.CompareTo(person2.UserScore);

                    if (resultOfCompare == 1)
                    {
                        userScore = person1.UserScore;
                        person1.UserScore = person2.UserScore;
                        person2.UserScore = userScore;

                        age = person1.UserAge;
                        person1.UserAge = person2.UserAge;
                        person2.UserAge = age;

                        name = person1.UserName;
                        person1.UserName = person2.UserName;
                        person2.UserName = name;
                    }
                }
            }
        }

        private void AddIntoLeadboard(User user)
        {
            infoPersonList.Add(user);
        }
    }
}
