using System.Windows;
using System.Windows.Threading;

namespace FoundryModManager2024
{
    /// <summary>
    /// Interaction logic for ApplyWindow.xaml
    /// </summary>
    public partial class ApplyWindow : Window
    {
        private readonly Func<IProgress<string>, Action> _taskToRun;

        public ApplyWindow(Func<IProgress<string>, Action> taskToRun)
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(WindowLoaded);
            _taskToRun = taskToRun;
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var progress = new Progress<string>(status =>
            {
                StatusLabel.Text = status;
            });

            Task<Action> task = Task.Run(() => _taskToRun(progress));
            task.ContinueWith(t =>
            {
                t.Result?.Invoke();

                Close();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
