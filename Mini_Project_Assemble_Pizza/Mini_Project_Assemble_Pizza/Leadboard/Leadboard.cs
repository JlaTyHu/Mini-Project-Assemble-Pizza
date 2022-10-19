namespace Mini_Project_Assemble_Pizza
{
    using System.IO;
    using Mini_Project_Assemble_Pizza.FieldInfoPerson;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public class Leadboard
    {
        List<InfoPerson> infoPersonList = new List<InfoPerson>();
        InfoPerson infoPerson = new InfoPerson();

        private void FillingList()
        {
            string pathLeadboard = @"leadboard.json";

            using (StreamReader leadboardRead = new StreamReader(pathLeadboard))
            {
                string jsonLeadboard = leadboardRead.ReadToEnd();
                infoPersonList = JsonConvert.DeserializeObject<List<InfoPerson>>(jsonLeadboard);
            }
        }
        private void SortingList()
        {
            int person;
            int age;
            string name;

            foreach (var person1 in infoPersonList)
            {
                foreach (var person2 in infoPersonList)
                {
                    var resultOfCompare = person1.Record.CompareTo(person2.Record);

                    if (resultOfCompare == 1)
                    {
                        person = person1.Record;
                        person1.Record = person2.Record;
                        person2.Record = person;

                        age = person1.Age;
                        person1.Age = person2.Age;
                        person2.Age = age;

                        name = person1.Name;
                        person1.Name = person2.Name;
                        person2.Name = name;
                    }
                }
            }
        }

        private void DisplayList()
        {
            foreach (var person in infoPersonList)
            {
                Console.WriteLine($"{person.Name} \t {person.Age} \t {person.Record}");
            }
        }

        private void ChangeLeadboard(int record, string name, int age)
        {
            foreach (var person1 in infoPersonList)
            {
                var resultOfCompareOfNames = person1.Name.CompareTo(name);
                var resultOfCompareOfAge = person1.Age.CompareTo(age);

                if (resultOfCompareOfNames == 0 && resultOfCompareOfAge == 0)
                {
                    person1.Record = record;
                    break;
                }
            }
        }

        private void AddIntoLeadboard()
        {
            infoPersonList.Add(infoPerson);
        }

        public void MainLeadboard()
        {
            FillingList();
            SortingList();
            DisplayList();
        }
    }
}

