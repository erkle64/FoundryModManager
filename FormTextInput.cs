
namespace FoundryModManager
{
    public partial class FormTextInput : Form
    {
        public FormTextInput()
        {
            InitializeComponent();
        }

        private void FormTextInput_Load(object sender, EventArgs e)
        {
            textName.Focus();
            textName.Select();
        }
    }
}
