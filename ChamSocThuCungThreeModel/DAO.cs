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
        
        public bool LuuThuCungBenh(ThuCungBenh thuCung)
        {
            string sql = "INSERT INTO ThuCung(MaDon, TenThuCung, ChungLoai, CanNang, NgayNhan, TinhTrang, DichVu, ChiPhiThuoc)" + "VALUES ( @MaDon, @TenThuCung, @ChungLoai, @CanNang, @NgayNhan, @TinhTrang, @DichVu, @ChiPhiThuoc )";
            Object[] prms = new object[] { thuCung.MaDon, thuCung.TenThu, thuCung.Chungloai, thuCung.Cannang, thuCung.NgayNhan, thuCung.TinhTrang, thuCung.DichVu, thuCung.ChiPhiThuoc };
            return DataProvider.Instance.execNonSql(sql, prms) > 0;
        }
        
        public bool LuuThuCungBth(ThuCungBinhThuong thuCungbth)
        {
            string sql = "INSERT INTO ThuCung(MaDon, TenThuCung, ChungLoai, CanNang, NgayNhan, TinhTrang, DichVu, SoNgay)" + "VALUES ( @MaDon, @TenThuCung, @ChungLoai, @CanNang, @NgayNhan, @TinhTrang, @DichVu, @SoNgay )";
            Object[] prms = new object[] { thuCungbth.MaDon, thuCungbth.TenThu, thuCungbth.Chungloai, thuCungbth.Cannang, thuCungbth.NgayNhan, thuCungbth.TinhTrang, thuCungbth.DichVu, thuCungbth.Songay };
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
            catch (Exception ex)
            {
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

        public bool SuaThuCungBenh(ThuCungBenh thuCungBenh, string madon)
        {
            string query = "UPDATE ThuCung SET TenThuCung = @TenThuCung, ChungLoai = @ChungLoai, CanNang = @CanNang, NgayNhan = @NgayNhan, TinhTrang = @TinhTrang, DichVu = @DichVu, ChiPhiThuoc = @ChiPhiThuoc" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { thuCungBenh.TenThu, thuCungBenh.Chungloai, thuCungBenh.Cannang, thuCungBenh.NgayNhan, thuCungBenh.TinhTrang, thuCungBenh.DichVu, thuCungBenh.ChiPhiChua, madon };
            return DataProvider.Instance.execNonSql(query, prms) > 0;
        }

        public bool SuathuCungBth(ThuCungBinhThuong thuCungBinhThuong, string madon)
        {
            string query = "UPDATE ThuCung SET TenThuCung = @TenThuCung, ChungLoai = @ChungLoai, CanNang = @CanNang, NgayNhan = @NgayNhan, TinhTrang = @TinhTrang, DichVu = @DichVu, SoNgay = @SoNgay" +
                " WHERE MaDon = @MaDon";
            object[] prms = new object[] { thuCungBinhThuong.TenThu, thuCungBinhThuong.Chungloai, thuCungBinhThuong.Cannang, thuCungBinhThuong.NgayNhan, thuCungBinhThuong.TinhTrang, thuCungBinhThuong.DichVu, thuCungBinhThuong.Songay, madon };
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
                $"SUM(CASE WHEN DichVu COLLATE Vietnamese_CI_AI LIKE N'Chữa bệnh%' THEN ChiPhiThuoc ELSE 0 END) AS TongDoanhThuChuaBenh, " +
                $"SUM(CASE WHEN DichVu COLLATE Vietnamese_CI_AI LIKE N'Chăm sóc hộ%' THEN SoNgay ELSE 0 END) AS TongDoanhThuChamSocHo " +
                $"FROM ThuCung " +
                $"GROUP BY DichVu;";
            return DataProvider.Instance.execSql(query);
        }
    }
}