using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using COMP313_002_Team1_GreenTrade_Website.Models;

namespace COMP313_002_Team1_GreenTrade_Website.Models
{
    [FirestoreData]
    public class Pickups
    {
        [FirestoreProperty]
        public string additionalInfo { get; set; }
        [FirestoreProperty]
        public Address address { get; set; }
        [FirestoreProperty]
        public Boolean cancelled { get; set; }
        [FirestoreProperty]
        public string collectorId { get; set; }
        [FirestoreProperty]
        public string collectorName { get; set; }
        [FirestoreDocumentCreateTimestamp]
        public Google.Protobuf.WellKnownTypes.Timestamp fulfilledTime { get; set; }
        [FirestoreProperty]
        public string memberId { get; set; }
        [FirestoreProperty]
        public string memberName { get; set; }
        [FirestoreProperty]
        public string memberProfilePicURL { get; set; }
        [FirestoreDocumentCreateTimestamp]
        public Google.Protobuf.WellKnownTypes.Timestamp scheduledTime { get; set; }
    }
}
