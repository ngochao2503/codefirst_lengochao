﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using codefirst_lengochao.data_access;

#nullable disable

namespace codefirst_lengochao.data_access.migrations
{
    [DbContext(typeof(sinhvien_DbContext))]
    partial class sinhvien_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("codefirst_lengochao.Models.Khoa", b =>
                {
                    b.Property<int>("KhoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaId"));

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhoaId");

                    b.ToTable("Khoa");

                    b.HasData(
                        new
                        {
                            KhoaId = 1,
                            TenKhoa = "Cong nghe so"
                        },
                        new
                        {
                            KhoaId = 2,
                            TenKhoa = "Dien - Dien tu"
                        },
                        new
                        {
                            KhoaId = 3,
                            TenKhoa = "Xay dung"
                        });
                });

            modelBuilder.Entity("codefirst_lengochao.Models.Lop", b =>
                {
                    b.Property<int>("LopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LopId"));

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<string>("TenLop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LopId");

                    b.HasIndex("KhoaId");

                    b.ToTable("Lop");

                    b.HasData(
                        new
                        {
                            LopId = 1,
                            KhoaId = 1,
                            TenLop = "LTC01"
                        },
                        new
                        {
                            LopId = 2,
                            KhoaId = 3,
                            TenLop = "VKT01"
                        },
                        new
                        {
                            LopId = 3,
                            KhoaId = 2,
                            TenLop = "KTĐ01"
                        });
                });

            modelBuilder.Entity("codefirst_lengochao.Models.SinhVien", b =>
                {
                    b.Property<int>("SinhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SinhVienId"));

                    b.Property<int>("LopId")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("SinhVienId");

                    b.HasIndex("LopId");

                    b.ToTable("SinhVien");

                    b.HasData(
                        new
                        {
                            SinhVienId = 1,
                            LopId = 1,
                            Ten = "Le Ngoc Hao",
                            Tuoi = 19
                        },
                        new
                        {
                            SinhVienId = 2,
                            LopId = 1,
                            Ten = "Lee Hao 1",
                            Tuoi = 20
                        },
                        new
                        {
                            SinhVienId = 3,
                            LopId = 1,
                            Ten = "Lee Ngoc 2",
                            Tuoi = 28
                        },
                        new
                        {
                            SinhVienId = 4,
                            LopId = 1,
                            Ten = "Lee Ngoc 3",
                            Tuoi = 22
                        },
                        new
                        {
                            SinhVienId = 5,
                            LopId = 1,
                            Ten = "Lee Hao 4",
                            Tuoi = 18
                        },
                        new
                        {
                            SinhVienId = 6,
                            LopId = 1,
                            Ten = "Lee Hao 5",
                            Tuoi = 19
                        },
                        new
                        {
                            SinhVienId = 7,
                            LopId = 1,
                            Ten = "Lee Ngoc 6",
                            Tuoi = 20
                        },
                        new
                        {
                            SinhVienId = 8,
                            LopId = 2,
                            Ten = "Lee Lee 7",
                            Tuoi = 20
                        },
                        new
                        {
                            SinhVienId = 9,
                            LopId = 3,
                            Ten = "Lee Lee 8",
                            Tuoi = 17
                        });
                });

            modelBuilder.Entity("codefirst_lengochao.Models.Lop", b =>
                {
                    b.HasOne("codefirst_lengochao.Models.Khoa", "Khoa")
                        .WithMany("Lops")
                        .HasForeignKey("KhoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("codefirst_lengochao.Models.SinhVien", b =>
                {
                    b.HasOne("codefirst_lengochao.Models.Lop", "Lop")
                        .WithMany()
                        .HasForeignKey("LopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lop");
                });

            modelBuilder.Entity("codefirst_lengochao.Models.Khoa", b =>
                {
                    b.Navigation("Lops");
                });
#pragma warning restore 612, 618
        }
    }
}
