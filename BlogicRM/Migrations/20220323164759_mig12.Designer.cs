﻿// <auto-generated />
using System;
using BlogicRM.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogicRM.Migrations
{
    [DbContext(typeof(BlogicDbContext))]
    [Migration("20220323164759_mig12")]
    partial class mig12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("BlogicRM.Models.Entity.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("BlogicRM.Models.Entity.Consultant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Consultant");
                });

            modelBuilder.Entity("BlogicRM.Models.Entity.Contract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ConsultantID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EvidenceNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Institution")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Contract");
                });
#pragma warning restore 612, 618
        }
    }
}
