using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace SIMAppFrontendWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //##################################################
        //Search by ID -------------------------------------
        //##################################################
        private void Filtered_entry_Click(object sender, RoutedEventArgs e)
        {           
            string getByIdRequestString = "https://localhost:44328/api/StorageInfoes/";
            int userid = 0;
            try
            {
                if (int.TryParse(tb_user_name.Text, out userid))
                {
                    if (userid != 0)
                    {
                        string jsonString = Get(getByIdRequestString + userid);
                        txtbox.Text = jsonString;
                    }
                    else
                    {
                        MessageBox.Show("User ID can not be zero!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong User ID!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No entry found!!! \n" + ex.Message);
            }

        }
        //End of search by ID ----------------------------


        //##################################################
        //Add new storage info----------------------------
        //##################################################
        private void New_entry_Click(object sender, RoutedEventArgs e)
        {
            string data01 = tb_user_input.Text;
            string url = "https://localhost:44328/api/StorageInfoes";
            string contentType = "text/json";
            string method1 = "POST";
            try
            {
                if (tb_user_input.Text != "")
                {
                    txtbox.Text = Post(url, data01, contentType, method1);
                }
                else
                {
                    MessageBox.Show("No JSON string found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong input format!\n"+ex.Message);                
            }          
            
        }
        //End of add new storage info----------------------------


        //##################################################
        //View all storage info----------------------------
        //##################################################

        private void View_all_Click_1Async(object sender, RoutedEventArgs e)
        {           
            try
            {

                string jString = Get("https://localhost:44328/api/StorageInfoes");
                txtbox.Text = jString;
                //storageinfo empObj = new storageinfo();
                //empObj = JsonConvert.DeserializeObject<storageinfo>(jsonString);
                //dataGridSource.Add(empObj);
                //dgrid.ItemsSource = dataGridSource;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        //##################################################
        //End of view all storage info----------------------------
        //##################################################

        //##################################################
        //Delete storage info----------------------------
        //##################################################

        private void del_entry_Click(object sender, RoutedEventArgs e)
        {
            string data01 = tb_del_entry_id.Text;
            string url = "https://localhost:44328/api/StorageInfoes/";
            string contentType = "text/json";
            string method1 = "DELETE";
            try
            {
                int userid = 0;
                if (int.TryParse(tb_del_entry_id.Text, out userid))                  
                {
                    url = url + userid;
                    txtbox.Text = Post(url, data01, contentType, method1);
                    MessageBox.Show("Successfully deleted storage data entry!");
                }
                else
                {
                    MessageBox.Show("Wrong ID Format!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not delete entry!\n" + ex.Message);
            }
        }

        //##################################################
        //End of delete storage info----------------------------
        //##################################################

        //##################################################
        //Edit storage info----------------------------
        //##################################################
        private void Edit_entry_Click(object sender, RoutedEventArgs e)
        {
            string data01 = tb_user_input.Text;
            string url = "https://localhost:44328/api/StorageInfoes/";
            string contentType = "text/json";
            string method1 = "PUT";
            try
            {
                int userid = 0;
                if (int.TryParse(tb_edit_entry_id.Text, out userid))
                {
                    url = url + userid;
                    Post(url, data01, contentType, method1);
                    MessageBox.Show("Successfully updated storage data entry!");
                    string jsonString = Get(url);
                    txtbox.Text = jsonString;
                }
                else
                {
                    MessageBox.Show("Wrong ID Format!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not edit entry!\n" + ex.Message);
            }
        }
        //##################################################
        //End of edit storage info----------------------------
        //##################################################


        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
        public string Post(string uri, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;
            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public async Task<string> PostAsync(string uri, string data, string contentType, string method = "POST")
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = method;
            using (Stream requestBody = request.GetRequestStream())
            {
                await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
             
    }
}

