﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeekOpdrachtSecurity.API.DbContexts;

namespace WeekOpdrachtSecurity.API.Migrations
{
    [DbContext(typeof(WeekOpdrachtDbContext))]
    [Migration("20210906093153_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeekOpdrachtSecurity.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Test1",
                            LastName = "Test1",
                            Password = "test",
                            Username = "test"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Test2",
                            LastName = "Test2",
                            Password = "test",
                            Username = "test2"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Test2",
                            LastName = "Test2",
                            Password = "test",
                            Username = "test3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
