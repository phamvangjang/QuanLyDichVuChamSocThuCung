using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Ngăn chặn việc đóng ứng dụng nếu người dùng không đồng ý.
            }
        }

        private void ResetListView(IEnumerable<ThuCung> tc)
        {
            lvDanhSachThuCung.Items.Clear();
            foreach (var a in tc)
            {
                ListViewItem listViewItem = new ListViewItem(a.MaDon);
                listViewItem.SubItems.Add(a.TenThuCung.ToString());
                listViewItem.SubItems.Add(a.ChungLoai.ToString());
                listViewItem.SubItems.Add(a.NgayNhan.Value.ToString("dd/MM/yyyy"));
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

            txtMadon.Enabled = true;
            txtMadon.Focus();
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
                    float cpt = 0;
                    int sn = 0;
                    if (rdbtnChuaBenh.Checked)
                    {
                        cpt = float.Parse(txtChiphithuoc.Text);
                        tcp += (float.Parse(txtChiphithuoc.Text) + 100000);
                    }
                    else
                    {
                        sn = int.Parse(txtSongay.Text);
                        tcp += (float.Parse(txtSongay.Text) * 200000);
                    }
                    //save to db
                    _db.ThuCungs.Add(new ThuCung() { MaDon = txtMadon.Text, TenThuCung = txtTenThu.Text, ChungLoai = txtChungLoai.Text, CanNang = int.Parse(txtCanNang.Text), NgayNhan = dtNgayNhan.Value, TinhTrang = txtTinhtrang.Text, DichVu = rdbtnChuaBenh.Checked ? "ChuaBenh" : "ChamSocHo", ChiPhiThuoc = cpt, SoNgay = sn, Tong = tcp });
                    _db.SaveChanges();

                    //show to listview
                    ListViewItem listViewItem = new ListViewItem(txtMadon.Text);
                    listViewItem.SubItems.Add(txtTenThu.Text);
                    listViewItem.SubItems.Add(rdbtnChuaBenh.Checked ? "ChuaBenh" : "ChamSocHo");
                    listViewItem.SubItems.Add(dtNgayNhan.Value.ToString("dd/MM/yyyy"));

                    //hight light listviewitem 
                    int cn = int.Parse(txtCanNang.Text);
                    lvDanhSachThuCung.Items.Add(listViewItem);
                    listViewItem.Selected = true;

                    if (cn >= 40)
                    {
                        listViewItem.BackColor = Color.LightGoldenrodYellow;
                    }
                    MessageBox.Show("Đã thêm thú cưng thành công!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    Reset();
                }
            }
        }

        private void lvDanhSachThuCung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                //get id in listview
                string madon = lvDanhSachThuCung.SelectedItems[0].SubItems[0].Text;
                txtMadon.Enabled = false;
                //find in _db if exists ?
                var thu = _db.ThuCungs.SingleOrDefault(z => z.MaDon == madon);
                if (thu != null)
                {
                    txtMadon.Text = thu.MaDon.Trim();
                    txtTenThu.Text = thu.TenThuCung.Trim();
                    txtChungLoai.Text = thu.ChungLoai.Trim();
                    txtCanNang.Text = thu.CanNang.ToString().Trim();
                    dtNgayNhan.Value = thu.NgayNhan.Value;
                    txtTinhtrang.Text = thu.TinhTrang.Trim();
                    if (thu.DichVu.ToString() == "ChuaBenh")
                    {
                        rdbtnChuaBenh.Checked = true;
                        txtChiphithuoc.Text = thu.ChiPhiThuoc.ToString();
                        txtSongay.Clear();
                    }
                    else
                    {
                        rdbtnChamSocHo.Checked = true;
                        txtSongay.Text = thu.SoNgay.ToString().Trim();
                        txtChiphithuoc.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã thú cưng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa thú cưng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = lvDanhSachThuCung.Items.IndexOf(lvDanhSachThuCung.SelectedItems[0]);
                    string mathu = lvDanhSachThuCung.SelectedItems[0].SubItems[0].Text.Trim();

                    ThuCung thu = _db.ThuCungs.Where(p => p.MaDon.Trim() == mathu).SingleOrDefault();
                    _db.ThuCungs.Remove(thu);
                    _db.SaveChanges();

                    lvDanhSachThuCung.Items.Remove(lvDanhSachThuCung.SelectedItems[0]);

                    if (lvDanhSachThuCung.Items.Count > 0)
                    {
                        if (index < lvDanhSachThuCung.Items.Count)
                        {
                            lvDanhSachThuCung.Items[index].Selected = true;
                        }
                        else
                        {
                            Reset();
                        }
                    }
                    else if (lvDanhSachThuCung.Items.Count == 0)
                    {
                        Reset();
                    }
                }
                MessageBox.Show("Đã xóa thú cưng thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thú cưng nào để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                int index = lvDanhSachThuCung.Items.IndexOf(lvDanhSachThuCung.SelectedItems[0]);
                string mathu = lvDanhSachThuCung.SelectedItems[0].SubItems[0].Text.Trim();

                ThuCung thu = _db.ThuCungs.Where(p => p.MaDon.Trim() == mathu).SingleOrDefault();
                float tcp = 0;
                float cpt = 0;
                int sn = 0;
                if (rdbtnChuaBenh.Checked)
                {
                    tcp += (float.Parse(txtChiphithuoc.Text) + 100000);
                    cpt = float.Parse(txtChiphithuoc.Text);
                }
                else
                {
                    tcp += (float.Parse(txtSongay.Text) * 200000);
                    sn = int.Parse(txtSongay.Text);
                }

                if (Validate())
                {
                    thu.TenThuCung = txtTenThu.Text;
                    thu.ChungLoai = txtChungLoai.Text;
                    thu.CanNang = int.Parse(txtCanNang.Text);
                    thu.NgayNhan = dtNgayNhan.Value;
                    thu.CanNang = int.Parse(txtCanNang.Text);
                    thu.TinhTrang = txtTinhtrang.Text;
                    thu.DichVu = rdbtnChuaBenh.Checked ? "ChuaBenh" : "ChamSocHo";
                    thu.ChiPhiThuoc = cpt;
                    thu.SoNgay = sn;
                    thu.Tong = tcp;
                    _db.SaveChanges();
                    txtMadon.Enabled = true;
                    ResetListView(_db.ThuCungs.ToList());
                    Reset();
                    MessageBox.Show("Đã sửa thú cưng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thú cưng nào để sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            try
            {
                var sort = _db.ThuCungs.OrderByDescending(p => p.NgayNhan ).ThenBy(p => p.CanNang).ToList();
                ResetListView(sort);
                MessageBox.Show("Đã sắp xếp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                var s = from thu in _db.ThuCungs
                        group thu by thu.DichVu into g
                        select new
                        {
                            dvu = g.Key,
                            Socon = g.Count(),
                            Chiphi = g.Sum(p => p.Tong)
                        };

                string message = "Thống kê theo loại thú cưng\n\n";

                foreach (var t in s)
                {
                    if (t.dvu== "ChuaBenh")
                        message += $"Thú cưng bệnh:\n";
                    else
                        message += $"Thú cưng bình thường:\n";
                    message += $"Số lượng: {t.Socon}\n";
                    message += $"Tổng chi phí: {t.Chiphi:#,#}\n\n";
                }

                MessageBox.Show(message, "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
