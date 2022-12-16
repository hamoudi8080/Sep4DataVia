﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.EfcData.DataAccess;

#nullable disable

namespace webApi.Migrations
{
    [DbContext(typeof(DataAccess1))]
    partial class DataAccess1ModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Model.MashroomRoom", b =>
                {
                    b.Property<string>("MusId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MusId");

                    b.ToTable("MushroomRooms");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.Property<int>("MeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasureId"));

                    b.Property<decimal>("Co2Level")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Humidity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LightLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MushroomRoomMusId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MeasureId");

                    b.HasIndex("MushroomRoomMusId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Model.Threshold", b =>
                {
                    b.Property<int>("ThresholdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThresholdId"));

                    b.Property<decimal>("Co2MaxLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Co2MinLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HumidityMaxLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HumidityMinLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LightMaxLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LightMinLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TemperatureMaxLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TemperatureMinLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("muiMusId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ThresholdId");

                    b.HasIndex("muiMusId");

                    b.ToTable("Thresholds");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.HasOne("Model.MashroomRoom", "MushroomRoom")
                        .WithMany("Measurements")
                        .HasForeignKey("MushroomRoomMusId");

                    b.Navigation("MushroomRoom");
                });

            modelBuilder.Entity("Model.Threshold", b =>
                {
                    b.HasOne("Model.MashroomRoom", "mui")
                        .WithMany("Threshold")
                        .HasForeignKey("muiMusId");

                    b.Navigation("mui");
                });

            modelBuilder.Entity("Model.MashroomRoom", b =>
                {
                    b.Navigation("Measurements");

                    b.Navigation("Threshold");
                });
#pragma warning restore 612, 618
        }
    }
}
