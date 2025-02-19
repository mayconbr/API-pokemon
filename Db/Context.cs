﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex;

public partial class Context : DbContext
{
   public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Trainer> Treiners { get; set; }
    public DbSet<User> Users { get; set; }

    #region DB_FACTORY
    public Context()
    {
    }

    //injecao de configuracao do context
    public Context(DbContextOptions<Context> options): base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            string conn = configuration.GetSection("DatabaseData")["MySQL"];
            optionsBuilder.UseMySql(conn, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.17-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    #endregion

}
