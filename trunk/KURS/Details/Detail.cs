using System.Collections.Generic;
using Kompas6API5;
using KURS.Enumerations; //????????????????

namespace KURS.Details
{
    public abstract class Detail
    {
        /// <summary>
        /// Деталь.
        /// </summary>
        protected ksPart Part;
        protected ksPart Part2;
        protected ksPart Part3;
        protected const double tolsh = 0.5; // Толщина стенки корпуса
        protected const double contactHeight = 1.5; // Толщина контактной части


        /// <summary>
        /// Построение детали.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public abstract void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data);

        /// <summary>
        /// Выдавливание эскиза.
        /// </summary>
        /// <param name="data">Параметры разъема</param>
        /// <param name="entity">Эскиз для выдавливания</param>
        //public abstract void Extrusion(Dictionary<Parametr, double> data, ksEntity entity);
    }
}
