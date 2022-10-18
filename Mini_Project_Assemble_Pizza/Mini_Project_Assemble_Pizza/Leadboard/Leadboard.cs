using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Mini_Project_Assemble_Pizza.FieldInfoPerson;
using Newtonsoft.Json;

namespace Mini_Project_Assemble_Pizza.Leadboard
{
    class Leadboard
    {
         List<InfoPerson> infoPerson = new List<InfoPerson>();

        void FillingList()
        {
            string pathLeadboard = @"leadboard.json";

            using (StreamReader leadboardRead = new StreamReader(pathLeadboard))
            {
                string jsonLeadboard = leadboardRead.ReadToEnd();
                infoPerson = JsonConvert.DeserializeObject<List<InfoPerson>>(jsonLeadboard);
            }
        }

        void SortingList()
        {
            infoPerson = infoPerson.OrderByDescending(x => x.Record).ToList();
        }

        void DisplayList()
        {
            foreach (var person in infoPerson)
            {
                Console.WriteLine($"{person.Name} \t {person.Age} \t {person.Record}");
            }
        }
    }
}
