using System.Windows;

namespace FoundryModManager2024
{
    /// <summary>
    /// Interaction logic for AddConfigurationDialog.xaml
    /// </summary>
    public partial class AddConfigurationDialog : Window
    {
        public AddConfigurationDialog()
        {
            InitializeComponent();
        }

        public string ConfigurationName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
