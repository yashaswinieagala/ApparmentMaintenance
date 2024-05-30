﻿// <auto-generated />
using System;
using AppartmentServiceBE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppartmentServiceBE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppartmentServiceBE.Models.Domain.UserDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"));

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTable");
                });

            modelBuilder.Entity("AppartmentServiceBE.Models.Domain.complexDetails", b =>
                {
                    b.Property<int>("complexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("complexId"));

                    b.Property<int>("noofFlats")
                        .HasColumnType("int");

                    b.HasKey("complexId");

                    b.ToTable("ComplexDetails");
                });

            modelBuilder.Entity("AppartmentServiceBE.Models.Domain.flatDetails", b =>
                {
                    b.Property<int>("flatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("flatId"));

                    b.Property<int>("complexId")
                        .HasColumnType("int");

                    b.Property<int>("contactNumbers")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("flatNo")
                        .HasColumnType("int");

                    b.Property<int>("occupants")
                        .HasColumnType("int");

                    b.Property<string>("ownerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("selectedServices")
                        .HasColumnType("bit");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.HasKey("flatId");

                    b.ToTable("ApartMentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
