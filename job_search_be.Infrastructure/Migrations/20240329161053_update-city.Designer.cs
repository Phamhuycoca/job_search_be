﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using job_search_be.Infrastructure.Context;

#nullable disable

namespace job_search_be.Infrastructure.Migrations
{
    [DbContext(typeof(job_search_DbContext))]
    [Migration("20240329161053_update-city")]
    partial class updatecity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("job_search_be.Domain.Entity.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CityId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Employers", b =>
                {
                    b.Property<Guid>("EmployersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("IsStatus")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployersId");

                    b.HasIndex("CityId");

                    b.ToTable("Employers", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Formofwork", b =>
                {
                    b.Property<Guid>("FormofworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormofworkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FormofworkId");

                    b.ToTable("Formofworks", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Permission", b =>
                {
                    b.Property<string>("PermissionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PermissionId");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Refresh_Token", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefreshTokenExpiration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Refresh_TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PermissionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Salary", b =>
                {
                    b.Property<Guid>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SalaryPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SalaryId");

                    b.ToTable("Salaries", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Workexperience", b =>
                {
                    b.Property<Guid>("WorkexperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkexperienceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkexperienceId");

                    b.ToTable("Workexperiences", (string)null);
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Employers", b =>
                {
                    b.HasOne("job_search_be.Domain.Entity.City", "City")
                        .WithMany("Employers")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Refresh_Token", b =>
                {
                    b.HasOne("job_search_be.Domain.Entity.User", "User")
                        .WithMany("Refresh_Tokens")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.User", b =>
                {
                    b.HasOne("job_search_be.Domain.Entity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.City", b =>
                {
                    b.Navigation("Employers");
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("job_search_be.Domain.Entity.User", b =>
                {
                    b.Navigation("Refresh_Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
