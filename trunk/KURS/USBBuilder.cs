using System.Collections.Generic;
using Kompas6API5;
using KURS.Details;
using KURS.Enumerations;

using System.Windows.Forms;
namespace KURS
{
    /// <summary>
    /// Построитель разъема.
    /// </summary>
    public class USBBuilder
    {
        public void BuildParts(ksDocument3D doc3D, DataStorage data, USBType usbType)
        {
            switch (usbType)
            {
                case USBType.TypeA:
                    foreach (var detail in data.PartsA.Parts)
                    {
                        detail.Build(doc3D, data.Parametrs);
                    }
                    break;
                case USBType.TypeC:
                    foreach (var detail in data.PartsC.Parts)
                    {
                        detail.Build(doc3D, data.Parametrs);
                    }
                    break;
            }
        }
    }
}
