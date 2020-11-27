﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.DataContext;

namespace WebApi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201125235756_updateDB")]
    partial class updateDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.AwardDirectory.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AwardDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VeteranId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VeteranId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("WebApi.BusinessDirectory.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("WebApi.BusinessRatingsDirectory.BusinessRatings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VeteranId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("VeteranId");

                    b.ToTable("BusinessesRatings");
                });

            modelBuilder.Entity("WebApi.EnterpreneurSaleDirectory.EnterpreneurSale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("SaleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActivated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("EnterpreneurSales");
                });

            modelBuilder.Entity("WebApi.OrganizationDirectory.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("WebApi.ServiceDirectory.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("WebApi.UserDirectory.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RecoveryKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("WebApi.VeteranOrganizationDirectory.VeteranOrganization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VeteranId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("VeteranId");

                    b.ToTable("VeteranOrganizations");
                });

            modelBuilder.Entity("WebApi.VeteranSaleDirectory.VeteranSale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("SaleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VeteranId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isActivated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.HasIndex("VeteranId");

                    b.ToTable("VeteranSales");
                });

            modelBuilder.Entity("WebApi.UserDirectory.Enterpreneur", b =>
                {
                    b.HasBaseType("WebApi.UserDirectory.User");

                    b.Property<Guid?>("BusinessId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("BusinessId");

                    b.HasDiscriminator().HasValue("Enterpreneur");
                });

            modelBuilder.Entity("WebApi.UserDirectory.Veteran", b =>
                {
                    b.HasBaseType("WebApi.UserDirectory.User");

                    b.Property<string>("VeteranCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("veteran");
                });

            modelBuilder.Entity("WebApi.UserDirectory.VeteranCenter", b =>
                {
                    b.HasBaseType("WebApi.UserDirectory.User");

                    b.HasDiscriminator().HasValue("enterpreneur");
                });

            modelBuilder.Entity("WebApi.AwardDirectory.Award", b =>
                {
                    b.HasOne("WebApi.UserDirectory.Veteran", null)
                        .WithMany("Awards")
                        .HasForeignKey("VeteranId");
                });

            modelBuilder.Entity("WebApi.BusinessRatingsDirectory.BusinessRatings", b =>
                {
                    b.HasOne("WebApi.BusinessDirectory.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId");

                    b.HasOne("WebApi.UserDirectory.Veteran", "Veteran")
                        .WithMany()
                        .HasForeignKey("VeteranId");
                });

            modelBuilder.Entity("WebApi.EnterpreneurSaleDirectory.EnterpreneurSale", b =>
                {
                    b.HasOne("WebApi.BusinessDirectory.Business", "Business")
                        .WithMany("EnterpreneurSales")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("WebApi.VeteranOrganizationDirectory.VeteranOrganization", b =>
                {
                    b.HasOne("WebApi.OrganizationDirectory.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("WebApi.UserDirectory.Veteran", "Veteran")
                        .WithMany()
                        .HasForeignKey("VeteranId");
                });

            modelBuilder.Entity("WebApi.VeteranSaleDirectory.VeteranSale", b =>
                {
                    b.HasOne("WebApi.BusinessDirectory.Business", null)
                        .WithMany("VeteranSales")
                        .HasForeignKey("BusinessId");

                    b.HasOne("WebApi.UserDirectory.Veteran", "Veteran")
                        .WithMany()
                        .HasForeignKey("VeteranId");
                });

            modelBuilder.Entity("WebApi.UserDirectory.Enterpreneur", b =>
                {
                    b.HasOne("WebApi.BusinessDirectory.Business", null)
                        .WithMany("Enterpreneurs")
                        .HasForeignKey("BusinessId");
                });
#pragma warning restore 612, 618
        }
    }
}
