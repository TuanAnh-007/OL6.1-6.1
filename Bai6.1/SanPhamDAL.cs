using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Bai6_1.DTO;

namespace Bai6_1.DAL
{
    public class SanPhamDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Tìm kiếm sản phẩm
        public DataTable TimKiemSanPham(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM SanPham WHERE MaSP LIKE @Key OR TenSP LIKE @Key";
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

        // THÊM Sản phẩm (Dùng SqlParameter chống SQL Injection)
        public bool ThemSanPham(SanPhamDTO sp)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // SỬA Sản phẩm
        public bool SuaSanPham(SanPhamDTO sp)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon WHERE MaSP = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // XÓA Sản phẩm
        public bool XoaSanPham(string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}