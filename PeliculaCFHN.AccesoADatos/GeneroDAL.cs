using Microsoft.EntityFrameworkCore;
using PeliculaCFHN.EntidadeDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculaCFHN.AccesoADatos
{
    public class GeneroDAL
    {
        public static async Task<int> CrearAsync(Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pGenero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
                genero.Nombre = pGenero.Nombre;
                dbContexto.Update(genero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Genero pGenero)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var genero = await dbContexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
                dbContexto.Genero.Remove(genero);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Genero> OptenerPorIdAsync(Genero pGenero)
        {
            var genero = new Genero();
            using (var dbContexto = new DBContexto())
            {
                genero = await dbContexto.Genero.FirstOrDefaultAsync(g => g.Id == pGenero.Id);
            }
            return genero;
        }

        public static async Task<List<Genero>> OptenerTodosAsync()
        {
            var generos = new List<Genero>();
            using (var dbContexto = new DBContexto())
            {
                generos = await dbContexto.Genero.ToListAsync();
            }
            return generos;
        }

        internal static IQueryable<Genero> QuerySelect(IQueryable<Genero> pQuery, Genero pGenero)
        {
            if (pGenero.Id > 0)
                pQuery = pQuery.Where(g => g.Id == pGenero.Id);

            if (!string.IsNullOrWhiteSpace(pGenero.Nombre))
                pQuery = pQuery.Where(g => g.Nombre.Contains(pGenero.Nombre));
            pQuery = pQuery.OrderByDescending(g => g.Id).AsQueryable();

            if (pGenero.Top_Aux > 0)
                pQuery = pQuery.Take(pGenero.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Genero>> BuscarAsync(Genero pGenero)
        {
            var generos = new List<Genero>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Genero.AsQueryable();
                select = QuerySelect(select, pGenero);
                generos = await select.ToListAsync();
            }
            return generos;
        }
    }
}
