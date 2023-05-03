﻿// <auto-generated />
using Emp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Emp.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Emp.Model.Models.BankDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("IFSCCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("bankDetailsList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNo = "1234567890",
                            Branch = "HYD",
                            EmployeeId = 1,
                            IFSCCode = "SBIN0000967"
                        });
                });

            modelBuilder.Entity("Emp.Model.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("departmentList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentName = "Digital",
                            Location = "Gurgaon"
                        });
                });

            modelBuilder.Entity("Emp.Model.Models.EmployeeDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("employeeDetailsList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DepartmentId = 1,
                            EmployeeCode = "22060023",
                            FirstName = "Guna",
                            LastName = "Varma"
                        });
                });

            modelBuilder.Entity("Emp.Model.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProjectLead")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("projectName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("projectsList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectLead = "Shiva",
                            projectName = "xNet"
                        });
                });

            modelBuilder.Entity("Emp.Model.Models.BankDetails", b =>
                {
                    b.HasOne("Emp.Model.Models.EmployeeDetails", "employeeDetails")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employeeDetails");
                });

            modelBuilder.Entity("Emp.Model.Models.EmployeeDetails", b =>
                {
                    b.HasOne("Emp.Model.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
