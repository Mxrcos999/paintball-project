﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paintball_Project.Infrastructure.Context;

#nullable disable

namespace Paintball_Project.Infrastructure.Migrations
{
    [DbContext(typeof(PaintBallContext))]
    partial class PaintBallContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Paintball_Project.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeCreating")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("player");
                });

            modelBuilder.Entity("Paintball_Project.Domain.Entities.Scheduling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateHourScheduling")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeChange")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeCreating")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumberPlayer")
                        .HasColumnType("integer");

                    b.Property<int>("PlayerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("scheduling");
                });

            modelBuilder.Entity("Paintball_Project.Domain.Entities.Scheduling", b =>
                {
                    b.HasOne("Paintball_Project.Domain.Entities.Player", "Player")
                        .WithOne()
                        .HasForeignKey("Paintball_Project.Domain.Entities.Scheduling", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_scheduling_player");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
