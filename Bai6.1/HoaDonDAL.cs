using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai6_1.DAL
{
    public class HoaDonDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool ThucHienThanhToan(int maNV, int maKH, decimal tongTien, DataTable dtChiTiet)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Mở Transaction

                try
                {
                    // 1. Chèn Hóa đơn và lấy về MaHD tự sinh
                    string queryHD = "INSERT INTO HoaDon (NgayLap, MaNV, MaKH, TongTien) OUTPUT INSERTED.MaHD VALUES (GETDATE(), @MaNV, @MaKH, @TongTien)";
                    int maHD = 0;

                    using (SqlCommand cmdHD = new SqlCommand(queryHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                        cmdHD.Parameters.AddWithValue("@MaKH", maKH == 0 ? (object)DBNull.Value : maKH);
                        cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                        maHD = (int)cmdHD.ExecuteScalar();
                    }

                    // 2. Duyệt giỏ hàng để thêm ChiTietHoaDon và trừ tồn kho
                    foreach (DataRow row in dtChiTiet.Rows)
                    {
                        string maSP = row["MaSP"].ToString();
                        int soLuongBan = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        // Kiểm tra tồn kho trước khi bán
                        string queryCheck = "SELECT SoLuongTon FROM SanPham WHERE MaSP = @MaSP";
                        int tonKho = 0;
                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@MaSP", maSP);
                            tonKho = (int)cmdCheck.ExecuteScalar();
                        }

                        if (tonKho < soLuongBan)
                        {
                            trans.Rollback(); // Không đủ hàng -> Hủy bỏ toàn bộ giao dịch
                            throw new Exception($"Sản phẩm {maSP} không đủ số lượng trong kho!");
                        }

                        // Chèn chi tiết hóa đơn
                        string queryCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                        using (SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                            cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCT.Parameters.AddWithValue("@SoLuong", soLuongBan);
                            cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                            cmdCT.ExecuteNonQuery();
                        }

                        // Trừ số lượng tồn kho
                        string queryUpdate = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP";
                        using (SqlCommand cmdUp = new SqlCommand(queryUpdate, conn, trans))
                        {
                            cmdUp.Parameters.AddWithValue("@SoLuong", soLuongBan);
                            cmdUp.Parameters.AddWithValue("@MaSP", maSP);
                            cmdUp.ExecuteNonQuery();
                        }
                    }

                    // 3. Cộng điểm tích lũy cho khách hàng (Nếu có chọn khách hàng)
                    if (maKH > 0)
                    {
                        int diemThem = (int)(tongTien / 100000);
                        string queryPoint = "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH";
                        using (SqlCommand cmdP = new SqlCommand(queryPoint, conn, trans))
                        {
                            cmdP.Parameters.AddWithValue("@Diem", diemThem);
                            cmdP.Parameters.AddWithValue("@MaKH", maKH);
                            cmdP.ExecuteNonQuery();
                        }
                    }

                    trans.Commit(); // Hoàn tất thành công -> Lưu thay đổi vào DB
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback(); // Có lỗi xảy ra -> Rollback hoàn trả trạng thái cũ
                    throw new Exception("Thanh toán thất bại: " + ex.Message);
                }
            }
        }
    }
}