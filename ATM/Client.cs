using System;
namespace ATM
{
    public class Client
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        private int age;
        public int Age
        {
            get => age;
            set
            {
                if (value < 18) throw new Exception("Age must be greater than 18");
                else age = value;
            }
        }

        private int salary;
        public int Salary
        {
            get => salary;
            set
            {
                if (value < 250) throw new Exception("Salary is too low");
                else salary = value;
            }
        }

        private BankCard card;

        public BankCard GetCard() => card;

        public void AddCard(BankCard card)
        {
            card.Fullname = Name + " " + Surname;
            this.card = card;
        }

        public Client()
        {
            Name = "unknown";
            Surname = "unknown";
            Age = 18;
            salary = 250;
        }

        public Client(string name, string surname, int age, int salary, BankCard card)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            card.Fullname = name + " " + surname;
            this.card = card;
        }

        public override string ToString()
        {
            return $"User:\nName: {Name}\nSurname: {Surname}\nAge: {Age}\nSalary: { Salary}\n\nCard:\n{card}";
        }
    }
}
