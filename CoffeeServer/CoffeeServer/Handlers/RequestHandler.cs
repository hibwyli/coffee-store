using CoffeeServer.FirestoreHelpers;
using CoffeeServer.Models;
using System;
using System.Text.Json;
using static Google.Rpc.Context.AttributeContext.Types;

namespace CoffeeServer.Handlers
{

    public class RequestHandler
    {
        // Hàm xử lý JSON client gửi lên
        public  async Task<string> HandleRequest(string json)
        {
            try
            {
                var request = JsonSerializer.Deserialize<RequestModel>(json);
                var service = new FirestoreService();

                if (request == null)
                {
                    Console.WriteLine("Invalid JSON request!");
                    return "Invalid JSON request";
                }

                switch (request.Action.ToUpper())
                {
                    case "LOGIN":
                        Console.WriteLine($"[LOGIN] User: {request.Data.TenTaiKhoan}");
                        // TODO: Gọi hàm FirestoreService để check user
                        KhachHang success = await service.LoginUser(request.Data.TenTaiKhoan, request.Data.MatKhau);
                        if (success != null)
                        {
                            return JsonSerializer.Serialize<KhachHang>(success);
                        }else
                        {
                            NhanVien nvSuccess = await service.LoginNhanVien(request.Data.TenTaiKhoan, request.Data.MatKhau);
                            if(nvSuccess != null)
                            {
                                return JsonSerializer.Serialize<NhanVien>(nvSuccess);


                            }
                        }
                        return "LOGIN FAIL";

                    case "REGISTER":
                        Console.WriteLine($"[REGISTER] {request.Data.TenTaiKhoan} - {request.Data.Email}");
                        // CHeck email exists 
                        bool exists = await service.EmailExistsAsync(request.Data.Email);
                        if (exists)
                        {
                            return "EMAIL EXISTS";
                        }
                        if (request.Data.Quyen == "KH")
                        {
                            string maKH = "KH" + Guid.NewGuid().ToString("N"    ).Substring(0, 6).ToUpper();

                            var user = new KhachHang
                            {
                                MaKH = maKH,
                                TenKH = request.Data.TenTaiKhoan,
                                SDT = request.Data.Sdt ?? "0",
                                DiaChi = request.Data.DiaChi ?? "Hanoi",
                                MatKhau = request.Data.MatKhau,
                                Email = request.Data.Email
                            };
                            bool regSuccess = await service.RegisterUser(user);
                            if (regSuccess)
                            {
                                Console.WriteLine("REGISTER KH SUCCESS");
                                return "REGISTER KH SUCCESS";

                            }
                            else
                            {
                                Console.WriteLine("REGISTER KH FAIL");
                                return "REGISTER KH FAIL";

                            }
                        }
                        else
                        {
                            string maNV = "";
                            if (string.IsNullOrEmpty(request.Data.MaNv))
                            {
                                maNV = "NV" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                            }
                            else
                            {
                                maNV = request.Data.MaNv;
                            }

                                // Tạo đối tượng NhanVien
                                var nv = new NhanVien
                                {
                                    MaNV = maNV,
                                    TenNV = request.Data.TenTaiKhoan,      // biến tenTaiKhoan chứa tên đăng nhập
                                    SDT = request.Data.Sdt ?? "0",
                                    DiaChi = request.Data.DiaChi ?? "Hanoi",
                                    MatKhau = request.Data.MatKhau,        // biến matKhau chứa mật khẩu
                                    Email = request.Data.Email
                                };

                            // Khởi tạo service
                            bool regSuccess = await service.RegisterNhanVien(nv);

                            if (regSuccess)
                            {
                                Console.WriteLine("REGISTER NV SUCCESS");
                                return "REGISTER NV SUCCESS";

                            }
                            else
                            {
                                Console.WriteLine("REGISTER NV FAIL");
                                return "REGISTER NV FAIL";

                            }
                        }
                    case "RESET":
                        if (request.Data.Email != "" && request.Data.MatKhau == "")
                        {
                            //Send token
                            bool resSetsuccess = await service.SaveResetTokenAsync(request.Data.Email);
                            if (resSetsuccess)
                            {
                                return "Check your email !!!";
                            }
                            return "Something went wrong !";

                        }
                        else
                        {
                            bool resSetsuccess = await service.VerifyResetTokenAsync(request.Data.MatKhau);
                            if (resSetsuccess)
                            {
                                bool resetPass = await service.ChangePasswordByEmailAsync(request.Data.Email, request.Data.XacNhanMK);
                                if (resSetsuccess)
                                {
                                    return "Change password success !!";
                                }
                                return "Something went wrong";
                            }
                            return "Something went wrong";
                            //Verify token
                        }
                        break;

                    case "UPDATE":
                        if(request.Data.DiaChi != "" && request.Data.Sdt !=""&& request.Data.MaNv != "" && request.Data.Email != "")
                        {
                            bool updateSuccess = await service.CapNhatThongTinNhanVien(request.Data.MaNv,request.Data.Sdt,request.Data.DiaChi,request.Data.Email,request.Data.TenTaiKhoan);
                            if (updateSuccess)
                            {
                                return "Update success!!";
                            }
                        }
                        return "Update failed";
                    case "DELETE":
                        if (request.Data.MaNv != "" )
                        {
                            await service.Delete("NhanVien", request.Data.MaNv);
                             return "Update success!!";
                            
                        }
                        return "NV not exists to delete!";

                    case "GETALL":
                        if (request.CollectionName != null)
                        {
                            List<NhanVien> employees = await service.GetAll<NhanVien>("NhanVien");
                            var displayList = employees.Select(x => new
                            {
                                x.MaNV,
                                x.TenNV,
                                x.SDT,
                                x.DiaChi,
                                x.Email
                            }).ToList();
                            string jsond = JsonSerializer.Serialize(displayList);
                            Console.WriteLine(jsond);
                            return jsond;
                        }
                        return "Wrong shit";
                    case "CREATEDU":
                        return await HandleDoUongCrud("CREATEDU", request, service);

                    case "UPDATEDU":
                        return await HandleDoUongCrud("UPDATEDU", request, service);

                    case "DELETEDU":
                        return await HandleDoUongCrud("DELETEDU", request, service);

                    case "GETALLDU":
                        return await HandleDoUongCrud("GETALLDU", request, service);
                    case "CREATEBAN":
                        return await HandleBanCrud("CREATEBAN", request, service);
                    case "UPDATEBAN":
                        return await HandleBanCrud("UPDATEBAN", request, service);
                    case "DELETEBAN":
                        return await HandleBanCrud("DELETEBAN", request, service);
                    case "GETALLBAN":
                        return await HandleBanCrud("GETALLBAN", request, service);
                    default:
                        Console.WriteLine($"[ERROR] Unknown action: {request.Action}");
                        return $"[ERROR] Unknown action: {request.Action}";

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling request: {ex.Message}");
                return $"Error handling request: {ex.Message}";

            }
        }
        private async Task<string> HandleDoUongCrud(string action, RequestModel request, FirestoreService service)
        {
            if (action == "GETALLDU")
            {
                try
                {
                    List<DoUong> drinks = await service.GetAll<DoUong>("DoUong");
                    return JsonSerializer.Serialize(drinks);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Get All Do Uong: {ex.Message}");
                    return "GETALLDU FAIL: Lỗi server khi lấy dữ liệu.";
                }
            }
            DoUongData duData = request.DuData;

            if (duData == null)
            {
                return $"{action} FAIL: Dữ liệu Đồ Uống (DuData) rỗng.";
            }
            switch (action)
            {
                case "CREATEDU":
                    if (string.IsNullOrEmpty(duData.MaDU))
                    {
                        duData.MaDU = "DU" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                    }

                    bool createSuccess = await service.CreateDu("DoUong", duData);
                    return createSuccess ? "CREATE SUCCESS" : "CREATE FAIL";

                case "UPDATEDU":
                    if (string.IsNullOrEmpty(duData.MaDU))
                    {
                        return "UPDATEDU FAIL: Thiếu Mã Đồ Uống (MaDU).";
                    }
                    bool updateSuccess = await service.UpdateDu("DoUong", duData.MaDU, duData);
                    return updateSuccess ? "UPDATE SUCCESS" : "UPDATE FAIL";

                case "DELETEDU": 
                    if (string.IsNullOrEmpty(duData.MaDU))
                    {
                        return "DELETEDU FAIL: Thiếu Mã Đồ Uống (MaDU).";
                    }
                    await service.Delete("DoUong", duData.MaDU);
                    return "DELETE SUCCESS";

                default:
                    return $"[ERROR] Unknown CRUD action for DoUong: {action}";
            }
        }
        private async Task<string> HandleBanCrud(string action, RequestModel request, FirestoreService service)
        {
            if (action == "GETALLBAN")
            {
                try
                {
                    List<Ban> tables = await service.GetAll<Ban>("Ban");
                    return JsonSerializer.Serialize(tables);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Get All Ban: {ex.Message}");
                    return "GETALLBAN FAIL: Lỗi server khi lấy dữ liệu.";
                }
            }
            BanData banData = request.BanData;

            if (banData == null)
            {
                return $"{action} FAIL: Dữ liệu Đồ Uống (DuData) rỗng.";
            }
            switch (action)
            {
                case "CREATEBAN":
                    if (string.IsNullOrEmpty(banData.MaBan))
                    {
                        banData.MaBan = "Ban" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
                    }

                    bool createSuccess = await service.CreateBan("Ban", banData);
                    return createSuccess ? "CREATE SUCCESS" : "CREATE FAIL";

                case "UPDATEBAN":
                    if (string.IsNullOrEmpty(banData.MaBan))
                    {
                        return "UPDATEBAN FAIL: Thiếu Mã Bàn.";
                    }
                    bool updateSuccess = await service.UpdateBan("Ban", banData.MaBan, banData);
                    return updateSuccess ? "UPDATE SUCCESS" : "UPDATE FAIL";

                case "DELETEBAN":
                    if (string.IsNullOrEmpty(banData.MaBan))
                    {
                        return "DELETEDU FAIL: Thiếu Mã Bàn.";
                    }
                    await service.Delete("Ban", banData.MaBan);
                    return "DELETE SUCCESS";

                default:
                    return $"[ERROR] Unknown CRUD action for DoUong: {action}";
            }
        }
    }
}
