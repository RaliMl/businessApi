﻿// <auto-generated />
using System;
using GoodeBooks.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoodeBooks.Database.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20230607124612_addingVolumeInfoAuthorRelationship")]
    partial class addingVolumeInfoAuthorRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorVolumeInfo", b =>
                {
                    b.Property<string>("AuthorsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VolumeInfosId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorsId", "VolumeInfosId");

                    b.HasIndex("VolumeInfosId");

                    b.ToTable("AuthorVolumeInfo");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Bookshelf", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VolumeCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Bookshelves");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.SaleInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEbook")
                        .HasColumnType("bit");

                    b.Property<string>("SaleAbility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SaleInfos");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.SearchInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TextSnippet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SearchInfos");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Volume", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("BookshelfId")
                        .HasColumnType("bigint");

                    b.Property<string>("Etag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleInfoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SearchInfoId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VolumeInfoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookshelfId");

                    b.HasIndex("SaleInfoId");

                    b.HasIndex("SearchInfoId");

                    b.HasIndex("VolumeInfoId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.VolumeInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VolumeInfos");
                });

            modelBuilder.Entity("AuthorVolumeInfo", b =>
                {
                    b.HasOne("GoodeBooks.Models.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodeBooks.Models.Entities.VolumeInfo", null)
                        .WithMany()
                        .HasForeignKey("VolumeInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Bookshelf", b =>
                {
                    b.HasOne("GoodeBooks.Models.Entities.User", null)
                        .WithMany("Bookshelves")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Volume", b =>
                {
                    b.HasOne("GoodeBooks.Models.Entities.Bookshelf", null)
                        .WithMany("Volumes")
                        .HasForeignKey("BookshelfId");

                    b.HasOne("GoodeBooks.Models.Entities.SaleInfo", "SaleInfo")
                        .WithMany()
                        .HasForeignKey("SaleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodeBooks.Models.Entities.SearchInfo", "SearchInfo")
                        .WithMany()
                        .HasForeignKey("SearchInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoodeBooks.Models.Entities.VolumeInfo", "VolumeInfo")
                        .WithMany()
                        .HasForeignKey("VolumeInfoId");

                    b.Navigation("SaleInfo");

                    b.Navigation("SearchInfo");

                    b.Navigation("VolumeInfo");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.Bookshelf", b =>
                {
                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("GoodeBooks.Models.Entities.User", b =>
                {
                    b.Navigation("Bookshelves");
                });
#pragma warning restore 612, 618
        }
    }
}
