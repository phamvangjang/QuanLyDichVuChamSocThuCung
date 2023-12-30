namespace QuanLyThuCungEntityFramwork
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colMadon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChungLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtChiphithuoc = new System.Windows.Forms.TextBox();
            this.lblChiphithuoc = new System.Windows.Forms.Label();
            this.grbdv = new System.Windows.Forms.GroupBox();
            this.rdbtnChamSocHo = new System.Windows.Forms.RadioButton();
            this.rdbtnChuaBenh = new System.Windows.Forms.RadioButton();
            this.colNgayNhan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTacvu = new System.Windows.Forms.GroupBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtNgayNhan = new System.Windows.Forms.DateTimePicker();
            this.txtSongay = new System.Windows.Forms.TextBox();
            this.txtTinhtrang = new System.Windows.Forms.TextBox();
            this.lblSongay = new System.Windows.Forms.Label();
            this.lblDichvu = new System.Windows.Forms.Label();
            this.lblNgaynhan = new System.Windows.Forms.Label();
            this.txtCanNang = new System.Windows.Forms.TextBox();
            this.lblCanNang = new System.Windows.Forms.Label();
            this.txtChungLoai = new System.Windows.Forms.TextBox();
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTinhtrang = new System.Windows.Forms.Label();
            this.lblChungloai = new System.Windows.Forms.Label();
            this.grbDSTC = new System.Windows.Forms.GroupBox();
            this.lvDanhSachThuCung = new System.Windows.Forms.ListView();
            this.txtTenThu = new System.Windows.Forms.TextBox();
            this.lblten = new System.Windows.Forms.Label();
            this.txtMadon = new System.Windows.Forms.TextBox();
            this.lblMadon = new System.Windows.Forms.Label();
            this.gbtttc = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbdv.SuspendLayout();
            this.grbTacvu.SuspendLayout();
            this.grbDSTC.SuspendLayout();
            this.gbtttc.SuspendLayout();
            this.SuspendLayout();
            // 
            // colMadon
            // 
            this.colMadon.Text = "Mã Đơn";
            this.colMadon.Width = 100;
            // 
            // colChungLoai
            // 
            this.colChungLoai.Text = "Chủng loại";
            this.colChungLoai.Width = 150;
            // 
            // txtChiphithuoc
            // 
            this.txtChiphithuoc.Location = new System.Drawing.Point(187, 412);
            this.txtChiphithuoc.Name = "txtChiphithuoc";
            this.txtChiphithuoc.Size = new System.Drawing.Size(231, 34);
            this.txtChiphithuoc.TabIndex = 17;
            // 
            // lblChiphithuoc
            // 
            this.lblChiphithuoc.AutoSize = true;
            this.lblChiphithuoc.Location = new System.Drawing.Point(9, 418);
            this.lblChiphithuoc.Name = "lblChiphithuoc";
            this.lblChiphithuoc.Size = new System.Drawing.Size(152, 29);
            this.lblChiphithuoc.TabIndex = 16;
            this.lblChiphithuoc.Text = "Chi phí thuốc";
            // 
            // grbdv
            // 
            this.grbdv.Controls.Add(this.rdbtnChamSocHo);
            this.grbdv.Controls.Add(this.rdbtnChuaBenh);
            this.grbdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbdv.Location = new System.Drawing.Point(104, 297);
            this.grbdv.Name = "grbdv";
            this.grbdv.Size = new System.Drawing.Size(314, 54);
            this.grbdv.TabIndex = 15;
            this.grbdv.TabStop = false;
            // 
            // rdbtnChamSocHo
            // 
            this.rdbtnChamSocHo.AutoSize = true;
            this.rdbtnChamSocHo.Location = new System.Drawing.Point(151, 18);
            this.rdbtnChamSocHo.Name = "rdbtnChamSocHo";
            this.rdbtnChamSocHo.Size = new System.Drawing.Size(161, 29);
            this.rdbtnChamSocHo.TabIndex = 1;
            this.rdbtnChamSocHo.TabStop = true;
            this.rdbtnChamSocHo.Text = "Chăm Sóc Hộ ";
            this.rdbtnChamSocHo.UseVisualStyleBackColor = true;
            this.rdbtnChamSocHo.CheckedChanged += new System.EventHandler(this.rdbtnChamSocHo_CheckedChanged);
            // 
            // rdbtnChuaBenh
            // 
            this.rdbtnChuaBenh.AutoSize = true;
            this.rdbtnChuaBenh.Location = new System.Drawing.Point(11, 18);
            this.rdbtnChuaBenh.Name = "rdbtnChuaBenh";
            this.rdbtnChuaBenh.Size = new System.Drawing.Size(132, 29);
            this.rdbtnChuaBenh.TabIndex = 0;
            this.rdbtnChuaBenh.TabStop = true;
            this.rdbtnChuaBenh.Text = "Chữa Bệnh";
            this.rdbtnChuaBenh.UseVisualStyleBackColor = true;
            this.rdbtnChuaBenh.CheckedChanged += new System.EventHandler(this.rdbtnChuaBenh_CheckedChanged);
            // 
            // colNgayNhan
            // 
            this.colNgayNhan.Text = "Ngày nhận";
            this.colNgayNhan.Width = 200;
            // 
            // grbTacvu
            // 
            this.grbTacvu.Controls.Add(this.btnThongKe);
            this.grbTacvu.Controls.Add(this.btnSapXep);
            this.grbTacvu.Controls.Add(this.btnSua);
            this.grbTacvu.Controls.Add(this.btnXoa);
            this.grbTacvu.Controls.Add(this.btnLuu);
            this.grbTacvu.Controls.Add(this.btnThem);
            this.grbTacvu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTacvu.Location = new System.Drawing.Point(15, 553);
            this.grbTacvu.Name = "grbTacvu";
            this.grbTacvu.Size = new System.Drawing.Size(1165, 96);
            this.grbTacvu.TabIndex = 7;
            this.grbTacvu.TabStop = false;
            this.grbTacvu.Text = "Tác Vụ ";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThongKe.Location = new System.Drawing.Point(999, 31);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(150, 50);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnSapXep
            // 
            this.btnSapXep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSapXep.Location = new System.Drawing.Point(807, 31);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(150, 50);
            this.btnSapXep.TabIndex = 4;
            this.btnSapXep.Text = "Sắp Xếp ";
            this.btnSapXep.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSua.Location = new System.Drawing.Point(608, 31);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 50);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXoa.Location = new System.Drawing.Point(406, 31);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 50);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLuu.Location = new System.Drawing.Point(218, 31);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 50);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThem.Location = new System.Drawing.Point(12, 31);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 50);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtNgayNhan
            // 
            this.dtNgayNhan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayNhan.Location = new System.Drawing.Point(167, 208);
            this.dtNgayNhan.Name = "dtNgayNhan";
            this.dtNgayNhan.Size = new System.Drawing.Size(251, 34);
            this.dtNgayNhan.TabIndex = 14;
            // 
            // txtSongay
            // 
            this.txtSongay.Location = new System.Drawing.Point(187, 366);
            this.txtSongay.Name = "txtSongay";
            this.txtSongay.Size = new System.Drawing.Size(231, 34);
            this.txtSongay.TabIndex = 13;
            // 
            // txtTinhtrang
            // 
            this.txtTinhtrang.Location = new System.Drawing.Point(167, 253);
            this.txtTinhtrang.Name = "txtTinhtrang";
            this.txtTinhtrang.Size = new System.Drawing.Size(251, 34);
            this.txtTinhtrang.TabIndex = 12;
            // 
            // lblSongay
            // 
            this.lblSongay.AutoSize = true;
            this.lblSongay.Location = new System.Drawing.Point(9, 372);
            this.lblSongay.Name = "lblSongay";
            this.lblSongay.Size = new System.Drawing.Size(106, 29);
            this.lblSongay.TabIndex = 11;
            this.lblSongay.Text = "Số ngày ";
            // 
            // lblDichvu
            // 
            this.lblDichvu.AutoSize = true;
            this.lblDichvu.Location = new System.Drawing.Point(9, 319);
            this.lblDichvu.Name = "lblDichvu";
            this.lblDichvu.Size = new System.Drawing.Size(97, 29);
            this.lblDichvu.TabIndex = 10;
            this.lblDichvu.Text = "Dịch vụ ";
            // 
            // lblNgaynhan
            // 
            this.lblNgaynhan.AutoSize = true;
            this.lblNgaynhan.Location = new System.Drawing.Point(9, 215);
            this.lblNgaynhan.Name = "lblNgaynhan";
            this.lblNgaynhan.Size = new System.Drawing.Size(133, 29);
            this.lblNgaynhan.TabIndex = 8;
            this.lblNgaynhan.Text = "Ngày nhận ";
            // 
            // txtCanNang
            // 
            this.txtCanNang.Location = new System.Drawing.Point(167, 163);
            this.txtCanNang.Name = "txtCanNang";
            this.txtCanNang.Size = new System.Drawing.Size(251, 34);
            this.txtCanNang.TabIndex = 7;
            // 
            // lblCanNang
            // 
            this.lblCanNang.AutoSize = true;
            this.lblCanNang.Location = new System.Drawing.Point(9, 166);
            this.lblCanNang.Name = "lblCanNang";
            this.lblCanNang.Size = new System.Drawing.Size(126, 29);
            this.lblCanNang.TabIndex = 6;
            this.lblCanNang.Text = "Cân Nặng ";
            // 
            // txtChungLoai
            // 
            this.txtChungLoai.Location = new System.Drawing.Point(167, 119);
            this.txtChungLoai.Name = "txtChungLoai";
            this.txtChungLoai.Size = new System.Drawing.Size(251, 34);
            this.txtChungLoai.TabIndex = 5;
            // 
            // colTen
            // 
            this.colTen.Text = "Tên thú cưng ";
            this.colTen.Width = 150;
            // 
            // lblTinhtrang
            // 
            this.lblTinhtrang.AutoSize = true;
            this.lblTinhtrang.Location = new System.Drawing.Point(9, 259);
            this.lblTinhtrang.Name = "lblTinhtrang";
            this.lblTinhtrang.Size = new System.Drawing.Size(127, 29);
            this.lblTinhtrang.TabIndex = 9;
            this.lblTinhtrang.Text = "Tình trạng ";
            // 
            // lblChungloai
            // 
            this.lblChungloai.AutoSize = true;
            this.lblChungloai.Location = new System.Drawing.Point(9, 122);
            this.lblChungloai.Name = "lblChungloai";
            this.lblChungloai.Size = new System.Drawing.Size(128, 29);
            this.lblChungloai.TabIndex = 4;
            this.lblChungloai.Text = "Chủng loại";
            // 
            // grbDSTC
            // 
            this.grbDSTC.Controls.Add(this.lvDanhSachThuCung);
            this.grbDSTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSTC.Location = new System.Drawing.Point(445, 69);
            this.grbDSTC.Name = "grbDSTC";
            this.grbDSTC.Size = new System.Drawing.Size(735, 467);
            this.grbDSTC.TabIndex = 6;
            this.grbDSTC.TabStop = false;
            this.grbDSTC.Text = "Danh sách thú cưng";
            // 
            // lvDanhSachThuCung
            // 
            this.lvDanhSachThuCung.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMadon,
            this.colTen,
            this.colChungLoai,
            this.colNgayNhan});
            this.lvDanhSachThuCung.FullRowSelect = true;
            this.lvDanhSachThuCung.GridLines = true;
            this.lvDanhSachThuCung.HideSelection = false;
            this.lvDanhSachThuCung.Location = new System.Drawing.Point(7, 34);
            this.lvDanhSachThuCung.Name = "lvDanhSachThuCung";
            this.lvDanhSachThuCung.Size = new System.Drawing.Size(722, 413);
            this.lvDanhSachThuCung.TabIndex = 0;
            this.lvDanhSachThuCung.UseCompatibleStateImageBehavior = false;
            this.lvDanhSachThuCung.View = System.Windows.Forms.View.Details;
            // 
            // txtTenThu
            // 
            this.txtTenThu.Location = new System.Drawing.Point(167, 75);
            this.txtTenThu.Name = "txtTenThu";
            this.txtTenThu.Size = new System.Drawing.Size(251, 34);
            this.txtTenThu.TabIndex = 3;
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.Location = new System.Drawing.Point(9, 78);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(152, 29);
            this.lblten.TabIndex = 2;
            this.lblten.Text = "Tên thú cưng";
            // 
            // txtMadon
            // 
            this.txtMadon.Location = new System.Drawing.Point(167, 31);
            this.txtMadon.Name = "txtMadon";
            this.txtMadon.Size = new System.Drawing.Size(251, 34);
            this.txtMadon.TabIndex = 1;
            // 
            // lblMadon
            // 
            this.lblMadon.AutoSize = true;
            this.lblMadon.Location = new System.Drawing.Point(9, 34);
            this.lblMadon.Name = "lblMadon";
            this.lblMadon.Size = new System.Drawing.Size(93, 29);
            this.lblMadon.TabIndex = 0;
            this.lblMadon.Text = "Mã đơn";
            // 
            // gbtttc
            // 
            this.gbtttc.Controls.Add(this.txtChiphithuoc);
            this.gbtttc.Controls.Add(this.lblChiphithuoc);
            this.gbtttc.Controls.Add(this.grbdv);
            this.gbtttc.Controls.Add(this.dtNgayNhan);
            this.gbtttc.Controls.Add(this.txtSongay);
            this.gbtttc.Controls.Add(this.txtTinhtrang);
            this.gbtttc.Controls.Add(this.lblSongay);
            this.gbtttc.Controls.Add(this.lblDichvu);
            this.gbtttc.Controls.Add(this.lblTinhtrang);
            this.gbtttc.Controls.Add(this.lblNgaynhan);
            this.gbtttc.Controls.Add(this.txtCanNang);
            this.gbtttc.Controls.Add(this.lblCanNang);
            this.gbtttc.Controls.Add(this.txtChungLoai);
            this.gbtttc.Controls.Add(this.lblChungloai);
            this.gbtttc.Controls.Add(this.txtTenThu);
            this.gbtttc.Controls.Add(this.lblten);
            this.gbtttc.Controls.Add(this.txtMadon);
            this.gbtttc.Controls.Add(this.lblMadon);
            this.gbtttc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtttc.Location = new System.Drawing.Point(15, 69);
            this.gbtttc.Name = "gbtttc";
            this.gbtttc.Size = new System.Drawing.Size(424, 467);
            this.gbtttc.TabIndex = 5;
            this.gbtttc.TabStop = false;
            this.gbtttc.Text = "Thông tin thú cưng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(836, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "QUẢN LÝ DOANH THU DỊCH VỤ CHĂM SÓC THÚ CƯNG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1216, 692);
            this.Controls.Add(this.grbTacvu);
            this.Controls.Add(this.grbDSTC);
            this.Controls.Add(this.gbtttc);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbdv.ResumeLayout(false);
            this.grbdv.PerformLayout();
            this.grbTacvu.ResumeLayout(false);
            this.grbDSTC.ResumeLayout(false);
            this.gbtttc.ResumeLayout(false);
            this.gbtttc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colMadon;
        private System.Windows.Forms.ColumnHeader colChungLoai;
        public System.Windows.Forms.TextBox txtChiphithuoc;
        private System.Windows.Forms.Label lblChiphithuoc;
        private System.Windows.Forms.GroupBox grbdv;
        public System.Windows.Forms.RadioButton rdbtnChamSocHo;
        public System.Windows.Forms.RadioButton rdbtnChuaBenh;
        private System.Windows.Forms.ColumnHeader colNgayNhan;
        private System.Windows.Forms.GroupBox grbTacvu;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThem;
        public System.Windows.Forms.DateTimePicker dtNgayNhan;
        public System.Windows.Forms.TextBox txtSongay;
        public System.Windows.Forms.TextBox txtTinhtrang;
        private System.Windows.Forms.Label lblSongay;
        private System.Windows.Forms.Label lblDichvu;
        private System.Windows.Forms.Label lblNgaynhan;
        public System.Windows.Forms.TextBox txtCanNang;
        private System.Windows.Forms.Label lblCanNang;
        public System.Windows.Forms.TextBox txtChungLoai;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.Label lblTinhtrang;
        private System.Windows.Forms.Label lblChungloai;
        private System.Windows.Forms.GroupBox grbDSTC;
        public System.Windows.Forms.ListView lvDanhSachThuCung;
        public System.Windows.Forms.TextBox txtTenThu;
        private System.Windows.Forms.Label lblten;
        public System.Windows.Forms.TextBox txtMadon;
        private System.Windows.Forms.Label lblMadon;
        private System.Windows.Forms.GroupBox gbtttc;
        private System.Windows.Forms.Label label1;
    }
}

