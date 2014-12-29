using System.Collections.Generic;
using System.Drawing;
using KURS.Enumerations;

namespace KURS
{
    /// <summary>
    /// Менеджер.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Построитель разъема Type A.
        /// </summary>
        private readonly USBBuilder _usb = new USBBuilder();
       
        /// <summary>
        /// Построитель разъема Type C.
        /// </summary>
        private readonly USBBuilderC _usbC = new USBBuilderC();

        /// <summary>
        /// Параметры разъема.
        /// </summary>
        public DataStorage Data = new DataStorage();

        /// <summary>
        /// Компас-3D.
        /// </summary>
        public Kompas Kompas3D = new Kompas();

        /// <summary>
        /// Строит разъем в yказанном докyменте с yказанными параметрами Type A.
        /// </summary>
        public void BuildUSB()
        {
            _usb.BuildParts(Kompas3D.Document3D, Data.Parametrs);
        }

        /// <summary>
        /// Строит разъем в yказанном докyменте с yказанными параметрами Type C.
        /// </summary>
        public void BuildUSBC()
        {
            _usbC.BuildParts(Kompas3D.Document3D, Data.Parametrs);
        }

        /// <summary>
        /// Проверить правильность введенных данных
        /// </summary>
        /// <returns>Лист имен полей с ошибками</returns>
        public Dictionary<Parametr,PointF> CheckValidation()
        {
            return Data.CheckValidData();
        }
    }
}
