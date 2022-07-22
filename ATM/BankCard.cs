using System;


namespace ATM
{
    public class BankCard
    {

        public string BankName { get; set; }

        public string Fullname { get; set; }


        public string PAN { get; private set; }

        private string pin;

        public string PIN
        {
            get => pin;
            set
            {
                if (!int.TryParse(value, out int result))
                    throw new Exception("Pin should be string of number");
                if (value.Length != 4)
                    throw new Exception("Length of PIN should be 4");
                pin = value;
            }
        }

        public string CVC { get; private set; }

        public double Balance { get; set; }

        public BankCard(string bankName, string fullname, string pin, double balance)
        {
            BankName = bankName;
            Fullname = fullname;
            PIN = pin;
            Balance = balance;
            PAN = RandomGenerator.GetRandNumOfString(16);
            CVC = RandomGenerator.GetRandNumOfString(3);
        }

        public BankCard(string bankName, string pin, double balance)
        {
            BankName = bankName;
            Fullname = "unknown";
            PIN = pin;
            Balance = balance;
            PAN = RandomGenerator.GetRandNumOfString(16);
            CVC = RandomGenerator.GetRandNumOfString(3);
        }

        public BankCard()
        {
            BankName = "unknown";
            Fullname = "unknown";
            PIN = "0000";
            Balance = 0;
            PAN = RandomGenerator.GetRandNumOfString(16);
            CVC = RandomGenerator.GetRandNumOfString(3);
        }

        public override string ToString()
        {
            char[] temp = new char[20];
            int j = 0;
            for (int i = 0; i < 16; i++)
            {
                if (i % 4 == 0 && i !=0)
                {
                    temp[j] = ' ';
                    j++;
                }
                if (i < 4 || i > 11)
                {
                    temp[j] = PAN[i];
                    j++;
                }
                else
                {
                    temp[j] = '*';
                    j++;
                }
                
            }
            return $"Bank: {BankName}\nClient: {Fullname.ToUpper()}\nPAN: {new string(temp)}\nBalance: {Balance}";
        }
    }
}
