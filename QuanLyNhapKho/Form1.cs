using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhapKho
{
    public partial class Form1 : Form
    {
        db_QuanLyNhapKhoEntitiesa _db = new db_QuanLyNhapKhoEntitiesa();
        public Form1()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            foreach (ListViewItem item in lvdssp.Items)
            {
                item.Selected = false;
            }
            txtMasp.Clear();
            txtTensp.Clear();
            cbbDmuc.ResetText();
            txtSL.Clear();
            txtDG.Clear();
            rdbtnHCM.Checked = true;
            dtNnhap.Value=DateTime.Now;
            txtMasp.Enabled = true;
            txtMasp.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            ResetListView(_db.SanPhams.ToList());
        }

        private void ResetListView(IEnumerable<SanPham> sanPhams)
        {
            lvdssp.Items.Clear();
            foreach (var a in sanPhams)
            {
                ListViewItem listViewItem = new ListViewItem(a.masp);
                listViewItem.SubItems.Add(a.tensp.ToString());
                listViewItem.SubItems.Add(a.dmuc.ToString());
                listViewItem.SubItems.Add(a.sluong.ToString());
                listViewItem.SubItems.Add(a.dgia.ToString());
                listViewItem.SubItems.Add(a.kho.ToString());
                listViewItem.SubItems.Add(a.ngaynhap.Value.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(a.ttien.ToString());

                lvdssp.Items.Add(listViewItem);
            }

            txtTtien.Clear();
            var thanhtien = _db.SanPhams.Sum(d => d.ttien);
            txtTtien.Text = thanhtien.ToString()+" USD";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            cbbDmuc.SelectedText = "Điện thoại";
        }

        private bool validate
        {
            get
            {
                if ( string.IsNullOrEmpty(txtMasp.Text) || string.IsNullOrEmpty(txtTensp.Text) || string.IsNullOrEmpty(cbbDmuc.Text) || string.IsNullOrEmpty(txtSL.Text) || string.IsNullOrEmpty(txtDG.Text) )
                {
                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (dtNnhap.Value > DateTime.Now)
                {
                    MessageBox.Show("Ngày nhập không được lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtSL.Text.Any(n => !char.IsDigit(n)))
                {
                    MessageBox.Show("Số lượng phải là số dương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDG.Text.Any(n => !char.IsDigit(n)))
                {
                    MessageBox.Show("Đơn giá là số dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (validate)
            {
                bool a = _db.SanPhams.Any(b => b.masp == txtMasp.Text);
                if (a)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    float tt = 0;
                    tt = int.Parse(txtSL.Text) * float.Parse(txtDG.Text);
                    string kh = "";
                    if (rdbtnHCM.Checked)
                    {
                        kh = "tp HCM";
                    }
                    else if (rdbtnDN.Checked)
                    {
                        kh = "Đà nẵng";
                    }
                    else
                    {
                        kh = "tp Hà Nội";
                    }
                    //save to db
                    _db.SanPhams.Add(new SanPham() { masp=txtMasp.Text, tensp=txtTensp.Text, dmuc=cbbDmuc.Text, sluong=int.Parse(txtSL.Text), dgia=float.Parse(txtDG.Text), kho=kh, ngaynhap=dtNnhap.Value, ttien=tt });
                    _db.SaveChanges();

                    //show to listview
                    ResetListView(_db.SanPhams.ToList());
                }
            }
        }

        private void lvdssp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvdssp.SelectedItems.Count > 0)
            {
                //get id in listview
                string madon = lvdssp.SelectedItems[0].SubItems[0].Text;
                txtMasp.Enabled = false;
                //find in _db if exists ?
                var spham = _db.SanPhams.SingleOrDefault(z => z.masp == madon);
                if (spham != null)
                {
                    txtMasp.Text = spham.masp.Trim();
                    txtTensp.Text = spham.tensp.Trim();
                    cbbDmuc.Text = spham.dmuc.Trim();
                    txtSL.Text = spham.sluong.ToString().Trim();
                    txtDG.Text = spham.dgia.ToString().Trim();
                    if (spham.kho.ToString() == "tp,HCM")
                    {
                        rdbtnHCM.Checked = true;
                    }
                    else if (spham.kho.ToString() == "Đà nẵng")
                    {
                        rdbtnDN.Checked = true;
                    }
                    else
                    {
                        rdbtnHN.Checked = true;
                    }
                    dtNnhap.Value = spham.ngaynhap.Value;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvdssp.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = lvdssp.Items.IndexOf(lvdssp.SelectedItems[0]);
                    string masp = lvdssp.SelectedItems[0].SubItems[0].Text.Trim();

                    SanPham sanPham = _db.SanPhams.Where(p => p.masp.Trim() == masp).SingleOrDefault();
                    _db.SanPhams.Remove(sanPham);
                    _db.SaveChanges();

                    lvdssp.Items.Remove(lvdssp.SelectedItems[0]);

                    if (lvdssp.Items.Count > 0)
                    {
                        if (index < lvdssp.Items.Count)
                        {
                            lvdssp.Items[index].Selected = true;
                        }
                        else
                        {
                            Reset();
                        }
                    }
                    else if (lvdssp.Items.Count == 0)
                    {
                        Reset();
                    }
                }
                MessageBox.Show("Đã xóa sản phẩm thành công", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào để xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvdssp.SelectedItems.Count > 0)
            {
                int index = lvdssp.Items.IndexOf(lvdssp.SelectedItems[0]);
                string mathu = lvdssp.SelectedItems[0].SubItems[0].Text.Trim();

                SanPham thu = _db.SanPhams.Where(p => p.masp.Trim() == mathu).SingleOrDefault();
                float tt = 0;
                tt = int.Parse(txtSL.Text) * float.Parse(txtDG.Text);
                string kh = "";
                if (rdbtnHCM.Checked)
                {
                    kh = "tp HCM";
                }
                else if (rdbtnDN.Checked)
                {
                    kh = "Đà nẵng";
                }
                else
                {
                    kh = "tp Hà Nội";
                }

                if (validate)
                {
                    thu.tensp = txtTensp.Text;
                    thu.dmuc = cbbDmuc.Text;
                    thu.sluong = int.Parse(txtSL.Text);
                    thu.dgia = float.Parse(txtDG.Text);
                    thu.kho = kh;
                    thu.ngaynhap = dtNnhap.Value;
                    thu.ttien = tt;
                    _db.SaveChanges();
                    txtMasp.Enabled = true;
                    ResetListView(_db.SanPhams.ToList());
                    MessageBox.Show("Đã sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào để sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
