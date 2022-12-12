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
    [Migration("20221209004320_InitialCreate7")]
    partial class InitialCreate7
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

            modelBuilder.Entity("Model.Measurements", b =>
                {
                    b.Property<int>("MeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasureId"));

                    b.Property<decimal>("Co2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Humidity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LightLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MashroomRoomMusId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MeasureId");

                    b.HasIndex("MashroomRoomMusId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("Model.Measurements", b =>
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
