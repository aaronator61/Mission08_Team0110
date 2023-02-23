﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission08_Team0110.Models;

namespace Mission08_Team0110.Migrations
{
    [DbContext(typeof(TimeManagement))]
    partial class TimeManagementModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission08_Team0110.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("taskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Quadrant")
                        .HasColumnType("INTEGER");

                    b.Property<string>("task")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("taskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("responses");
                });

            modelBuilder.Entity("Mission08_Team0110.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CatName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CatName = "Home"
                        },
                        new
                        {
                            Id = 2,
                            CatName = "School"
                        },
                        new
                        {
                            Id = 3,
                            CatName = "Work"
                        },
                        new
                        {
                            Id = 4,
                            CatName = "Church"
                        });
                });

            modelBuilder.Entity("Mission08_Team0110.Models.ApplicationResponse", b =>
                {
                    b.HasOne("Mission08_Team0110.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
