using System;
using System.Collections.Generic;
using Mini_Project_Assemble_Pizza.Entities;
namespace Mini_Project_Assemble_Pizza.Services
{
    internal class Leadboard
    {
        List<User> infoPersonList = new List<User>();

        public void DisplayList()
        {
            Console.Clear();

            Console.WriteLine("Name: \t Age: \t Score:");
            foreach (var person in this.infoPersonList)
            {
                Console.WriteLine($"{person.UserName} \t {person.UserAge} \t {person.UserScore}");
            }
        }

        public void SortingList()
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

        public void AddIntoLeadboard(User user)
        {
            this.infoPersonList.Add(user);
        }

        public void ChangeLeadboard(User user)
        {
            foreach (var person1 in infoPersonList)
            {
                var resultOfCompareOfNames = person1.UserName.CompareTo(user.UserName);
                var resultOfCompareOfAge = person1.UserAge.CompareTo(user.UserAge);

                if (resultOfCompareOfNames == 0 && resultOfCompareOfAge == 0)
                {
                    person1.UserScore = user.UserScore;
                    break;
                }
            }
        }

    }
}
