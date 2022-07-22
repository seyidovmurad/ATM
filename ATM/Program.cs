using System;
using System.Threading;

namespace ATM
{
    class MainClass
    {

        static void AddClients(Bank bank)
        {
            BankCard[] card = new BankCard[5];
            card[0] = new BankCard("Kapital Bank", "2345", 20021.75);
            card[1] = new BankCard("Rabite Bank", "3113", 21.43);
            card[2] = new BankCard("Kapital Bank", "0000", 1725);
            card[3] = new BankCard("Pasa Bank", "4321", 1234);
            card[4] = new BankCard("Pasa Bank", "1234", 3485.42);

            Client[] clients = new Client[5];
            clients[0] = new Client("Murad", "Seyidov", 20, 2790, card[0]);
            clients[1] = new Client("John", "Doe", 22, 1450, card[1]);
            clients[2] = new Client("Leyla", "Vusalzade", 47, 343, card[2]);
            clients[3] = new Client("Eli", "Veliyev", 24, 798, card[3]);
            clients[4] = new Client("Elman", "Qasimov", 54, 2240, card[4]);

            for (int i = 0; i < 5; i++)
            {
                try { bank.AddClient(clients[i]); }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.Beep();
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        public static int choose(string[] items, int size)
        {
            bool[] isChoosenLine = new bool[size];
            int index = 0;
            while (true)
            {
                Console.Clear();
                int j = 0;
                foreach (var item in items)
                {
                    if (isChoosenLine[j])
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    j++;
                }
                ConsoleKeyInfo rKey = Console.ReadKey();
                if (rKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                        index = size - 1;
                }
                else if (rKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == size)
                        index = 0;
                }
                else if (rKey.Key == ConsoleKey.Enter)
                {
                    return index;
                }
                for (int i = 0; i < size; i++)
                {
                    isChoosenLine[i] = false;
                }
                isChoosenLine[index] = true;

            }
        }

        public static void Main(string[] args)
        {
            //Creating Bank
            Bank bank = new Bank();
            bank.BankName = "Kapital";
            AddClients(bank);

            //variables
            Client client = new Client();
            int index = -1;
            string pin = "";

            string[] menu = new string[] { "Info", "Draw Money","Exit" };
            string[] money = new string[] { "10 AZN", "20 AZN", "50 AZN", "100 AZN", "Custom","Back" };
            while (true)
            {
                Console.Clear();
                if (index == -1) //enter pin
                {
                    Console.Write("PIN: ");
                    pin = Console.ReadLine();
                    Console.Clear();
                    try { client = bank.GetClientByPIN(pin); }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                        continue;
                    }
                }
                index = choose(menu, 3);
                Console.Clear();
                if(index == 0)//Info
                {
                    Console.WriteLine(client);
                    Console.WriteLine("\nPress Enter to return menu");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter);//this loop will stop when enter pressed
                }
                else if(index == 1)//Draw Money
                {
                    int amountOfMoney = 0;
                    index = choose(money, 6);
                    Console.Clear();
                    switch (index)
                    {
                        case 0: amountOfMoney = 10;break;//10 azn
                        case 1: amountOfMoney = 20;break;//20 azn
                        case 2: amountOfMoney = 50;break;//50 azn
                        case 3: amountOfMoney = 100;break;//100 azn
                        case 4: { //Custom
                                Console.Write("Enter Amount: ");
                                if(int.TryParse(Console.ReadLine(), out int temp))
                                {
                                    amountOfMoney = temp;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Wrong Information");
                                    Thread.Sleep(1000);
                                    continue;
                                }
                            } break;
                        case 5: continue;//Back
                    }
                    try { bank.DrawMoney(pin, amountOfMoney); }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(1000);
                    }
                    
                }
                else if (index == 2) { index = -1; } //Exit
            }
            
        }
    }
}