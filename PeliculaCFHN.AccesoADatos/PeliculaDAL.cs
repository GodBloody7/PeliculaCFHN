using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.AccesoADatos
{
    public class PeliculaDAL
    {
        public static async Task<int> CrearAsync(Pelicula pPelicula)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pPelicula);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;

        }

        public static async Task<int> ModificarAsync(Pelicula pPelicula)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pelicula = await bdContexto.Pelicula.FirstOrDefaultAsync(p => p.Id == pPelicula.Id);
                pelicula.IdGenero = pPelicula.IdGenero;
                pelicula.IdDirector = pPelicula.IdDirector;
                pelicula.Titulo = pPelicula.Titulo;
                pelicula.FechaEstreno = pPelicula.FechaEstreno;
                pelicula.Actores = pPelicula.Actores;
                pelicula.Descripcion = pPelicula.Descripcion;
                pelicula.Imagen = pPelicula.Imagen;

                bdContexto.Update(pelicula);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Pelicula pPelicula)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pelicula = await bdContexto.Pelicula.FirstOrDefaultAsync(p => p.Id == pPelicula.Id);
                bdContexto.Pelicula.Remove(pelicula);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Pelicula> ObtenerPorIdAsync(Pelicula pPelicula)
        {
            var pelicula = new Pelicula();
            using (var bdContexto = new BDContexto())
            {
                pelicula = await bdContexto.Pelicula.FirstOrDefaultAsync(p => p.Id == pPelicula.Id);
            }
            return pelicula;
        }

        public static async Task<List<Pelicula>> ObtenerTodosAsync()
        {
            var peliculas = new List<Pelicula>();
            using (var bdContecto = new BDContexto())
            {
                peliculas = await bdContecto.Pelicula.ToListAsync();
            }
            return peliculas;
        }

        internal static IQueryable<Pelicula> QuerySelect(IQueryable<Pelicula> pQuery, Pelicula pPelicula)
        {
            if (pPelicula.Id > 0)
                pQuery = pQuery.Where(p => p.Id == pPelicula.Id);

            if (pPelicula.IdGenero > 0)
                pQuery = pQuery.Where(p => p.IdGenero == pPelicula.IdGenero);

            if (pPelicula.IdDirector > 0)
                pQuery = pQuery.Where(p => p.IdDirector == pPelicula.IdDirector);

            if (!string.IsNullOrWhiteSpace(pPelicula.Titulo))
                pQuery = pQuery.Where(p => p.Titulo.Contains(pPelicula.Titulo));
            /** 
            if (!string.IsNullOrWhiteSpace(pPelicula.FechaEstreno))
                pQuery = pQuery.Where(p => p.FechaEstreno.Contains(pPelicula.FechaEstreno));
            if (!string.IsNullOrWhiteSpace(pPelicula.Actores))
                pQuery = pQuery.Where(p => p.Actores.Contains(pPelicula.Actores));
            if (!string.IsNullOrWhiteSpace(pPelicula.Descripcion))
                pQuery = pQuery.Where(p => p.Descripcion.Contains(pPelicula.Descripcion));
            if (!string.IsNullOrWhiteSpace(pPelicula.Imagen))
                pQuery = pQuery.Where(p => p.Imagen.Contains(pPelicula.Imagen));
            **/
            pQuery = pQuery.OrderByDescending(p => p.Id).AsQueryable();
            if (pPelicula.Top_Aux > 0)
                pQuery = pQuery.Take(pPelicula.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Pelicula>> BuscarAsync(Pelicula pPelicula)
        {
            var peliculas = new List<Pelicula>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Pelicula.AsQueryable();
                select = QuerySelect(select, pPelicula);
                peliculas = await select.ToListAsync();
            }
            return peliculas;
        }

        public static async Task<List<Pelicula>> BuscarIncluirRelacionesAsync(Pelicula pPelicula)
        {
            var peliculas = new List<Pelicula>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Pelicula.AsQueryable();
                select = QuerySelect(select, pPelicula).Include(p => p.Genero).Include(p => p.Director).AsQueryable();
                peliculas = await select.ToListAsync();
            }

            return peliculas;
        }
    }
}
