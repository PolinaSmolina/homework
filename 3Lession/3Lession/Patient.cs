using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital
{
    public abstract class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Condition { get; set; }
        public virtual void Information()
        {
            Console.WriteLine($"\n {Name}\nВозраст - {Age}\nСтатус - {Condition}");
        }
        public virtual void Reg(Doctor doctor)
        {
            Console.WriteLine($"\n{Name} записан на прием к врачу - {doctor.Specialization} {doctor.Name}");
        }
    }
    public class SurgeonPatient : Patient
    {
        public bool Consent { get; set; }

        public override void Information()
        {
            base.Information();
            if (Consent == true)
            {
                Console.WriteLine("Есть согласие на оперативное вмешательство");
            }
            else
            {
                Console.WriteLine("Нет согласия на оперативное вмешательство");
            }
        }
    }

    public class OphthalmicPatient : Patient
    {
        public double Visual { get; set; }

        public override void Information()
        {
            base.Information();
            Console.WriteLine($"Острота зрения - {Visual}");
        }
    }

    public class PsychPatient : Patient
    {
        public bool Cognitive { get; set; }

        public override void Information()
        {
            base.Information();
            if (Cognitive == true)
            {
                Console.WriteLine("У пациента нет когнитивных нарушений");

            }
            else
            {
                Console.WriteLine("Пациент с когнитивными нарушениями");
            }
        }
    }
}