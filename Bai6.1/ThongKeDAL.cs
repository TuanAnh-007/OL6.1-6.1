using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai6_1.DAL
{
    public class ThongKeDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // 1. Dùng ExecuteScalar tính tổng doanh thu theo khoảng thời gian (ngày/tháng)
        public decimal TinhTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE NgayLap >= @TuNgay AND NgayLap <= @DenNgay";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                    // Dùng ExecuteScalar vì chỉ trả về 1 giá trị duy nhất (tổng tiền)
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        // 2. Dùng SqlDataReader hiển thị danh sách Top 5 sản phẩm bán chạy nhất
        public DataTable LayTop5SanPhamBanChay()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT TOP 5 sp.MaSP, sp.TenSP, SUM(ct.SoLuong) AS TongSoLuongBan 
                                 FROM ChiTietHoaDon ct 
                                 JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                                 GROUP BY sp.MaSP, sp.TenSP 
                                 ORDER BY TongSoLuongBan DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Dùng SqlDataReader đọc dữ liệu theo yêu cầu đề bài
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}