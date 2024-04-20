using codefirst_lengochao.Models;
using Microsoft.EntityFrameworkCore;

namespace codefirst_lengochao.data_access
{
    public class sinhvien_DbContext: DbContext
    {
        public sinhvien_DbContext(DbContextOptions<sinhvien_DbContext> options) : base(options)
        { }
        public DbSet<SinhVien> SinhVien { get; set; }


        public DbSet<Lop> Lop { get; set; }

        public DbSet<Khoa> Khoa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien() { SinhVienId = 1, Ten = "Le Ngoc Hao", Tuoi = 19, LopId = 1 },
                new SinhVien() { SinhVienId = 2, Ten = "Lee Hao 1", Tuoi = 20, LopId = 1 },
                new SinhVien() { SinhVienId = 3, Ten = "Lee Ngoc 2", Tuoi = 28, LopId = 1 },
                new SinhVien() { SinhVienId = 4, Ten = "Lee Ngoc 3", Tuoi = 22, LopId = 1 },
                new SinhVien() { SinhVienId = 5, Ten = "Lee Hao 4", Tuoi = 18, LopId = 1 },
                new SinhVien() { SinhVienId = 6, Ten = "Lee Hao 5", Tuoi = 19, LopId = 1 },
                new SinhVien() { SinhVienId = 7, Ten = "Lee Ngoc 6", Tuoi = 20, LopId = 1 },
                new SinhVien() { SinhVienId = 8, Ten = "Lee Lee 7", Tuoi = 20, LopId = 2 },
                new SinhVien() { SinhVienId = 9, Ten = "Lee Lee 8", Tuoi = 17, LopId = 3 });
            modelBuilder.Entity<Lop>().HasData(
                new Lop() { LopId = 1, TenLop = "LTC01", KhoaId = 1 },
                new Lop() { LopId = 2, TenLop = "VKT01", KhoaId = 3 },
                new Lop() { LopId = 3, TenLop = "KTĐ01", KhoaId = 2 });
            modelBuilder.Entity<Khoa>().HasData(
                new Khoa() { KhoaId = 1, TenKhoa = "Cong nghe so" },
                new Khoa() { KhoaId = 2, TenKhoa = "Dien - Dien tu" },
                new Khoa() { KhoaId = 3, TenKhoa = "Xay dung" });
        }
    }
}
