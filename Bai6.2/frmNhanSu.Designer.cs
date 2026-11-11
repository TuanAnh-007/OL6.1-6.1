namespace Bai6_2.GUI
{
    partial class frmNhanSu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblKeyword = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.btnTaiChamCong = new System.Windows.Forms.Button();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();
            this.lblChamCong = new System.Windows.Forms.Label();
            this.btnLuuChamCong = new System.Windows.Forms.Button();
            this.btnChotLuong = new System.Windows.Forms.Button();

            // Controls nhập liệu nhân sự
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblPB = new System.Windows.Forms.Label();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.lblLuongCB = new System.Windows.Forms.Label();
            this.txtLuongCB = new System.Windows.Forms.TextBox();
            this.lblHeSo = new System.Windows.Forms.Label();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChuyenPB = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 30);
            this.lblTitle.Text = "QUẢN LÝ NHÂN SỰ & CHẤM CÔNG";
            // 
            // lblKeyword
            // 
            this.lblKeyword.AutoSize = true;
            this.lblKeyword.Location = new System.Drawing.Point(15, 55);
            this.lblKeyword.Name = "lblKeyword";
            this.lblKeyword.Size = new System.Drawing.Size(61, 15);
            this.lblKeyword.Text = "Tìm kiếm:";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(80, 52);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(150, 23);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(235, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(15, 105);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(460, 220);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(15, 85);
            this.lblNhanVien.Size = new System.Drawing.Size(125, 15);
            this.lblNhanVien.Text = "Danh sách nhân viên:";
            // 
            // Input Controls Nhân sự
            // 
            this.lblMaNV.AutoSize = true; this.lblMaNV.Location = new System.Drawing.Point(15, 340);
            this.lblMaNV.Text = "Mã NV:";
            this.txtMaNV.Location = new System.Drawing.Point(80, 337); this.txtMaNV.Size = new System.Drawing.Size(140, 23);

            this.lblHoTen.AutoSize = true; this.lblHoTen.Location = new System.Drawing.Point(230, 340);
            this.lblHoTen.Text = "Họ tên:";
            this.txtHoTen.Location = new System.Drawing.Point(295, 337); this.txtHoTen.Size = new System.Drawing.Size(180, 23);

            this.lblCCCD.AutoSize = true; this.lblCCCD.Location = new System.Drawing.Point(15, 375);
            this.lblCCCD.Text = "CCCD:";
            this.txtCCCD.Location = new System.Drawing.Point(80, 372); this.txtCCCD.Size = new System.Drawing.Size(140, 23);

            this.lblPB.AutoSize = true; this.lblPB.Location = new System.Drawing.Point(230, 375);
            this.lblPB.Text = "Phòng ban:";
            this.cbPhongBan.Location = new System.Drawing.Point(295, 372); this.cbPhongBan.Size = new System.Drawing.Size(180, 23); this.cbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblLuongCB.AutoSize = true; this.lblLuongCB.Location = new System.Drawing.Point(15, 410);
            this.lblLuongCB.Text = "Lương CB:";
            this.txtLuongCB.Location = new System.Drawing.Point(80, 407); this.txtLuongCB.Size = new System.Drawing.Size(140, 23);

            this.lblHeSo.AutoSize = true; this.lblHeSo.Location = new System.Drawing.Point(230, 410);
            this.lblHeSo.Text = "Hệ số lương:";
            this.txtHeSoLuong.Location = new System.Drawing.Point(295, 407); this.txtHeSoLuong.Size = new System.Drawing.Size(180, 23);

            // Nút CRUD Nhân sự
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue; this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 445); this.btnThem.Size = new System.Drawing.Size(105, 32); this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.BackColor = System.Drawing.Color.DarkOrange; this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(125, 445); this.btnSua.Size = new System.Drawing.Size(105, 32); this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.BackColor = System.Drawing.Color.Crimson; this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(235, 445); this.btnXoa.Size = new System.Drawing.Size(105, 32); this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnChuyenPB.BackColor = System.Drawing.Color.SlateGray; this.btnChuyenPB.ForeColor = System.Drawing.Color.White;
            this.btnChuyenPB.Location = new System.Drawing.Point(345, 445); this.btnChuyenPB.Size = new System.Drawing.Size(130, 32); this.btnChuyenPB.Text = "Chuyển PB";
            this.btnChuyenPB.UseVisualStyleBackColor = false; this.btnChuyenPB.Click += new System.EventHandler(this.btnChuyenPB_Click);

            // Phần Chấm công & Lương bên phải
            this.lblThang.AutoSize = true; this.lblThang.Location = new System.Drawing.Point(495, 55); this.lblThang.Text = "Tháng:";
            this.txtThang.Location = new System.Drawing.Point(545, 52); this.txtThang.Size = new System.Drawing.Size(35, 23); this.txtThang.Text = "11";

            this.lblNam.AutoSize = true; this.lblNam.Location = new System.Drawing.Point(590, 55); this.lblNam.Text = "Năm:";
            this.txtNam.Location = new System.Drawing.Point(630, 52); this.txtNam.Size = new System.Drawing.Size(55, 23); this.txtNam.Text = "2026";

            this.btnTaiChamCong.Location = new System.Drawing.Point(695, 51); this.btnTaiChamCong.Size = new System.Drawing.Size(130, 25);
            this.btnTaiChamCong.Text = "Nạp Chấm Công"; this.btnTaiChamCong.UseVisualStyleBackColor = true;
            this.btnTaiChamCong.Click += new System.EventHandler(this.btnTaiChamCong_Click);

            this.lblChamCong.AutoSize = true; this.lblChamCong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChamCong.Location = new System.Drawing.Point(495, 85); this.lblChamCong.Text = "Bảng chấm công ngắt kết nối:";

            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCong.Location = new System.Drawing.Point(495, 105); this.dgvChamCong.Size = new System.Drawing.Size(330, 320);

            this.btnLuuChamCong.BackColor = System.Drawing.Color.SteelBlue; this.btnLuuChamCong.ForeColor = System.Drawing.Color.White;
            this.btnLuuChamCong.Location = new System.Drawing.Point(495, 445); this.btnLuuChamCong.Size = new System.Drawing.Size(155, 32);
            this.btnLuuChamCong.Text = "Lưu Chấm Công"; this.btnLuuChamCong.UseVisualStyleBackColor = false;
            this.btnLuuChamCong.Click += new System.EventHandler(this.btnLuuChamCong_Click);

            this.btnChotLuong.BackColor = System.Drawing.Color.ForestGreen; this.btnChotLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChotLuong.ForeColor = System.Drawing.Color.White; this.btnChotLuong.Location = new System.Drawing.Point(660, 445);
            this.btnChotLuong.Size = new System.Drawing.Size(165, 32); this.btnChotLuong.Text = "CHỐT LƯƠNG THÁNG";
            this.btnChotLuong.UseVisualStyleBackColor = false; this.btnChotLuong.Click += new System.EventHandler(this.btnChotLuong_Click);

            // 
            // frmNhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 495);
            this.Controls.Add(this.btnChotLuong);
            this.Controls.Add(this.btnLuuChamCong);
            this.Controls.Add(this.lblChamCong);
            this.Controls.Add(this.dgvChamCong);
            this.Controls.Add(this.btnTaiChamCong);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.lblThang);

            // Add CRUD controls
            this.Controls.Add(this.btnChuyenPB);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtHeSoLuong); this.Controls.Add(this.lblHeSo);
            this.Controls.Add(this.txtLuongCB); this.Controls.Add(this.lblLuongCB);
            this.Controls.Add(this.cbPhongBan); this.Controls.Add(this.lblPB);
            this.Controls.Add(this.txtCCCD); this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.txtHoTen); this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaNV); this.Controls.Add(this.lblMaNV);

            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.lblKeyword);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmNhanSu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Nhân sự & Chấm công";
            this.Load += new System.EventHandler(this.frmNhanSu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.TextBox txtThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Button btnTaiChamCong;
        private System.Windows.Forms.DataGridView dgvChamCong;
        private System.Windows.Forms.Label lblChamCong;
        private System.Windows.Forms.Button btnLuuChamCong;
        private System.Windows.Forms.Button btnChotLuong;

        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblPB;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.Label lblLuongCB;
        private System.Windows.Forms.TextBox txtLuongCB;
        private System.Windows.Forms.Label lblHeSo;
        private System.Windows.Forms.TextBox txtHeSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChuyenPB;
    }
}