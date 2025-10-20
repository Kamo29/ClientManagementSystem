 namespace ClientManagementSystem.Presentation
{
    public partial class adminDash : Form
    {
        private int id;
        private string username, password;

        private DataGridView dt;

        public adminDash()
        {
            InitializeComponent();
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            AgentData agentData = new AgentData();
            agentData.DeleteAgent(id);

            ClientData clients = new ClientData();
            clients.DeleteClient(id);
        }

        private void LoadAgentData()
        {
            AgentData agentData = new AgentData();
            //DataTable agentsTable = agentData.getAgents();

            dt.DataSource = agentData.getAgents();
        }

        private void adminDash_Load(object sender, EventArgs e)
        {
            dt = new DataGridView();
            this.Controls.Add(dt);

            dt.Dock = DockStyle.Fill;

            LoadAgentData();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            AgentData agentData = new AgentData();
            agentData.SearchAgentById(id);

            dt.DataSource = agentData;
        }

        private void agentsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bttnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            UserData ud = new UserData();
            ud.addAgent(username, password);
        }
    }
}
