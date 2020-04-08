using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class DataAccessLayer
    {
        public string projectId;
        public FirestoreDb fireStoreDb;
        public DataAccessLayer()
        {
            string filepath = ".\\serviceAccountKey.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            projectId = "green-trade-comp313";
            fireStoreDb = FirestoreDb.Create(projectId);
        }
    }
}
