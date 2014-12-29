using System;
using System.Linq;
using KURS;
using KURS.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NUnitTestsProject
{
    /// <summary>
    /// Тест хранилища данных.
    /// </summary>
    [TestClass]
    public class DataStorageTest
    {
        /// <summary>
        /// Тест параметров разъема.
        /// </summary>
        [TestMethod]
        public void TestParametrs()
        {
            var dataStorage = new DataStorage();
            dataStorage.Parametrs.Clear();
            // Установить параметры по-yмолчанию.
            dataStorage.SetToDefault();
            // Создался ли объект класса DataStorage.
            Assert.IsNotNull(dataStorage);
            // Определены ли все параметры.
            foreach (var parametr in Enum.GetValues(typeof(Parametr)).Cast<Parametr>())
            {
                Assert.AreNotEqual(dataStorage.Parametrs[parametr], null);
            }
        }

        /// <summary>
        /// Тест валидации данных.
        /// </summary>
        [TestMethod]
        public void TestValidation()
        {
            var dataStorage = new DataStorage();

            dataStorage.SetToDefault();

            Assert.AreEqual(0, dataStorage.CheckValidData().Count);
        }
    }
}
