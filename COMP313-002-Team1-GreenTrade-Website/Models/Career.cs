using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Career
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string firstname { get; set; }
        [FirestoreProperty]
        public string lastname { get; set; }
        [FirestoreProperty]
        public string phone { get; set; }
        [FirestoreProperty]
        public string city { get; set; }
        [FirestoreProperty]
        public string zipcode { get; set; }
        [FirestoreProperty]
        public string address { get; set; }
    }
}
