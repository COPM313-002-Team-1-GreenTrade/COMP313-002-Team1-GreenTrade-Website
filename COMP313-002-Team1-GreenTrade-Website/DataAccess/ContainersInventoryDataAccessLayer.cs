using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class ContainersInventoryDataAccessLayer : DataAccessLayer
    {
        public async Task<List<Containers_Inventory>> GetAllContainersInventory()
        {
            try
            {
                Query containersInventoryQuery = fireStoreDb.Collection("containers-inventory");
                QuerySnapshot containersQuerySnapshot = await containersInventoryQuery.GetSnapshotAsync();
                List<Containers_Inventory> containersInventoryList = new List<Containers_Inventory>();
                foreach (DocumentSnapshot documentSnapshot in containersQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> inventory = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(inventory);
                        Containers_Inventory newInventory = JsonConvert.DeserializeObject<Containers_Inventory>(json);
                        newInventory.uid = documentSnapshot.Id;
                        containersInventoryList.Add(newInventory);
                    }
                }
                return containersInventoryList;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Containers_Inventory>> GetContainerInventoryBySize(string size)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("containers-inventory").WhereEqualTo("size", size);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    List<Containers_Inventory> containersInventoryList = new List<Containers_Inventory>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> inventory = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(inventory);
                            Containers_Inventory newInventory = JsonConvert.DeserializeObject<Containers_Inventory>(json);
                            newInventory.uid = documentSnapshot.Id;
                            containersInventoryList.Add(newInventory);
                        }
                    }

                    return containersInventoryList;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public async void AddContainerInventory(Containers_Inventory inventory)
        {
            try
            {
                DocumentReference colRef = fireStoreDb.Collection("containers-inventory").Document(inventory.size);
                await colRef.SetAsync(inventory);
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteContainersInventorybyId(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("containers-inventory").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateContainerInventory(Containers_Inventory inventory)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("containers-inventory").Document(inventory.uid);
                await empRef.SetAsync(inventory, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}
