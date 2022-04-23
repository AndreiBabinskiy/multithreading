using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laba9
{
    class Registry
    {
        Random random = new Random();

        Queue<Patient> patients;
        List<string> names;

        public Registry(Queue<Patient> patients, List<string> names)
        {
            this.patients = patients;
            this.names = names;
        }

        public void addPatient()
        {
            while(patients.Count <= 10)
            {
                Patient patient = new Patient(names[random.Next(names.Count)], random.Next(100));
                patients.Enqueue(patient);
                Console.WriteLine($" => {patient} встал в очередь. ({patients.Count})");
                Thread.Sleep(2000);
            }
            Console.WriteLine("Регистратура закрыта");
        }
    }
}
