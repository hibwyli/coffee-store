using CoffeeServer.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeServer.FirestoreHelpers
{
    public class HoaDonService<DoUong> where DoUong : class
    {
        private readonly FirestoreDb _db;
        private List<DoUong> result;

        public HoaDonService()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = Path.Combine(userProfile, "source", "repos", "coffee-store", "CoffeeServer", "CoffeeServer", "FirestoreHelpers", "serviceAccountKey.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            _db = FirestoreDb.Create("coffee-manage-f42fa");
            result = new List<DoUong>();
        }

        public async Task<List<DoUong>> LoadDoUong(string collectionName)
        {
            var snapshot = await _db.Collection(collectionName).GetSnapshotAsync();
            result.Clear();
            foreach (var doc in snapshot.Documents)
            {
                result.Add(doc.ConvertTo<DoUong>());
            }
            return result;
        }
    }


}
