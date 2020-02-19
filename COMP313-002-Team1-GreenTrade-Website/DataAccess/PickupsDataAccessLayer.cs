using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class PickupsDataAccessLayer:DataAccessLayer
    {
        
        public PickupsDataAccessLayer() : base() { }

        public async Task<List<Pickups>> GetAllPickups()
        {
            try
            {
                Query employeeQuery = fireStoreDb.Collection("pickups");
                QuerySnapshot employeeQuerySnapshot = await employeeQuery.GetSnapshotAsync();
                List<Pickups> pickupsList = new List<Pickups>();
                foreach (DocumentSnapshot documentSnapshot in employeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> p = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(p);
                        Pickups newpickup = JsonConvert.DeserializeObject<Pickups>(json);
                        pickupsList.Add(newpickup);
                    }
                }
                return pickupsList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddPickup(Pickups pickup)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("pickups");
                await colRef.AddAsync(pickup);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pickups> GetPickupData(string id)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("pickups").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Pickups pickup = snapshot.ConvertTo<Pickups>();
                    return pickup;
                }
                else
                {
                    return new Pickups();
                }
            }
            catch
            {
                throw;
            }
        }

        public async void DeletePickup(string id)
        {
            try
            {
                DocumentReference PickupRef = fireStoreDb.Collection("pickups").Document(id);
                await PickupRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdatePickup(Pickups pickup)
        {
            try
            {
                DocumentReference pickupRef = fireStoreDb.Collection("pickups").Document(pickup.documentId.Id);
                await pickupRef.SetAsync(pickup, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}
