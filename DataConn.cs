namespace ClientManagementSystem.Data
{
    public class DataConn
    {
        private readonly string connection = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=CallCenterDB;Integrated Security=True;Encrypt=False";
        
        public SqlConnection getConn()
        {
            return new SqlConnection(connection);
        }
    }
}
