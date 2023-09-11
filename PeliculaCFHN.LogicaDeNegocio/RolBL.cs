using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PeliculaCFHN.AccesoADatos;
using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.LogicaDeNegocio
{
    public class RolBL
    {
        public async Task<int> CrearAsync(Rol pRol)
        {
            return await RolDAL.CrearAsync(pRol);
        }
        public async Task<int> ModificarAsync(Rol pRol)
        {
            return await RolDAL.ModificarAsync(pRol);
        }
        public async Task<int> EliminarAsync(Rol pRol)
        {
            return await RolDAL.EliminarAsync(pRol);
        }
        public async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            return await RolDAL.OptenerPorIdAsync(pRol);
        }
        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await RolDAL.OptenerTodosAsync();
        }
        public async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
    }
}
