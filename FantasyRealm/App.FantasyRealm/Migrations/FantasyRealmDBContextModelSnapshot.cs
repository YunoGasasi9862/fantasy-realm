﻿// <auto-generated />
using System;
using App.FantasyRealm.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.FantasyRealm.Migrations
{
    [DbContext(typeof(FantasyRealmDBContext))]
    partial class FantasyRealmDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.FantasyRealm.Domain.FantasyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FantasyUsers");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.FantasyUserPersonalityAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FantasyUserId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalityTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FantasyUserId");

                    b.HasIndex("PersonalityTypeId");

                    b.ToTable("FantsayUserPersonalityAssociations");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.PersonalityAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChoiceId");

                    b.HasIndex("PersonalityTypeId");

                    b.HasIndex("QuestionId");

                    b.ToTable("PersonalityAnswers");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.PersonalityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("Id");

                    b.ToTable("PersonalityTypes");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Verbiage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.QuestionChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Choice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.FantasyUserPersonalityAssociation", b =>
                {
                    b.HasOne("App.FantasyRealm.Domain.FantasyUser", "FantasyUser")
                        .WithMany()
                        .HasForeignKey("FantasyUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.FantasyRealm.Domain.PersonalityType", "PersonalityType")
                        .WithMany()
                        .HasForeignKey("PersonalityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FantasyUser");

                    b.Navigation("PersonalityType");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.PersonalityAnswer", b =>
                {
                    b.HasOne("App.FantasyRealm.Domain.QuestionChoice", "Choice")
                        .WithMany()
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.FantasyRealm.Domain.PersonalityType", "PersonalityType")
                        .WithMany()
                        .HasForeignKey("PersonalityTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.FantasyRealm.Domain.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Choice");

                    b.Navigation("PersonalityType");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("App.FantasyRealm.Domain.QuestionChoice", b =>
                {
                    b.HasOne("App.FantasyRealm.Domain.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}
