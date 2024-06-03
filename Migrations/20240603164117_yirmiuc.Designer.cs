﻿// <auto-generated />
using System;
using Internet_Programlama_Final_Work.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Internet_Programlama_Final_Work.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240603164117_yirmiuc")]
    partial class yirmiuc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UzmanlikAlani")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Hasta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SorumluDoktorId")
                        .HasColumnType("int");

                    b.Property<int?>("SorumluHemsireId")
                        .HasColumnType("int");

                    b.Property<int>("Yas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SorumluDoktorId");

                    b.HasIndex("SorumluHemsireId");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Hemsire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bölüm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("İşeBaşlamaTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hemsireler");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.LabAdres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KatNo")
                        .HasColumnType("int");

                    b.Property<string>("KoridorNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LabAdresler");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Logincs", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("LoggedStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Logincs");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Sonuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("FotografDosyasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HastaId")
                        .HasColumnType("int");

                    b.Property<int>("HemsireId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("HastaId");

                    b.HasIndex("HemsireId");

                    b.ToTable("Sonuclar");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.TestTur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AcTok")
                        .HasColumnType("bit");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SonucSuresi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TestTurler");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Hasta", b =>
                {
                    b.HasOne("Internet_Programlama_Final_Work.Models.Doktor", "SorumluDoktor")
                        .WithMany()
                        .HasForeignKey("SorumluDoktorId");

                    b.HasOne("Internet_Programlama_Final_Work.Models.Hemsire", "SorumluHemsire")
                        .WithMany()
                        .HasForeignKey("SorumluHemsireId");

                    b.Navigation("SorumluDoktor");

                    b.Navigation("SorumluHemsire");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Sonuc", b =>
                {
                    b.HasOne("Internet_Programlama_Final_Work.Models.Doktor", "Doktor")
                        .WithMany("Sonuclar")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internet_Programlama_Final_Work.Models.Hasta", "Hasta")
                        .WithMany()
                        .HasForeignKey("HastaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internet_Programlama_Final_Work.Models.Hemsire", "Hemsire")
                        .WithMany()
                        .HasForeignKey("HemsireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");

                    b.Navigation("Hemsire");
                });

            modelBuilder.Entity("Internet_Programlama_Final_Work.Models.Doktor", b =>
                {
                    b.Navigation("Sonuclar");
                });
#pragma warning restore 612, 618
        }
    }
}
