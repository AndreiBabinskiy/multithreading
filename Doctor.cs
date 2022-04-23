using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba9
{
    class Doctor
    {
        public enum COMPETENCE {Intern = 10, Medic = 7, Supervisor = 5 };
        private string name;
        Queue<Patient> patients;

        public Doctor(Queue<Patient> patients, string name, COMPETENCE competence)
        {
            this.patients = patients;
            Name = name;
            Competence = competence;
        }

        private bool checkQueue()
        {
            // Thread.Sleep(1000);
            return patients.Count > 0;
        }

        public void reception()
        {
            while(true)
            {
                lock(patients)
                if(!checkQueue())
                {
                    break;
                }
                Console.WriteLine($"\n{ patients.Dequeue()} на приёме у {this}");
                //Thread.Sleep((int)Competence * 1000);
                switch (Competence)
                {
                    case COMPETENCE.Intern:
                        {
                            Thread.Sleep(10000);
                            break;
                        }
                    case COMPETENCE.Medic:
                        {
                            Thread.Sleep(9000);
                            break;
                        }
                    case COMPETENCE.Supervisor:
                        {
                            Thread.Sleep(15000);
                            break;
                        }
                }
                Console.WriteLine($"{this} приём закончил");
            }
        }

        public string Name { get => name; set => name = value; }
        public COMPETENCE Competence { get; set; }

        public override string ToString()
        {
            return $"{Competence} {Name}";
        }
    }
}
