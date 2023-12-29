using ChamSocThuCungThreeModel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocThuCungThreeModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn việc đóng ứng dụng nếu người dùng không đồng ý.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            Bussiness.Instance.Xem(lvDanhSachThuCung);
        }

        private void rdbtnChuaBenh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnChuaBenh.Checked)
            {
                txtChiphithuoc.Visible = true;
                txtSongay.Visible = false;
                txtChiphithuoc.Clear();
                lblChiphithuoc.Visible = true;
                lblSongay.Visible = false;
            }
        }

        private void rdbtnChamSocHo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnChamSocHo.Checked)
            {
                txtChiphithuoc.Visible = false;
                txtSongay.Visible = true;
                txtSongay.Clear();
                lblSongay.Visible = true;
                lblChiphithuoc.Visible = false;
            }
        }
        public void Reset()
        {
            // Xóa dữ liệu trong các TextBox nhập liệu
            txtMadon.Text = string.Empty;
            txtTenThu.Text = string.Empty;
            txtChungLoai.Text = string.Empty;
            txtCanNang.Text = string.Empty;
            dtNgayNhan.Value = DateTime.Now;
            txtTinhtrang.Text = string.Empty;
            rdbtnChuaBenh.Checked = true;
            txtChiphithuoc.Text = string.Empty;
            txtSongay.Text = string.Empty;

            // Gán giá trị mặc định cho các TextBox nhập liệu
            txtMadon.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public new bool Validate
        {
            get
            {
                // Kiểm tra thông tin có hợp lệ
                if (string.IsNullOrEmpty(txtMadon.Text) || string.IsNullOrEmpty(txtTenThu.Text) || string.IsNullOrEmpty(txtChungLoai.Text) || string.IsNullOrEmpty(txtCanNang.Text) || string.IsNullOrEmpty(txtTinhtrang.Text))
                {
                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dtNgayNhan.Value > DateTime.Now)
                {
                    MessageBox.Show("Ngày nhận không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtSongay.Text.Any(n => !char.IsDigit(n)) && rdbtnChamSocHo.Checked)
                {
                    MessageBox.Show("Số ngày chăm sóc phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtChiphithuoc.Text.Any(n => !char.IsDigit(n)) && rdbtnChuaBenh.Checked)
                {
                    MessageBox.Show("Chi phí thuốc phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin có hợp lệ
            if (Validate)
            {
                Bussiness.Instance.Luu(lvDanhSachThuCung);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                //hien thi hop thoai xac nhan
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa thu cung này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //lay dong duoc chon
                    ListViewItem selectedRow = lvDanhSachThuCung.SelectedItems[0];
                    // Lấy thông tin của phim từ dòng được chọn
                    string maDon = lvDanhSachThuCung.SelectedItems[0].SubItems[0].Text;
                    // Lấy index của dòng để xóa
                    int indexToRemove = selectedRow.Index;

                    // Xóa dòng khỏi ListView
                    lvDanhSachThuCung.Items.Remove(selectedRow);

                    // Chọn dòng liền kề sau nếu có
                    if (indexToRemove < lvDanhSachThuCung.Items.Count)
                    {
                        lvDanhSachThuCung.Items[indexToRemove].Selected = true;
                        lvDanhSachThuCung.Select();
                    }
                    else if (indexToRemove > 0)
                    {
                        // Nếu không có dòng liền kề sau, chọn dòng liền kề trước
                        lvDanhSachThuCung.Items[indexToRemove - 1].Selected = true;
                        lvDanhSachThuCung.Select();
                    }
                    else
                    {
                        // Nếu không còn dòng nào trong ListView, xóa thông tin ở bảng điều khiển và đưa trỏ chuột lên txtMaDon
                        Reset();
                    }

                    // Thực hiện xóa từ cơ sở dữ liệu
                    Bussiness.Instance.XoaThongtinTheoMaDon(maDon);
                    MessageBox.Show("Đã xóa thú cưng thành công!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thu cung nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void lvDanhSachThuCung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                // Lấy giá trị của cột "Mã Đơn" từ dòng được chọn
                string maDon = lvDanhSachThuCung.SelectedItems[0].SubItems[0].Text;

                // Gọi phương thức trong Bussiness để lấy thông tin chi tiết từ cơ sở dữ liệu
                ThuCung thuCung = Bussiness.Instance.LayThongTinPhimTheoMaDon(maDon);
                txtMadon.Text = thuCung.MaDon.ToString();
                txtTenThu.Text = thuCung.TenThu.ToString();
                txtChungLoai.Text = thuCung.Chungloai.ToString();
                txtCanNang.Text=thuCung.Cannang.ToString();
                dtNgayNhan.Text = thuCung.NgayNhan.Date.ToString();
                txtTinhtrang.Text=thuCung.TinhTrang.ToString();
                if (thuCung.DichVu == "Chữa bệnh")
                {
                    rdbtnChuaBenh.Checked = true;
                }
                else if (thuCung.DichVu == "Chăm sóc hộ")
                {
                    rdbtnChamSocHo.Checked = true;
                }
                if (thuCung.ChiPhiThuoc == 0)
                {
                    lblChiphithuoc.Visible = false;
                    txtChiphithuoc.Visible = false;
                    rdbtnChamSocHo.Checked = true;
                    rdbtnChuaBenh.Checked = false;
                    lblSongay.Visible = true;
                    txtSongay.Visible = true;
                    txtSongay.Text = thuCung.Songay.ToString();
                }
                else if (thuCung.Songay == 0)
                {
                    lblSongay.Visible = false;
                    txtSongay.Visible = false;
                    rdbtnChamSocHo.Checked = false;
                    rdbtnChuaBenh.Checked = true;
                    lblChiphithuoc.Visible = true;
                    txtChiphithuoc.Visible = true;
                    txtChiphithuoc.Text = thuCung.ChiPhiThuoc.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (Validate)
            {
                Bussiness.Instance.Sua(lvDanhSachThuCung);
                lvDanhSachThuCung.Items.Clear();
                Bussiness.Instance.Xem(lvDanhSachThuCung);
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            lvDanhSachThuCung.Items.Clear();
            Bussiness.Instance.SapXepThuCung(lvDanhSachThuCung);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Bussiness.Instance.ThongKe();
        }
    }
}
