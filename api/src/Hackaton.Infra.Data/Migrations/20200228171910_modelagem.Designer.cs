﻿// <auto-generated />
using System;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20200228171910_modelagem")]
    partial class modelagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hackaton.Domain.Entities.Trail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Reward");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TypeID");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("TypeID");

                    b.ToTable("Trails");

                    b.HasData(
                        new { Id = 1, CreateAt = new DateTime(2020, 2, 28, 14, 19, 9, 536, DateTimeKind.Local), Description = "Text", Reward = 10, Title = "Title Text", TypeID = 1 },
                        new { Id = 2, CreateAt = new DateTime(2020, 2, 28, 14, 19, 9, 537, DateTimeKind.Local), Description = "Video 2", Reward = 10, Title = "Title Video 2", TypeID = 2 }
                    );
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.TrailType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("TrailType");

                    b.HasData(
                        new { Id = 1, CreateAt = new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local), Description = "Text" },
                        new { Id = 2, CreateAt = new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local), Description = "Video" },
                        new { Id = 3, CreateAt = new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local), Description = "Quiz" }
                    );
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Coins")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<DateTime?>("CreateAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Level")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<int>("TrailID");

                    b.Property<DateTime?>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TrailID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.Trail", b =>
                {
                    b.HasOne("Hackaton.Domain.Entities.TrailType", "TrailType")
                        .WithMany("Trails")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackaton.Domain.Entities.User", b =>
                {
                    b.HasOne("Hackaton.Domain.Entities.Trail", "Trail")
                        .WithMany("Users")
                        .HasForeignKey("TrailID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
