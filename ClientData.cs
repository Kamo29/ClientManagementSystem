namespace ClientManagementSystem.Data
{
    internal class ClientData
    {
        private DataConn db = new DataConn();

        public List <ClientData> getClients()
        {
            List<ClientData> clients = new List<ClientData>();
            using (var conn = db.getConn())
            {
                conn.Open();
                var query = "SELECT * FROM Clients";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Clients client = new Clients
                    {
                        ClientID = reader.GetInt32(reader.GetOrdinal("ID")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Address = reader.GetString(reader.GetOrdinal("Address")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        AccountHistory = reader.GetString(reader.GetOrdinal("AccountHistory")),
                        PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))
                    };

                    //clients.Add(client);
                }
            }

            return clients;
        }
        public void AddClient(string name, string address, string phoneNumber, string email, string accountHistory)
        {
            using (SqlConnection conn = db.getConn())
            {
                conn.Open();
                string query = "INSERT INTO Clients (Name, Address, PhoneNumber, Email, AccountHistory) " +
                               "VALUES (@name, @address, @phoneNumber, @Email, @accountHistory)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@accountHistory", accountHistory);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void UpdateClient(int id, string name, string address, string phoneNumber, string email,
            string accountHistory)
        {
            using (SqlConnection conn = db.getConn())
            {
                conn.Open();
                string query =
                    "UPDATE Clients SET Name = @name, Address = @address, PhoneNumber = @phoneNumber, Email = @Email, AccountHistory = @accountHistory WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@accountHistory", accountHistory);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void DeleteClient(int id)
        {
            using (SqlConnection conn = db.getConn())
            {
                conn.Open();
                string query = "DELETE FROM Clients WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public SqlDataReader SearchClientById(int clientId)
        {
            SqlConnection conn = db.getConn();
            conn.Open();
            string query = "SELECT * FROM Clients WHERE ClientID = @clientId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clientId", clientId);
            return cmd.ExecuteReader();
        }
    }
}
