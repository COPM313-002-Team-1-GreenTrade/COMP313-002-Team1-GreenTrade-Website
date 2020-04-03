using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Admin
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string firstName { get; set; }
        [FirestoreProperty]
        public string lastName { get; set; }
        [FirestoreProperty]
        public string displayName { get; set; }
        [FirestoreProperty]
        public string password { get; set; }
        [FirestoreProperty]
        public int accessLevel { get; set; }
        [FirestoreProperty]
        public Address address { get; set; }
    }
}
