using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReservacionHoteles.Models;



namespace ReservacionHoteles.Repos;

public partial class ReservacionHotelesContext : DbContext
{
    public ReservacionHotelesContext()
    {
    }

    public ReservacionHotelesContext(DbContextOptions<ReservacionHotelesContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Hotel> Hotel { get; set; }
    public virtual DbSet<Destinos> Destinos{ get; set; }
    public virtual DbSet<Habitaciones> Habitaciones{ get; set; }
    public virtual DbSet<Disponibilidad> Disponibilidad { get; set; }
    public virtual DbSet<Tipo> Tipo { get; set; }
    public virtual DbSet<CondicionPago> CondicionPago { get; set; }
    public virtual DbSet<ListaPrecio> ListaPrecio { get; set; }
    public virtual DbSet<Tarifa> Tarifa { get; set; }
    public virtual DbSet<Funcion> Funcion { get; set; }
    public DbSet<GestionReserva> GestionReservas { get; set; }
    public DbSet<funcionTarifa> FuncionTarifas { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //   => optionsBuilder.UseSqlServer("name=conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
