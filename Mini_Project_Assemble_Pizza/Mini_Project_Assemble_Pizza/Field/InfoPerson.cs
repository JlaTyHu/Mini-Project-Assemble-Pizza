using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project_Assemble_Pizza.Field
{
    public class InfoPerson
    {
        public InfoPerson() { }
        public InfoPerson(string name, int age, int record)
        {
            Name = name;
            Age = age;
            Record = record;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Record { get; set; }
    }
}
