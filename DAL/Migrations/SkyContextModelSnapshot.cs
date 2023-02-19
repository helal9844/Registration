﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(SkyContext))]
    partial class SkyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.EmailConfirm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("EmailConfirms");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserCountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCountryId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConfirmPassword = "123456",
                            Email = "ahmedmo@gmail.com",
                            FirstName = "Ahmed",
                            LastName = "Mohamed",
                            Password = "123456",
                            Phone = "010202020",
                            UserCountryId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConfirmPassword = "123456",
                            Email = "ahmedmo@gmail.com",
                            FirstName = "mohamed",
                            LastName = "Mohamed",
                            Password = "123456",
                            Phone = "010202020",
                            UserCountryId = 2
                        },
                        new
                        {
                            Id = 3,
                            ConfirmPassword = "123456",
                            Email = "ahmedmo@gmail.com",
                            FirstName = "sara",
                            LastName = "Mohamed",
                            Password = "123456",
                            Phone = "010202020",
                            UserCountryId = 3
                        });
                });

            modelBuilder.Entity("DAL.UserCountry", b =>
                {
                    b.Property<int>("UserCountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCountryId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DailCode")
                        .HasColumnType("int");

                    b.HasKey("UserCountryId");

                    b.ToTable("UserCountries");

                    b.HasData(
                        new
                        {
                            UserCountryId = 1,
                            Country = "Afghanistan",
                            DailCode = 93
                        },
                        new
                        {
                            UserCountryId = 2,
                            Country = "Aland Islands",
                            DailCode = 358
                        },
                        new
                        {
                            UserCountryId = 3,
                            Country = "Albania",
                            DailCode = 355
                        },
                        new
                        {
                            UserCountryId = 4,
                            Country = "Algeria",
                            DailCode = 213
                        },
                        new
                        {
                            UserCountryId = 5,
                            Country = "AmericanSamoa",
                            DailCode = 1684
                        },
                        new
                        {
                            UserCountryId = 6,
                            Country = "Andorra",
                            DailCode = 376
                        },
                        new
                        {
                            UserCountryId = 7,
                            Country = "Angola",
                            DailCode = 244
                        },
                        new
                        {
                            UserCountryId = 8,
                            Country = "Anguilla",
                            DailCode = 1264
                        },
                        new
                        {
                            UserCountryId = 9,
                            Country = "Antarctica",
                            DailCode = 672
                        });
                });

            modelBuilder.Entity("DAL.EmailConfirm", b =>
                {
                    b.HasOne("DAL.User", "User")
                        .WithOne("EmailConfirm")
                        .HasForeignKey("DAL.EmailConfirm", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.HasOne("DAL.UserCountry", "Country")
                        .WithMany("Users")
                        .HasForeignKey("UserCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DAL.User", b =>
                {
                    b.Navigation("EmailConfirm")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.UserCountry", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
