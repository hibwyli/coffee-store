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
        private List<HoaDon> result;

        public HoaDonService()
        {
               string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = Path.Combine(userProfile, "source", "repos", "coffee-store", "CoffeeServer", "CoffeeServer", "FirestoreHelpers", "serviceAccountKey.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            _db = FirestoreDb.Create("coffee-manage-f42fa");
            result = new List<HoaDon>();
        }

        public async Task<List<HoaDonData>> CreateHoaDon(HoaDonData hoaDon)
        {
            if (hoaDon == null)
                throw new ArgumentNullException(nameof(hoaDon));

            var rawHoaDon = new HoaDon()
            {
                MaBan = hoaDon.MaBan,
                NgayLap = hoaDon.NgayLap,
                MaKH = hoaDon.MaKH,
                TrangThai = hoaDon.TrangThai,
                TongTien = hoaDon.TongTien,
                MaHD = hoaDon.MaHD,
            };

            try
            {
                CollectionReference collection = _db.Collection("HoaDon");
                DocumentReference docRef = await collection.AddAsync(rawHoaDon);
                Console.WriteLine($"HoaDon created with ID: {docRef.Id}");

                var property = typeof(DoUong).GetProperty("MaHD");
                if (property != null && property.CanWrite)
                {
                    property.SetValue(rawHoaDon, docRef.Id);
                }

                result.Add(rawHoaDon);

                // Convert List<HoaDon> -> List<HoaDonData>
                return result.Select(hd => new HoaDonData
                {
                    MaBan = hd.MaBan,
                    NgayLap = hd.NgayLap,
                    MaKH = hd.MaKH,
                    TrangThai = hd.TrangThai,
                    TongTien = hd.TongTien,
                    MaHD = hd.MaHD,

                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating HoaDon: {ex.Message}");
                return result.Select(hd => new HoaDonData
                {
                    MaBan = hd.MaBan,
                    NgayLap = hd.NgayLap,
                    MaKH = hd.MaKH,
                    TrangThai = hd.TrangThai,
                    TongTien = hd.TongTien,
                }).ToList();
            }
        }
        public async Task<List<HoaDonData>> LoadHoaDon()
        {
            try
            {
                // Get the "HoaDon" collection
                CollectionReference collection = _db.Collection("HoaDon");
                QuerySnapshot snapshot = await collection.GetSnapshotAsync();

                // Map documents to HoaDonData
                List<HoaDonData> hoaDonList = snapshot.Documents
                    .Select(doc => new HoaDonData
                    {
                        MaBan = doc.GetValue<string>("MaBan"),
                        NgayLap = doc.GetValue<DateTime>("NgayLap"),
                        MaKH = doc.GetValue<string>("MaKH"),
                        TrangThai = doc.GetValue<string>("TrangThai"),
                        TongTien = doc.GetValue<double>("TongTien"),
                        // Optionally include MaHD
                        MaHD = doc.Id
                    }).ToList();

                return hoaDonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading HoaDon: {ex.Message}");
                return new List<HoaDonData>();
            }
        }
    }


}
