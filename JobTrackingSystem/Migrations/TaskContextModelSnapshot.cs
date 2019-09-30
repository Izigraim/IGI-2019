﻿// <auto-generated />
using System;
using JobTrackingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobTrackingSystem.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobTrackingSystem.Models.TrackingTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dateOfFinishing");

                    b.Property<string>("dateOfTaking");

                    b.Property<string>("status");

                    b.Property<string>("taskName");

                    b.Property<int?>("whoGaveId");

                    b.Property<int?>("whoTakeId");

                    b.HasKey("Id");

                    b.HasIndex("whoGaveId");

                    b.HasIndex("whoTakeId");

                    b.ToTable("TrackingTasks");
                });

            modelBuilder.Entity("JobTrackingSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("nickname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobTrackingSystem.Models.TrackingTask", b =>
                {
                    b.HasOne("JobTrackingSystem.Models.User", "whoGave")
                        .WithMany()
                        .HasForeignKey("whoGaveId");

                    b.HasOne("JobTrackingSystem.Models.User", "whoTake")
                        .WithMany()
                        .HasForeignKey("whoTakeId");
                });
#pragma warning restore 612, 618
        }
    }
}
