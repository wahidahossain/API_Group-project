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

namespace SIMAppFrontendWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string username_wahida;
        string password_password;
        public Login()
        {
            InitializeComponent();
            getParameter();
        }
        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            if ((tb_username.Text==username_wahida) && (password_password== tb_password.Password))
            {
                MainWindow nMW = new MainWindow();
                this.Hide();
                nMW.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!!!");
            }
        }
        private async void getParameter()
        {
            try
            {
                AwsParameterStoreClient client = new AwsParameterStoreClient(Amazon.RegionEndpoint.CACentral1);
                username_wahida = await client.GetValueAsync("username_wahida");
                password_password = await client.GetValueAsync("password_password");
            }
            catch (Exception ex)
            {
                MessageBox.Show("unable to grab parameters from parameter store. " + ex.Message);
            }

        }

    }
}
