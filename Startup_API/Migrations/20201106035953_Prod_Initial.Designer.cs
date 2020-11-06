﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Startup_API.Models;

namespace Startup_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201106035953_Prod_Initial")]
    partial class Prod_Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Startup_models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category_Parent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Parent_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("insert_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("seo_keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("topParentMapper")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Startup_models.LinkRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insert_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("linkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("link_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link_iframe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seo_keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sourcesId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vote")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoriesId");

                    b.HasIndex("linkTypeId");

                    b.HasIndex("sourcesId");

                    b.ToTable("LinkRepository");
                });

            modelBuilder.Entity("Startup_models.LinkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Linktype_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("insert_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("seo_keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinkType");
                });

            modelBuilder.Entity("Startup_models.Sources", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Source_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("insert_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("seo_keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Startup_models.linkRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("insert_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("linkTypeId")
                        .HasColumnType("int");

                    b.Property<string>("link_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("link_iframe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sourcesId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("vote")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LinkRepo");
                });

            modelBuilder.Entity("Startup_models.LinkRepository", b =>
                {
                    b.HasOne("Startup_models.Categories", "categories")
                        .WithMany()
                        .HasForeignKey("categoriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Startup_models.LinkType", "linkType")
                        .WithMany()
                        .HasForeignKey("linkTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Startup_models.Sources", "sources")
                        .WithMany()
                        .HasForeignKey("sourcesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
