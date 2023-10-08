﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vebtech_test.DAL.DateDbContext;

#nullable disable

namespace vebtech_test.DAL.Migrations
{
    [DbContext(typeof(VebtechDbContext))]
    partial class VebtechDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("vebtech_test.DAL.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"),
                            Name = "User"
                        },
                        new
                        {
                            Id = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("ba96c858-bc06-463d-864e-d411836fc931"),
                            Name = "Support"
                        },
                        new
                        {
                            Id = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"),
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("vebtech_test.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"),
                            Age = 25,
                            Email = "user1@example.com",
                            Name = "User1"
                        },
                        new
                        {
                            Id = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"),
                            Age = 30,
                            Email = "admin1@example.com",
                            Name = "Admin1"
                        },
                        new
                        {
                            Id = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"),
                            Age = 35,
                            Email = "superadmin1@example.com",
                            Name = "SuperAdmin1"
                        });
                });

            modelBuilder.Entity("vebtech_test.DAL.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5db705b2-6c4f-41b6-a461-56ba62b96082"),
                            RoleId = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8"),
                            UserId = new Guid("d80c8954-b524-4f3e-960a-7711fde800d8")
                        },
                        new
                        {
                            Id = new Guid("d6ef90dd-537b-4d6e-9587-118db3a09353"),
                            RoleId = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d"),
                            UserId = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d")
                        },
                        new
                        {
                            Id = new Guid("dd844386-9d3f-47b8-984b-46c295219c4f"),
                            RoleId = new Guid("ba96c858-bc06-463d-864e-d411836fc931"),
                            UserId = new Guid("42bd93a1-2704-4351-bace-ae9814b6e45d")
                        },
                        new
                        {
                            Id = new Guid("c4b467c8-a335-416b-8b5c-4912d9c694e5"),
                            RoleId = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0"),
                            UserId = new Guid("c594c4db-11f6-49aa-84ce-d04c38eb56b0")
                        });
                });

            modelBuilder.Entity("vebtech_test.DAL.Entities.UserRole", b =>
                {
                    b.HasOne("vebtech_test.DAL.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("vebtech_test.DAL.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("vebtech_test.DAL.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("vebtech_test.DAL.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
