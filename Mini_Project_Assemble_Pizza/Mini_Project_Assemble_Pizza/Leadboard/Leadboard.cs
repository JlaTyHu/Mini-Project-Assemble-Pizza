namespace Mini_Project_Assemble_Pizza.Learboard
{
    using System.IO;
    using Mini_Project_Assemble_Pizza.FieldInfoPerson;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public class LeadboardGame
    {
        List<InfoPerson> infoPersonList = new List<InfoPerson>();
        
        const string pathLeadboard = @"leadboard.json";
        private void FillingList()
        {
            using (StreamReader leadboardRead = new StreamReader(pathLeadboard))
            {
                string jsonLeadboard = leadboardRead.ReadToEnd();
                infoPersonList = JsonConvert.DeserializeObject<List<InfoPerson>>(jsonLeadboard);
            }
        }

        private void SortingList()
        {
            double userScore;
            int age;
            string name;

            foreach (var person1 in infoPersonList)
            {
                foreach (var person2 in infoPersonList)
                {
                    var resultOfCompare = person1.UserScore.CompareTo(person2.UserScore);

                    if (resultOfCompare == 1)
                    {
                        userScore = person1.UserScore;
                        person1.UserScore = person2.UserScore;
                        person2.UserScore = userScore;

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
                Console.WriteLine($"{person.Name} \t {person.Age} \t {person.UserScore}");
            }
        }
        private void AddIntoLeadboard(InfoPerson infoPerson)
        {
            infoPersonList.Add(infoPerson);
        }

        private void OwerwriteListFile()
        {
            string owerWriting = System.Text.Json.JsonSerializer.Serialize(infoPersonList);
            File.WriteAllText(pathLeadboard, owerWriting);
        }

        private void CreateFileForLeadboard()
        {
            using (FileStream fileStream = File.Open(pathLeadboard, FileMode.OpenOrCreate))
            {
                using (StreamWriter output = new StreamWriter(fileStream))
                {
                    output.Write("[]");
                }
            }
        }

        private void FileExistenceCheck()
        {
            if (!File.Exists(pathLeadboard))
            {
                CreateFileForLeadboard();
            }
        }

        public void MainLeadboard()
        {
            FileExistenceCheck();
            FillingList();
            SortingList();
            DisplayList();
        }

        public void SavingleadboardAfterGame(InfoPerson infoPerson)
        {
            FileExistenceCheck();
            FillingList();
            AddIntoLeadboard(infoPerson);
            OwerwriteListFile();
        }
    }
}

