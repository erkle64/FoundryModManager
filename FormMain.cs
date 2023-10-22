namespace FoundryModManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listConfigurations.BeginUpdate();
            listConfigurations.Items.Clear();
            listConfigurations.Items.Add("Vanilla");
            listConfigurations.Items.Add("Default");
            listConfigurations.EndUpdate();
        }
    }
}
