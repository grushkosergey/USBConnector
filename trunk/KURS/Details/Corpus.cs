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
            // Новый компонент.
            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	
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
                        // Установим плоскость XOY базовой для эскиза.
                        sketchDef.SetPlane(basePlane);
                        // Создадим эскиз.
                        entitySketch.Create();			
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
                        // Завершение редактирования эскиза.
                        sketchDef.EndEdit(); 
                        var color = Color.FromName(Enum.Parse(typeof(ColorList), data[Parametr.BodyColor].ToString()).ToString());
                        // Выдавить эскиз.
                        Extrusion(entitySketch, Direction_Type.dtReverse, data[Parametr.CorpusDepth], color); 
                    }
                }
            }
        }
    }
}
