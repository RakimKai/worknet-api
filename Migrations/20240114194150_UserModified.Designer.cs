﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using worknet_api.Data;

#nullable disable

namespace worknet_api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240114194150_UserModified")]
    partial class UserModified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("worknet_api.Models.EmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Full-time"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Part-time"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Remote"
                        });
                });

            modelBuilder.Entity("worknet_api.Models.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Industries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Real Estate"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Technology"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Healthcare"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Hospitality"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Manufacturing"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Retail"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Transportation"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Construction"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Agriculture"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Media and Entertainment"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Energy"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Telecommunications"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Automotive"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Legal"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Environmental"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Architecture"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Pharmaceuticals"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Nonprofit"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Research and Development"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Information Technology"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("worknet_api.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnikLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salts")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikLocationId");

                    b.ToTable("Korisnici");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Korisnik");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("worknet_api.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = ""
                        },
                        new
                        {
                            Id = 2,
                            City = "Banja Luka"
                        },
                        new
                        {
                            Id = 3,
                            City = "Bijeljina"
                        },
                        new
                        {
                            Id = 4,
                            City = "Bihać"
                        },
                        new
                        {
                            Id = 5,
                            City = "Bosanska Krupa"
                        },
                        new
                        {
                            Id = 6,
                            City = "Cazin"
                        },
                        new
                        {
                            Id = 7,
                            City = "Čapljina"
                        },
                        new
                        {
                            Id = 8,
                            City = "Derventa"
                        },
                        new
                        {
                            Id = 9,
                            City = "Doboj"
                        },
                        new
                        {
                            Id = 10,
                            City = "Goražde"
                        },
                        new
                        {
                            Id = 11,
                            City = "Gračanica"
                        },
                        new
                        {
                            Id = 12,
                            City = "Gradačac"
                        },
                        new
                        {
                            Id = 13,
                            City = "Gradiška"
                        },
                        new
                        {
                            Id = 14,
                            City = "Istočno Sarajevo"
                        },
                        new
                        {
                            Id = 15,
                            City = "Konjic"
                        },
                        new
                        {
                            Id = 16,
                            City = "Laktaši"
                        },
                        new
                        {
                            Id = 17,
                            City = "Livno"
                        },
                        new
                        {
                            Id = 18,
                            City = "Lukavac"
                        },
                        new
                        {
                            Id = 19,
                            City = "Ljubuški"
                        },
                        new
                        {
                            Id = 20,
                            City = "Mostar"
                        },
                        new
                        {
                            Id = 21,
                            City = "Orašje"
                        },
                        new
                        {
                            Id = 22,
                            City = "Prijedor"
                        },
                        new
                        {
                            Id = 23,
                            City = "Sarajevo"
                        },
                        new
                        {
                            Id = 24,
                            City = "Srebrenik"
                        },
                        new
                        {
                            Id = 25,
                            City = "Stolac"
                        },
                        new
                        {
                            Id = 26,
                            City = "Široki Brijeg"
                        },
                        new
                        {
                            Id = 27,
                            City = "Trebinje"
                        },
                        new
                        {
                            Id = 28,
                            City = "Tuzla"
                        },
                        new
                        {
                            Id = 29,
                            City = "Visoko"
                        },
                        new
                        {
                            Id = 30,
                            City = "Zavidovići"
                        },
                        new
                        {
                            Id = 31,
                            City = "Zenica"
                        },
                        new
                        {
                            Id = 32,
                            City = "Zvornik"
                        },
                        new
                        {
                            Id = 33,
                            City = "Živinice"
                        },
                        new
                        {
                            Id = 34,
                            City = "Travnik"
                        });
                });

            modelBuilder.Entity("worknet_api.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostEmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PostIndustryId")
                        .HasColumnType("int");

                    b.Property<int>("PostLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PostEmploymentTypeId");

                    b.HasIndex("PostIndustryId");

                    b.HasIndex("PostLocationId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("worknet_api.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewCompanyId");

                    b.HasIndex("ReviewEmployeeId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("worknet_api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("worknet_api.Models.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("worknet_api.Models.Company", b =>
                {
                    b.HasBaseType("worknet_api.Models.Korisnik");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyOwner")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("worknet_api.Models.Employee", b =>
                {
                    b.HasBaseType("worknet_api.Models.Korisnik");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Universty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("worknet_api.Models.Korisnik", b =>
                {
                    b.HasOne("worknet_api.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("KorisnikLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("worknet_api.Models.Post", b =>
                {
                    b.HasOne("worknet_api.Models.Company", "Company")
                        .WithMany("Posts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("worknet_api.Models.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("PostEmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("worknet_api.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("PostIndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("worknet_api.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("PostLocationId");

                    b.Navigation("Company");

                    b.Navigation("EmploymentType");

                    b.Navigation("Industry");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("worknet_api.Models.Review", b =>
                {
                    b.HasOne("worknet_api.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("ReviewCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("worknet_api.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("ReviewEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("worknet_api.Models.Token", b =>
                {
                    b.HasOne("worknet_api.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("worknet_api.Models.Company", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
