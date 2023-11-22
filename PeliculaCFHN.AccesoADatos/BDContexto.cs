using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PeliculaCFHN.EntidadeDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace PeliculaCFHN.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source=henryramos;Initial Catalog=Peliculas;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NFDMETJ\SQLEXPRESS;Initial Catalog=Peliculas;Integrated Security=True");

            //optionsBuilder.UseSqlServer(@"Data Source=henryramos;Initial Catalog=Peliculas;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NFDMETJ\SQLEXPRESS;Initial Catalog=Peliculas;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=PC-FERNANDO;Initial Catalog=Peliculas;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=ServidorHR; Initial Catalog=Pelicula; User Id=sa: Pwd=Admin2023: encrypt=false; trustServerCertificate=true");

        }
    }
}
