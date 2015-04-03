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
                    range.Y = (float)Math.Round((Parametrs[Parametr.BodyHeight] / 0.3), 1);
                    break;
                case Parametr.BodyDepth:
                    range.X = 6f;
                    range.Y = (float)Math.Round((Parametrs[Parametr.BodyWidth] * 1.3), 1);
                    break;
                case Parametr.CorpusHeight:
                    range.X = (float)Math.Round((Parametrs[Parametr.BodyHeight] + 0.2), 1);
                    range.Y = (float)Math.Round((Parametrs[Parametr.BodyHeight] * 2), 1);
                    break;
                case Parametr.CorpusWidth:
                    range.X = (float)Math.Round((Parametrs[Parametr.BodyWidth] + 0.6), 1);
                    range.Y = (float)Math.Round((Parametrs[Parametr.BodyWidth] * 1.5), 1);
                    break;
                case Parametr.CorpusDepth:
                    range.X = 15f;
                    range.Y = (float)Math.Round((Parametrs[Parametr.CorpusWidth] * 3), 1);
                    break;
                case Parametr.WireLength:
                    range.X = 2f;
                    range.Y = (float)Math.Round((Parametrs[Parametr.CorpusDepth] * 5), 1);
                    break;
                case Parametr.NumberOfPins:
                    range.X = 2f;
                    range.Y = 6f;
                    break;
                case Parametr.BodyColor:
                    range.X = 0;
                    range.Y = 8;
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
    }
}