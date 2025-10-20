namespace ClientManagementSystem.Logic
{
    internal class Clients
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AccountHistory { get; set; }

        public Clients() 
        { }

        public Clients(int clientID, string name, string address, string phoneNumber, string email, string accountHistory)
        {
            ClientID = clientID;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            AccountHistory = accountHistory;
        }
    }
}
