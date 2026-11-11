using System;
using System.Data;
using System.Windows.Forms;
using Bai6_2.DAL;
using Bai6_2.DTO;

namespace Bai6_2.GUI
{
    public partial class frmNhanSu : Form
    {
        NhanVienDAL nvDAL = new NhanVienDAL();
        ChamCongDAL ccDAL = new ChamCongDAL();
        BangLuongDAL blDAL = new BangLuongDAL();

        DataSet dsChamCong;

        public frmNhanSu()
        {
            InitializeComponent();
        }

        private void frmNhanSu_Load(object sender, EventArgs e)
        {
            LoadComboboxPhongBan();
            LoadDanhSachNhanVien("");
        }

        private void LoadDanhSachNhanVien(string keyword)
        {
            dgvNhanVien.DataSource = nvDAL.TimKiemNhanVien(keyword);
        }

        private void LoadComboboxPhongBan()
        {
            cbPhongBan.DataSource = nvDAL.LayDanhSachPhongBan();
            cbPhongBan.DisplayMember = "TenPB";
            cbPhongBan.ValueMember = "MaPB";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien(txtKeyword.Text.Trim());
        }

        // Chọn dòng trên lưới nhân viên để đổ lên ô nhập liệu
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtLuongCB.Text = row.Cells["LuongCoBan"].Value.ToString();
                txtHeSoLuong.Text = row.Cells["HeSoLuong"].Value.ToString();
                if (row.Cells["MaPB"].Value != DBNull.Value)
                {
                    cbPhongBan.SelectedValue = row.Cells["MaPB"].Value;
                }
            }
        }

        // THÊM NHÂN VIÊN
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    MaNV = txtMaNV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    MaPB = Convert.ToInt32(cbPhongBan.SelectedValue),
                    LuongCoBan = decimal.Parse(txtLuongCB.Text),
                    HeSoLuong = double.Parse(txtHeSoLuong.Text)
                };

                if (nvDAL.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadDanhSachNhanVien("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        // SỬA NHÂN VIÊN
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    MaNV = txtMaNV.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    MaPB = Convert.ToInt32(cbPhongBan.SelectedValue),
                    LuongCoBan = decimal.Parse(txtLuongCB.Text),
                    HeSoLuong = double.Parse(txtHeSoLuong.Text)
                };

                if (nvDAL.SuaNhanVien(nv))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadDanhSachNhanVien("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân viên: " + ex.Message);
            }
        }

        // XÓA NHÂN VIÊN
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nvDAL.XoaNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        LoadDanhSachNhanVien("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhân viên: " + ex.Message);
            }
        }

        // CHUYỂN PHÒNG BAN
        private void btnChuyenPB_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                int maPBMoi = Convert.ToInt32(cbPhongBan.SelectedValue);

                if (nvDAL.ChuyenPhongBan(maNV, maPBMoi))
                {
                    MessageBox.Show("Chuyển phòng ban thành công!");
                    LoadDanhSachNhanVien("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển phòng ban: " + ex.Message);
            }
        }

        // NẠP CHẤM CÔNG (Disconnected Model)
        private void btnTaiChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(txtThang.Text);
                int nam = int.Parse(txtNam.Text);

                dsChamCong = ccDAL.LayDuLieuChamCong(thang, nam);
                dgvChamCong.DataSource = dsChamCong.Tables["ChamCong"];
                MessageBox.Show("Nạp chấm công thành công! Bạn có thể sửa trực tiếp số ngày công/OT trên lưới.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chấm công: " + ex.Message);
            }
        }

        // LƯU CHẤM CÔNG (SqlCommandBuilder + Adapter.Update)
        private void btnLuuChamCong_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(txtThang.Text);
                int nam = int.Parse(txtNam.Text);

                if (ccDAL.LuuChamCong(dsChamCong, thang, nam))
                {
                    MessageBox.Show("Đã đồng bộ dữ liệu chấm công về SQL Server thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu chấm công: " + ex.Message);
            }
        }

        // CHỐT LƯƠNG THÁNG (SqlTransaction)
        private void btnChotLuong_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = int.Parse(txtThang.Text);
                int nam = int.Parse(txtNam.Text);

                if (blDAL.ChotLuongThang(thang, nam))
                {
                    MessageBox.Show("Chốt lương tháng thành công và đã khóa dữ liệu chấm công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chốt lương thất bại (Đã Rollback Transaction):\n{ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}