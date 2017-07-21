using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;
using System.Collections.Generic;

namespace ejercicio11Test
{
    [TestClass]
    public class AvisoServiceTest
    {
        private Aviso aviso1;
        private Aviso aviso2;

        private IAvisoService sut;

        [TestInitialize]
        public void InitTest()
        {
            aviso1 = new Aviso(2, "Aviso0 - Criticidad 2");
            aviso2 = new Aviso(5, "Aviso1 - Criticidad 5");
        }

        [TestMethod]
        public void AddAvisoMockTest()
        {
            var mockAvisoRepository = new Mock<IAvisoRepository>();
            IAvisoRepository avisoRepository = mockAvisoRepository.Object;

            mockAvisoRepository.Setup(aviso => aviso.listAvisos()).Returns(() => new List<Aviso> { aviso1 });

            mockAvisoRepository.Setup(aviso => aviso.addAviso(aviso2));

            sut = new AvisoService(avisoRepository);

            sut.addAviso(aviso2);

            mockAvisoRepository.Verify(aviso => aviso.listAvisos(), Times.Exactly(1));
            mockAvisoRepository.Verify(aviso => aviso.addAviso(It.IsAny<Aviso>()), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(AvisoYaExisteException),
            "El aviso ya existe")]
        public void AddAvisoYaExisteMockTest()
        {
            var mockAvisoRepository = new Mock<IAvisoRepository>();
            IAvisoRepository avisoRepository = mockAvisoRepository.Object;

            mockAvisoRepository.Setup(aviso => aviso.listAvisos()).Returns(() => new List<Aviso> { aviso1 });

            mockAvisoRepository.Setup(aviso => aviso.addAviso(aviso1));

            sut = new AvisoService(avisoRepository);

            sut.addAviso(aviso1);
        }
    }
}
