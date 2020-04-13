using _COMP313_002_Team1_GreenTrade_Website.Models;
using COMP313_002_Team1_GreenTrade_Website.DataAccess;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class CodesDataAccessLayer: DataAccessLayer
    {
        public async Task<List<Codes>> GetAllCodes(string parent)
        {
            try
            {
                Query RewardsQuery = fireStoreDb.Collection("rewards").Document(parent).Collection("codes");
                QuerySnapshot RewardsQuerySnapshot = await RewardsQuery.GetSnapshotAsync();
                List<Codes> codesList = new List<Codes>();
                foreach (DocumentSnapshot documentSnapshot in RewardsQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> p = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(p);
                        Codes newCode = JsonConvert.DeserializeObject<Codes>(json);
                        newCode.id = documentSnapshot.Id;
                        newCode.parent = parent;
                        codesList.Add(newCode);
                    }
                }
                return codesList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddCodes(Codes obj, string parent)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("rewards").Document(parent).Collection("codes"); ;
                await colRef.AddAsync(obj);
            }
            catch
            {
                throw;
            }
        }

        public async void DeleteCodes(string id, string parent)
        {
            try
            {
                DocumentReference objRef = fireStoreDb.Collection("rewards").Document(parent).Collection("codes").Document(id);
                await objRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateCodes(Codes obj, string parent)
        {
            try
            {
                DocumentReference objRef = fireStoreDb.Collection("rewards").Document(parent).Collection("codes").Document(obj.id);
                await objRef.SetAsync(obj, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}