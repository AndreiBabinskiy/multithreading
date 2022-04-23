using System;
using System.Collections.Generic;
using System.Threading;

namespace Laba9
{
    class Program
    {
        static public List<string> names = new List<string>
        {
            "Андрей",
            "Матвей",
            "Игорь",
            "Олег",
            "Оксана",
            "Леонид",
            "Николай",
            "Петр",
            "Григорий",
            "Вера"
        };

        static public Queue<Patient> patients = new Queue<Patient>();
        static void Main(string[] args)
        {
            Registry registry = new Registry(patients, names);
            Thread reg = new Thread(new ThreadStart(registry.addPatient));
            reg.Start();

            while(patients.Count < 4) // создадим очередь
            {
                Thread.Sleep(10);
            }

            Doctor doctor1 = new Doctor(patients, "Комсомольский", Doctor.COMPETENCE.Supervisor);
            Thread doc1 = new Thread(new ThreadStart(doctor1.reception));
            Doctor doctor2 = new Doctor(patients, "Дудько", Doctor.COMPETENCE.Intern);
            Thread doc2 = new Thread(new ThreadStart(doctor2.reception));
            Doctor doctor3 = new Doctor(patients, "Лужников", Doctor.COMPETENCE.Medic);
            Thread doc3 = new Thread(new ThreadStart(doctor3.reception));
            doc1.Start();
            doc2.Start();
            doc3.Start();
            Console.ReadKey();
        }

    }
}
