﻿// <auto-generated />
using FoodDelivery.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodDelivery.Migrations
{
    [DbContext(typeof(FoodDelivery_DataContext))]
    [Migration("20230627040358_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PostCode")
                        .HasColumnType("text")
                        .HasColumnName("postcode");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Delivery", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("DriverId")
                        .HasColumnType("text")
                        .HasColumnName("driverid");

                    b.Property<string>("OrderId")
                        .HasColumnType("text")
                        .HasColumnName("orderid");

                    b.HasKey("Id");

                    b.ToTable("delivery");
                });

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Driver", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PostCode")
                        .HasColumnType("text")
                        .HasColumnName("postcode");

                    b.HasKey("Id");

                    b.ToTable("driver");
                });

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("text")
                        .HasColumnName("restaurantid");

                    b.HasKey("Id");

                    b.ToTable("item");
                });

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<double>("CustomerId")
                        .HasColumnType("double precision")
                        .HasColumnName("customerid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("FoodDelivery.EntityFramework.Entities.Restaurant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PostCode")
                        .HasColumnType("text")
                        .HasColumnName("postcode");

                    b.HasKey("Id");

                    b.ToTable("restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}