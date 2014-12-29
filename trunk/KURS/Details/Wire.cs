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
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOY базовой для эскиза.
                        entitySketch.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        var radius = data[Parametr.CorpusHeight] / 2;   // Максимальный радиус для провода
                        var rasstH = data[Parametr.BodyHeight] / 2;     //Расположение окружности по горизонтали
                        var rasstW = data[Parametr.BodyWidth] / 2;  //Расположение окружности по вертикали


                        //Окружность.
                        sketchEdit.ksCircle(rasstW, rasstH, radius, 1);

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
                entityExtr.name = @"Выдавливание провода";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtReverse;   // Направление выдавливания.
                    extrusionDef.SetSideParam(false, (short)End_Type.etBlind, data[Parametr.CorpusDepth] + data[Parametr.WireLength]);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                    entityExtr.SetAdvancedColor(Color.Gray.ToArgb(), .2, .3, .9, .0, 5, .8);  // Цвет пинов.
                    entityExtr.Create();    // Создать операцию.
                }
            }
        }


    }
}