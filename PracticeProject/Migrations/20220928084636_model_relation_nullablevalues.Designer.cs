﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticeProject.Database;

#nullable disable

namespace PracticeProject.Migrations
{
    [DbContext(typeof(FamilyDbContext))]
    [Migration("20220928084636_model_relation_nullablevalues")]
    partial class model_relation_nullablevalues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PracticeProject.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PracticeProject.Models.Relation", b =>
                {
                    b.Property<int>("RelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelationId"), 1L, 1);

                    b.Property<int?>("PersonId1")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId2")
                        .HasColumnType("int");

                    b.Property<string>("RelationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelationId");

                    b.HasIndex("PersonId1");

                    b.HasIndex("PersonId2");

                    b.ToTable("Relations");
                });

            modelBuilder.Entity("PracticeProject.Models.Relation", b =>
                {
                    b.HasOne("PracticeProject.Models.Person", "Person1")
                        .WithMany("Person1Relations")
                        .HasForeignKey("PersonId1");

                    b.HasOne("PracticeProject.Models.Person", "Person2")
                        .WithMany("Person2Relations")
                        .HasForeignKey("PersonId2")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Person1");

                    b.Navigation("Person2");
                });

            modelBuilder.Entity("PracticeProject.Models.Person", b =>
                {
                    b.Navigation("Person1Relations");

                    b.Navigation("Person2Relations");
                });
#pragma warning restore 612, 618
        }
    }
}
