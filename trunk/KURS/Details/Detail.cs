using System.Collections.Generic;
using Kompas6API5;
using Kompas6Constants3D;
using System.Drawing;
using KURS.Enumerations;
using System.Windows.Forms;
using System;

namespace KURS.Details
{
    public abstract class Detail
    {
        /// <summary>
        /// Деталь.
        /// </summary>
        protected ksPart Part;

        /// <summary>
        /// Построение детали.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public abstract void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data);

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="data">Параметры разъема</param>
        /// <param name="entity">Эскиз для выдавливания</param>
        public void Extrusion(ksEntity entity, Direction_Type directionType, double distance, Color color)
        {
            // Интерфейс базовой операции выдавливания.
            var entityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtr != null)
            {
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    switch (directionType)
                    {
                        case Direction_Type.dtNormal:
                            // Направление выдавливания.
                            extrusionDef.directionType = (short)Direction_Type.dtNormal;   
                            extrusionDef.SetSideParam(true, (short)End_Type.etBlind, distance);
                            break;
                        case Direction_Type.dtReverse:
                            // Направление выдавливания.
                            extrusionDef.directionType = (short)Direction_Type.dtReverse;   
                            extrusionDef.SetSideParam(false, (short)End_Type.etBlind, distance);
                            break;
                    }

                    // Без тонкой стенки.
                    extrusionDef.SetThinParam(false, 0, 0, 0);
                    // Эскиз операции выдавливания.
                    extrusionDef.SetSketch(entity);
                    // Цвет корпуса.
                    entityExtr.SetAdvancedColor(Color.FromArgb(color.B, color.G, color.R).ToArgb(), .2, .3, .9, .0, 5, .8);
                    // Создать операцию.
                    entityExtr.Create();    
                }
            }
        }
    }
}
