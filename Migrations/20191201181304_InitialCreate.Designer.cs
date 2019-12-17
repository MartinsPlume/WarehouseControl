﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseControl.Models;

namespace WarehouseControl.Migrations
{
    [DbContext(typeof(ItemDetailContext))]
    [Migration("20191201181304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WarehouseControl.Models.ItemDetail", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemCount");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("ItemPrice");

                    b.HasKey("ItemId");

                    b.ToTable("ItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
