﻿// <auto-generated />
using System;
using GreenGarden.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenGarden.Migrations
{
    [DbContext(typeof(GardenerContext))]
    partial class GardenerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GreenGarden.Models.Gardeners", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Cell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("FirstName");

                    b.Property<int?>("GenderIdentity")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("LastName");

                    b.Property<string>("State")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int?>("TopCropCropId")
                        .HasColumnType("int");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TopCropCropId");

                    b.ToTable("Gardenership");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Email = "freyaplaya@gmail.com",
                            FirstName = "Freya",
                            LastName = "Greene"
                        },
                        new
                        {
                            ID = 2,
                            Email = "victorharwood@gmail.com",
                            FirstName = "Victor",
                            LastName = "Harwood"
                        },
                        new
                        {
                            ID = 3,
                            Email = "luisnotluis@gmail.com",
                            FirstName = "Luis",
                            LastName = "Greene"
                        });
                });

            modelBuilder.Entity("GreenGarden.Models.GardenersTopCrops", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CropId")
                        .HasColumnType("int");

                    b.Property<int>("GardenersID")
                        .HasColumnType("int");

                    b.Property<int?>("TopCropCropId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GardenersID");

                    b.HasIndex("TopCropCropId");

                    b.ToTable("GardenersTopCrops");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CropId = 1,
                            GardenersID = 1
                        },
                        new
                        {
                            ID = 2,
                            CropId = 2,
                            GardenersID = 2
                        },
                        new
                        {
                            ID = 3,
                            CropId = 3,
                            GardenersID = 1
                        });
                });

            modelBuilder.Entity("GreenGarden.Models.TopCrop", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CropId");

                    b.ToTable("TopCrops");

                    b.HasData(
                        new
                        {
                            CropId = 1,
                            Description = "Native to Asia. Part of the nightshade family.",
                            Name = "Eggplant"
                        },
                        new
                        {
                            CropId = 2,
                            Description = "Part of the nightshade family. Native to the Andes of South America, around Peru.",
                            Name = "Tomato"
                        },
                        new
                        {
                            CropId = 3,
                            Description = "Part of the nightshade family. Native to the Andes of South America.",
                            Name = "Potato"
                        });
                });

            modelBuilder.Entity("GreenGarden.Models.Gardeners", b =>
                {
                    b.HasOne("GreenGarden.Models.TopCrop", "TopCrop")
                        .WithMany()
                        .HasForeignKey("TopCropCropId");

                    b.Navigation("TopCrop");
                });

            modelBuilder.Entity("GreenGarden.Models.GardenersTopCrops", b =>
                {
                    b.HasOne("GreenGarden.Models.Gardeners", "Gardeners")
                        .WithMany("TopCrops")
                        .HasForeignKey("GardenersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenGarden.Models.TopCrop", "TopCrop")
                        .WithMany("Gardeners")
                        .HasForeignKey("TopCropCropId");

                    b.Navigation("Gardeners");

                    b.Navigation("TopCrop");
                });

            modelBuilder.Entity("GreenGarden.Models.Gardeners", b =>
                {
                    b.Navigation("TopCrops");
                });

            modelBuilder.Entity("GreenGarden.Models.TopCrop", b =>
                {
                    b.Navigation("Gardeners");
                });
#pragma warning restore 612, 618
        }
    }
}
