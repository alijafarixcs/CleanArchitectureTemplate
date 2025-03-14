﻿// <auto-generated />
using System;
using CleanArchitectureTemplate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArchitectureTemplate.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("CleanArchitectureTemplate.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CleanArchitectureTemplate.Domain.Book", b =>
                {
                    b.OwnsOne("CleanArchitectureTemplate.Shared.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("BookId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Value")
                                .HasColumnType("TEXT")
                                .HasColumnName("Price");

                            b1.HasKey("BookId");

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("BookId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
