using ChamSocThuCungThreeModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChamSocThuCungThreeModel
{
    class DAO
    {
        private static DAO instance;
        private object command;
        internal static DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO();
                return instance;
            }
        }
        
        private DAO() { }
        
        public DataTable Xem()
        {
            string sql = "SELECT * FROM ThuCung";
            return DataProvider.Instance.execSql(sql);
        }
        
        public bool LuuThuCung(ThuCung thuCung)
        {
            string sql = "INSERT INTO ThuCung(MaDon, TenThuCung, ChungLoai, CanNang, NgayNhan, TinhTrang, DichVu, ChiPhiThuoc, SoNgay, Tong)" + "VALUES ( @MaDon, @TenThuCung, @ChungLoai, @CanNang, @NgayNhan, @TinhTrang, @DichVu, @ChiPhiThuoc, @SoNgay, @Tong )";
            Object[] prms = new object[] { thuCung.MaDon, thuCung.TenThu, thuCung.Chungloai, thuCung.Cannang, thuCung.NgayNhan, thuCung.TinhTrang, thuCung.DichVu, thuCung.ChiPhiThuoc, thuCung.Songay, thuCung.TongChiPhi };
            return DataProvider.Instance.execNonSql(sql, prms) > 0;
        }
        
        public bool XoaThongtinTheoMaDon(string maDon)
        {
            try
            {
                string query = $"DELETE FROM ThuCung WHERE MaDon = '{maDon}'";
                int affectedRows = DataProvider.Instance.execNonSql(query);

                // Kiểm tra số dòng bị ảnh hưởng, nếu lớn hơn 0, xóa thành công
                return affectedRows > 0;
            }
            catch (Exception )
            {
                MessageBox.Show("Không xóa được thú cưng: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable LayThongTinPhimTheoMaDon(string maDon)
        {
            // Viết câu truy vấn SQL để lấy thông tin chi tiết của phim từ cơ sở dữ liệu
            string query = $"SELECT * FROM ThuCung WHERE MaDon = '{maDon}'";

            // Thực hiện truy vấn và trả về đối tượng Phim
            return DataProvider.Instance.execSql(query);
        }

        public bool SuaThuCung(ThuCung thuCung, string madon)
        {
            string query = "UPDATE ThuCung SET TenThuCung = @TenThuCung, ChungLoai = @ChungLoai, CanNang = @CanNang, NgayNhan = @NgayNhan, TinhTrang = @TinhTrang, DichVu = @DichVu, ChiPhiThuoc = @ChiPhiThuoc, SoNgay = @SoNgay, Tong = @Tong" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { thuCung.TenThu, thuCung.Chungloai, thuCung.Cannang, thuCung.NgayNhan, thuCung.TinhTrang, thuCung.DichVu, thuCung.ChiPhiThuoc, thuCung.Songay, thuCung.TongChiPhi, madon };
            return DataProvider.Instance.execNonSql(query, prms) > 0;
        }

        public DataTable SapXepThuCung()
        {
            string query = $"SELECT * FROM ThuCung ORDER BY NgayNhan DESC, CanNang ASC";
            return DataProvider.Instance.execSql(query);
        }

        public DataTable ThongKe()
        {
            /*
              SELECT DichVu,
                COUNT(*) AS TongSoLuong, 
                SUM(CASE WHEN DichVu COLLATE Vietnamese_CI_AI LIKE N'Chữa bệnh%' THEN ChiPhiThuoc ELSE 0 END) AS TongDoanhThuChuaBenh,
                SUM(CASE WHEN DichVu COLLATE Vietnamese_CI_AI LIKE N'Chăm sóc hộ%' THEN SoNgay ELSE 0 END) AS TongDoanhThuChamSocHo 
                FROM ThuCung 
                GROUP BY DichVu;
            */
            string query = $"SELECT DichVu, " +
                $"COUNT(*) AS TongSoLuong, " +
                $"SUM(CASE WHEN DichVu = 'ChuaBenh' THEN Tong ELSE 0 END) AS TongDoanhThuChuaBenh, " +
                $"SUM(CASE WHEN DichVu = 'ChamSocHo' THEN Tong ELSE 0 END) AS TongDoanhThuChamSocHo " +
                $"FROM ThuCung " +
                $"GROUP BY DichVu;";
            return DataProvider.Instance.execSql(query);
        }
    }
}