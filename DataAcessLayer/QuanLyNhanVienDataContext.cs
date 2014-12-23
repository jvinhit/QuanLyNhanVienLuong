using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcessLayer
{
    public class QuanLyNhanVienDataContext:DbContext
    {
        // Tao csdl voi lop taocsdl
        public QuanLyNhanVienDataContext():
            base("QuanLyNhanVienDataContext")// ten csdl
        {

        }
        // Danh sách các bảng:
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<BangChamCong> BangChamCongs { get; set; }
        public DbSet<LuongThang> LuongThangs { get; set; }
        public DbSet<ChucVu> ChucVus{ get; set; }
        public DbSet<KiLuat> KiLuats { get; set; }
        public DbSet<KhenThuong> KhenThuongs { get; set; }
        //public DbSet<LienHe> LienHes{ get; set; }
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<TamUng> TamUngs { get; set; }
        public DbSet<ThoiViec> ThoiViecs { get; set; }
        //public DbSet<ThongTinCaNhan> ThongTinCaNhans { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
           /* modelbuilder.Entity<ThoiViec>().HasKey(s => new { s.MaPhongBan, s.MaNV });*/
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QuanLyNhanVienDataContext>());
        }


    }
    // Tao bang thanh pho voi cac truong 
    public class NhanVien
    {
        [Key] // Khoa chinh
        public string  MaNV { get; set; }
        public string  MaPhongBan { get; set; }
        public string HoTen  { get; set; }
        public bool Nu { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayNhapViec { get; set; }
        public bool TTinHonNhan { get; set; }
        public int CMND { get; set; }
        public string NoiCap { get; set; }
        public DateTime NgayCap { get; set; }
        public string  MaCV { get; set; }
        public string  TenDN { get; set; }
        public string MatKhauDN { get; set; }
        public string GhiChu { get; set; }
        public int QuyenDN { get; set; }
        public Byte[] Hinh { get; set; }
        [ForeignKey("MaCV")]
        public ChucVu ChucVu { get; set; }
        // Tạo relationship giữa 2 entity NhanVien va BangChamCong
        public virtual ICollection<BangChamCong> BangChamCongs { get; set; } 
        // De hieu rang C# cung cấp từ khóa virtual để chỉ rõ phương thức có thể bị lớp dẫn xuất ghi đè (overridden). 
        //Lớp dẫn xuất có thể ghi đè phương thức virtual bằng cách sử dụng từ khóa override.
        public virtual ICollection<TamUng> TamUngs { get; set; }
        public virtual ICollection<LuongThang> LuongThangs { get; set; }
       // public virtual ICollection<ThongTinCaNhan> ThongTinCaNhans { get; set; }
        public virtual ICollection<ThoiViec> ThoiViecs { get; set; }
        public virtual ICollection<KiLuat> KiLuats { get; set; }
        public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        
    }
    public class BangChamCong
    {
        [Key]
        public int  MaBCC { get; set; }
        public string  MaNV { get; set; }
        public int ThangDo { get; set; }
        public int  Nam { get; set; }
        public int SoGioLamThem { get; set; }
        public int SoNgayCong { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; } // Tao tham chieu den NhanVien

    }
    public class TamUng
    {
        [Key]
        public string  MaTU { get; set; }
        public string MaNV { get; set; }
        public int  SoTien { get; set; }
        public DateTime NgayTU { get; set; }
        public DateTime ThangTU { get; set; }
        public DateTime SoTienTU { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; }

    }
    public class LuongThang
    {
        [Key]
        public string  MaLT { get; set; }
        public string MaNV { get; set; }
        public DateTime ThangLuong { get; set; }
        public DateTime NamLuong { get; set; }
        public int  LuongCB { get; set; }
        public int TongLuong { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien NhanVien { get; set; }
    }
    //public class ThongTinCaNhan
    //{
    //    [Key]
    //    public string MaCN { get; set; }
    //    public string MaNV { get; set; }
    //    public string NoiSinh { get; set; }
    //    public string NguyenQuan { get; set; }
    //    public string DiaChiThuongChu { get; set; }
    //    public string DiaChiTamChu { get; set; }
    //    public int SDT { get; set; }
    //    public string DanToc { get; set; }
    //    public string TonGiao { get; set; }
    //    public string TiengMeDe { get; set; }
    //    public string TrinhDoNgoaiNgu { get; set; }
    //    public string HocVan { get; set; }
    //    public string GhiChu { get; set; }
    //    [ForeignKey("MaNV")]
    //    public NhanVien NhanVien { get; set; }
    //}
        public class ChucVu
        {
            [Key]
            public string MaCV { get; set; }
            public string CVu { get; set; }
            public string GhiChuCvu { get; set; }
            public int LuongCoBan { get; set; }
            public virtual ICollection<NhanVien> NhanViens { get; set; }
            public virtual ICollection<ThoiViec> ThoiViecs { get; set; }

        }
        public class ThoiViec
        {
            [Key]
            public string MaTV { get; set; }
            /*[Key, Column(Order = 1)]*/
            public string MaPhongBan { get; set; }
            public string MaCV { get; set; }
            //[Key, Column(Order=2)]
            public string MaNV { get; set; }
            public DateTime NgayThoiViec { get; set; }
            public string LyDo { get; set; }
            [ForeignKey("MaNV")]
            public NhanVien NhanVien { get; set; }// tao tham chieu den Nhan Vien
            [ForeignKey("MaCV")]
            public ChucVu ChucVu { get; set; }
            [ForeignKey("MaPhongBan")]
            public PhongBan PhongBan { get; set; } // tao tham chieu den Phongban 
        }
        public class PhongBan
        {
            [Key]
            public string MaPhongBan { get; set; }
            public string TenPhongBan { get; set; }
            public string GhiChu { get; set; }
            public virtual ICollection<ThoiViec> ThoiViecs { get; set; }
            public virtual ICollection<NhanVien> NhanViens { get; set; }
            public virtual ICollection<KiLuat> KiLuats { get; set; }
            public virtual ICollection<KhenThuong> KhenThuongs { get; set; }
        }
        public class KiLuat
        {
            [Key]
            public string MaKL { get; set; }
            public string MaPhongBan { get; set; }
            public string MaNV { get; set; }
            public string HinhthucKL { get; set; }
            public DateTime NgayKL { get; set; }
            public string LyDoKL { get; set; }
            public int SoTienKL { get; set; }
            [ForeignKey("MaNV")]
            public NhanVien NhanVien { get; set; }
            [ForeignKey("MaPhongBan")]
            public PhongBan PhongBan { get; set; }
        }
        public class KhenThuong
        {
            [Key]
            public string MaKT { get; set; }
            public string MaPhongBan { get; set; }
            public string MaNV { get; set; }
            public string HinhThucKT { get; set; }
            public DateTime NgayKT { get; set; }
            public string LyDoKT { get; set; }
            public int SoTienKT { get; set; }
            [ForeignKey("MaPhongBan")]
            public PhongBan PhongBan { get; set; } // co nghia la tao tham chieu den Phong ban va Ma Phong Ban la khoa ngoai . Co nghia la Trong Cai 
            [ForeignKey("MaNV")]
            public NhanVien NhanVien { get; set; }
        }
        //public class LienHe
        //{
        //    [Key]
        //    public string MaLH { get; set; }
        //    public string HoTenLH { get; set; }
        //    public string email { get; set; }
        //    public string SDTLH { get; set; }
        //    public string NoiDung { get; set; }

        //}
    }
}
