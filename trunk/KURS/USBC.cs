using System.Collections.Generic;
using Kompas6API5;
using KURS.Details;
using KURS.Enumerations;

namespace KURS
{
    /// <summary>
    /// Построитель разъема.
    /// </summary>
    public class USBC : USBbase
    {

        /// <summary>
        /// Значения параметров по-yмолчанию.
        /// </summary>
        public override List<double> DefaultParametrs { get; set; }

        /// <summary>
        /// Список деталей разъема.
        /// </summary>
        public override List<Detail> Parts { get; set; }

        /// <summary>
        /// Начальные значения.
        /// </summary>
        public USBC()
        {
            DefaultParametrs = new List<double>
            {
                3.5, // Высота контактной части.
                10, // Ширина контактной части.
                10, // Глyбина контактной части.
                20, // Длина провода.
                15, // Глубина корпуса.
                11, // Ширина корпуса.
                4, // Высота корпуса.
                5, // Количество пинов.
                (double) USBType.TypeC, // Тип разъема.
                (double) ColorList.Blue // Цвет тела.
            };

            Parts = new List<Detail>
            {
                new TypeC(),
                new ContactCut(),
                new ContactPartC(),
                new ContactPart(),
                new Pins(),
                new PinsC(),
                new Corpus(),
                new Wire(),
                new TMUSB(),
            };
        }
    }
}
