using System;
namespace ATM
{
    public class Bank
    {
        public string BankName { get; set; }

        private Client[] clients;
        public int clientsCount { get; private set; } = 0;

        public void AddClient(Client _client)
        {
            for (int i = 0; i < clientsCount; i++) 
            {
                if((clients[i].GetCard().PIN == _client.GetCard().PIN) || (clients[i].GetCard().PAN == _client.GetCard().PAN))
                {
                    throw new Exception("Clients can not have same PIN or PAN");
                }
            }
            Array.Resize<Client>(ref clients, ++clientsCount);
            clients[clientsCount - 1] = _client;
        }

        public Client GetClientByPIN(string pin)
        {
            foreach (var client in clients)
            {
                if (client.GetCard().PIN == pin)
                {
                    return client;
                }
            }
            throw new Exception("Wrong PIN");
        }

        public void DrawMoney(string pin, int amount)
        {
            if (GetClientByPIN(pin).GetCard().Balance < amount)
                throw new Exception("You don't have enough money in balance");
            else
                GetClientByPIN(pin).GetCard().Balance -= amount;
        }
        public Bank(){}
    }
}
