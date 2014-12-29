using System;
using System.Collections.Generic;
using System.Drawing;
using KURS.Enumerations;

namespace KURS
{
    /// <summary>
    /// Хранилище данных.
    /// </summary>
    public class DataStorage
    {
        /// <summary>
        /// Словарь для хранения значений элементов.
        /// </summary>
        public Dictionary<Parametr, double> Parametrs = new Dictionary<Parametr, double>();

        /// <summary>
        /// Значения параметров по-yмолчанию.
        /// </summary>
        private readonly List<double> _defaultParametrs = new List<double>
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


        /// <summary>
        /// Значения параметров по-yмолчанию.
        /// </summary>
        private readonly List<double> _defaultParametrsC = new List<double>
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
        
        /// <summary>
        /// Полyчить ограничения для параметра.
        /// </summary>
        /// <param name="key">Индекс параметра</param>
        /// <returns>Интервал допyстимых значений</returns>
        public PointF GetRange(Parametr key)
        {
            var range = new PointF();
            switch (key)
            {
                case Parametr.BodyHeight:
                    range.X = 3.5f;
                    range.Y = 8f;
                    break;
                case Parametr.BodyWidth:
                    range.X = 6;
                    range.Y = (float) Math.Round((Parametrs[Parametr.BodyHeight] / 0.3), 1);
                    break;
                case Parametr.BodyDepth:
                    range.X = 6f;
                    range.Y = (float) Math.Round((Parametrs[Parametr.BodyWidth] * 1.3), 1);
                    break;
                case Parametr.CorpusHeight:
                    range.X = (float) Math.Round((Parametrs[Parametr.BodyHeight] + 0.2), 1);
                    range.Y = (float) Math.Round((Parametrs[Parametr.BodyHeight] * 2), 1);
                    break;
                case Parametr.CorpusWidth:
                    range.X = (float) Math.Round((Parametrs[Parametr.BodyWidth] + 0.6), 1);
                    range.Y = (float) Math.Round((Parametrs[Parametr.BodyWidth] * 1.5), 1);
                    break;
                case Parametr.CorpusDepth:
                    range.X = 15f;
                    range.Y = (float) Math.Round((Parametrs[Parametr.CorpusWidth] * 3), 1);
                    break;
                case Parametr.WireLength:
                    range.X = 2f;
                    range.Y = (float)Math.Round((Parametrs[Parametr.CorpusDepth] * 5), 1);
                    break;
                case Parametr.NumberOfPins:
                    range.X = 2f;
                    range.Y = 6f;
                    break;
            }
            return range;
        }

        /// <summary>
        /// Проверить валидность данных.
        /// </summary>
        /// <returns>Словарь ошибок</returns>
        public Dictionary<Parametr, PointF> CheckValidData()
        {
            // Словарь ошибок.
            var errorList = new Dictionary<Parametr, PointF>();

            foreach (var parametr in Parametrs)
            {
                if (parametr.Value < GetRange(parametr.Key).X ||
                    parametr.Value > GetRange(parametr.Key).Y)
                {
                    errorList.Add(parametr.Key,
                        new PointF(GetRange(parametr.Key).X, GetRange(parametr.Key).Y));
                    return errorList;
                }
            }
            return errorList;
        }
        
        /// <summary>
        /// Сбросить параметры к стандартным.
        /// </summary>
        public void SetToDefault()
        {
            // Инициализировать начальные значения.
            //
            for (int i = 0; i < 10; i++)
            {
                Parametrs.Add((Parametr) i, _defaultParametrs[i]);
            }

        }

        /// <summary>
        /// Сбросить параметры к стандартным.
        /// </summary>
        public void SetToDefaultC()
        {
            // Инициализировать начальные значения.
            //
            for (int i = 0; i < 10; i++)
            {
                Parametrs.Add((Parametr)i, _defaultParametrsC[i]);
            }
        }

    }
}