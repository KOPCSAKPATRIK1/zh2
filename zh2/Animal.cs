using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh2
{
    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public Animal(string name, string type, int age)
        {
            Name = name;
            Type = type;
            Age = age;
        }
    }
}
