using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;

namespace _COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Users
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string type { get; set; }
        [FirestoreProperty]
        public string providerid { get; set; }
        [FirestoreProperty]
        public string profilePhoto { get; set; }
        [FirestoreProperty]
        public string points { get; set; }
        [FirestoreProperty]
        public string email { get; set; }
        [FirestoreProperty]
        public string firstName { get; set; }
        [FirestoreProperty]
        public string lastName { get; set; }
        [FirestoreProperty]
        public Boolean deleted { get; set; }
        [FirestoreProperty]
        public string displayName { get; set; }
        [FirestoreProperty]
        public Address address { get; set; }
    }
}
