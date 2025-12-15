using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeServer.Models;

namespace CoffeeServer.DoanhThuService
{
    public class DoanhThuService
    {
        public  FirestoreDb _db;

        public DoanhThuService()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = Path.Combine(userProfile, "source", "repos", "coffee-store", "CoffeeServer", "CoffeeServer", "FirestoreHelpers", "serviceAccountKey.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            _db = FirestoreDb.Create("coffee-manage-f42fa");
        }

        // Get total revenue for a specific date
        public async Task<double> GetTotalRevenueByDate(DateTime date)
        {
            double total = 0;

            // Get all HoaDon documents
            CollectionReference hoaDonRef = _db.Collection("HoaDon");
            QuerySnapshot snapshot = await hoaDonRef.GetSnapshotAsync();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (doc.Exists)
                {
                    HoaDon hd = doc.ConvertTo<HoaDon>();
                    // Compare only the date part
                    if (hd.NgayLap.Date == date.Date)
                    {
                        total += hd.TongTien;
                    }
                }
            }

            return total;
        }

        // Get total revenue from start
        public async Task<double> GetTotalRevenueAllTime()
        {
            double total = 0;

            CollectionReference hoaDonRef = _db.Collection("HoaDon");
            QuerySnapshot snapshot = await hoaDonRef.GetSnapshotAsync();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (doc.Exists)
                {
                    HoaDon hd = doc.ConvertTo<HoaDon>();
                    total += hd.TongTien;
                }
            }

            return total;
        }
        public async Task<double> GetTotalRevenueBetweenDates(DateTime startDate, DateTime endDate)
        {
            double total = 0;

            CollectionReference hoaDonRef = _db.Collection("HoaDon");
            QuerySnapshot snapshot = await hoaDonRef.GetSnapshotAsync();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (doc.Exists)
                {
                    HoaDon hd = doc.ConvertTo<HoaDon>();
                    if (hd.NgayLap.Date >= startDate.Date && hd.NgayLap.Date <= endDate.Date)
                    {
                        total += hd.TongTien;
                    }
                }
            }

            return total;
        }
        public async Task<List<HoaDon>> GetHoaDonBetweenDates(
    DateTime startDate,
    DateTime endDate)
        {
            List<HoaDon> hoaDons = new List<HoaDon>();

            CollectionReference hoaDonRef = _db.Collection("HoaDon");
            QuerySnapshot snapshot = await hoaDonRef.GetSnapshotAsync();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (!doc.Exists) continue;

                HoaDon hd = doc.ConvertTo<HoaDon>();

                if (hd.NgayLap.Date >= startDate.Date &&
                    hd.NgayLap.Date <= endDate.Date)
                {
                    hoaDons.Add(hd);
                }
            }

            return hoaDons;
        }

    }
}
