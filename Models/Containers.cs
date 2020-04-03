using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Containers
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public double cost { get; set; }
        [FirestoreProperty]
        public string description { get; set; }
        [FirestoreProperty]
        public string img_url { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string size { get; set; }
        [FirestoreProperty]
        public double height { get; set; }
        [FirestoreProperty]
        public double length { get; set; }
        [FirestoreProperty]
        public double width { get; set; }
    }
}
