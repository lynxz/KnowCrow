﻿// <auto-generated />
using System;
using KnowCrow.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KnowCrow.GraphQL.Migrations
{
    [DbContext(typeof(CrowDbContext))]
    [Migration("20221004185944_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WorkExperienceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Ended")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Started")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Person", b =>
                {
                    b.HasOne("KnowCrow.GraphQL.Data.Subject", null)
                        .WithMany("People")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Score", b =>
                {
                    b.HasOne("KnowCrow.GraphQL.Data.Person", "Person")
                        .WithMany("Scores")
                        .HasForeignKey("PersonId");

                    b.HasOne("KnowCrow.GraphQL.Data.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Person");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Subject", b =>
                {
                    b.HasOne("KnowCrow.GraphQL.Data.WorkExperience", null)
                        .WithMany("Subjects")
                        .HasForeignKey("WorkExperienceId");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.WorkExperience", b =>
                {
                    b.HasOne("KnowCrow.GraphQL.Data.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("KnowCrow.GraphQL.Data.Person", "Person")
                        .WithMany("Experiences")
                        .HasForeignKey("PersonId");

                    b.Navigation("Company");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Person", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Scores");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.Subject", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("KnowCrow.GraphQL.Data.WorkExperience", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}