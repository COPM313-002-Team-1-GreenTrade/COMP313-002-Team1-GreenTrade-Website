using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class PickupsDataAccessLayer : DataAccessLayer
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
                        newpickup.uid = documentSnapshot.Id;
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

        public async Task<List<Pickups>> GetPickupDataByCollectorId(string collectorId)
        {
            try
            {
                Query pickupsQuery = fireStoreDb.Collection("pickups").WhereEqualTo("collectorId", collectorId);
                QuerySnapshot employeeQuerySnapshot = await pickupsQuery.GetSnapshotAsync();
                List<Pickups> pickupsList = new List<Pickups>();
                foreach (DocumentSnapshot documentSnapshot in employeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> p = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(p);
                        Pickups newpickup = JsonConvert.DeserializeObject<Pickups>(json);
                        newpickup.uid = documentSnapshot.Id;
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

        public async Task<List<Pickups>> GetPickupDataByMemberId(string memberId)
        {
            try
            {
                Query pickupsQuery = fireStoreDb.Collection("pickups").WhereEqualTo("memberId", memberId);
                QuerySnapshot employeeQuerySnapshot = await pickupsQuery.GetSnapshotAsync();
                List<Pickups> pickupsList = new List<Pickups>();
                foreach (DocumentSnapshot documentSnapshot in employeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> p = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(p);
                        Pickups newpickup = JsonConvert.DeserializeObject<Pickups>(json);
                        newpickup.uid = documentSnapshot.Id;
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

        public async void DeletePickup(string id)
        {
            try
            {
                Google.Cloud.Firestore.DocumentReference PickupRef = fireStoreDb.Collection("pickups").Document(id);
                await PickupRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdatePickup(Pickups pickup, string id)
        {
            try
            {
                Google.Cloud.Firestore.DocumentReference pickupRef = fireStoreDb.Collection("pickups").Document(id);
                await pickupRef.SetAsync(pickup, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}