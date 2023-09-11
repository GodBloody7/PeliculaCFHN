using Microsoft.EntityFrameworkCore;
using PeliculaCFHN.EntidadeDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculaCFHN.AccesoADatos
{
    public class DirectorDAL
    {
        public static async Task<int> CrearAsync (Director pDirector)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDirector);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync (Director pDirector)
        {
            int result = 0;
            using(var bdContexto = new BDContexto())
            {
                var director = await bdContexto.Director.FirstOrDefaultAsync(d => d.Id == pDirector.Id);
                director.Nombre = pDirector.Nombre;
                director.Apellido = pDirector.Apellido;
                director.Nacionalidad = pDirector.Nacionalidad;
                director.Imagen = pDirector.Imagen;
                bdContexto.Update(director);
                result = await bdContexto.SaveChangesAsync();


            }
            return result;
        }

        public static async Task<int> EliminarAsync(Director pDirector)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var director = await bdContexto.Director.FirstOrDefaultAsync(d => d.Id == pDirector.Id);
                bdContexto.Director.Remove(director);
                result =  await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Director> ObtenerPorIdAsync (Director pDirector)
        {
            var director = new Director();
            using (var bdContexto = new BDContexto()) 
            {
                director = await bdContexto.Director.FirstOrDefaultAsync(d => d.Id == pDirector.Id);
            }
            return director;

        }

        public static async Task<List<Director>> ObtenerTodosAsync()
        {
            var directores = new List<Director>();
            using(var bdContexto = new BDContexto())
            {
                directores = await bdContexto.Director.ToListAsync();
            }
            return directores;
        }

        internal static IQueryable<Director> QuerySelect(IQueryable<Director>pQuery, Director pDirector){
            if (pDirector.Id > 0)
                pQuery = pQuery.Where(d => d.Id == pDirector.Id);

            if (!String.IsNullOrWhiteSpace(pDirector.Nombre))
            
                pQuery = pQuery.Where(d => d.Nombre.Contains(pDirector.Nombre));
                pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();
            


            if (!String.IsNullOrWhiteSpace(pDirector.Apellido))
            
                pQuery = pQuery.Where(d => d.Apellido.Contains(pDirector.Apellido));
                pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();
            
            
            
            if (!String.IsNullOrWhiteSpace(pDirector.FechaNacimiento))
            
                pQuery = pQuery.Where(d => d.FechaNacimiento.Contains(pDirector.FechaNacimiento));
                pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();
            
            
            if (!String.IsNullOrWhiteSpace(pDirector.Nacionalidad))
            
                pQuery = pQuery.Where(d => d.Nacionalidad.Contains(pDirector.Nacionalidad));
                pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();
            


            if (!String.IsNullOrWhiteSpace(pDirector.Imagen))
            
                pQuery = pQuery.Where(d => d.Imagen.Contains(pDirector.Imagen));
               pQuery = pQuery.OrderByDescending(d => d.Id).AsQueryable();

            if (pDirector.Top_Aux > 0)
                pQuery = pQuery.Take(pDirector.Top_Aux).AsQueryable();
            
            return pQuery;
        }

        public static async Task<List<Director>> BuscarAsync(Director pDirector)
        {
            var directores = new List<Director>();
            using(var bdContexto = new BDContexto())
            {
                var select = bdContexto.Director.AsQueryable();
                select = QuerySelect(select, pDirector);
                directores = await select.ToListAsync();
            }
            return directores;
        }

    }
}
