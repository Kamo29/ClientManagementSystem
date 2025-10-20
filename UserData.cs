namespace ClientManagementSystem.Data
{
    internal class UserData
    {
        private DataConn db = new DataConn();

        public void addAgent(string username, string password, string role = "Agent")
        {
            using (SqlConnection conn = db.getConn())
            {
                conn.Open();
                using (SqlCommand cmd =
                       new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)",
                           conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

    }
}
