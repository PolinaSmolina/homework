using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    public abstract class Doctor
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public double Experience { get; set; }
        public virtual void Information()
        {
            Console.WriteLine($"\n{Name}\nСпециалист - {Specialization}\nСтаж работы- {Experience}");
        }
        public virtual void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 1)
            {
                patient.Condition = "здоров";
                Console.WriteLine($"\n Пациент {patient.Condition}");
            }
            else
            {
                patient.Condition = "нездоров";
                Console.WriteLine($"\nПациент {patient.Condition}");
            }
        }
    }
    public class Surgeon : Doctor
    {
        public bool Operation { get; set; }

        public override void Information()
        {
            base.Information();
            if (Operation == true)
            {
                Console.WriteLine("Врач провел операцию сегодня");
            }
            else 
            {
                Console.WriteLine("Врач не провел операцию сегодня");
            }
        }
    }

    public class Psych : Doctor
    {
        public override void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 3)
            {
                patient.Condition = "здоров";
                Console.WriteLine($"\nПациент {patient.Condition}");
            }
            else
            {
                patient.Condition = "нездоров";
                Console.WriteLine($"\nПациент {patient.Condition}");
            }
        }
    }

    public class Ophthalmic : Doctor
    {
        public override void Heal(Patient patient)
        {
            if (new Random().Next(0, 11) > 2)
            {
                patient.Condition = "здоров";
                Console.WriteLine($"\nПациент {patient.Condition}");
            }
            else
            {
                patient.Condition = "нездоров";
                Console.WriteLine($"\nПациент {patient.Condition}");
            }
        }
    }
}
