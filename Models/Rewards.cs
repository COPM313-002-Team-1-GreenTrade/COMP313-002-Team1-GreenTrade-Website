using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Rewards
    {
        [FirestoreDocumentId]
        public string documentId { get; set; }

        [FirestoreProperty]
        public string brand { get; set; }

        [FirestoreProperty]
        public int cost { get; set; }

        [FirestoreProperty]
        public bool hasStock { get; set; }

        [FirestoreProperty]
        public int id { get; set; }

        [FirestoreProperty]
        public string img_url { get; set; }

        [FirestoreProperty]
        public int value { get; set; }
    }
}
