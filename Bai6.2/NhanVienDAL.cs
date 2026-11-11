using System.Data;
using Microsoft.Data.SqlClient;
using Bai6_2.DTO;

namespace Bai6_2.DAL
{
    public class NhanVienDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=HR_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable TimKiemNhanVien(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT nv.MaNV, nv.HoTen, nv.CCCD, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong, nv.MaPB 
                                 FROM NhanVien nv 
                                 JOIN PhongBan pb ON nv.MaPB = pb.MaPB 
                                 WHERE nv.HoTen LIKE @Key OR nv.CCCD LIKE @Key OR pb.TenPB LIKE @Key";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Key", "%" + keyword + "%");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable LayDanhSachPhongBan()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM PhongBan";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO NhanVien (MaNV, HoTen, CCCD, MaPB, LuongCoBan, HeSoLuong) VALUES (@MaNV, @HoTen, @CCCD, @MaPB, @LuongCB, @HeSo)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                    cmd.Parameters.AddWithValue("@MaPB", nv.MaPB);
                    cmd.Parameters.AddWithValue("@LuongCB", nv.LuongCoBan);
                    cmd.Parameters.AddWithValue("@HeSo", nv.HeSoLuong);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE NhanVien SET HoTen = @HoTen, CCCD = @CCCD, MaPB = @MaPB, LuongCoBan = @LuongCB, HeSoLuong = @HeSo WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);
                    cmd.Parameters.AddWithValue("@MaPB", nv.MaPB);
                    cmd.Parameters.AddWithValue("@LuongCB", nv.LuongCoBan);
                    cmd.Parameters.AddWithValue("@HeSo", nv.HeSoLuong);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Xóa dữ liệu phụ thuộc trước tránh lỗi khóa ngoại
                using (SqlCommand cmd1 = new SqlCommand("DELETE FROM ChamCong WHERE MaNV = @MaNV", conn))
                {
                    cmd1.Parameters.AddWithValue("@MaNV", maNV);
                    cmd1.ExecuteNonQuery();
                }
                using (SqlCommand cmd2 = new SqlCommand("DELETE FROM BangLuong WHERE MaNV = @MaNV", conn))
                {
                    cmd2.Parameters.AddWithValue("@MaNV", maNV);
                    cmd2.ExecuteNonQuery();
                }

                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ChuyenPhongBan(string maNV, int maPBMoi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE NhanVien SET MaPB = @MaPB WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPB", maPBMoi);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}