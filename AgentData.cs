namespace ClientManagementSystem.Data
{
    internal class AgentData
    {
        private DataConn db = new DataConn();

        public List<AgentData> getAgents()
        {
            List<AgentData> agents = new List<AgentData>();
            using (var conn = db.getConn())
            {
                conn.Open();
                var query = "SELECT * FROM Roles WHERE RoleName LIKE Agent*";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Agent agent = new Agent()
                    {
                        RoleID = reader.GetInt32(reader.GetOrdinal("ID"))
                    };

                    //agents.Add(agent);
                    
                }
            }

            return agents;
        }

        public void DeleteAgent(int id)
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

        public SqlDataReader SearchAgentById(int agentID)
        {
            SqlConnection conn = db.getConn();
            conn.Open();
            string query = "SELECT * FROM Roles WHERE RoleID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@clientId", agentID);
            return cmd.ExecuteReader();
        }
    }
}
