﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.ERD.Appspace.Data;

#nullable disable

namespace Reservation.ERD.Appspace.Migrations
{
    [DbContext(typeof(ReservationContext))]
    partial class ReservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Resource", (string)null);
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.ResourceEvent", b =>
                {
                    b.Property<Guid>("ResourceEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("TEXT");

                    b.HasKey("ResourceEventId");

                    b.HasIndex("EventId");

                    b.HasIndex("ResourceId");

                    b.ToTable("ResourceEvent", (string)null);
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.ResourceEventAttendee", b =>
                {
                    b.Property<Guid>("ResourceEventAttendeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ResourceEventId")
                        .HasColumnType("TEXT");

                    b.HasKey("ResourceEventAttendeeId");

                    b.HasIndex("ResourceEventId");

                    b.ToTable("ResourceEventAttendee", (string)null);
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.ResourceEvent", b =>
                {
                    b.HasOne("Reservation.ERD.Appspace.Model.Event", null)
                        .WithMany("ResourceEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservation.ERD.Appspace.Model.Resource", null)
                        .WithMany("ResourceEvents")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.ResourceEventAttendee", b =>
                {
                    b.HasOne("Reservation.ERD.Appspace.Model.ResourceEvent", null)
                        .WithMany("ResourceEventAttendees")
                        .HasForeignKey("ResourceEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.Event", b =>
                {
                    b.Navigation("ResourceEvents");
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.Resource", b =>
                {
                    b.Navigation("ResourceEvents");
                });

            modelBuilder.Entity("Reservation.ERD.Appspace.Model.ResourceEvent", b =>
                {
                    b.Navigation("ResourceEventAttendees");
                });
#pragma warning restore 612, 618
        }
    }
}
