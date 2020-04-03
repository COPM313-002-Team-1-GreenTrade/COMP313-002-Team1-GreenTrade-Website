using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Address
    {
        [FirestoreProperty]
        public string city { get; set; }
        [FirestoreProperty]
        public string postalCode { get; set; }
        [FirestoreProperty]
        public string street { get; set; }
        [FirestoreProperty]
        public string province { get; set; }
    }

}
