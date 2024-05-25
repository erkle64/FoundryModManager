using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoundryModManager
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private delegate void CloseDelegate();

        private static SplashScreen? splashScreen;

        static public void ShowSplashScreen()
        {
            if (splashScreen != null) return;
            splashScreen = new SplashScreen();
            Thread thread = new Thread(new ThreadStart(ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            if (splashScreen != null) Application.Run(splashScreen);
        }

        static public void CloseSplashScreen()
        {
            splashScreen?.Invoke(new CloseDelegate(CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            if (splashScreen != null)
            {
                splashScreen.Close();
                splashScreen = null;
            };
        }
    }
}
