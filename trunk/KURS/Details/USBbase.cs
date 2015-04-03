using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using KURS.Enumerations;

namespace KURS.Details
{
    public abstract class USBbase
    {
        /// <summary>
        /// Значения параметров по-yмолчанию.
        /// </summary>
        public abstract List<double> DefaultParametrs { get; set; }

        /// <summary>
        /// Параметры разъема.
        /// </summary>
        public Dictionary<Parametr, double> Parametrs = new Dictionary<Parametr, double>();

        /// <summary>
        /// Список деталей разъема.
        /// </summary>
        public abstract List<Detail> Parts { get; set; }

        /// <summary>
        /// Построение детали.
        /// </summary>
        public void Build(ksDocument3D doc3D)
        {
            foreach (var detail in Parts)
            {
                detail.Build(doc3D, Parametrs);
            }
        }

        /// <summary>
        /// Добавление начальных праметров.
        /// </summary>
        public void SetToDefault()
        {
            // Инициализировать начальные значения.
            for (int i = 0; i < 10; i++)
            {
                Parametrs.Add((Parametr)i, DefaultParametrs[i]);
            }
        }
    }
}