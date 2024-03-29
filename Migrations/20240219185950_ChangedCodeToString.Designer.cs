﻿// <auto-generated />
using System;
using Inventory_managment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Inventory_managment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240219185950_ChangedCodeToString")]
    partial class ChangedCodeToString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Inventory_managment.Model.Bottle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoxId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bottles");
                });

            modelBuilder.Entity("Inventory_managment.Model.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BoxId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PalletId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BoxId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("Inventory_managment.Model.Pallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PalletId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PalletId");

                    b.ToTable("Pallets");
                });

            modelBuilder.Entity("Inventory_managment.Model.Box", b =>
                {
                    b.HasOne("Inventory_managment.Model.Bottle", null)
                        .WithMany("Box")
                        .HasForeignKey("BoxId");
                });

            modelBuilder.Entity("Inventory_managment.Model.Pallet", b =>
                {
                    b.HasOne("Inventory_managment.Model.Box", null)
                        .WithMany("Pallet")
                        .HasForeignKey("PalletId");
                });

            modelBuilder.Entity("Inventory_managment.Model.Bottle", b =>
                {
                    b.Navigation("Box");
                });

            modelBuilder.Entity("Inventory_managment.Model.Box", b =>
                {
                    b.Navigation("Pallet");
                });
#pragma warning restore 612, 618
        }
    }
}
