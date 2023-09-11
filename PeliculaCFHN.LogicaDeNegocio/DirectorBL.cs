using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PeliculaCFHN.AccesoADatos;
using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.LogicaDeNegocio
{
    public class DirectorBL
    {

        public async Task<int>CrearAsync(Director pDirector)
        {
            return await DirectorDAL.CrearAsync(pDirector); 
        }
        public async Task<int>ModificarAsync(Director pDirector)
        {
            return await DirectorDAL.ModificarAsync(pDirector); 
        }
        public async Task<int>EliminarAsync(Director pDirector)
        {
            return await DirectorDAL.EliminarAsync(pDirector);
        }
        public async Task<Director> ObtenerPorIdAsync(Director pDirector)
        {
            return await DirectorDAL.ObtenerPorIdAsync(pDirector);
        }
        public async Task<List<Director>> ObtenerTodosAsync()
        {
            return await DirectorDAL.ObtenerTodosAsync();
        }
        public async Task<List<Director>> BuscarAsync(Director pDirector)
        {
            return await DirectorDAL.BuscarAsync(pDirector);
        }

    }
}
