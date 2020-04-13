using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Codes
    {
        [FirestoreProperty]
        public Boolean used{ get; set; }

        [FirestoreProperty]
        public String id { get; set; }

        [FirestoreProperty]
        public String parent { get; set; }

    }
}
