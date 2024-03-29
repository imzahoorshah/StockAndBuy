﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockAndBuy.EF;

namespace StockAndBuy.EF.Migrations
{
    [DbContext(typeof(BundleContext))]
    partial class BundleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockAndBuy.EF.Node", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BUNDLEID")
                        .HasColumnType("int");

                    b.Property<string>("NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PARENTID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Node");
                });
#pragma warning restore 612, 618
        }
    }
}
