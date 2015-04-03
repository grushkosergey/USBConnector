using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class Wire : Detail
    {
        /// <summary>
        /// Построение провода.
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
                    entitySketch.name = @"Эскиз провода";
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

                        // Максимальный радиус для провода
                        var radius = data[Parametr.CorpusHeight] / 2;
                        //Расположение окружности по горизонтали
                        var rasstH = data[Parametr.BodyHeight] / 2;
                        //Расположение окружности по вертикали
                        var rasstW = data[Parametr.BodyWidth] / 2;  

                        //Окружность.
                        sketchEdit.ksCircle(rasstW, rasstH, radius, 1);
                        // Завершение редактирования эскиза.
                        sketchDef.EndEdit();
                        // Выдавить эскиз.
                        Extrusion(entitySketch, Direction_Type.dtReverse, 
                            data[Parametr.CorpusDepth] + data[Parametr.WireLength], Color.Gray); 
                    }
                }
            }
        }
    }
}