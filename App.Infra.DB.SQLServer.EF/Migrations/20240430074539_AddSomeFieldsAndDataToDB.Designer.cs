﻿// <auto-generated />
using System;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240430074539_AddSomeFieldsAndDataToDB")]
    partial class AddSomeFieldsAndDataToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.AdminEntity.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FistName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Admins", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "navid@gmail.com",
                            FistName = "Navid",
                            LastName = "Jafarzadeh",
                            Password = "9"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.BidEntity.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FinishedAt")
                        .HasColumnType("date");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("RequestId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("App.Domain.Core.CategoryEntity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PictureLocation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "دکوراسیون ساختمان"
                        },
                        new
                        {
                            Id = 2,
                            Title = "تاسیسات ساختمان"
                        },
                        new
                        {
                            Id = 3,
                            Title = "وسایل نقلیه"
                        },
                        new
                        {
                            Id = 4,
                            Title = "اسباب کشی و باربری"
                        },
                        new
                        {
                            Id = 5,
                            Title = "لوازم خانگی"
                        },
                        new
                        {
                            Id = 7,
                            Title = "خدمان اداری"
                        },
                        new
                        {
                            Id = 8,
                            Title = "بهداشت و نظافت"
                        },
                        new
                        {
                            Id = 9,
                            Title = "دیجیتال و نرم افزار"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.CommentEntity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Core.CustomerEntity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.ExpertEntity.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumberBackUp")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Experts", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.RequestEntity.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ImageSrc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("App.Domain.Core.ServiceEntity.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageSrc")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core._0_BaseEntities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "آذربایجان شرقی"
                        },
                        new
                        {
                            Id = 2,
                            Name = "آذربایجان غربی"
                        },
                        new
                        {
                            Id = 3,
                            Name = "اردبیل"
                        },
                        new
                        {
                            Id = 4,
                            Name = "اصفهان"
                        },
                        new
                        {
                            Id = 5,
                            Name = "البرز"
                        },
                        new
                        {
                            Id = 6,
                            Name = "ایلام"
                        },
                        new
                        {
                            Id = 7,
                            Name = "بوشهر"
                        },
                        new
                        {
                            Id = 8,
                            Name = "تهران"
                        },
                        new
                        {
                            Id = 9,
                            Name = "چهارمحال و بختیاری"
                        },
                        new
                        {
                            Id = 10,
                            Name = "خراسان جنوبی"
                        },
                        new
                        {
                            Id = 11,
                            Name = "خراسان رضوی"
                        },
                        new
                        {
                            Id = 12,
                            Name = "خراسان شمالی"
                        },
                        new
                        {
                            Id = 13,
                            Name = "خوزستان"
                        },
                        new
                        {
                            Id = 14,
                            Name = "زنجان"
                        },
                        new
                        {
                            Id = 15,
                            Name = "سمنان"
                        },
                        new
                        {
                            Id = 16,
                            Name = "سیستان و بلوچستان"
                        },
                        new
                        {
                            Id = 17,
                            Name = "فارس"
                        },
                        new
                        {
                            Id = 18,
                            Name = "قزوین"
                        },
                        new
                        {
                            Id = 19,
                            Name = "قم"
                        },
                        new
                        {
                            Id = 20,
                            Name = "کردستان"
                        },
                        new
                        {
                            Id = 21,
                            Name = "کرمان"
                        },
                        new
                        {
                            Id = 22,
                            Name = "کرمانشاه"
                        },
                        new
                        {
                            Id = 23,
                            Name = "کهگیلویه و بویراحمد"
                        },
                        new
                        {
                            Id = 24,
                            Name = "گلستان"
                        },
                        new
                        {
                            Id = 25,
                            Name = "گیلان"
                        },
                        new
                        {
                            Id = 26,
                            Name = "لرستان"
                        },
                        new
                        {
                            Id = 27,
                            Name = "مازندران"
                        },
                        new
                        {
                            Id = 28,
                            Name = "مرکزی"
                        },
                        new
                        {
                            Id = 29,
                            Name = "هرمزگان"
                        },
                        new
                        {
                            Id = 30,
                            Name = "همدان"
                        },
                        new
                        {
                            Id = 31,
                            Name = "یزد"
                        });
                });

            modelBuilder.Entity("App.Domain.Core._0_BaseEntity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("PlateNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.Property<int>("ExpertsId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("ExpertsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("ExpertService");
                });

            modelBuilder.Entity("App.Domain.Core.BidEntity.Bid", b =>
                {
                    b.HasOne("App.Domain.Core.ExpertEntity.Expert", "Expert")
                        .WithMany("Bids")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.RequestEntity.Request", "Request")
                        .WithMany("Bids")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("App.Domain.Core.CommentEntity.Comment", b =>
                {
                    b.HasOne("App.Domain.Core.CustomerEntity.Customer", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.ExpertEntity.Expert", "Expert")
                        .WithMany("Comments")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("App.Domain.Core.RequestEntity.Request", b =>
                {
                    b.HasOne("App.Domain.Core.CustomerEntity.Customer", "Customer")
                        .WithMany("Requests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.ServiceEntity.Service", "Service")
                        .WithMany("Requests")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("App.Domain.Core.ServiceEntity.Service", b =>
                {
                    b.HasOne("App.Domain.Core.CategoryEntity.Category", "Category")
                        .WithMany("Services")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("App.Domain.Core._0_BaseEntity.Address", b =>
                {
                    b.HasOne("App.Domain.Core._0_BaseEntities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.CustomerEntity.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ExpertService", b =>
                {
                    b.HasOne("App.Domain.Core.ExpertEntity.Expert", null)
                        .WithMany()
                        .HasForeignKey("ExpertsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.ServiceEntity.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.CategoryEntity.Category", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("App.Domain.Core.CustomerEntity.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Comments");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("App.Domain.Core.ExpertEntity.Expert", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("App.Domain.Core.RequestEntity.Request", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("App.Domain.Core.ServiceEntity.Service", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
