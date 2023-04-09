using hospital;

class Program
{
    static void Main(string[] args)
    {

        var surgeon = new Surgeon
        {
            Name = "И.И. Иванов",
            Specialization = "Хирург",
            Experience = 17,
        };

        var psych = new Psych
        {
            Name = "П.П. Петров",
            Specialization = "Психиатр",
            Experience = 22,
        };

        var ophtalmic = new Ophthalmic
        {
            Name = "Н.Н. Николаев",
            Specialization = "Офтальмолог",
            Experience = 30,
        };


        var patient1 = new OphthalmicPatient
        {
            Name = "Илья",
            Age = 22,
            Condition = "Болен",
            Visual = 0.7
        };

        var patient2 = new SurgeonPatient
        {
            Name = "Анна",
            Age = 39,
            Condition = "Больна",
            Consent = true
        };

        var patient3 = new PsychPatient
        {
            Name = "Женя",
            Age = 41,
            Condition = "Больна",
            Cognitive = false
        };

        patient1.Information();
        patient1.Reg(ophtalmic);

        ophtalmic.Information();
        ophtalmic.Heal(patient1);

        patient2.Information();
        patient2.Reg(surgeon);

        surgeon.Information();
        surgeon.Heal(patient2);

        patient3.Information();
        patient3.Reg(psych);

        psych.Information();
        psych.Heal(patient3);
    }
}