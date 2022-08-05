﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleAPI.Data;

#nullable disable

namespace SimpleAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220804165606_FixOccupationKey")]
    partial class FixOccupationKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimpleAPI.Models.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OccupationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Occupations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OccupationName = "Doctor"
                        },
                        new
                        {
                            Id = 2,
                            OccupationName = "Firefighter"
                        },
                        new
                        {
                            Id = 3,
                            OccupationName = "Policeman"
                        });
                });

            modelBuilder.Entity("SimpleAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OccupationId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OccupationId")
                        .IsUnique()
                        .HasFilter("[OccupationId] IS NOT NULL");

                    b.ToTable("People");
                });

            modelBuilder.Entity("SimpleAPI.Models.Person", b =>
                {
                    b.HasOne("SimpleAPI.Models.Occupation", "Occupation")
                        .WithOne("Person")
                        .HasForeignKey("SimpleAPI.Models.Person", "OccupationId");

                    b.Navigation("Occupation");
                });

            modelBuilder.Entity("SimpleAPI.Models.Occupation", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
