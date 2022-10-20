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
        
        private const string PATH_LEADBOARD_LIST = @"leadboard.json";

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

        private void FillingList()
        {
            using (StreamReader leadboardRead = new StreamReader(PATH_LEADBOARD_LIST))
            {
                string jsonLeadboard = leadboardRead.ReadToEnd();
                this.infoPersonList = JsonConvert.DeserializeObject<List<InfoPerson>>(jsonLeadboard);
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
            Console.WriteLine("Name: \t Age: \t Score:");
            foreach (var person in this.infoPersonList)
            {
                Console.WriteLine($"{person.Name} \t {person.Age} \t {person.UserScore}");
            }
        }

        private void AddIntoLeadboard(InfoPerson infoPerson)
        {
            this.infoPersonList.Add(infoPerson);
        }

        private void OwerwriteListFile()
        {
            string owerWriting = System.Text.Json.JsonSerializer.Serialize(this.infoPersonList);
            File.WriteAllText(PATH_LEADBOARD_LIST, owerWriting);
        }

        private void CreateFileForLeadboard()
        {
            using (FileStream fileStream = File.Open(PATH_LEADBOARD_LIST, FileMode.OpenOrCreate))
            {
                using (StreamWriter output = new StreamWriter(fileStream))
                {
                    output.Write("[]");
                }
            }
        }

        private void FileExistenceCheck()
        {
            if (!File.Exists(PATH_LEADBOARD_LIST))
            {
                CreateFileForLeadboard();
            }
        }        
    }
}

