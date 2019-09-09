using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace OlympiadProject.Windows
{
    /// <summary>
    /// Interaction logic for SecretWindow.xaml
    /// </summary>
    public partial class SecretWindow : MetroWindow
    {
        public SecretWindow()
        {
            InitializeComponent();
            PasswordBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordBox.Password == "GODDAM")
            {
                MessageBox.Show("Welcome to the world of new opportunities.");
                AdminWindow window = new AdminWindow();
                this.Hide();
                window.ShowDialog();
                this.Close();
            }
        }

        private void PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            Button_Click(null, null);
        }
    }
}
