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
    public class DirectorDALTests
    {

        private static Director directorInicial = new Director { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var director = new Director();
            director.Nombre = "Mel";
            director.Apellido = "Gibson";
            director.FechaNacimiento = "09/07/1980";
            director.Nacionalidad = " EUU";
            director.Imagen = "png.imge";
            int result = await DirectorDAL.CrearAsync(director);
            Assert.AreNotEqual(0, result);
            directorInicial.Id = director.Id;
            
        
        
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var director = new Director();
            director.Id = directorInicial.Id;
            director.Nombre = "Mel";
            director.Apellido = "Gibson";
            director.FechaNacimiento = "09/07/1980";
            director.Nacionalidad = "Estados Unidos";
            director.Imagen = "png.imgenes";
            int result = await DirectorDAL.ModificarAsync(director);
            Assert.AreNotEqual(0, result);
           
        }


        [TestMethod()]
        public async Task T3ObtenerPorIdTest()
        {
            var director = new Director();
            director.Id = directorInicial.Id;
            var resultDirector = await DirectorDAL.ObtenerPorIdAsync(director);
            Assert.AreEqual(director.Id, resultDirector.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultDirectores = await DirectorDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultDirectores.Count);


        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var director  = new  Director();
            director.Nombre = "A";
            director.Apellido = "i";
            director.FechaNacimiento = "9";
            director.Nacionalidad = "s";
         
            director.Top_Aux = 10;
            var resultDirectores = await DirectorDAL.BuscarAsync(director);
            Assert.AreNotEqual(0, resultDirectores.Count);


        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var director = new  Director();
            director.Id = directorInicial.Id;
            int result = await DirectorDAL.EliminarAsync(director);
            Assert.AreNotEqual(0, result);

        }

    }
}