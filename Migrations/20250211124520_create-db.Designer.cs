﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex;

#nullable disable

namespace Pokedex.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250211124520_create-db")]
    partial class createdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "latin1");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Pokedex.Models.Pokemon", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("pokedexNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pokemon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("trainerId")
                        .HasColumnType("bigint");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("trainerId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("Pokedex.Models.Trainer", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<DateTime?>("creationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("dateDelete")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("initialPokemon")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Treiners");
                });

            modelBuilder.Entity("Pokedex.Models.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("hash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("typeUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pokedex.Models.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Models.Trainer", "treiner")
                        .WithMany()
                        .HasForeignKey("trainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("treiner");
                });

            modelBuilder.Entity("Pokedex.Models.Trainer", b =>
                {
                    b.HasOne("Pokedex.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
