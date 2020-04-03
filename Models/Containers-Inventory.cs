using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Containers_Inventory
    {
        [FirestoreProperty]
        public string uid { get; set; }
        [FirestoreProperty]
        public string size { get; set; }
        [FirestoreProperty]
        public double cost { get; set; }
        [FirestoreProperty]
        public int restock { get; set; }
        [FirestoreProperty]
        public int stock { get; set; }
    }
}
