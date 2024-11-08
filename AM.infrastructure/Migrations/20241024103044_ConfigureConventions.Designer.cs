﻿// <auto-generated />
using System;
using AM.infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20241024103044_ConfigureConventions")]
    partial class ConfigureConventions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Am.ApplicationCore.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("AirlineLogo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("EffictiveArrival")
                        .HasColumnType("date");

                    b.Property<int>("EstimedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("date");

                    b.Property<int>("PLaneFK")
                        .HasColumnType("int");

                    b.Property<string>("departure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("FlightId");

                    b.HasIndex("PLaneFK");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Passengers", b =>
                {
                    b.Property<int>("PassportNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassportNumber"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmailPassort")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passengers");

                    b.HasDiscriminator().HasValue("Passengers");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCpacity");

                    b.Property<DateTime>("ManufactDate")
                        .HasColumnType("date");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlanes", (string)null);
                });

            modelBuilder.Entity("FlightPassengers", b =>
                {
                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("passengersPassportNumber")
                        .HasColumnType("int");

                    b.HasKey("FlightId", "passengersPassportNumber");

                    b.HasIndex("passengersPassportNumber");

                    b.ToTable("reservition", (string)null);
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Staff", b =>
                {
                    b.HasBaseType("Am.ApplicationCore.Domain.Passengers");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("date");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("Staff");
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Travaler", b =>
                {
                    b.HasBaseType("Am.ApplicationCore.Domain.Passengers");

                    b.Property<string>("Nationlitay")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("healthinformation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasDiscriminator().HasValue("Travaler");
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Flight", b =>
                {
                    b.HasOne("Am.ApplicationCore.Domain.Plane", "plane")
                        .WithMany("flight")
                        .HasForeignKey("PLaneFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plane");
                });

            modelBuilder.Entity("FlightPassengers", b =>
                {
                    b.HasOne("Am.ApplicationCore.Domain.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Am.ApplicationCore.Domain.Passengers", null)
                        .WithMany()
                        .HasForeignKey("passengersPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Am.ApplicationCore.Domain.Plane", b =>
                {
                    b.Navigation("flight");
                });
#pragma warning restore 612, 618
        }
    }
}
