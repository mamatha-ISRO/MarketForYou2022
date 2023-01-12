﻿// <auto-generated />
using System;
using MKFY.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MKFY.Repositories.Migrations
{
    [DbContext(typeof(MKFYApplicationDbContext))]
    [Migration("20230111235738_alldeleteandadd")]
    partial class alldeleteandadd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MKFY.Models.Entities.MKFYList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BuyerId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsSold")
                        .HasColumnType("boolean");

                    b.Property<string>("ItemCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemCondition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("PickAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("MKFYListItems");
                });

            modelBuilder.Entity("MKFY.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MKFY.Models.Entities.UserLog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("LogCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SearchCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SearchString")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("MKFY.Models.Entities.MKFYList", b =>
                {
                    b.HasOne("MKFY.Models.Entities.User", "User")
                        .WithMany("MKFYListItems")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MKFY.Models.Entities.User", b =>
                {
                    b.Navigation("MKFYListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
