﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProccesFlowTraning.Data;

#nullable disable

namespace ProccesFlowTraning.Migrations
{
    [DbContext(typeof(SmartFlowDbContext))]
    [Migration("20231111095717_m2")]
    partial class m2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProccesFlowTraning.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeState")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateGender")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.Process", b =>
                {
                    b.Property<int?>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessId"));

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessState")
                        .HasColumnType("int");

                    b.HasKey("ProcessId");

                    b.ToTable("Processes");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.ProcessRequest", b =>
                {
                    b.Property<int?>("ProcessRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessRequestId"));

                    b.Property<DateTime?>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessRequestState")
                        .HasColumnType("int");

                    b.Property<int?>("ProcessStagesId")
                        .HasColumnType("int");

                    b.Property<string>("RequestDescraption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcessRequestId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProcessStagesId");

                    b.ToTable("ProcessRequests");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.ProcessStages", b =>
                {
                    b.Property<int?>("ProcessStagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessStagesId"));

                    b.Property<int?>("Next")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.HasKey("ProcessStagesId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("StageId");

                    b.ToTable("ProcessStages");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.Stage", b =>
                {
                    b.Property<int?>("StageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("StageId"));

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StageId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.ProcessRequest", b =>
                {
                    b.HasOne("ProccesFlowTraning.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ProccesFlowTraning.Models.ProcessStages", "ProcessStages")
                        .WithMany()
                        .HasForeignKey("ProcessStagesId");

                    b.Navigation("Employee");

                    b.Navigation("ProcessStages");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.ProcessStages", b =>
                {
                    b.HasOne("ProccesFlowTraning.Models.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId");

                    b.HasOne("ProccesFlowTraning.Models.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId");

                    b.Navigation("Process");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("ProccesFlowTraning.Models.Stage", b =>
                {
                    b.HasOne("ProccesFlowTraning.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
