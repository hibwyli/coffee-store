using CoffeeServer.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoffeeServer.FirestoreHelpers
{
    public class FirestoreService
    {
        private readonly FirestoreDb _db;
        private readonly FirebaseOtpService _otpService;

        public FirestoreService()
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string path = Path.Combine(userProfile, "source", "repos", "coffee-store", "CoffeeServer", "CoffeeServer", "FirestoreHelpers", "serviceAccountKey.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            FirestoreDb db = FirestoreDb.Create("coffee-manage-f42fa");
            _db = db;
            _otpService = new FirebaseOtpService();
        }

        // --------------------- GET ALL ---------------------
        public async Task<List<T>> GetAll<T>(string collectionName) where T : class
        {
            var snapshot = await _db.Collection(collectionName).GetSnapshotAsync();
            var result = new List<T>();
            foreach (var doc in snapshot.Documents)
            {
                result.Add(doc.ConvertTo<T>());
            }
            return result;
        }

        // --------------------- GET BY ID ---------------------
        public async Task<T> GetById<T>(string collectionName, string id) where T : class
        {
            var docRef = _db.Collection(collectionName).Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
                return snapshot.ConvertTo<T>();
            return null;
        }

        // --------------------- GET DOCUMENT ID ---------------------
        private string GetDocumentId<T>(T item) where T : class
        {
            if (item is DoUongData du && !string.IsNullOrEmpty(du.MaDU)) return du.MaDU;
            if (item is KhachHang kh && !string.IsNullOrEmpty(kh.MaKH)) return kh.MaKH;
            if (item is NhanVien nv && !string.IsNullOrEmpty(nv.MaNV)) return nv.MaNV;

            return Guid.NewGuid().ToString("N");
        }

        // --------------------- ADD ---------------------
        public async Task Add<T>(string collectionName, string id, T item) where T : class
        {
            await _db.Collection(collectionName).Document(id).SetAsync(item);
        }

        // --------------------- CREATE ---------------------

        public async Task<bool> CreateDu(string collectionName, DoUongData item) 
        {
            try
            {
                // Convert tu DoUOngData ve DoUong moi dc 
                DoUong cac = new DoUong()
                {
                    DonGia = item.DonGia,
                    MaDU = item.MaDU,
                    TenDU = item.TenDU,
                    MaLoai = item.MaLoai,

                };
                // 1. Lấy ID từ đối tượng
                string documentId = GetDocumentId(cac);

                // 2. Sử dụng logic SetAsync với ID đã lấy
                await _db.Collection(collectionName).Document(documentId).SetAsync(cac);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Lỗi khi tạo tài liệu trong {collectionName}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateBan(string collectionName, BanData item)
        {
            try
            {
                // Convert tu DoUOngData ve DoUong moi dc 
                Ban cac = new Ban()
                {
                    MaBan = item.MaBan,
                    SoBan = item.SoBan,
                    SucChua = item.SucChua,

                };
                // 1. Lấy ID từ đối tượng
                string documentId = GetDocumentId(cac);

                // 2. Sử dụng logic SetAsync với ID đã lấy
                await _db.Collection(collectionName).Document(documentId).SetAsync(cac);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Lỗi khi tạo tài liệu trong {collectionName}: {ex.Message}");
                return false;
            }
        }

        // --------------------- UPDATE ---------------------
        public async Task UpdateFields(string collectionName, string id, Dictionary<string, object> updates)
        {
            var docRef = _db.Collection(collectionName).Document(id);
            await docRef.UpdateAsync(updates);
        }

        public async Task<bool> UpdateDu(string collectionName, string id, DoUongData item)
        {
            try
            {
                DoUong cac = new DoUong()
                {
                    DonGia = item.DonGia,   
                    MaDU = item.MaDU,
                    TenDU = item.TenDU,
                    MaLoai = item.MaLoai,

                };
                var docRef = _db.Collection(collectionName).Document(id);
                await docRef.SetAsync(cac);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<bool> UpdateBan(string collectionName, string id, BanData item)
        {
            try
            {
                Ban cac = new Ban()
                {
                   MaBan = item.MaBan,
                   SucChua = item.SucChua,
                   SoBan = item.SoBan,
                };
                var docRef = _db.Collection(collectionName).Document(id);
                await docRef.SetAsync(cac);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // --------------------- DELETE ---------------------
        public async Task Delete(string collectionName, string id)
        {
            var docRef = _db.Collection(collectionName).Document(id);
            await docRef.DeleteAsync();
        }

        // --------------------- GET HOADON WITH CHITIET ---------------------
        public async Task<(HoaDon, List<ChiTietHoaDon>)> GetHoaDonWithChiTiet(string maHD)
        {
            var hd = await GetById<HoaDon>("HoaDon", maHD);
            if (hd == null) return (null, null);

            var snapshot = await _db.Collection("ChiTietHoaDon")
                                    .WhereEqualTo("MaHD", maHD)
                                    .GetSnapshotAsync();
            var chiTiet = new List<ChiTietHoaDon>();
            foreach (var doc in snapshot.Documents)
                chiTiet.Add(doc.ConvertTo<ChiTietHoaDon>());

            return (hd, chiTiet);
        }

        // --------------------- QUERY ---------------------
        public async Task<List<T>> Query<T>(string collectionName, string field, object value) where T : class
        {
            var snapshot = await _db.Collection(collectionName)
                                    .WhereEqualTo(field, value)
                                    .GetSnapshotAsync();
            var result = new List<T>();
            foreach (var doc in snapshot.Documents)
                result.Add(doc.ConvertTo<T>());
            return result;
        }
        public async Task DeleteAllDatabase()
        {
            string[] collections = new string[]
            {
        "ChiTietHoaDon",
        "HoaDon",
        "NhanVien",
        "Ban",
        "KhachHang",
        "DoUong",
        "LoaiDoUong"
            };

            foreach (var collectionName in collections)
            {
                var snapshot = await _db.Collection(collectionName).GetSnapshotAsync();
                foreach (var doc in snapshot.Documents)
                {
                    await _db.Collection(collectionName).Document(doc.Id).DeleteAsync();
                    Console.WriteLine($"Deleted {collectionName}/{doc.Id}");
                }
            }

            Console.WriteLine("✅ All data deleted from database.");
        }
        // --------------------- REGISTER ---------------------
        public async Task<bool> RegisterUser(KhachHang user)
        {
            // Kiểm tra user đã tồn tại chưa
            var existing = await _db.Collection("KhachHang").Document(user.MaKH).GetSnapshotAsync();
            if (existing.Exists)
            {
                Console.WriteLine($"⚠️ Khách hàng có MaKH {user.MaKH} đã tồn tại.");
                return false;
            }

            await _db.Collection("KhachHang").Document(user.MaKH).SetAsync(user);
            try
            {
                _otpService.SendRegistrationSuccessEmail(user.Email, "Khách hàng");
                Console.WriteLine($"✅ Email đăng ký thành công đã được gửi đến: {user.Email}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Lỗi khi gửi email đăng ký cho Khách hàng {user.MaKH}: {ex.Message}");
            }
            return true;
        }

        // --------------------- LOGIN ---------------------
        public async Task<KhachHang> LoginUser(string TenKH, string password)
        {
            var query = _db.Collection("KhachHang")
         .WhereEqualTo("TenKH", TenKH)
         .Limit(1);

            var snapshot = await query.GetSnapshotAsync();
            if (snapshot.Count == 0)
                return null;

            var user = snapshot.Documents[0].ConvertTo<KhachHang>();

            if (user.MatKhau == password)
                return user;

            return null;
        }
        // NHAN VIEN 
        public async Task<bool> RegisterNhanVien(NhanVien nv)
        {
            // Kiểm tra nhân viên đã tồn tại chưa (dựa vào MaNV)
            var existing = await _db.Collection("NhanVien").Document(nv.MaNV).GetSnapshotAsync();
            if (existing.Exists)
            {
                Console.WriteLine($"⚠️ Nhân viên có MaNV {nv.MaNV} đã tồn tại.");
                return false; // Đã tồn tại
            }

            await _db.Collection("NhanVien").Document(nv.MaNV).SetAsync(nv);

            try
            {
                _otpService.SendRegistrationSuccessEmail(nv.Email, "Nhân viên");
                Console.WriteLine($"✅ Email đăng ký thành công đã được gửi đến: {nv.Email}");
            }
            catch (Exception ex)
            {
                // Ghi log lỗi gửi email nhưng vẫn trả về true vì đăng ký thành công
                Console.WriteLine($"⚠️ Lỗi khi gửi email đăng ký cho Nhân viên {nv.MaNV}: {ex.Message}");
            }
            return true;
        }

        // --------------------- LOGIN ---------------------
        public async Task<NhanVien> LoginNhanVien(string TenNV, string password)
        {
            // Tìm nhân viên theo TenNV
            var query = _db.Collection("NhanVien")
                .WhereEqualTo("TenNV", TenNV)
                .Limit(1);

            var snapshot = await query.GetSnapshotAsync();
            if (snapshot.Count == 0)
                return null; // Không tìm thấy

            var nv = snapshot.Documents[0].ConvertTo<NhanVien>();

            // So sánh mật khẩu
            if (nv.MatKhau == password)
                return nv;

            return null; // Sai mật khẩu
        }
        static async Task InitializeDatabase(FirestoreDb db)
        {
            // ==== 1. LoaiDoUong ====
            var loaiTraSua = new LoaiDoUong { MaLoai = "LT001", TenLoai = "Trà sữa" };
            var loaiCafe = new LoaiDoUong { MaLoai = "LT002", TenLoai = "Cà phê" };
            await db.Collection("LoaiDoUong").Document(loaiTraSua.MaLoai).SetAsync(loaiTraSua);
            await db.Collection("LoaiDoUong").Document(loaiCafe.MaLoai).SetAsync(loaiCafe);

            // ==== 2. DoUong ====
            var douong1 = new DoUong { MaDU = "DU001", TenDU = "Trà sữa trân châu", MaLoai = "LT001", DonGia = 35000, HinhAnh = "trasua.jpg" };
            var douong2 = new DoUong { MaDU = "DU002", TenDU = "Cà phê sữa", MaLoai = "LT002", DonGia = 30000, HinhAnh = "cafe.jpg" };
            await db.Collection("DoUong").Document(douong1.MaDU).SetAsync(douong1);
            await db.Collection("DoUong").Document(douong2.MaDU).SetAsync(douong2);

            // ==== 3. KhachHang ====
            var kh1 = new KhachHang { MaKH = "KH001", TenKH = "Nguyen Van A", SDT = "0123456789", DiaChi = "Hanoi" };
            await db.Collection("KhachHang").Document(kh1.MaKH).SetAsync(kh1);

            // ==== 4. Ban ====
            var ban1 = new Ban { MaBan = "B01", SucChua = 4, SoBan = 1 };
            await db.Collection("Ban").Document(ban1.MaBan).SetAsync(ban1);

            // ==== 5. NhanVien ====
            var nv1 = new NhanVien { MaNV = "NV001", TenNV = "Tran Thi B", MatKhau = "123456", SDT = "0987654321", DiaChi = "Hanoi" };
            await db.Collection("NhanVien").Document(nv1.MaNV).SetAsync(nv1);

            // ==== 6. HoaDon ====
            var hd1 = new HoaDon
            {
                MaHD = "HD001",
                NgayLap = DateTime.UtcNow, // ✅ phải dùng UTC
                MaNV = "NV001",
                MaKH = "KH001",
                MaBan = "B01",
                TongTien = 65000,
                TrangThai = "Chưa thanh toán"
            };
            await db.Collection("HoaDon").Document(hd1.MaHD).SetAsync(hd1);

            // ==== 7. ChiTietHoaDon ====
            var cthd1 = new ChiTietHoaDon
            {
                Id = Guid.NewGuid().ToString(),
                MaHD = "HD001",
                MaDU = "DU001",
                SoLuong = 1,
                DonGia = 35000,
                ThanhTien = 35000
            };
            var cthd2 = new ChiTietHoaDon
            {
                Id = Guid.NewGuid().ToString(),
                MaHD = "HD001",
                MaDU = "DU002",
                SoLuong = 1,
                DonGia = 30000,
                ThanhTien = 30000
            };
            await db.Collection("ChiTietHoaDon").Document(cthd1.Id).SetAsync(cthd1);
            await db.Collection("ChiTietHoaDon").Document(cthd2.Id).SetAsync(cthd2);
        }
        public async Task<bool> SaveResetTokenAsync(string email)
        {
            // 1. Kiểm tra xem email có tồn tại trong KhachHang KHÔNG
            var khSnapshot = await _db.Collection("KhachHang")
                                      .WhereEqualTo("Email", email)
                                      .GetSnapshotAsync();

            // 2. Kiểm tra xem email có tồn tại trong NhanVien KHÔNG
            var nvSnapshot = await _db.Collection("NhanVien")
                                      .WhereEqualTo("Email", email)
                                      .GetSnapshotAsync();

            // 3. Nếu không tồn tại ở CẢ HAI nơi, thì mới return false
            if (khSnapshot.Count == 0 && nvSnapshot.Count == 0)
            {
                Console.WriteLine($"Không tìm thấy người dùng nào có email: {email}");
                return false;
            }

            // 4. Nếu email tồn tại (bất kể là KH hay NV), thì tiếp tục tạo token
            var collection = _db.Collection("reset_tokens");
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                             .Replace("+", "").Replace("/", "").Substring(0, 6);

            var resetToken = new ResetPasswordToken
            {
                Email = email,
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(15)
            };

            await collection.AddAsync(resetToken);

            // 5. Gửi email và trả về true
            await _otpService.SendOtpEmail(email, token);
            return true;
        }
        public async Task<bool> VerifyResetTokenAsync(string token)
        {
            var collection = _db.Collection("reset_tokens");
            var query = collection.WhereEqualTo("Token", token).WhereEqualTo("IsUsed", false);
            var snapshot = await query.GetSnapshotAsync();

            if (snapshot.Count == 0) return false;

            var doc = snapshot.Documents[0];
            var data = doc.ConvertTo<ResetPasswordToken>();

            if (data.ExpiresAt < DateTime.UtcNow)
                return false;

            // đánh dấu đã dùng
            await doc.Reference.UpdateAsync("IsUsed", true);

            return true;
        }
        // --------------------- CHANGE PASSWORD BY EMAIL ---------------------
        public async Task<bool> ChangePasswordByEmailAsync(string email, string newPassword)
        {
            // 1. Kiểm tra trong KhachHang
            var khSnapshot = await _db.Collection("KhachHang")
                                      .WhereEqualTo("Email", email)
                                      .GetSnapshotAsync();

            if (khSnapshot.Count > 0)
            {
                var doc = khSnapshot.Documents[0];
                await doc.Reference.UpdateAsync("MatKhau", newPassword);
                Console.WriteLine($"Password for KhachHang {email} updated successfully.");
                return true;
            }

            // 2. Kiểm tra trong NhanVien
            var nvSnapshot = await _db.Collection("NhanVien")
                                      .WhereEqualTo("Email", email)
                                      .GetSnapshotAsync();

            if (nvSnapshot.Count > 0)
            {
                var doc = nvSnapshot.Documents[0];
                await doc.Reference.UpdateAsync("MatKhau", newPassword);
                Console.WriteLine($"Password for NhanVien {email} updated successfully.");
                return true;
            }

            // Nếu không tìm thấy email trong cả 2 collection
            Console.WriteLine($"No user found with email: {email}");
            return false;
        }
        // Email exisst 
        public async Task<bool> EmailExistsAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            // 1️⃣ Kiểm tra trong KhachHang
            var khSnapshot = await _db.Collection("KhachHang")
                                      .WhereEqualTo("Email", email)
                                      .Limit(1)
                                      .GetSnapshotAsync();
            if (khSnapshot.Count > 0)
                return true;

            // 2️⃣ Kiểm tra trong NhanVien
            var nvSnapshot = await _db.Collection("NhanVien")
                                      .WhereEqualTo("Email", email)
                                      .Limit(1)
                                      .GetSnapshotAsync();
            if (nvSnapshot.Count > 0)
                return true;

            // ❌ Không tồn tại trong cả 2
            return false;
        }

        //Update Thong tin nhan vien
        public async Task<bool> CapNhatThongTinNhanVien(string maNV, string sdt, string diaChi,string email,string tenNV)
        {
            try
            {
                // Lấy document nhân viên theo Mã NV
                var docRef = _db.Collection("NhanVien").Document(maNV);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    // Nếu nhân viên chưa có trong Firestore → không được thêm mới
                    Console.WriteLine($"⚠️ Nhân viên {maNV} chưa có tài khoản, không thể cập nhật.");
                    return false;
                }

                // Nếu tồn tại → chỉ cập nhật thêm thông tin SDT & Địa chỉ
                var updates = new Dictionary<string, object>
        {
            { "TenNV", tenNV},
            { "SDT", sdt },
            { "DiaChi", diaChi },
            { "Email", email }

        };

                await docRef.UpdateAsync(updates);

                Console.WriteLine($"✅ Đã cập nhật thông tin cho nhân viên {maNV}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật nhân viên: {ex.Message}");
                return false;
            }
        }
    }
}
