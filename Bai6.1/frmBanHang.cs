using System;
using System.Data;
using System.Windows.Forms;
using Bai6_1.BUS;
using Bai6_1.DAL;
using Bai6_1.DTO;

namespace Bai6_1.GUI
{
    public partial class frmBanHang : Form
    {
        SanPhamBUS bus = new SanPhamBUS();
        HoaDonDAL hoaDonDAL = new HoaDonDAL();
        DataTable dtGioHang = new DataTable();

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            // Khởi tạo các cột cho giỏ hàng
            if (dtGioHang.Columns.Count == 0)
            {
                dtGioHang.Columns.Add("MaSP", typeof(string));
                dtGioHang.Columns.Add("TenSP", typeof(string));
                dtGioHang.Columns.Add("SoLuong", typeof(int));
                dtGioHang.Columns.Add("DonGia", typeof(decimal));
                dtGioHang.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");
            }

            dgvGioHang.DataSource = dtGioHang;
            LoadLaiDanhSach();
        }

        private void LoadLaiDanhSach()
        {
            try
            {
                dgvSanPham.DataSource = bus.TimKiemSanPham("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtKeyword.Text.Trim();
                dgvSanPham.DataSource = bus.TimKiemSanPham(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Click vào dòng sản phẩm trên bảng để đổ dữ liệu lên các ô TextBox (phục vụ Sửa/Xóa)
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuongTon"].Value.ToString();
            }
        }

        // Nhấp đúp chuột để đưa sản phẩm vào giỏ hàng mua
        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                string maSP = row.Cells["MaSP"].Value.ToString();
                string tenSP = row.Cells["TenSP"].Value.ToString();
                decimal donGia = Convert.ToDecimal(row.Cells["GiaBan"].Value);

                DataRow[] existingRows = dtGioHang.Select($"MaSP = '{maSP}'");
                if (existingRows.Length > 0)
                {
                    existingRows[0]["SoLuong"] = Convert.ToInt32(existingRows[0]["SoLuong"]) + 1;
                }
                else
                {
                    dtGioHang.Rows.Add(maSP, tenSP, 1, donGia);
                }
            }
        }

        // Nút THÊM sản phẩm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO()
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    GiaBan = decimal.Parse(txtGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (bus.ThemSanPham(sp))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    LoadLaiDanhSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        // Nút SỬA sản phẩm
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamDTO sp = new SanPhamDTO()
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    GiaBan = decimal.Parse(txtGiaBan.Text),
                    SoLuongTon = int.Parse(txtSoLuong.Text)
                };

                if (bus.SuaSanPham(sp))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    LoadLaiDanhSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        // Nút XÓA sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtMaSP.Text.Trim();
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bus.XoaSanPham(maSP))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        LoadLaiDanhSach();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }

        // Nút THANH TOÁN (Dùng SqlTransaction)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGioHang.Rows.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng đang trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNV = 1;
                int maKH = 1;

                decimal tongTien = 0;
                foreach (DataRow row in dtGioHang.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }

                bool ketQua = hoaDonDAL.ThucHienThanhToan(maNV, maKH, tongTien, dtGioHang);

                if (ketQua)
                {
                    MessageBox.Show("Thanh toán thành công và đã tự động trừ tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtGioHang.Rows.Clear();
                    LoadLaiDanhSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Thanh toán thất bại (SqlTransaction Rollback):\n{ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}