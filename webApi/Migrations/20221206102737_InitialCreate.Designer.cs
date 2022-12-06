﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.EfcData.DataAccess;

#nullable disable

namespace webApi.Migrations
{
    [DbContext(typeof(DataAccess1))]
    [Migration("20221206102737_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MusId");

                    b.ToTable("MushroomRooms");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.Property<int>("SettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettingId"));

                    b.Property<int>("Co2")
                        .HasColumnType("int");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<decimal>("LightLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MashroomRoomMusId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("SettingId");

                    b.HasIndex("MashroomRoomMusId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Model.Measurement", b =>
                {
                    b.HasOne("Model.MashroomRoom", null)
                        .WithMany("Measurements")
                        .HasForeignKey("MashroomRoomMusId");
                });

            modelBuilder.Entity("Model.MashroomRoom", b =>
                {
                    b.Navigation("Measurements");
                });
#pragma warning restore 612, 618
        }
    }
}
