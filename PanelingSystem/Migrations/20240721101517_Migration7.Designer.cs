﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PanelingSystem.DatabaseContext;

#nullable disable

namespace PanelingSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240721101517_Migration7")]
    partial class Migration7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PanelingSystem.Models.CapstoneFileModel", b =>
                {
                    b.Property<int>("CapstoneFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CapstoneFileId"));

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("CapstoneFileId");

                    b.ToTable("CapstoneFiles", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.CommentModel", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrouId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.FileModel", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"));

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilePosition")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.ToTable("Files", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.GradeModel", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<string>("GradedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradedById")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GradeId");

                    b.HasIndex("UserId");

                    b.ToTable("Grades", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.GroupModel", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupThesisTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Groupname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.MembersModel", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Members", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.PanelistModel", b =>
                {
                    b.Property<int>("PanelistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PanelistId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int?>("ScheduleModelScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PanelistId");

                    b.HasIndex("ScheduleModelScheduleId");

                    b.HasIndex("UserId");

                    b.ToTable("Panels", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.ScheduleModel", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"));

                    b.Property<int>("DefenseType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScheduleId");

                    b.HasIndex("GroupId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("PanelingSystem.Models.UserAccountModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("PanelingSystem.Models.CommentModel", b =>
                {
                    b.HasOne("PanelingSystem.Models.UserAccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("PanelingSystem.Models.GradeModel", b =>
                {
                    b.HasOne("PanelingSystem.Models.UserAccountModel", "Student")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PanelingSystem.Models.MembersModel", b =>
                {
                    b.HasOne("PanelingSystem.Models.GroupModel", null)
                        .WithMany("Members")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PanelingSystem.Models.UserAccountModel", "Student")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PanelingSystem.Models.PanelistModel", b =>
                {
                    b.HasOne("PanelingSystem.Models.ScheduleModel", null)
                        .WithMany("Panels")
                        .HasForeignKey("ScheduleModelScheduleId");

                    b.HasOne("PanelingSystem.Models.UserAccountModel", "Panel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Panel");
                });

            modelBuilder.Entity("PanelingSystem.Models.ScheduleModel", b =>
                {
                    b.HasOne("PanelingSystem.Models.GroupModel", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("PanelingSystem.Models.GroupModel", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("PanelingSystem.Models.ScheduleModel", b =>
                {
                    b.Navigation("Panels");
                });
#pragma warning restore 612, 618
        }
    }
}