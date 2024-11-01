﻿using Gualoto_Romel_ExamenProgreso1.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<RGualoto> Apellidos { get; set; }
    public DbSet<Celular> Celulares { get; set; }
}
