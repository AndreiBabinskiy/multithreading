using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    class Patient
    {
        private string name;
        private int age;

        public Patient(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { 
            
            get => age;

            set
            {
                if(value >= 0 && value <= 100)
                {
                    age = value;
                }
                else
                {
                    new Exception("Не соответсвует возраст");
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Age} лет";
        }
    }
}
