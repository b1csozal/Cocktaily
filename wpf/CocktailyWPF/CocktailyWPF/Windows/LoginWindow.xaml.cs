using CocktailyWPF.Extensions;
using CocktailyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CocktailyWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void HandleLogin(object sender, RoutedEventArgs e)
        {
            string username = inputUsername.Text;
            string password = inputPassword.Text;
            
            

            var json = "{ \"username\": \"" + username + "\", \"password\": \"" + password + "\"}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{ApiConfig.BaseUrl}/auth/login", content);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                AccessTokenModel responseJson = JsonSerializer.Deserialize<AccessTokenModel>(responseBody);
                SessionStorage.Set("accessToken", responseJson.AccessToken);

                this.DialogResult = true; // Optional: if shown as dialog
                this.Close();
            } 
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Hibás bejelentkezési adatok");
            }

            
        }
    }
}
