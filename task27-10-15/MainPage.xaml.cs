using Bing.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private void comboplaces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gl.DesiredAccuracyInMeters = 1000;


            
             
        }
    }
}
