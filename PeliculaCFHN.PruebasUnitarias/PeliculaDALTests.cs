using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeliculaCFHN.AccesoADatos;
using PeliculaCFHN.EntidadeDeNegocio;

namespace PeliculaCFHN.AccesoADatos.Tests
{
    [TestClass()]
    public class PeliculaDALTests
    {
        private static Pelicula peliculaInicial = new Pelicula { Id = 4, IdGenero = 1, IdDirector = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.IdGenero = peliculaInicial.IdGenero;
            pelicula.IdDirector = peliculaInicial.IdDirector;
            pelicula.Titulo = "Doctor Strange multiverso de la locura";
            pelicula.FechaEstreno = "06/05/2022";
            pelicula.Actores = "Benedict Cumberbatch, Elizabeth Olsen, Chiwetel Ejiofor, Benedict Wong, Xochitl Gomez, Jett Klyne, Julian Hilliard, Sheila Atim, Adam Hugil, Michael Stuhlbarg, Rachel McAdams";
            pelicula.Descripcion = "Viaja en lo desconocido con Doctor Strange, quien, con la ayuda de los antiguos y nuevos aliados místicos, atraviesa las realidades alternativas del Multiverso para enfrentarse a un nuevo y misterioso adversario.";
            pelicula.Imagen = "https://depor.com/resizer/0ezChNerx6qZKcgPu3nn9WsYRlc=/1200x1200/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/43EIEJEBXZHGDPXF4NBZ6O5DS4.jpg";

            int result = await PeliculaDAL.CrearAsync(pelicula);
            Assert.AreNotEqual(0, result);
            peliculaInicial.Id = pelicula.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.Id = peliculaInicial.Id;
            pelicula.IdGenero = peliculaInicial.IdGenero;
            pelicula.IdDirector = peliculaInicial.IdDirector;
            pelicula.Titulo = "Doctor Strange en el multiverso de la locura";
            pelicula.FechaEstreno = "06/05/2022";
            pelicula.Actores = "Benedict Cumberbatch, Elizabeth Olsen, Chiwetel Ejiofor, Benedict Wong, Xochitl Gomez, Jett Klyne, Julian Hilliard, Sheila Atim, Adam Hugil, Michael Stuhlbarg, Rachel McAdams";
            pelicula.Descripcion = "Viaja en lo desconocido con Doctor Strange, quien, con la ayuda de los antiguos y nuevos aliados místicos, atraviesa las realidades alternativas del Multiverso para enfrentarse a un nuevo y misterioso adversario.";
            pelicula.Imagen = "https://depor.com/resizer/0ezChNerx6qZKcgPu3nn9WsYRlc=/1200x1200/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/43EIEJEBXZHGDPXF4NBZ6O5DS4.jpg";

            int result = await PeliculaDAL.ModificarAsync(pelicula);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.Id = peliculaInicial.Id;
            var resultPelicula = await PeliculaDAL.ObtenerPorIdAsync(pelicula);
            Assert.AreEqual(pelicula.Id, resultPelicula.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultPeliculas = await PeliculaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultPeliculas.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.IdGenero = peliculaInicial.IdGenero;
            pelicula.IdDirector = peliculaInicial.IdDirector;
            pelicula.Titulo = "M";
            pelicula.Top_Aux = 10;

            var resultPeliculas = await PeliculaDAL.BuscarAsync(pelicula);
            Assert.AreNotEqual(0, resultPeliculas.Count);

        }

        [TestMethod()]
        public async Task T6BuscarIncluirRelacionesAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.IdGenero = peliculaInicial.IdGenero;
            pelicula.IdDirector = peliculaInicial.IdDirector;
            pelicula.Titulo = "M";
            pelicula.Top_Aux = 10;
            var resultPeliculas = await PeliculaDAL.BuscarIncluirRelacionesAsync(pelicula);
            Assert.AreNotEqual(0, resultPeliculas.Count);
            var ultimaPelicula = resultPeliculas.FirstOrDefault();
            Assert.IsTrue(ultimaPelicula.Genero != null && pelicula.IdGenero == ultimaPelicula.Genero.Id);
            Assert.IsTrue(ultimaPelicula.Director != null && pelicula.IdDirector == ultimaPelicula.Director.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var pelicula = new Pelicula();
            pelicula.Id = peliculaInicial.Id;

            int result = await PeliculaDAL.EliminarAsync(pelicula);
            Assert.AreNotEqual(0, result);
        }
    }
}