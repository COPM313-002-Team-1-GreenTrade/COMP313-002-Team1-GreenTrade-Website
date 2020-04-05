using COMP313_002_Team1_GreenTrade_Website.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP313_002_Team1_GreenTrade_Website.DataAccess
{
    public class ContactUsDataAccessLayer: DataAccessLayer
    {
        public ContactUsDataAccessLayer() : base() { }

        public async Task<List<ContactUs>> GetAllContacts()
        {
            try
            {
                Query contactUsQuery = fireStoreDb.Collection("contact-us");
                QuerySnapshot contactUsQuerySnapshot = await contactUsQuery.GetSnapshotAsync();
                List<ContactUs> contactUsList = new List<ContactUs>();
                foreach (DocumentSnapshot documentSnapshot in contactUsQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> contactUs = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(contactUs);
                        ContactUs newContactUs = JsonConvert.DeserializeObject<ContactUs>(json);
                        newContactUs.uid = documentSnapshot.Id;
                        contactUsList.Add(newContactUs);
                    }
                }
                return contactUsList;
            }
            catch
            {
                throw;
            }
        }

        public async void AddContact(ContactUs contact)
        {
            try
            {
                CollectionReference colRef = fireStoreDb.Collection("contact-us");
                await colRef.AddAsync(contact);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ContactUs>> GetContactByEmail(string email)
        {
            try
            {
                Query docRef = fireStoreDb.Collection("contact-us").WhereEqualTo("email", email);
                QuerySnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Count > 0)
                {
                    List<ContactUs> contactUsList = new List<ContactUs>();
                    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                    {
                        if (documentSnapshot.Exists)
                        {
                            Dictionary<string, object> contactUs = documentSnapshot.ToDictionary();
                            string json = JsonConvert.SerializeObject(contactUs);
                            ContactUs newContactUs = JsonConvert.DeserializeObject<ContactUs>(json);
                            newContactUs.uid = documentSnapshot.Id;
                            contactUsList.Add(newContactUs);
                        }
                    }

                    return contactUsList;
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

        public async void DeleteContactbyId(string id)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("contact-us").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateContact(ContactUs contact)
        {
            try
            {
                DocumentReference empRef = fireStoreDb.Collection("contact-us").Document(contact.uid);
                await empRef.SetAsync(contact, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
    }
}
