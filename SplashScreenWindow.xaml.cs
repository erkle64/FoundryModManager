using System.Windows;
using System.Windows.Threading;

namespace FoundryModManager2024
{
    /// <summary>
    /// Interaction logic for SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Splash_Loaded);
        }

        void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            Task<Action> task = Task.Run(() => App.Current!.ApplicationInitialize(this));
            task.ContinueWith(t =>
            {
                t.Result?.Invoke();

                Close();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
