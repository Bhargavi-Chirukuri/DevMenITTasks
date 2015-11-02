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
        //chey  ther>> what?? late avtadi fast ga chey ha ippudu axis bank fav kadahaa malla open chey chudam

        public BlankPage1()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            RootObject r1 = new RootObject();

            gv2.ItemsSource = results;


            tblock.Text = (App.Current as App).NavigateText;
            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
            List<Favourite> favs = await con.QueryAsync<Favourite>(string.Format("select id from Favourite where userName = '{0}' and placeName = '{1}'", tblock.Text, results[0].name)) as List<Favourite>;
            if (favs.Count > 0 && favs.First().id > 0)
            {
                aptb.IsChecked = true;
            }


            
            //con.CreateTableAsync<Favourite>();

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AppBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {

            AppBarToggleButton favButton = sender as AppBarToggleButton;
            //if ((bool)favButton.IsChecked)
            //{
            //    var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            //    var con = new SQLiteAsyncConnection(path);
            //    //await con.InsertAllAsync(results);

            //    await con.QueryAsync<Result>(string.Format("insert into Result (name,name) values('{0}','{1}')", results[0].name, tblock.Text));
            //}
            //else
            //{

            //}
            if ((bool)favButton.IsChecked)
            {
                var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
                var con = new SQLiteAsyncConnection(path);
                con.QueryAsync<Favourite>(string.Format("insert into Favourite (placeName,userName) values('{0}','{1}')", results[0].name, tblock.Text));
            }
            else if (!(bool)favButton.IsChecked)
            {
                var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
                var con = new SQLiteAsyncConnection(path);
                con.QueryAsync<Favourite>(string.Format("delete from Favourite where placeName = '{0}' and username='{1}'", results[0].name, tblock.Text));
            }


        }

        private async void b1_Click(object sender, RoutedEventArgs e)
        {
            var path = ApplicationData.Current.LocalFolder.Path + "/myDb1.DB";
            var con = new SQLiteAsyncConnection(path);
            Favourite myfav = new Favourite();
            List<Favourite> allfavs = new List<Favourite>();
            allfavs=await con.QueryAsync<Favourite>("select placeName from Favourite ");
            string r = "";
            foreach(Favourite f in allfavs)
            {
                r += f.placeName;
            }
            restb.Text = r;
            
            //Frame.Navigate(typeof(Favouriteslist));
        }


    }



}
