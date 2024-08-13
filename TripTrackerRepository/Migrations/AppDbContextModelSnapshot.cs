﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TripTrackerRepository;

#nullable disable

namespace TripTrackerRepository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TripTrackerCore.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UptatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedDate = new DateTime(2024, 8, 13, 9, 19, 30, 670, DateTimeKind.Local).AddTicks(9973),
                            Name = "Melih",
                            Surname = "Bahadir"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedDate = new DateTime(2024, 8, 13, 9, 19, 30, 670, DateTimeKind.Local).AddTicks(9983),
                            Name = "Yaser",
                            Surname = "Kalkan"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedDate = new DateTime(2024, 8, 13, 9, 19, 30, 670, DateTimeKind.Local).AddTicks(9984),
                            Name = "Yilmaz",
                            Surname = "Genc"
                        });
                });

            modelBuilder.Entity("TripTrackerCore.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UptatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("TripTrackerCore.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Information")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UptatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("TripTrackerCore.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Stay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UptatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StatusId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("TripTrackerCore.Travel", b =>
                {
                    b.HasOne("TripTrackerCore.Admin", "Admin")
                        .WithMany("ApprovedTravels")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripTrackerCore.Staff", "Staff")
                        .WithMany("Travels")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TripTrackerCore.Status", "Status")
                        .WithMany("Travels")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Staff");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TripTrackerCore.Admin", b =>
                {
                    b.Navigation("ApprovedTravels");
                });

            modelBuilder.Entity("TripTrackerCore.Staff", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("TripTrackerCore.Status", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
