using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class UserDataAccessLayer: DataAccessLayer
    {
        
        public UserDataAccessLayer() : base(){}

        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                Query employeeQuery = fireStoreDb.Collection("users");
                QuerySnapshot employeeQuerySnapshot = await employeeQuery.GetSnapshotAsync();
                List<Users> usersList = new List<Users>();
                foreach (DocumentSnapshot documentSnapshot in employeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        Users newuser = JsonConvert.DeserializeObject<Users>(json);
                        newuser.uid = documentSnapshot.Id;
                        usersList.Add(newuser);
                    }
                }
                return usersList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddUser(Users user)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("users");
                await colRef.AddAsync(user);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Users>> GetUserData(string email)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("users").WhereEqualTo("email", email);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count>0)
                {
                    List<Users> usersList = new List<Users>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> p = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(p);
                            Users newpickup = JsonConvert.DeserializeObject<Users>(json);
                            newpickup.uid = documentSnapshot.Id;
                            usersList.Add(newpickup);
                        }
                    }

                    return usersList;
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

        public async void DeleteUser(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("users").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateUser(Users user)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("users").Document(user.uid);
                await empRef.SetAsync(user, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }


    }
}
