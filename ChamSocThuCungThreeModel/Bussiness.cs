using System;
using System.Collections.Generic;
using System.Data;
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
                listView.Items.Add(item);
            }
        }

        public void Luu(ListView lv)
        {
            ThuCungBenh thuCungBenh = new ThuCungBenh();
            ThuCungBinhThuong thuCungBinhThuong = new ThuCungBinhThuong();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                if (form1.rdbtnChuaBenh.Checked)
                {
                    string ngaynhan = form1.dtNgayNhan.Value.ToShortDateString();
                    ListViewItem listViewItem = new ListViewItem(form1.txtMadon.Text);
                    listViewItem.SubItems.Add(form1.txtTenThu.Text);
                    listViewItem.SubItems.Add(form1.txtChungLoai.Text);
                    listViewItem.SubItems.Add(ngaynhan);

                    form1.lvDanhSachThuCung.Items.Add(listViewItem);

                    thuCungBenh.MaDon = form1.txtMadon.Text;
                    thuCungBenh.TenThu = form1.txtTenThu.Text;
                    thuCungBenh.Chungloai = form1.txtChungLoai.Text;
                    thuCungBenh.Cannang = Convert.ToInt32(form1.txtCanNang.Text);
                    thuCungBenh.NgayNhan = DateTime.Parse(ngaynhan);
                    thuCungBenh.TinhTrang = form1.txtTinhtrang.Text;
                    string dichvu = "Chữa bệnh";
                    thuCungBenh.DichVu = dichvu;
                    thuCungBenh.ChiPhiThuoc = float.Parse(form1.txtChiphithuoc.Text);

                    DAO.Instance.LuuThuCungBenh(thuCungBenh);
                    MessageBox.Show("Đã thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (form1.rdbtnChamSocHo.Checked)
                {
                    string ngaynhan = form1.dtNgayNhan.Value.ToShortDateString();
                    ListViewItem listViewItem = new ListViewItem(form1.txtMadon.Text);
                    listViewItem.SubItems.Add(form1.txtTenThu.Text);
                    listViewItem.SubItems.Add(form1.txtChungLoai.Text);
                    listViewItem.SubItems.Add(ngaynhan);

                    form1.lvDanhSachThuCung.Items.Add(listViewItem);

                    thuCungBinhThuong.MaDon = form1.txtMadon.Text;
                    thuCungBinhThuong.TenThu = form1.txtTenThu.Text;
                    thuCungBinhThuong.Chungloai = form1.txtChungLoai.Text;
                    thuCungBinhThuong.Cannang = Convert.ToInt32(form1.txtCanNang.Text);
                    thuCungBinhThuong.NgayNhan = DateTime.Parse(ngaynhan);
                    thuCungBinhThuong.TinhTrang = form1.txtTinhtrang.Text;
                    string dichvu = "Chăm sóc hộ";
                    thuCungBinhThuong.DichVu = dichvu;
                    thuCungBinhThuong.ChiPhiThuoc = Convert.ToInt32(form1.txtSongay.Text);

                    DAO.Instance.LuuThuCungBth(thuCungBinhThuong);
                    MessageBox.Show("Đã thêm phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                if (dataRow[7].ToString() != "")
                {
                    thuCungs.ChiPhiThuoc = float.Parse(dataRow[7].ToString());
                    thuCungs.Songay = 0;
                }
                else
                {
                    thuCungs.Songay = int.Parse(dataRow[8].ToString());
                    thuCungs.ChiPhiThuoc = 0;
                }
            }
            return thuCungs;
        }

        public void Sua(ListView listView)
        {
            ThuCungBenh thuCungBenh = new ThuCungBenh();
            ThuCungBinhThuong thuCungBinhThuong = new ThuCungBinhThuong();
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1.lvDanhSachThuCung.SelectedItems.Count > 0)
            {
                string madon = form1.lvDanhSachThuCung.SelectedItems[0].Text;
                if (!string.IsNullOrEmpty(madon))
                {
                    string ngaynhan = form1.dtNgayNhan.Value.ToShortDateString();
                    if (form1.rdbtnChuaBenh.Checked)
                    {
                        thuCungBenh.TenThu = form1.txtTenThu.Text;
                        thuCungBenh.Chungloai = form1.txtChungLoai.Text;
                        thuCungBenh.Cannang = Convert.ToInt32(form1.txtCanNang.Text);
                        thuCungBenh.NgayNhan = DateTime.Parse(ngaynhan);
                        thuCungBenh.TinhTrang = form1.txtTinhtrang.Text;
                        thuCungBenh.DichVu = "Chữa bệnh";
                        thuCungBenh.ChiPhiThuoc = float.Parse(form1.txtChiphithuoc.Text);
                        DAO.Instance.SuaThuCungBenh(thuCungBenh, madon);
                        MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (form1.rdbtnChamSocHo.Checked)
                    {
                        thuCungBinhThuong.TenThu = form1.txtTenThu.Text;
                        thuCungBinhThuong.Chungloai = form1.txtChungLoai.Text;
                        thuCungBinhThuong.Cannang = Convert.ToInt32(form1.txtCanNang.Text);
                        thuCungBinhThuong.NgayNhan = DateTime.Parse(ngaynhan);
                        thuCungBinhThuong.TinhTrang = form1.txtTinhtrang.Text;
                        thuCungBinhThuong.DichVu = "Chăm sóc hộ";
                        thuCungBinhThuong.Songay = int.Parse(form1.txtChiphithuoc.Text);
                        DAO.Instance.SuathuCungBth(thuCungBinhThuong, madon);
                        MessageBox.Show("Dữ liệu đã được sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim nào để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void SapXepPhims(ListView listView)
        {
            foreach (DataRow row in DAO.Instance.SapXepThuCung().Rows)
            {
                ListViewItem item = new ListViewItem(row["MaDon"].ToString());
                item.SubItems.Add(row["TenThuCung"].ToString());
                item.SubItems.Add(row["ChungLoai"].ToString());
                item.SubItems.Add(row["NgayNhan"].ToString());
                listView.Items.Add(item);
            }
        }

        public void ThongKe()
        {
            DataTable dataTable = DAO.Instance.ThongKe();
            DataRow dataRow1 = dataTable.Rows[0];
            int slcbenh = dataRow1.Field<int>("TongSoLuong");
            double dtcbenh = dataRow1.Field<double>("TongDoanhThuChuaBenh");

            DataRow dataRow2 = dataTable.Rows[1];
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
