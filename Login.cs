public partial class Login : Form
{
    private DataConn db = new DataConn();
    public Login()
    {
        InitializeComponent();
    }

    private void bttnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string role = "";
        int userId = 0;

        if (autenticate(username, password, role))
        {
            // Log the login action
            string ipAddress = GetClientIPAddress();
            ActionLogger logger = new ActionLogger();
            logger.LogAction(userId, "User logged in", ipAddress);
        }

        if (autenticate(username, password,  role))
        {
            if (role.Equals(radioAdmin))
            {
                new adminDash().Show();
                this.Hide();
            }

            else
            {
                new agentDash().Show();
                this.Hide();
            }
        }
    }

    private bool autenticate(string username, string pass, string role)
    {
        using (SqlConnection conn = db.getConn())
        {
            conn.Open();
            string query = "SELECT PasswordHash, Role FROM Users WHERE Username = @username";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string hashedPassword = reader["PasswordHash"].ToString(); role = reader["Role"].ToString();
                
                if (VerifyPassword( pass, storedHash: hashedPassword))
                {
                    // Login successful
                    MessageBox.Show("Login successful");
                    // Redirect to the appropriate page based on the user's role
                    if (role == "Admin")
                    {
                        adminDash aD = new adminDash();
                        aD.Show();
                        this.Hide();
                    }
                    else if (role == "User")
                    {
                        agentDash agD = new agentDash();
                        agD.Show();
                        this.Hide();
                    }
                }
                else
                {
                    // Login failed
                    MessageBox.Show("Login failed. Incorrect password.");
                }
            }
            else
            {
                // Login failed
                MessageBox.Show("Login failed. User not found.");
            }
        }

        return true;
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        // For simplicity, assuming the storedHash is created using SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
            return hashString == storedHash;
        }
    }

    private string GetClientIPAddress()
    {
        // Dummy implementation for Windows Forms.
        return "127.0.0.1"; // Replace with logic to fetch the actual client IP if applicable
    }

    public class ActionLogger
    {
        private string connectionString = "YourConnectionStringHere";

        public void LogAction(int userId, string action, string ipAddress = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                    INSERT INTO ActionLogs (UserID, Action, IPAddress)
                    VALUES (@UserID, @Action, @IPAddress)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@Action", action);
                        command.Parameters.AddWithValue("@IPAddress", ipAddress ?? DB);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging action: {ex.Message}");
                // You might also log this exception to a file or monitoring tool
            }
        }
    }


private void Login_Load(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void txtUsername_TextChanged(object sender, EventArgs e)
    {

    }
}
