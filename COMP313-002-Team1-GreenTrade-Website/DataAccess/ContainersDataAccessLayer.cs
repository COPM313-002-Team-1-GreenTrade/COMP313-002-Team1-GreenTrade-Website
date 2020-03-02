using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class ContainersDataAccessLayer: DataAccessLayer
    {
        public ContainersDataAccessLayer() : base() { }

        public async Task<List<Containers>> GetAllContainers()
        {
            try
            {
                Query containersQuery = fireStoreDb.Collection("containers");
                QuerySnapshot containersQuerySnapshot = await containersQuery.GetSnapshotAsync();
                List<Containers> containersList = new List<Containers>();
                foreach (DocumentSnapshot documentSnapshot in containersQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> container = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(container);
                        Containers newContainer = JsonConvert.DeserializeObject<Containers>(json);
                        newContainer.uid = documentSnapshot.Id;
                        containersList.Add(newContainer);
                    }
                }
                return containersList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Containers>> GetContainerBySize(string size)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("containers").WhereEqualTo("size", size);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    List<Containers> containerList = new List<Containers>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> container = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(container);
                            Containers newContainers = JsonConvert.DeserializeObject<Containers>(json);
                            newContainers.uid = documentSnapshot.Id;
                            containerList.Add(newContainers);
                        }
                    }

                    return containerList;
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

        public async void AddContainer(Containers container)
        {
            try
            {
                DocumentReference colRef = fireStoreDb.Collection("containers").Document(container.size);
                await colRef.SetAsync(container);
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteContainersbyId(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("containers").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateContainer(Containers containers)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("containers").Document(containers.uid);
                await empRef.SetAsync(containers, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }


    }
}
