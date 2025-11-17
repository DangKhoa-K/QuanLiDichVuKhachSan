using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiDichVuKhachSan.Data
{
    public static class RoomRepo
    {
        public static DataTable List() =>
            Db.GetTable("SELECT PhongId, SoPhong, GhiChu FROM PHONG ORDER BY SoPhong", CommandType.Text);

        public static void Add(string soPhong, string ghiChu) =>
            Db.Exec("INSERT PHONG(SoPhong,GhiChu) VALUES(@p,@g)", CommandType.Text,
                new SqlParameter("@p", soPhong), new SqlParameter("@g", (object?)ghiChu ?? DBNull.Value));

        public static void Update(int id, string soPhong, string ghiChu) =>
            Db.Exec("UPDATE PHONG SET SoPhong=@p, GhiChu=@g WHERE PhongId=@id", CommandType.Text,
                new SqlParameter("@p", soPhong), new SqlParameter("@g", (object?)ghiChu ?? DBNull.Value),
                new SqlParameter("@id", id));

        public static void Delete(int id) =>
            Db.Exec("DELETE PHONG WHERE PhongId=@id", CommandType.Text, new SqlParameter("@id", id));
    }

    public static class CustomerRepo
    {
        public static DataTable List() =>
            Db.GetTable(@"SELECT KhachHangId, HoTen, DienThoai, Email, CCCD, DiaChi
                          FROM KHACHHANG ORDER BY HoTen", CommandType.Text);

        public static void Add(string ho, string dt, string em, string cccd, string dc) =>
            Db.Exec(@"INSERT KHACHHANG(HoTen,DienThoai,Email,CCCD,DiaChi)
                      VALUES(@h,@d,@e,@c,@dc)", CommandType.Text,
                new SqlParameter("@h", ho), new SqlParameter("@d", (object?)dt ?? DBNull.Value),
                new SqlParameter("@e", (object?)em ?? DBNull.Value),
                new SqlParameter("@c", (object?)cccd ?? DBNull.Value),
                new SqlParameter("@dc", (object?)dc ?? DBNull.Value));

        public static void Update(int id, string ho, string dt, string em, string cccd, string dc) =>
            Db.Exec(@"UPDATE KHACHHANG SET HoTen=@h,DienThoai=@d,Email=@e,CCCD=@c,DiaChi=@dc
                      WHERE KhachHangId=@id", CommandType.Text,
                new SqlParameter("@h", ho), new SqlParameter("@d", (object?)dt ?? DBNull.Value),
                new SqlParameter("@e", (object?)em ?? DBNull.Value),
                new SqlParameter("@c", (object?)cccd ?? DBNull.Value),
                new SqlParameter("@dc", (object?)dc ?? DBNull.Value),
                new SqlParameter("@id", id));

        public static void Delete(int id) =>
            Db.Exec("DELETE KHACHHANG WHERE KhachHangId=@id", CommandType.Text, new SqlParameter("@id", id));
    }

    public static class ServiceRepo
    {
        public static DataTable List() =>
            Db.GetTable("SELECT DichVuId, TenDichVu, DonVi, MoTa FROM DICHVU ORDER BY TenDichVu", CommandType.Text);

        public static void Add(string ten, string dv, string mota) =>
            Db.Exec("INSERT DICHVU(TenDichVu,DonVi,MoTa) VALUES(@t,@d,@m)", CommandType.Text,
                new SqlParameter("@t", ten), new SqlParameter("@d", (object?)dv ?? DBNull.Value),
                new SqlParameter("@m", (object?)mota ?? DBNull.Value));

        public static void Update(int id, string ten, string dv, string mota) =>
            Db.Exec("UPDATE DICHVU SET TenDichVu=@t,DonVi=@d,MoTa=@m WHERE DichVuId=@id", CommandType.Text,
                new SqlParameter("@t", ten), new SqlParameter("@d", (object?)dv ?? DBNull.Value),
                new SqlParameter("@m", (object?)mota ?? DBNull.Value), new SqlParameter("@id", id));

        public static void Delete(int id) =>
            Db.Exec("DELETE DICHVU WHERE DichVuId=@id", CommandType.Text, new SqlParameter("@id", id));
    }

    public static class PriceRepo
    {
        public static DataTable ListByService(int dichVuId) =>
            Db.GetTable(@"SELECT BangGiaId, DichVuId, DonGia, HieuLucTu, HieuLucDen
                          FROM BANGGIADICHVU WHERE DichVuId=@id ORDER BY HieuLucTu DESC",
                CommandType.Text, new SqlParameter("@id", dichVuId));

        public static void Insert(int dichVuId, decimal gia, DateTime tu, DateTime? den) =>
            Db.Exec("usp_Price_Insert", CommandType.StoredProcedure,
                new SqlParameter("@DichVuId", dichVuId),
                new SqlParameter("@DonGia", gia),
                new SqlParameter("@HieuLucTu", tu),
                new SqlParameter("@HieuLucDen", (object?)den ?? DBNull.Value));

        public static void Update(int bangGiaId, decimal gia, DateTime tu, DateTime? den) =>
            Db.Exec("usp_Price_Update", CommandType.StoredProcedure,
                new SqlParameter("@BangGiaId", bangGiaId),
                new SqlParameter("@DonGia", gia),
                new SqlParameter("@HieuLucTu", tu),
                new SqlParameter("@HieuLucDen", (object?)den ?? DBNull.Value));

        public static void Delete(int id) =>
            Db.Exec("DELETE BANGGIADICHVU WHERE BangGiaId=@id", CommandType.Text, new SqlParameter("@id", id));
    }

    public static class UsageRepo
    {
        public static void Add(int phongId, int dichVuId, decimal soLuong, DateTime thoiDiem, int? khId, string? note) =>
            Db.Exec("usp_RecordServiceUsage", CommandType.StoredProcedure,
                new SqlParameter("@PhongId", phongId),
                new SqlParameter("@DichVuId", dichVuId),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@ThoiDiem", thoiDiem),
                new SqlParameter("@KhachHangId", (object?)khId ?? DBNull.Value),
                new SqlParameter("@GhiChu", (object?)note ?? DBNull.Value));

        public static DataTable List(DateTime from, DateTime to, int? phongId = null, int? dichVuId = null) =>
            Db.GetTable(@"
                SELECT s.SuDungId, p.SoPhong, dv.TenDichVu, s.ThoiDiem, s.SoLuong, s.DonGia, s.ThanhTien, s.GhiChu
                FROM SUDUNGDICHVU s 
                 JOIN PHONG p ON p.PhongId=s.PhongId
                 JOIN DICHVU dv ON dv.DichVuId=s.DichVuId
                WHERE s.ThoiDiem BETWEEN @f AND @t
                  AND (@ph IS NULL OR s.PhongId=@ph)
                  AND (@dv IS NULL OR s.DichVuId=@dv)
                ORDER BY s.ThoiDiem DESC",
                CommandType.Text,
                new SqlParameter("@f", from), new SqlParameter("@t", to),
                new SqlParameter("@ph", (object?)phongId ?? DBNull.Value),
                new SqlParameter("@dv", (object?)dichVuId ?? DBNull.Value));

        public static DataTable RoomTotal(int phongId, DateTime from, DateTime to, out decimal tong)
        {
            var dt = Db.GetTable("usp_RoomTotal", CommandType.StoredProcedure,
                    new SqlParameter("@PhongId", phongId),
                    new SqlParameter("@From", from),
                    new SqlParameter("@To", to));
            // thủ tục trả 2 resultsets; ta chỉ lấy table đầu, rồi gọi Scalar để lấy tổng:
            var sum = Db.Scalar(@"SELECT SUM(ThanhTien) FROM SUDUNGDICHVU 
                                  WHERE PhongId=@p AND ThoiDiem BETWEEN @f AND @t",
                       CommandType.Text,
                       new SqlParameter("@p", phongId),
                       new SqlParameter("@f", from), new SqlParameter("@t", to));
            tong = sum != DBNull.Value ? Convert.ToDecimal(sum) : 0m;
            return dt;
        }

        public static DataTable DailyRevenue(DateTime ngay) =>
            Db.GetTable("usp_DailyRevenue", CommandType.StoredProcedure, new SqlParameter("@Ngay", ngay));

        public static DataTable RoomsCustomersByService(int dichVuId, DateTime from, DateTime to) =>
            Db.GetTable("usp_ListRoomsCustomersByService", CommandType.StoredProcedure,
                new SqlParameter("@DichVuId", dichVuId),
                new SqlParameter("@From", from),
                new SqlParameter("@To", to));
    }
}