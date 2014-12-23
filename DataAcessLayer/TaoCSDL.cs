using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;





namespace DataAcessLayer
{
    public class TaoCSDL
    {
        public byte[] ChuyenHinhSangByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public void ThemDuLieu()
        {
            // bat dau them du lieu va

            var DB = new QuanLyNhanVienDataContext();

            /*
            #region DuLieuNhanVien
            var nv1 = new NhanVien { MaNV = "NV001", MaPhongBan = "PHG01", HoTen = "Nguyễn Hoàng Anh", Nu = false, NgaySinh = new DateTime(1991, 10, 10), NgayNhapViec = new DateTime(2010, 10, 10), TTinHonNhan = true, CMND = 290988188, NoiCap = "Tây Ninh", 
                NgayCap = new DateTime(2009, 09, 09), MaCV = "NV", TenDN = "ha", MatKhauDN = "hoanganh", GhiChu = "", QuyenDN = 0, Hinh = ChuyenHinhSangByte(Image.FromFile(@"..\..\Resources\aiue.jpg")) };
            var nv2 = new NhanVien { MaNV = "NV002", MaPhongBan = "PHG01", HoTen = "Nguyễn Thị Ty", Nu = true, NgaySinh = new DateTime(1992, 01, 01), NgayNhapViec = new DateTime(2010, 10, 10), TTinHonNhan = true, CMND = 290989188, NoiCap = "Tiền Giang",
                NgayCap = new DateTime(2009, 10, 09), MaCV = "TK", TenDN = "ty", MatKhauDN = "pety", GhiChu = "", QuyenDN = 2, Hinh = ChuyenHinhSangByte(Image.FromFile(@"..\..\Resources\aiue.jpg")) };
 #endregion
            #region DuLieuPhongBan
            var pb01 = new PhongBan { MaPhongBan = "PHG01", TenPhongBan = "Văn Phòng", GhiChu = "Phòng này dành cho kĩ sư" };
            var pb02 = new PhongBan { MaPhongBan = "PHG01", TenPhongBan = "Thư Ký", GhiChu = "Phòng này dành cho con thư ký" };
#endregion
            #region DuLieuChucVu
            var cv01 = new ChucVu { MaCV = "NV", CVu = "Nhân Viên Van Phòng", GhiChuCvu = "Lam vi?c trên vi tính - Nh?p li?u", LuongCoBan = 3500000 };
            var cv02 = new ChucVu { MaCV = "TK", CVu = "Thu Ký Giám Ð?c", GhiChuCvu = "Con v? nh? c?a giám d?c", LuongCoBan = 5000000};
            #endregion
            #region DuLieuThongTinCaNhan
            var ttcn1 = new ThongTinCaNhan { MaNV = "NV001", NoiSinh = "B?c Giang", NguyenQuan = "Tây Ninh", DiaChiThuongChu = "S? 12 KVC, Phu?ng 11, Th? Ð?c, TPHCM", DiaChiTamChu = "S? 12 KVC, Phu?ng 11, Th? Ð?c, TPHCM", SDT = 0982919831, DanToc = "Kinh", TonGiao = "Khong", TiengMeDe = "Ti?ng Khome", TrinhDoNgoaiNgu = "Ti?ng Anh - Vi?t - Trung - Thái", HocVan = "Ð?i H?c", GhiChu = "H?i dó nó ngu l?m" };
            var ttcn2 = new ThongTinCaNhan { MaNV = "NV002", NoiSinh = "TPHCM", NguyenQuan = "Qu?ng Nam", DiaChiThuongChu = "S? 12 KVC, Phu?ng 11, Th? Ð?c, TPHCM", DiaChiTamChu = "S? 12 KVC, Phu?ng 11, Th? Ð?c, TPHCM", SDT = 0982919831, DanToc = "Kinh", TonGiao = "Khong", TiengMeDe = "Ti?ng Khome", TrinhDoNgoaiNgu = "Ti?ng Anh - Vi?t - Trung - Thái", HocVan = "Ð?i H?c", GhiChu = "H?i dó nó ngu l?m" };
 #endregion
            var bcc1 = new BangChamCong { MaBCC = 1,MaNV = "NV001", ThangDo= 10, Nam=2010, SoGioLamThem = 10, SoNgayCong=31};
            var bcc2 = new BangChamCong { MaBCC = 2, MaNV = "NV002", ThangDo = 9, Nam = 2010, SoGioLamThem = 10, SoNgayCong = 29 };
            */
            






            bool error = false;
            var validationErrors = DB.GetValidationErrors()
                .Where(vr => !vr.IsValid)
                .SelectMany(vr => vr.ValidationErrors);

            foreach (var err in validationErrors)
            {
                Console.WriteLine(err.ErrorMessage);
                error = true;
            }

            if (!error)
            {
                DB.SaveChanges();

            }

        }
    }
}
