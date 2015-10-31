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
    public sealed partial class BlankPage1 : Page
    {
        public static List<Result> results = null;

        public BlankPage1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            RootObject r1 = new RootObject();

            gv2.ItemsSource = results;


            tblock.Text = (App.Current as App).NavigateText;

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            AppBarToggleButton favButton = sender as AppBarToggleButton;
            if ((bool)favButton.IsChecked)
            {
                var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
                var con = new SQLiteAsyncConnection(path);
                //await con.InsertAllAsync(results);
                
                await con.QueryAsync<Result>(string.Format("insert into Result (name,name) values('{0}','{1}')", results[0].name, tblock.Text));
            }
            else
            {

            }
        }
    }



}
