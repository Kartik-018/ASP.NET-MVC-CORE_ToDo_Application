﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using To_Do.Models;

#nullable disable

namespace To_Do.Migrations
{
    [DbContext(typeof(ToDos))]
    [Migration("20231020160639_UpdateBargraphItems")]
    partial class UpdateBargraphItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("To_Do.Models.BargraphItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("completed_task")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("bargraphItems");
                });

            modelBuilder.Entity("To_Do.Models.ToDoItems", b =>
                {
                    b.Property<int>("todo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("todo_id"));

                    b.Property<DateTime>("date_added")
                        .HasColumnType("date");

                    b.Property<DateTime>("due_date")
                        .HasColumnType("date");

                    b.Property<string>("task_name")
                        .HasColumnType("varchar(MAX)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("todo_id");

                    b.ToTable("toDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
