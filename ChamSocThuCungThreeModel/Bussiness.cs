using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChamSocThuCungThreeModel.Model;

namespace ChamSocThuCungThreeModel
{
    class Bussiness
    {

        private static Bussiness instance;
        internal static Bussiness Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bussiness();
                }
                return instance;
            }
        }

        public Bussiness() { }
        public void Xem(ListView listView)
        {
            foreach (DataRow row in DAO.Instance.Xem().Rows)
            {
                ListViewItem item = new ListViewItem(row["MaDon"].ToString());
                item.SubItems.Add(row["TenThuCung"].ToString());
                item.SubItems.Add(row["ChungLoai"].ToString());
                item.SubItems.Add(row["NgayNhan"].ToString());
                int canNang = int.Parse(row["CanNang"].ToString());

                if (canNang > 40)
                {
                    item.BackColor = Color.LightGoldenrodYellow;
                }
                listView.Items.Add(item);
            }
        }

        public void Luu(ListView lv)
        {
            ThuCung thuCung = new ThuCung();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                //save to listview
                string ngaynhan = form1.dtNgayNhan.Value.ToShortDateString();
                ListViewItem listViewItem = new ListViewItem(form1.txtMadon.Text);
                listViewItem.SubItems.Add(form1.txtTenThu.Text);
                listViewItem.SubItems.Add(form1.txtChungLoai.Text);
                listViewItem.SubItems.Add(ngaynhan);
                form1.lvDanhSachThuCung.Items.Add(listViewItem);

                //save info form object
                thuCung.MaDon = form1.txtMadon.Text;
                thuCung.TenThu = form1.txtTenThu.Text;
                thuCung.Chungloai = form1.txtChungLoai.Text;
                int canNang = Convert.ToInt32(form1.txtCanNang.Text);
                thuCung.Cannang = canNang;
                thuCung.NgayNhan = DateTime.Parse(ngaynhan);
                thuCung.TinhTrang = form1.txtTinhtrang.Text;

                //hight light height for thu cung
                if (canNang > 40)
                {
                    listViewItem.BackColor = Color.LightGoldenrodYellow;
                }

                if (form1.rdbtnChuaBenh.Checked)
                {
                    thuCung.DichVu = "ChuaBenh";
                    thuCung.ChiPhiThuoc = float.Parse(form1.txtChiphithuoc.Text);
                    thuCung.TongChiPhi = 100000 + float.Parse(form1.txtChiphithuoc.Text);
                    thuCung.Songay = 0;
                }
                else if (form1.rdbtnChamSocHo.Checked)
                {
                    thuCung.DichVu = "ChamSocHo";
                    thuCung.Songay = int.Parse(form1.txtSongay.Text);
                    thuCung.TongChiPhi = 200000 * int.Parse(form1.txtSongay.Text);
                    thuCung.ChiPhiThuoc = 0;
                }
                DAO.Instance.LuuThuCung(thuCung);
                MessageBox.Show("Đã thêm thú cưng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool XoaThongtinTheoMaDon(string maDon)
        {
            return DAO.Instance.XoaThongtinTheoMaDon(maDon);
        }

        public ThuCung LayThongTinPhimTheoMaDon(string maDon)
        {
            ThuCung thuCungs = new ThuCung();
            DataTable dataTable = DAO.Instance.LayThongTinPhimTheoMaDon(maDon);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                thuCungs.MaDon = dataRow[0].ToString();
                thuCungs.TenThu = dataRow[1].ToString();
                thuCungs.Chungloai = dataRow[2].ToString();
                thuCungs.Cannang = Convert.ToInt32(dataRow[3].ToString());
                thuCungs.NgayNhan = DateTime.Parse(dataRow[4].ToString());
                thuCungs.TinhTrang = dataRow[5].ToString();
                thuCungs.DichVu = dataRow[6].ToString();
                if (dataRow[6].ToString() == "ChuaBenh")
                {
                    thuCungs.ChiPhiThuoc = float.Parse(dataRow[7].ToString());
                    thuCungs.Songay = 0;
                }
                else
                {
                    thuCungs.Songay = int.Parse(dataRow[8].ToString());
                    thuCungs.ChiPhiThuoc = 0;
                }
                thuCungs.TongChiPhi = float.Parse(dataRow[9].ToString());
            }
            return thuCungs;
        }

        public void Sua(ListView listView)
        {
            ThuCung thuCung = new ThuCung();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1.lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                string madon = form1.lvDanhSachThuCung.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(madon))
                {
                    string ngaynhan = form1.dtNgayNhan.Value.ToShortDateString();
                    thuCung.TenThu = form1.txtTenThu.Text;
                    thuCung.Chungloai = form1.txtChungLoai.Text;
                    thuCung.Cannang = Convert.ToInt32(form1.txtCanNang.Text);
                    thuCung.NgayNhan = DateTime.Parse(ngaynhan);
                    thuCung.TinhTrang = form1.txtTinhtrang.Text;
                    if (form1.rdbtnChuaBenh.Checked)
                    {
                        thuCung.DichVu = "ChuaBenh";
                        thuCung.ChiPhiThuoc = float.Parse(form1.txtChiphithuoc.Text);
                        thuCung.Songay = 0;
                        thuCung.TongChiPhi = 100000 + float.Parse(form1.txtChiphithuoc.Text);
                        
                    }
                    else if (form1.rdbtnChamSocHo.Checked)
                    {
                        thuCung.DichVu = "ChamSocHo";
                        thuCung.Songay = int.Parse(form1.txtChiphithuoc.Text);
                        thuCung.ChiPhiThuoc = 0;
                        thuCung.TongChiPhi = 200000 * float.Parse(form1.txtSongay.Text);
                    }
                    DAO.Instance.SuaThuCung(thuCung, madon);
                    MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thú cưng nào để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void SapXepThuCung(ListView listView)
        {
            foreach (DataRow row in DAO.Instance.SapXepThuCung().Rows)
            {
                ListViewItem item = new ListViewItem(row["MaDon"].ToString());
                item.SubItems.Add(row["TenThuCung"].ToString());
                item.SubItems.Add(row["ChungLoai"].ToString());
                item.SubItems.Add(row["NgayNhan"].ToString());

                //hightlight listview if height >40
                int height = int.Parse(row["CanNang"].ToString());
                if (height > 40)
                {
                    item.BackColor = Color.LightGoldenrodYellow;
                }

                listView.Items.Add(item);
            }
        }

        public void ThongKe()
        {
            DataTable dataTable = DAO.Instance.ThongKe();
            DataRow dataRow1 = dataTable.Rows[1];
            int slcbenh = dataRow1.Field<int>("TongSoLuong");
            double dtcbenh = dataRow1.Field<double>("TongDoanhThuChuaBenh");

            DataRow dataRow2 = dataTable.Rows[0];
            int slcsho = dataRow2.Field<int>("TongSoLuong");
            double dtcsho = dataRow2.Field<double>("TongDoanhThuChamSocHo");

            MessageBox.Show("Số lượng thú chữa bệnh: " + slcbenh + " Con\n" +
                            "Doanh thu thú chữa bệnh: " + (dtcbenh + slcbenh * 100000) + " VND\n" +
                            "Số lượng thú chăm sóc hộ: " + slcsho + " Con\n" +
                            "Doanh thu thú chăm sóc hộ: " + (dtcsho + slcsho * 200000 + " VND"),
                            "Thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
