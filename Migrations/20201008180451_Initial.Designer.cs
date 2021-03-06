﻿// <auto-generated />
using Doska.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Doska.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201008180451_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Doska.Models.Catalog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idSubtitle")
                        .HasColumnType("int");

                    b.Property<int>("idTitle")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("Doska.Models.Subtitle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameSubtitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Subtitles");
                });

            modelBuilder.Entity("Doska.Models.Title", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Titles");
                });
#pragma warning restore 612, 618
        }
    }
}
