using SQLite;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace task27_10_15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }


        protected override  void OnNavigatedTo(NavigationEventArgs e)
        {
            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
        }
        private async void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).NavigateText = unametxt.Text;

            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
            person p1 = new person();
            List<person> allpersons = new List<person>();
        
           allpersons = await con.QueryAsync<person>("select name,password from person where name=" + "\'" + unametxt.Text + "\'" + "and password=" + "\'" + pwdtxt.Password + "\'");
           if (allpersons.Count == 1)
           {

               p1 = allpersons[0];
               Frame.Navigate(typeof(MainPage));
               
           }
        }

        private void Rbtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }


    }
}
