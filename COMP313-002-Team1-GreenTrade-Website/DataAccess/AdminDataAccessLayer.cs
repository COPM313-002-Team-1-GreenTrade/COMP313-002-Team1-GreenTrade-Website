using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class AdminDataAccessLayer: DataAccessLayer
    {
        public AdminDataAccessLayer() : base() { }

        public async Task<List<Admin>> GetAllAdmins()
        {
            try
            {
                Query employeeQuery = fireStoreDb.Collection("admin");
                QuerySnapshot employeeQuerySnapshot = await employeeQuery.GetSnapshotAsync();
                List<Admin> adminList = new List<Admin>();
                foreach (DocumentSnapshot documentSnapshot in employeeQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> admin = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(admin);
                        Admin newAdmin = JsonConvert.DeserializeObject<Admin>(json);
                        newAdmin.uid = documentSnapshot.Id;
                        adminList.Add(newAdmin);
                    }
                }
                return adminList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddAdmin(Admin admin)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("admin");
                await colRef.AddAsync(admin);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Admin>> GetAdminByEmail(string email)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("admin").WhereEqualTo("email", email);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    List<Admin> adminList = new List<Admin>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> admin = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(admin);
                            Admin newAdmin = JsonConvert.DeserializeObject<Admin>(json);
                            newAdmin.uid = documentSnapshot.Id;
                            adminList.Add(newAdmin);
                        }
                    }

                    return adminList;
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

        public async void DeleteAdminbyId(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("admin").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateAdmin(Admin admin)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("admin").Document(admin.uid);
                await empRef.SetAsync(admin, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> checkCredentials(Admin admin)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("admin").WhereEqualTo("email", admin.email);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    //List<Admin> adminList = new List<Admin>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> admin1 = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(admin1);
                            Admin newAdmin = JsonConvert.DeserializeObject<Admin>(json);

                            if (newAdmin.password==admin.password)
                            {
                                return true;
                            }
                            
                        }
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
