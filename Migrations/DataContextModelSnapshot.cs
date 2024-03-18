﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using landingpagemaker.Models;

#nullable disable

namespace landingpagemaker.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("landingpagemaker.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("landingpagemaker.Models.LandingPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpiredOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("LandingPages");
                });

            modelBuilder.Entity("landingpagemaker.Models.LandingPageStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("LandingPageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalActions")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalVisits")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LandingPageId");

                    b.ToTable("LandingPageStats");
                });

            modelBuilder.Entity("landingpagemaker.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LogType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeStamp")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("landingpagemaker.Models.LandingPage", b =>
                {
                    b.HasOne("landingpagemaker.Models.Category", "PageCategory")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PageCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("landingpagemaker.Models.LandingPageStat", b =>
                {
                    b.HasOne("landingpagemaker.Models.LandingPage", "LandingPage")
                        .WithMany("LandingPageStats")
                        .HasForeignKey("LandingPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LandingPage");
                });

            modelBuilder.Entity("landingpagemaker.Models.LandingPage", b =>
                {
                    b.Navigation("LandingPageStats");
                });
#pragma warning restore 612, 618
        }
    }
}
