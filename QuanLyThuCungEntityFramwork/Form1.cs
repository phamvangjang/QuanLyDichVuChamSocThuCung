using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuCungEntityFramwork
{
    public partial class Form1 : Form
    {
        QLThuCungEntities _db = new QLThuCungEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            ResetListView(_db.ThuCungs.ToList());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn việc đóng ứng dụng nếu người dùng không đồng ý.
            }
            */
        }

        private void ResetListView(IEnumerable<ThuCung> tc)
        {
            lvDanhSachThuCung.Items.Clear();
            foreach (var a in tc)
            {
                ListViewItem listViewItem = new ListViewItem(a.MaDon);
                listViewItem.SubItems.Add(a.TenThuCung.ToString());
                listViewItem.SubItems.Add(a.ChungLoai.ToString());
                listViewItem.SubItems.Add(a.NgayNhan.ToString());
                int cn = int.Parse(a.CanNang.ToString());
                if (cn >= 40)
                {
                    listViewItem.BackColor = Color.LightGoldenrodYellow;
                }

                lvDanhSachThuCung.Items.Add(listViewItem);
            }
        }

        private void Reset()
        {
            foreach (ListViewItem item in lvDanhSachThuCung.Items)
            {
                item.Selected = false;
            }

            txtMadon.Clear();
            txtTenThu.Clear();
            txtChungLoai.Clear();
            txtCanNang.Clear();
            dtNgayNhan.Value = DateTime.Now;
            txtTinhtrang.Clear();
            rdbtnChuaBenh.Checked = true;
            txtChiphithuoc.Clear();
            txtSongay.Clear();
        }

        private void rdbtnChuaBenh_CheckedChanged(object sender, EventArgs e)
        {
            txtChiphithuoc.Visible = true;
            lblChiphithuoc.Visible = true;
            txtChiphithuoc.Clear();
            txtSongay.Visible = false;
            lblSongay.Visible = false;
        }

        private void rdbtnChamSocHo_CheckedChanged(object sender, EventArgs e)
        {
            txtChiphithuoc.Visible = false;
            lblChiphithuoc.Visible = false;
            txtSongay.Clear();
            txtSongay.Visible = true;
            lblSongay.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            txtMadon.Focus();
        }

        private new bool Validate()
        {
            if (string.IsNullOrEmpty(txtMadon.Text) || string.IsNullOrEmpty(txtTenThu.Text) || string.IsNullOrEmpty(txtChungLoai.Text) || string.IsNullOrEmpty(txtCanNang.Text) || string.IsNullOrEmpty(txtTinhtrang.Text) || (string.IsNullOrEmpty(txtChiphithuoc.Text) && rdbtnChuaBenh.Checked) || (string.IsNullOrEmpty(txtSongay.Text) && rdbtnChamSocHo.Checked))
            {
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtNgayNhan.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày nhận không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCanNang.Text.Any(n => !char.IsDigit(n)))
            {
                MessageBox.Show("Cân nặng phải là số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtChiphithuoc.Text.Any(n => !char.IsDigit(n)) && rdbtnChuaBenh.Checked)
            {
                MessageBox.Show("Chi phí thuốc phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSongay.Text.Any(n => !char.IsDigit(n)) && rdbtnChamSocHo.Checked)
            {
                MessageBox.Show("Số ngày phải là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                bool a = _db.ThuCungs.Any(b => b.MaDon == txtMadon.Text);
                if (a)
                {
                    MessageBox.Show("Mã thú cưng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float tcp = 0;
                    if (rdbtnChuaBenh.Checked)
                    {
                        tcp += (float.Parse(txtChiphithuoc.Text) + 100000);
                    }
                    else
                    {
                        tcp += (float.Parse(txtSongay.Text) * 200000);
                    }
                    //save to db
                    _db.ThuCungs.Add(new ThuCung() { MaDon = txtMadon.Text, TenThuCung = txtTenThu.Text, ChungLoai = txtChungLoai.Text, CanNang = int.Parse(txtCanNang.Text), NgayNhan = dtNgayNhan.Value, TinhTrang = txtTinhtrang.Text, DichVu = rdbtnChuaBenh.Checked ? "ChuaBenh" : "ChamSocHo", ChiPhiThuoc = float.Parse(txtChiphithuoc.Text), SoNgay = int.Parse(txtSongay.Text, Tong = tcp });
                    _db.SaveChanges();

                    //show to listview
                    ListViewItem listViewItem = new ListViewItem(txtMadon.Text);
                    listViewItem.SubItems.Add(txtTenThu.Text);
                    listViewItem.SubItems.Add(rdbtnChuaBenh.Checked ? "ChuaBenh" : "ChamSocHo");
                    listViewItem.SubItems.Add(dtNgayNhan.Value.ToString("dd/MM/yyyy"));

                    //hight light listviewitem 
                    int cn = int.Parse(txtCanNang.ToString());
                    lvDanhSachThuCung.Items.Add(listViewItem);
                    listViewItem.Selected = true;

                    if (cn >= 40)
                    {
                        listViewItem.BackColor = Color.LightGoldenrodYellow;
                    }
                }
            }
        }
    }
}
