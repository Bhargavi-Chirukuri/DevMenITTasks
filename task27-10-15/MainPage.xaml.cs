using Bing.Maps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
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
//using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace task27_10_15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            loctypes = new List<string>() { "hospital", "bus_station", "food", "atm", "bank", "restaurant" };
            
            //PushpinViewModel pvm = new PushpinViewModel();
            //pvm.PushpinList = new ObservableCollection<PushpinClass>();

            //pvm.PushpinList.Add(new PushpinClass() { Latitude = l2.lat, Longitude =l2.lng });
            //DataContext = pvm;
        }
        

        Pushpin pp = new Pushpin();
        Location1 l2 = new Location1();
        public List<string> loctypes;

        Geolocator gl = new Geolocator();
        Geoposition gp;

        Location l1;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            comboplaces.ItemsSource = loctypes;

            gp = await gl.GetGeopositionAsync();
            l1 = new Location();
            l1.Latitude = gp.Coordinate.Point.Position.Latitude;
            l1.Longitude = gp.Coordinate.Point.Position.Longitude;
            map1.SetView(l1, 15);
           
            MapLayer.SetPosition(pp1, l1);
            //if(session.Values["page"] !=null)
            //{
            //    Frame.Navigate(typeof(MainPage));
            //}

            //localsettings.Values["sessionsettings"] = task27_10_15.App.LoadComponent(this, System.Uri(task27-10-15\BlankPage1.xaml));
            ////localsettings.Values["sessionsetting"] = "task27-10-15";
            MainPage m = new MainPage();
            //Object value = localsettings.Values["sessionsetting"];

            //Windows.Storage.ApplicationData.Current.LocalSettings.Values["MainPage"] = sessionsettings;
            //string sessionsettings = Windows.Storage.ApplicationData.Current.LocalSettings.Values[""];
            
            //   StorageFile sf = await ApplicationData.Current.LocalSettings.Values[MainPage];


        }



        Windows.Storage.ApplicationDataContainer localsettings = Windows.Storage.ApplicationData.Current.LocalSettings;


        private async void comboplaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox b1 = sender as ComboBox;
            string types1 = loctypes[b1.SelectedIndex].ToString();

            Uri li = new Uri("https://maps.googleapis.com/maps/api/place/search/json?types=" + types1 + "&location=" + l1.Latitude + "," + l1.Longitude + "&radius=1000&sensor=false&key=AIzaSyBTptqaDtNTB0Fmba3N98oWrucR0vuctRU");
            HttpClient cli = new HttpClient();
            string content = await cli.GetStringAsync(li);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(content);
            gv1.ItemsSource = r.results;
            //List<Result> results = new List<Result>();
            //List<Location1> ll = new List<Location1>();



            //r.results
            // session.Values["page"] = Windows.ApplicationModel.Package.Current.InstalledLocation;

            foreach (Result rs in r.results)
            {
                Location ln = new Location();
                ln.Latitude = rs.geometry.location.lat;

                ln.Longitude = rs.geometry.location.lng;
                Pushpin pp = new Pushpin();
                
                map1.Children.Add(pp);

                MapLayer.SetPosition(pp, ln);
            }
                //string loc="+ll.lat+","+ll.lng+";
            //map1.SetView(ln, 15);
            

            //BasicGeoposition{Latitude=res.geometry.location.lat,Longitude=res.geometry.location.lng};
            //ln.Latitude = rs.lat;
            //ln.Longitude = rs.lng;
                ////   // map1.Children.Add(p);
                ////   //MapLayer.SetPosition(p,ll);
                // Location1 loc = new Location1();

                ////}
                //MapLayer.SetPosition(p,loc);
                //MapLayer.SetPosition(pp, l2);

                //var pushpinLayer = new MapLayer();
                //pushpinLayer.Name = "PushPinLayer";
                //map1.Children.Add(pushpinLayer);

                //var location = new Location(GetLattitude(), GetLongitude);
                //var pushpin = new Pushpin();
                //pushpin.Name = "My New Pushpin";

                //pushpinLayer.AddChild(pushpin);
                //pushpin. = location;
                //myMap.Children.Add(pushpin);

                //var pushpinLayer = new MapLayer();
                ////pushpinLayer.Name = "PushPinLayer";
                //map1.Children.Add(pushpinLayer);

                //var loc = new Location1();
                //var latt = loc.lat;
                //var lang = loc.lng;
                //var pushpin = new Pushpin();

                //pushpinLayer.Children(pushpin);

            
        }

        private void gv1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RootObject r1 = new RootObject();
            Result result = e.AddedItems[0] as Result;
            BlankPage1.results = new List<Result>() { result };
            Frame.Navigate(typeof(BlankPage1));


        }


        //class PushpinViewModel
        //{
        //    public ObservableCollection<PushpinClass> PushpinList { get; set; }
        //}

        //class PushpinClass
        //{
        //    public double Longitude { get; set; }
        //    public double Latitude { get; set; }
        //}
    }
}

