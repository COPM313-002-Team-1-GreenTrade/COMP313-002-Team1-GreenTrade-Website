using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class ContactUs
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string comments { get; set; }
    }
}
