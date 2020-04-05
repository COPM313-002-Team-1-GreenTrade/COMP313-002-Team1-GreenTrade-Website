using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class CareerDataAccessLayer: DataAccessLayer
    {
        public CareerDataAccessLayer() : base() { }

        public async Task<List<Career>> GetAllCareers()
        {
            try
            {
                Query careerQuery = fireStoreDb.Collection("career");
                QuerySnapshot careerQuerySnapshot = await careerQuery.GetSnapshotAsync();
                List<Career> careerList = new List<Career>();
                foreach (DocumentSnapshot documentSnapshot in careerQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> career = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(career);
                        Career newCareer = JsonConvert.DeserializeObject<Career>(json);
                        newCareer.uid = documentSnapshot.Id;
                        careerList.Add(newCareer);
                    }
                }
                return careerList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddCareer(Career career)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("career");
                await colRef.AddAsync(career);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Career>> GetCareerByEmail(string email)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("career").WhereEqualTo("email", email);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    List<Career> careerList = new List<Career>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> career = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(career);
                            Career newCareer = JsonConvert.DeserializeObject<Career>(json);
                            newCareer.uid = documentSnapshot.Id;
                            careerList.Add(newCareer);
                        }
                    }

                    return careerList;
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

        public async void DeleteCareerbyId(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("career").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateCareer(Career career)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("career").Document(career.uid);
                await empRef.SetAsync(career, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}
