using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai6_2.DAL
{
    public class ChamCongDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=HR_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataSet LayDuLieuChamCong(int thang, int nam)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                // 1. Tự động kiểm tra và thêm bản ghi chấm công 0 ngày cho các nhân viên chưa có trong tháng/năm này
                string queryCheck = @"INSERT INTO ChamCong (MaNV, Thang, Nam, SoNgayCong, SoGioOT, TrangThai)
                                      SELECT MaNV, @Thang, @Nam, 0, 0, N'Chưa chốt' 
                                      FROM NhanVien 
                                      WHERE MaNV NOT IN (SELECT MaNV FROM ChamCong WHERE Thang = @Thang AND Nam = @Nam)";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@Thang", thang);
                    cmdCheck.Parameters.AddWithValue("@Nam", nam);
                    cmdCheck.ExecuteNonQuery();
                }

                // 2. Nạp toàn bộ dữ liệu chấm công lên DataSet
                string query = "SELECT MaCC, MaNV, Thang, Nam, SoNgayCong, SoGioOT, TrangThai FROM ChamCong WHERE Thang = @Thang AND Nam = @Nam";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, "ChamCong");
                        return ds;
                    }
                }
            }
        }

        public bool LuuChamCong(DataSet ds, int thang, int nam)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT MaCC, MaNV, Thang, Nam, SoNgayCong, SoGioOT, TrangThai FROM ChamCong WHERE Thang = @Thang AND Nam = @Nam";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    da.Update(ds, "ChamCong");
                    return true;
                }
            }
        }
    }
}