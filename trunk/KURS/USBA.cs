using System.Collections.Generic;
using Kompas6API5;
using KURS.Details;
using KURS.Enumerations;

namespace KURS
{
    /// <summary>
    /// Построитель разъема.
    /// </summary>
    public class USBA :USBbase
    {


        /// <summary>
        /// Значения параметров по-yмолчанию.
        /// </summary>
        public override List<double> DefaultParametrs { get; set; }

        public override List<Detail> Parts { get; set; }

        /// <summary>
        /// Начальные значения.
        /// </summary>
        public USBA()
        {
            DefaultParametrs = new List<double>
            {
                5, // Высота контактной части.
                12, // Ширина контактной части.
                15, // Глyбина контактной части.
                50, // Длина провода.
                30, // Глубина корпуса.
                15, // Ширина корпуса.
                6, // Высота корпуса.
                4, // Количество пинов.
                (double) USBType.TypeA, // Тип разъема.
                (double) ColorList.Blue // Цвет тела.
            };

            Parts = new List<Detail>
            {
                new TypeA(),
                new ContactCut(),
                new ContactPart(),
                new Pins(),
                new Corpus(),
                new Wire(),
                new TMUSB(),
            };
        }
    }
}
