using System;
using KURS;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace NUnitTestsProject
{
    /// <summary>
    /// Тест класса "Manager".
    /// </summary>
    [TestFixture]
    public class ManagerTest
    {
        /// <summary>
        /// Тест yдачного построения разъема.
        /// </summary>
        [Test]
        public void BuildUSBSuccesTest()
        {
            var manager = new Manager();

            // Начальные параметры.
            manager.Data.SetToDefault();
            
            Assert.DoesNotThrow(manager.Kompas3D.OpenKompas3D);
            Assert.DoesNotThrow(manager.Kompas3D.CreateDocument);
            Assert.DoesNotThrow(manager.BuildUSB);
        }

        /// <summary>
        /// Тест неyдачного построения разъема.
        /// </summary>
        [Test]
        public void BuildUSBFailTest()
        {
            var manager = new Manager();

            // Начальные параметры.
            manager.Data.SetToDefault();

            Assert.Throws(typeof(NullReferenceException), manager.Kompas3D.CreateDocument);
            Assert.Throws(typeof(NullReferenceException), manager.BuildUSB);
        }
    }
}
