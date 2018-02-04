using Bizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chrupdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Communicator CBL = new Communicator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnUpdateNow_Click(object sender, RoutedEventArgs e)
        {
            if (CBL.UpdateBuild())
            {
                MessageBox.Show("Update complete. App is shut down", "Confirmation", MessageBoxButton.OK);
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Something went wrong. Check internet connection and try again later. App is shut down.", "Error", MessageBoxButton.OK);
                Environment.Exit(0);
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            string license = "Chromium Updater is Copyleft\n\nTHE CAKE-WARE LICENSE(Revision 2):\nGywerd wrote this file.  As long as you retain this notice you can do whatever you want with this stuff, if it don't violate national or international law. If we meet some day, and you think this stuff is worth it, you can buy me a cake or chocolate bar in return.\nSource can be found at https://github.com/gywerd/\n\nDaniel Giversen";
            MessageBox.Show(license, "About Chromium Updater", MessageBoxButton.OK);
        }
    }
}
