using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class ContactPartC : Detail
    {
        /// <summary>
        /// Построение нижнней контактной части черного цвета.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public override void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part != null)
            {
                // Интерфейс создания эскиза.

                var entityContactSketch = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_sketch);
                if (entityContactSketch != null)
                {
                    entityContactSketch.name = @"Контактная часть для пинов";
                    // Интерфейс свойств эскиза.
                    var sketchDef = (ksSketchDefinition)entityContactSketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        // Получим интерфейс базовой плоскости XOY.
                        var basePlane = (ksEntity)Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOY базовой для эскиза.
                        entityContactSketch.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        //Линии для построения верхней контактной части
                        sketchEdit.ksLineSeg(tolsh, data[Parametr.BodyHeight] - tolsh, data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - tolsh, 1);
                        sketchEdit.ksLineSeg(tolsh, data[Parametr.BodyHeight] - tolsh, tolsh, data[Parametr.BodyHeight] - contactHeight, 1);
                        sketchEdit.ksLineSeg(tolsh, data[Parametr.BodyHeight] - contactHeight, data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - contactHeight, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - contactHeight, data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - tolsh, 1);
                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entityContactSketch); // Выдавить эскиз.

                    }
                }
            }
        }


        /// <summary>
        /// Вырезать выдавливанием.
        /// </summary>
        /// <param name="data">Параметры разъема</param>
        /// <param name="entity">Эскиз для вырезания выдавливанием</param>
        private void Extrusion(Dictionary<Parametr, double> data, ksEntity entity)
        {
            // Интерфейс базовой операции выдавливания.
            var entityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtr != null)
            {
                entityExtr.name = @"Выдавливание контактной части для пинов";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtNormal;   // Направление выдавливания.
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, data[Parametr.BodyDepth] - 0.01);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                    entityExtr.SetAdvancedColor(Color.Black.ToArgb(), .8, .8, .8, .8, 100, .8);  // Цвет пинов.
                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}

