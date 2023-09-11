using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PeliculaCFHN.AccesoADatos;
using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.LogicaDeNegocio
{
    public class PeliculaBL
    {
        public async Task<int> CrearAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.CrearAsync(pPelicula);
        }

        public async Task<int> ModificarAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.ModificarAsync(pPelicula);
        }

        public async Task<int> EliminarAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.EliminarAsync(pPelicula);
        }

        public async Task<Pelicula> ObtenerPorIdAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.ObtenerPorIdAsync(pPelicula);
        }

        public async Task<List<Pelicula>> ObtenerTodosAsync()
        {
            return await PeliculaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Pelicula>> BuscarAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.BuscarAsync(pPelicula);
        }

        public async Task<List<Pelicula>> BuscarIncluirRelacionesAsync(Pelicula pPelicula)
        {
            return await PeliculaDAL.BuscarIncluirRelacionesAsync(pPelicula);
        }
    }
}
