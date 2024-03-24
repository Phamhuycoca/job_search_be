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
    [Migration("20240324155716_update-init")]
    partial class updateinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
#pragma warning restore 612, 618
        }
    }
}
