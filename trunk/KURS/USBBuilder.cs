using System.Collections.Generic;
using Kompas6API5;
using KURS.Details;
using KURS.Enumerations; 

namespace KURS
{
    /// <summary>
    /// Построитель разъема.
    /// </summary>
    public class USBBuilder
    {
        /// <summary>
        /// Список деталей разъема.
        /// </summary>
        private readonly List<Detail> _parts = new List<Detail>
        {
            new TypeA(),
            new ContactCut(),
            new ContactPart(),
            new Pins(),
            new Corpus(),
            new Wire(),
            new TMUSB(),
        };
        
        /// <summary>
        /// Построение всех частей.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public void BuildParts(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            foreach (var detail in _parts)
            {
                detail.Build(doc3D, data);
            }
        }
    }

    public class USBBuilderC
    {

        /// <summary>
        /// Список составляющих разъема.
        /// </summary>
        private readonly List<Detail> _parts = new List<Detail>
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

        /// <summary>
        /// Построение всех частей.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public void BuildParts(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            foreach (var detail in _parts)
            {
                detail.Build(doc3D, data);
            }
        }
    }

}
