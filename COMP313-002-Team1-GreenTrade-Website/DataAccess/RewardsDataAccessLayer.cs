using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class RewardsDataAccessLayer:DataAccessLayer
    {
        public async Task<List<Rewards>> GetAllRewards()
        {
            try
            {
                Query RewardsQuery = fireStoreDb.Collection("rewards");
                QuerySnapshot RewardsQuerySnapshot = await RewardsQuery.GetSnapshotAsync();
                List<Rewards> rewardsList = new List<Rewards>();
                foreach (DocumentSnapshot documentSnapshot in RewardsQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> p = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(p);
                        Rewards newReward = JsonConvert.DeserializeObject<Rewards>(json);
                        newReward.documentId = documentSnapshot.Id;
                        rewardsList.Add(newReward);
                    }
                }
                return rewardsList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddRewards(Rewards obj)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("rewards");
                await colRef.AddAsync(obj);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Rewards> GetRewardsData(string id)
        {
            try
            {
                DocumentReference docRef = fireStoreDb.Collection("rewards").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Rewards rewards = snapshot.ConvertTo<Rewards>();
                    rewards.documentId = snapshot.Id;
                    return rewards;
                }
                else
                {
                    return new Rewards();
                }
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteRewards(string id)
        {
            try
            {
                DocumentReference objRef = fireStoreDb.Collection("rewards").Document(id);
                await objRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateRewards(Rewards obj)
        {
            try
            {
                DocumentReference objRef = fireStoreDb.Collection("rewards").Document(obj.documentId);
                await objRef.SetAsync(obj, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}
