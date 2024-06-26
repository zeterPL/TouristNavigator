﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TouristNavigator.Infrastructure;

#nullable disable

namespace TouristNavigator.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231117151121_favourite-user-place")]
    partial class favouriteuserplace
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TouristNavigator.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.CategoryIcon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryIcons");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.FavouriteUserPlace", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PlaceId");

                    b.HasIndex("PlaceId");

                    b.ToTable("FavouriteUserPlaces");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.PlaceCategory", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("PlaceId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PlacesCategories");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.PlacePhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId")
                        .IsUnique();

                    b.ToTable("PlacesPhotos");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewValue")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.UserPreferences", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserPreferences");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.CategoryIcon", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Category", "Category")
                        .WithOne("Icon")
                        .HasForeignKey("TouristNavigator.Domain.Entities.CategoryIcon", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.FavouriteUserPlace", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Place", "Place")
                        .WithMany("FavouriteUsers")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TouristNavigator.Domain.Entities.ApplicationUser", "User")
                        .WithMany("FavouritePlaces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Place", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.ApplicationUser", null)
                        .WithMany("OwnedPlaces")
                        .HasForeignKey("ApplicationUserId");

                    b.OwnsOne("TouristNavigator.Domain.ValueObjects.Adress", "Adress", b1 =>
                        {
                            b1.Property<int>("PlaceId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LocalNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PlaceId");

                            b1.ToTable("Places");

                            b1.WithOwner()
                                .HasForeignKey("PlaceId");
                        });

                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.PlaceCategory", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Category", "Category")
                        .WithMany("RelatedPlaces")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TouristNavigator.Domain.Entities.Place", "Place")
                        .WithMany("Categories")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.PlacePhoto", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Place", "Place")
                        .WithOne("PlacePhoto")
                        .HasForeignKey("TouristNavigator.Domain.Entities.PlacePhoto", "PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Review", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Place", "Place")
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TouristNavigator.Domain.Entities.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.UserPreferences", b =>
                {
                    b.HasOne("TouristNavigator.Domain.Entities.Category", "Category")
                        .WithMany("RelatedUsers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TouristNavigator.Domain.Entities.ApplicationUser", "User")
                        .WithMany("UserPreferences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("FavouritePlaces");

                    b.Navigation("OwnedPlaces");

                    b.Navigation("Reviews");

                    b.Navigation("UserPreferences");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Category", b =>
                {
                    b.Navigation("Icon")
                        .IsRequired();

                    b.Navigation("RelatedPlaces");

                    b.Navigation("RelatedUsers");
                });

            modelBuilder.Entity("TouristNavigator.Domain.Entities.Place", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("FavouriteUsers");

                    b.Navigation("PlacePhoto")
                        .IsRequired();

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
