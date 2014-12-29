using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class Corpus : Detail
    {
        /// <summary>
        /// Построение эскиза корпуса.
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
                    entitySketch.name = @"Корпус";
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

                        var korpusW = data[Parametr.CorpusWidth];
                        var korpusH = data[Parametr.CorpusHeight];

                        var otstupW = (data[Parametr.CorpusWidth] - data[Parametr.BodyWidth]);
                        var otstupH = (data[Parametr.CorpusHeight] - data[Parametr.BodyHeight]);

                        //Линии.
                        sketchEdit.ksLineSeg(-otstupW, -otstupH, korpusW, -otstupH, 1);
                        sketchEdit.ksLineSeg(korpusW, -otstupH, korpusW, korpusH, 1);
                        sketchEdit.ksLineSeg(korpusW, korpusH, -otstupW, korpusH, 1);
                        sketchEdit.ksLineSeg(-otstupW, korpusH, -otstupW, -otstupH, 1);
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
            var entityExtr = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
            if (entityExtr != null)
            {
                entityExtr.name = @"Выдавливание корпуса";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtReverse;   // Направление выдавливания.
                    extrusionDef.SetSideParam(false, (short)End_Type.etBlind, data[Parametr.CorpusDepth]);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                  
                    var color = Color.FromName(Enum.Parse(typeof(ColorList), data[Parametr.BodyColor].ToString()).ToString());
                    // Цвет детали.
                    entityExtr.SetAdvancedColor(Color.FromArgb(color.B, color.G, color.R).ToArgb(), .2, .3, .9, .0, 5, .8);  // Цвет корпуса.
                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}
