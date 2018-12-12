﻿// <auto-generated />
using System;
using CityAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CityAppBackend.Migrations
{
    [DbContext(typeof(CityAppBackendContext))]
    partial class CityAppBackendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CityAppBackend.Models.Business", b =>
                {
                    b.Property<Guid>("BusinessId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("Business");

                    b.Property<string>("Category");

                    b.Property<string>("Name");

                    b.HasKey("BusinessId");

                    b.HasIndex("Business")
                        .IsUnique()
                        .HasFilter("[Business] IS NOT NULL");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("CityAppBackend.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CityAppBackend.Models.Business", b =>
                {
                    b.HasOne("CityAppBackend.Models.User", "User")
                        .WithOne("Business")
                        .HasForeignKey("CityAppBackend.Models.Business", "Business");
                });
#pragma warning restore 612, 618
        }
    }
}
