 public partial class agentDash : Form
 {
     private string name, address, email, accountHistory, phoneNumber;
     private int id;

     private DataGridView dt;
     private DataTable table;

     private void LoadClientData()
     {
         ClientData clientData = new ClientData();

         clientsDataGrid.DataSource = clientData.getClients();
     }
     
     private void bttnSearch_Click(object sender, EventArgs e)
     {
         ClientData client = new ClientData();

         clientsDataGrid.DataSource = client.SearchClientById(id);

     }

     private void agentDash_Load(object sender, EventArgs e)
     {
         ClientData client = new ClientData();
         this.Controls.Add(dt);

         dt.Dock = DockStyle.Fill;

         LoadClientData();
     }

     private void bttnUpdate_Click(object sender, EventArgs e)
     {
         ClientData client = new ClientData();
         client.UpdateClient(id, name, address, phoneNumber, email, accountHistory);

         
     }

     public agentDash()
     {
         InitializeComponent();
         
     }

     private void bttnDelete_Click(object sender, EventArgs e)
     {

     }

     private void bttnAdd_Click(object sender, EventArgs e)
     {
         ClientData client = new ClientData();
         client.AddClient(name, address, phoneNumber, email, accountHistory);
     }
     
 }
