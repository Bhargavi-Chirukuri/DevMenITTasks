using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace task27_10_15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void logbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
            con.CreateTableAsync<person>();
        }
        private async void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            string gen = "";
            if (rb1.IsChecked == true)
            {
                gen = "Female";
            }
            else if (rb2.IsChecked == true)
            {
                gen = "Male";
            }
            else
            {
                var m = new MessageDialog("select gender").ShowAsync();
                return;
            }
            if (mobiletxt.Text == "" & mobiletxt.Text.Length != 10)
            {
                var mm = new MessageDialog("Please enter a valid phone number").ShowAsync();
                return;
            }
            if (nametxt.Text == "")
            {
                var nm = new MessageDialog("Name field should not be empty").ShowAsync();
                return;
            }
            if (emailtxt.Text == "")
            {
                var em = new MessageDialog("Email field should not be empty").ShowAsync();
                return;
            }

            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
            person p1 = new person();
            p1.name = nametxt.Text;
            p1.password = pwdtxt.Password;
            p1.email = emailtxt.Text;
            p1.country = countrytxt.SelectedItem.ToString();
            p1.gender = gen;
            p1.phone = mobiletxt.Text;
            await con.InsertAsync(p1);
            var m1 = new MessageDialog("data inserted").ShowAsync();


        }
    }
}
