using System;
using KURS;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NUnitTestsProject
{
    /// <summary>
    /// Тест класса Kompas.
    /// </summary>
    [TestFixture]
    public class KompasTest
    {
        /// <summary>
        /// Тест открытия КОМПАС-3D.
        /// </summary>
        [Test]
        public void OpenKompas3DTest()
        {
            var kompas = new Kompas();
            Assert.DoesNotThrow(kompas.OpenKompas3D);
        }

        /// <summary>
        /// Тест yдачного создания докyмента.
        /// </summary>
        [Test]
        public void CreateDocumentSuccesTest()
        {
            var kompas = new Kompas();
            Assert.DoesNotThrow(kompas.OpenKompas3D);
            Assert.DoesNotThrow(kompas.CreateDocument);
        }

        /// <summary>
        /// Тест неyдачного создания докyмента.
        /// </summary>
        [Test]
        public void CreateDocumentFailTest()
        {
            var kompas = new Kompas();
            
            Assert.Throws(typeof(NullReferenceException), kompas.CreateDocument);
        }

        /// <summary>
        /// Тест закрытия КОМПАСА-3D.
        /// </summary>
        [Test]
        public void CloseKompasSuccesTest()
        {
            var kompas = new Kompas();

            Assert.DoesNotThrow(kompas.OpenKompas3D);
            Assert.DoesNotThrow(kompas.CloseKompas3D);
        }

        /// <summary>
        /// Тест неyдачного закрытия КОМПАСА-3D.
        /// </summary>
        [Test]
        public void CloseKompasFailTest()
        {
            var kompas = new Kompas();

            Assert.Throws(typeof(NullReferenceException), kompas.CloseKompas3D);
        }

        /// <summary>
        /// Тест закрытия докyмента
        /// </summary>
        [Test]
        public void CloseDocumentTest()
        {
            var kompas = new Kompas();

            Assert.DoesNotThrow(OpenKompas3DTest);
            Assert.DoesNotThrow(kompas.CloseDocument);
        }
    }
}
