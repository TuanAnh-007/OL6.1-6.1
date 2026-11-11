using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Bai6_2.DAL
{
    public class BangLuongDAL
    {
        private string connStr = "Server=MSI\\SQLEXPRESS;Database=HR_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool ChotLuongThang(int thang, int nam)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Mở Transaction đảm bảo tính ACID

                try
                {
                    string queryCC = @"SELECT cc.MaNV, cc.SoNgayCong, cc.SoGioOT, nv.LuongCoBan, nv.HeSoLuong 
                                       FROM ChamCong cc 
                                       JOIN NhanVien nv ON cc.MaNV = nv.MaNV 
                                       WHERE cc.Thang = @Thang AND cc.Nam = @Nam";

                    DataTable dt = new DataTable();
                    using (SqlCommand cmdGet = new SqlCommand(queryCC, conn, trans))
                    {
                        cmdGet.Parameters.AddWithValue("@Thang", thang);
                        cmdGet.Parameters.AddWithValue("@Nam", nam);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmdGet))
                        {
                            da.Fill(dt);
                        }
                    }

                    if (dt.Rows.Count == 0)
                        throw new Exception("Không có dữ liệu chấm công trong tháng này để chốt lương!");

                    foreach (DataRow row in dt.Rows)
                    {
                        string maNV = row["MaNV"].ToString();
                        decimal luongCB = Convert.ToDecimal(row["LuongCoBan"]);
                        double heSo = Convert.ToDouble(row["HeSoLuong"]);
                        int ngayCong = Convert.ToInt32(row["SoNgayCong"]);
                        int gioOT = Convert.ToInt32(row["SoGioOT"]);

                        // Công thức: ThucLinh = (LuongCoBan * HeSoLuong / 22) * SoNgayCong + (SoGioOT * 50000)
                        decimal thucLinh = ((luongCB * (decimal)heSo) / 22m) * ngayCong + (gioOT * 50000m);

                        string queryInsert = "INSERT INTO BangLuong (MaNV, Thang, Nam, ThucLinh) VALUES (@MaNV, @Thang, @Nam, @ThucLinh)";
                        using (SqlCommand cmdIns = new SqlCommand(queryInsert, conn, trans))
                        {
                            cmdIns.Parameters.AddWithValue("@MaNV", maNV);
                            cmdIns.Parameters.AddWithValue("@Thang", thang);
                            cmdIns.Parameters.AddWithValue("@Nam", nam);
                            cmdIns.Parameters.AddWithValue("@ThucLinh", thucLinh);
                            cmdIns.ExecuteNonQuery();
                        }
                    }

                    // Khóa dữ liệu chấm công
                    string queryLock = "UPDATE ChamCong SET TrangThai = N'Đã chốt' WHERE Thang = @Thang AND Nam = @Nam";
                    using (SqlCommand cmdLock = new SqlCommand(queryLock, conn, trans))
                    {
                        cmdLock.Parameters.AddWithValue("@Thang", thang);
                        cmdLock.Parameters.AddWithValue("@Nam", nam);
                        cmdLock.ExecuteNonQuery();
                    }

                    trans.Commit(); // Hoàn tất thành công
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback(); // Lỗi -> Rollback toàn bộ
                    throw new Exception("Lỗi chốt lương: " + ex.Message);
                }
            }
        }
    }
}