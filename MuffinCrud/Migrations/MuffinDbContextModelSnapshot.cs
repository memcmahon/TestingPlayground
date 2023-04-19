﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MuffinCrud.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MuffinCrud.Migrations
{
    [DbContext(typeof(MuffinDbContext))]
    partial class MuffinDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MuffinCrud.Models.Muffin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("flavor");

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("boolean")
                        .HasColumnName("is_gluten_free");

                    b.HasKey("Id")
                        .HasName("pk_muffins");

                    b.ToTable("muffins", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
