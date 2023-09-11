using Microsoft.VisualStudio.TestTools.UnitTesting;

using PeliculaCFHN.AccesoADatos;
using PeliculaCFHN.EntidadeDeNegocio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculaCFHN.AccesoADatos.Tests
{
    [TestClass()]
    public class RolDALTests
    {
        private static Rol rolInicial = new Rol { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "Adminitrador";
            int result = await RolDAL.CrearAsync(rol);
            Assert.AreNotEqual(0, result);
            rolInicial.Id = rol.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            rol.Nombre = "Admin";
            int result = await RolDAL.ModificarAsync(rol);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3OptenerPorIdAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            var result = await RolDAL.OptenerPorIdAsync(rol);
            Assert.AreNotEqual(rol.Id, rolInicial.Id);
        }

        [TestMethod()]
        public async Task T4OptenerTodosAsyncTest()
        {
            var resultRoles = await RolDAL.OptenerTodosAsync();
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var rol = new Rol();
            rol.Nombre = "a";
            rol.Top_Aux = 10;
            var resultRoles = await RolDAL.BuscarAsync(rol);
            Assert.AreNotEqual(0, resultRoles.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var rol = new Rol();
            rol.Id = rolInicial.Id;
            int result = await RolDAL.EliminarAsync(rol);
            Assert.AreNotEqual(0, result);
        }
    }
}