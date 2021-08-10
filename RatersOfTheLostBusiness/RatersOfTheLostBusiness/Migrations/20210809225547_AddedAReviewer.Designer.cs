﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RatersOfTheLostBusiness.Data;

namespace RatersOfTheLostBusiness.Migrations
{
    [DbContext(typeof(BusinessDbContext))]
    [Migration("20210809225547_AddedAReviewer")]
    partial class AddedAReviewer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("businesses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "375 Beale Street Suite 300",
                            City = "San Franciso",
                            Name = "Twilio",
                            PhoneNumber = "844-814-4627",
                            State = "CA",
                            Type = "Software Service"
                        });
                });

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.BusinessReview", b =>
                {
                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusinessId", "ReviewerId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("businessReviews");
                });

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("First")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("reviewers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "JS191@example.com",
                            First = "John",
                            Last = "Stewart",
                            PhoneNumber = "555-555-1221",
                            UserName = "BestGreenLatern"
                        });
                });

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.BusinessReview", b =>
                {
                    b.HasOne("RatersOfTheLostBusiness.Models.Business", "business")
                        .WithMany("BusinessReviews")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RatersOfTheLostBusiness.Models.Reviewer", "reviewer")
                        .WithMany("BusinessReviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("business");

                    b.Navigation("reviewer");
                });

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.Business", b =>
                {
                    b.Navigation("BusinessReviews");
                });

            modelBuilder.Entity("RatersOfTheLostBusiness.Models.Reviewer", b =>
                {
                    b.Navigation("BusinessReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
