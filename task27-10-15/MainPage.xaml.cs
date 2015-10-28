using Bing.Maps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        }


        Geolocator gl = new Geolocator();
        Geoposition gp;
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            gp = await gl.GetGeopositionAsync();
            Location l1 = new Location();
            l1.Latitude = gp.Coordinate.Point.Position.Latitude;
            l1.Longitude = gp.Coordinate.Point.Position.Longitude;
            map1.SetView(l1, 15);
            MapLayer.SetPosition(pp1, l1);
           
        }

        private async void comboplaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gl.DesiredAccuracyInMeters = 1000;
            ////string dataSourceName = "Hospital";
            ////string dataEntityName = "Hospital";
            
           // Uri buri = new Uri("https://dev.virtualearth.net/REST/v1/Locations?q=hyderabad&output=Json&key=AjCcoWr2LvcjAFgtUDd37BhBPN7iyzuMIwwJNUwTYdezKVqxikySr7xbXIijzkhX"+ comboplaces.SelectedItem);
            //Uri buri = new Uri("http://spatial.virtualearth.net/REST/v1/data/20181f26d9e94c81acdf9496133d4f23/FourthCoffeeSample/FourthCoffeeShops?spatialFilter=nearby(27.894007,-82.670776,2)&$filter=StoreType%20Eq%20'Coffee Shop'&$select=IsWiFiHotSpot&$orderby=IsWiFiHotSpot&$format=json&key=queryKey");


            //Uri buri = new Uri("http://spatial.virtualearth.net/REST/v1/data/20181f26d9e94c81acdf9496133d4f23/FourthCoffeeSample/FourthCoffeeStores?spatialFilter=nearby(l1.Latitude,l1.Longitude,10.0)&$filter=Hyderabad&$json$&key=AjCcoWr2LvcjAFgtUDd37BhBPN7iyzuMIwwJNUwTYdezKVqxikySr7xbXIijzkhX");

            Uri buri = new Uri("http://spatial.virtualearth.net/REST/v1/data/20181f26d9e94c81acdf9496133d4f23/FourthCoffeeSample/FourthCoffeeShops?spatialFilter=nearby(l1.Latitude,l1.Longitude,2)&$filter=StoreType%20Eq%20'Coffee Shop'&$select=IsWiFiHotSpot&$orderby=IsWiFiHotSpot&$format=json&key=AjCcoWr2LvcjAFgtUDd37BhBPN7iyzuMIwwJNUwTYdezKVqxikySr7xbXIijzkhX");

            //Uri buri = new Uri("http://spatial.virtualearth.net/REST/v1/data/20181f26d9e94c81acdf9496133d4f23/dataSourceName/?spatialFilter=nearby(27.894007,-82.670776,2)&$filter=StoreType%20Eq%20'Coffee Shop'&$&$jason&$select=IsWiFiHotSpot&$orderby=IsWiFiHotSpot&key=AjCcoWr2LvcjAFgtUDd37BhBPN7iyzuMIwwJNUwTYdezKVqxikySr7xbXIijzkhX");
            HttpClient cli = new HttpClient();
           String content=await  cli.GetStringAsync(buri);
           RootObject roj = JsonConvert.DeserializeObject<RootObject>(content);

        }
    }
}
    