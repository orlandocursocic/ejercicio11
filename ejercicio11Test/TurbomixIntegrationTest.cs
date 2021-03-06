﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;
using Microsoft.Practices.Unity;

namespace ejercicio11Test
{
    [TestClass]
    public class TurbomixIntegrationTest
    {
        IUnityContainer container;

        private Alimento alimento1;
        private Alimento alimento2;
        private Alimento alimentoReceta1;
        private Alimento alimentoReceta2;
        private Alimento alimentoReceta3;
        private string nombreReceta1;
        private string nombreReceta2;
        private Categoria categoria1;
        private Categoria categoria2;
        private Receta receta;
        private Receta receta2;

        private ITurbomix sut;

        [TestInitialize]
        public void InitTest()
        {
            container = new UnityContainer();
            container.RegisterType<ITurbomix, Turbomix>();
            container.RegisterType<ICocinaUtilService, CocinaUtilService>();
            container.RegisterType<IRecetaService, RecetaService>();
            container.RegisterType<IRecetaRepository, RecetaRepository>();
            container.RegisterType<ICategoriaService, CategoriaService>();
            container.RegisterType<ICategoriaRepository, CategoriaRepository>();

            alimento1 = new Alimento("Curry", 200.0);
            alimento2 = new Alimento("Queso", 200.0);
            alimentoReceta1 = new Alimento("Curry", 155.5);
            alimentoReceta2 = new Alimento("Queso", 199.9);
            alimentoReceta3 = new Alimento("Chocolate", 2000.99);
            categoria1 = new Categoria("Primero", "Se trata de un primer plato");
            categoria2 = new Categoria("Segundo", "Se trata de un segundo plato");
            nombreReceta1 = "nombreReceta1";
            nombreReceta2= "nombreReceta2";

            receta = new Receta(nombreReceta1, alimentoReceta1, alimentoReceta2, categoria1);
            receta2 = new Receta(nombreReceta2, alimentoReceta2, alimentoReceta3, categoria2);

            sut = container.Resolve<ITurbomix>();
        }

        [TestMethod]
        public void CocinarRecetaTest()
        {
            sut.recetaService.categoriaService.addCategoria(categoria1);
            sut.recetaService.categoriaService.addCategoria(categoria2);
            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.AreNotEqual(null, plato);
        }

        [TestMethod]
        public void CocinarRecetaNombreAlimentoErroneoTest()
        {
            sut.recetaService.categoriaService.addCategoria(categoria1);
            sut.recetaService.categoriaService.addCategoria(categoria2);
            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            alimento1.nombre = "UnoQueNoVale";

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

        [TestMethod]
        public void CocinarRecetaAlimentoCalienteTest()
        {
            sut.recetaService.categoriaService.addCategoria(categoria1);
            sut.recetaService.categoriaService.addCategoria(categoria2);
            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            alimento1.caliente = true;

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

        [TestMethod]
        public void CocinarRecetaPesoMenorTest()
        {
            sut.recetaService.categoriaService.addCategoria(categoria1);
            sut.recetaService.categoriaService.addCategoria(categoria2);
            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            alimento1.peso = 0.0;

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

    }

    // Clase dummie para tests. Realizada previo al aprendizaje de mocks
    public class CocinaDeJuguete : ICocinaUtilService
    {
        public void CalentarAlimento(Alimento alimento)
        {           
        }

        public double PesarAlimento(Alimento alimento)
        {
            return 200.0;
        }
    }
}