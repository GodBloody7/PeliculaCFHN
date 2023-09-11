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
    public class GeneroDALTests
    {
        private static Genero generoInicial = new Genero { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "Terror";
            int result = await GeneroDAL.CrearAsync(genero);
            Assert.AreNotEqual(0, result);
            generoInicial.Id = genero.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            genero.Nombre = "Infantiles";
            int result = await GeneroDAL.ModificarAsync(genero);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3OptenerPorIdAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            var result = await GeneroDAL.OptenerPorIdAsync(genero);
            Assert.AreNotEqual(genero.Id, generoInicial.Id);
        }

        [TestMethod()]
        public async Task T4OptenerTodosAsyncTest()
        {
            var resultGeneros = await GeneroDAL.OptenerTodosAsync();
            Assert.AreNotEqual(0, resultGeneros.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "te";
            genero.Top_Aux = 10;
            var resultGeneros = await GeneroDAL.BuscarAsync(genero);
            Assert.AreNotEqual(0, resultGeneros.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            int result = await GeneroDAL.EliminarAsync(genero);
            Assert.AreNotEqual(0, result);
        }
    }
}