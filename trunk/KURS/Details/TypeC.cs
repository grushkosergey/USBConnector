using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class TypeC : Detail
    {
        /// <summary>
        /// Построение эскиза корпуса контактной части.
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
                    entitySketch.name = @"контактный корпус";
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


                        var radSkrug = 1;
                        //Углы.

                        sketchEdit.ksArcByAngle(data[Parametr.BodyWidth] - radSkrug, data[Parametr.BodyHeight] - radSkrug, radSkrug, 0, 90, 1, 1);
                        sketchEdit.ksArcByAngle(radSkrug, data[Parametr.BodyHeight] - radSkrug, radSkrug, 90, 180, 1, 1);
                        sketchEdit.ksArcByAngle(radSkrug, radSkrug, radSkrug, 180, 270, 1, 1);
                        sketchEdit.ksArcByAngle(data[Parametr.BodyWidth] - radSkrug, radSkrug, radSkrug, 270, 360, 1, 1);


                        //Линии.
                        sketchEdit.ksLineSeg(0 + radSkrug, 0, data[Parametr.BodyWidth] - radSkrug, 0, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth], 0 + radSkrug, data[Parametr.BodyWidth], data[Parametr.BodyHeight] - radSkrug, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - radSkrug, data[Parametr.BodyHeight], 0 + radSkrug, data[Parametr.BodyHeight], 1);
                        sketchEdit.ksLineSeg(0, data[Parametr.BodyHeight] - radSkrug, 0, 0 + radSkrug, 1);
                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entitySketch); // Выдавить эскиз.


                        sketchEdit.ksLineSeg(0, radSkrug,
                            0, data[Parametr.BodyHeight] - radSkrug, 1);
                        sketchEdit.ksLineSeg(radSkrug, data[Parametr.BodyHeight], data[Parametr.BodyWidth] - radSkrug,
                            data[Parametr.BodyHeight], 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth], data[Parametr.BodyHeight] - radSkrug,
                            data[Parametr.BodyWidth], radSkrug, 1);
                        sketchEdit.ksLineSeg(radSkrug,
                            0, data[Parametr.BodyWidth] - radSkrug, 0, 1);
                        sketchDef.EndEdit();	// Завершение редактирования эскиза.
                        Extrusion(data, entitySketch);  // Выдавить эскиз.
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
            var entityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtr != null)
            {
                entityExtr.name = @"Выдавливание корпуса контактной части";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtNormal;   // Направление выдавливания.
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, data[Parametr.BodyDepth]);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                    entityExtr.SetAdvancedColor(Color.Gray.ToArgb(), .2, .3, .9, .0, 5, .8);  // Цвет пинов.
                    entityExtr.Create();    // Создать операцию.
                }
            }
        }

    }
}
