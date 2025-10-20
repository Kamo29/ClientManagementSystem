namespace ClientManagementSystem.Logic
{
    internal class Users
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public Users() { }

        public Users(int userID, string username, string passwordHash, string role)
        {
            UserID = userID;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
