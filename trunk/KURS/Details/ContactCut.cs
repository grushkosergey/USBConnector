using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
     internal class ContactCut : Detail
    {
        /// <summary>
        /// Построение эскиза для выреза под контактную часть.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public override void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part != null)
            {
                // Интерфейс создания эскиза.
                var entitySketch = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_sketch);
                if (entitySketch != null)
                {
                    entitySketch.name = @"Эскиз 2";
                    // Интерфейс свойств эскиза.
                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        // Получим интерфейс базовой плоскости XOY.
                        var basePlane = (ksEntity)Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOY базовой для эскиза.
                        entitySketch.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        //Линии.

                        sketchEdit.ksLineSeg(tolsh, tolsh, data[Parametr.BodyWidth] - tolsh, tolsh, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - tolsh, tolsh, data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - tolsh, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - tolsh, data[Parametr.BodyHeight] - tolsh, tolsh, data[Parametr.BodyHeight] - tolsh, 1);
                        sketchEdit.ksLineSeg(tolsh, data[Parametr.BodyHeight] - tolsh, tolsh, tolsh, 1);
                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entitySketch); // Выдавить эскиз.

                    }
                }
            }
        }


        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="data">Параметры разъема</param>
        /// <param name="entity">Эскиз для выдавливания</param>
        private void Extrusion(Dictionary<Parametr, double> data, ksEntity entity)
        {
            // Интерфейс базовой операции выдавливания.
            var entityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            if (entityExtr != null)
            {
                entityExtr.name = @"Выдавливание контактной части";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksCutExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtReverse;   // Направление выдавливания.
                    extrusionDef.SetSideParam(false, (short)End_Type.etBlind, data[Parametr.BodyDepth]);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.

                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}

