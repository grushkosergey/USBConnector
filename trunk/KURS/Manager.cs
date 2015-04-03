using System.Collections.Generic;
using System.Drawing;
using KURS.Enumerations;


using System.Windows.Forms;
using Kompas6API5;
using KURS.Details;

namespace KURS
{
    /// <summary>
    /// Менеджер.
    /// </summary>
    //private class Manager
    public class Manager
    {
        /// <summary>
        /// Построитель разъема.
        /// </summary>
        public USBbase USB { get; private set; }

        /// <summary>
        /// Параметры разъема.
        /// </summary>
        public DataStorage Data = new DataStorage();

        /// <summary>
        /// Компас-3D.
        /// </summary>
        public Kompas Kompas3D = new Kompas();

        public void CreateUSB(USBType usbType)
        {
            USB = GetUSBInstance(usbType);
        }

        /// <summary>
        /// Строит разъем в yказанном докyменте с yказанными параметрами
        /// </summary>
        private USBbase GetUSBInstance(USBType usbType)
        {
            switch (usbType)
            {
                case USBType.TypeA:
                    return new USBA();
                case USBType.TypeC:
                    return new USBC();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Строит разъем в yказанном докyменте с yказанными параметрами
        /// </summary>
        public void BuildUSB()
        {
            USB.Parametrs = Data.Parametrs;
            USB.Build(Kompas3D.Document3D);
        }

        /// <summary>
        /// Проверить правильность введенных данных
        /// </summary>
        /// <returns>Лист имен полей с ошибками</returns>
        public Dictionary<Parametr, PointF> CheckValidation()
        {
            return Data.CheckValidData();
        }
    }
}
