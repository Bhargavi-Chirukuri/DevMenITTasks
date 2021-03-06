﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace task27_10_15
{
    public class person
    {
        public string name { get; set; }
        public string password { get; set; }

        public string email { get; set; }
        public string country { get; set; }
        public string gender { get; set; }

        public string phone { get; set; }
    }



    public class Location1
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Geometry
    {
        public Location1 location { get; set; }
        public Viewport viewport { get; set; }
    }

    public class OpeningHours
    {
        public bool open_now { get; set; }
        public List<object> weekday_text { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class Result
    { 
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        
        
        public string name { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string vicinity { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public double? rating { get; set; }
    }

    public class RootObject
    {
        public List<object> html_attributions { get; set; }
        public string next_page_token { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }


    [Table("Favourite")]
    public class Favourite
    {
        [Column("placeName")]
        public string  placeName { get; set; }
        [Column("userName")]
        public string  userName { get; set; }
        [Column("id")]
        public int id { get; set; }
    }


}


