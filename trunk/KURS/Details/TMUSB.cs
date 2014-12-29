using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class TMUSB : Detail
    {
        /// <summary>
        /// Построение провода.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        public override void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            var rW = (data[Parametr.BodyWidth] / 2) - 1.5; // Расчет растояния для расположения USB знака по центру, относительно ширины корпуса
            var rD = (data[Parametr.CorpusDepth] / 2) + 6; // Расчет растояния для расположения USB знака по центру, относительно высоты корпуса

            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part != null)
            {
                // Интерфейс создания эскиза.
                var entitySketch = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_sketch);
                if (entitySketch != null)
                {
                    entitySketch.name = @"Знак USB";
                    // Интерфейс свойств эскиза.
                    var sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                    if (sketchDef != null)
                    {
                        // Получим интерфейс базовой плоскости XOZ.
                        var basePlane = (ksEntity)Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOZ базовой для эскиза.
                        entitySketch.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                        sketchEdit.ksLineSeg(0 + rW, 0 + rD, 1.5 + rW, 1.5 + rD, 1);
                        sketchEdit.ksLineSeg(0 + rW, 0 + rD, 1 + rW, 0 + rD, 1);
                        sketchEdit.ksLineSeg(1.5 + rW, 1.5 + rD, 3 + rW, 0 + rD, 1);
                        sketchEdit.ksLineSeg(2 + rW, 0 + rD, 3 + rW, 0 + rD, 1);
                        //промежуток для левой части
                        sketchEdit.ksLineSeg(1 + rW, 0 + rD, 1 + rW, -8 + rD, 1);
                        sketchEdit.ksLineSeg(1 + rW, -9 + rD, 1 + rW, -10 + rD, 1);
                        //промежуток для правой части
                        sketchEdit.ksLineSeg(2 + rW, 0 + rD, 2 + rW, -6 + rD, 1);
                        sketchEdit.ksLineSeg(2 + rW, -7 + rD, 2 + rW, -10 + rD, 1);
                        //левая часть
                        sketchEdit.ksLineSeg(1 + rW, -8 + rD, -1 + rW, -6.5 + rD, 1);
                        sketchEdit.ksLineSeg(1 + rW, -9 + rD, -2 + rW, -7 + rD, 1);
                        sketchEdit.ksLineSeg(-1 + rW, -6.5 + rD, -1 + rW, -5 + rD, 1);
                        sketchEdit.ksLineSeg(-2 + rW, -7 + rD, -2 + rW, -5 + rD, 1);
                        //Соединяющая линия для левой части
                        sketchEdit.ksLineSeg(-1 + rW, -5 + rD, -2 + rW, -5 + rD, 1);
                        //правая часть
                        sketchEdit.ksLineSeg(2 + rW, -6 + rD, 4 + rW, -4.5 + rD, 1);
                        sketchEdit.ksLineSeg(2 + rW, -7 + rD, 5 + rW, -5 + rD, 1);
                        sketchEdit.ksLineSeg(5 + rW, -5 + rD, 5 + rW, -3 + rD, 1);
                        sketchEdit.ksLineSeg(4 + rW, -4.5 + rD, 4 + rW, -3 + rD, 1);
                        //квадрат для правой части
                        sketchEdit.ksLineSeg(5 + rW, -3 + rD, 5.5 + rW, -3 + rD, 1);
                        sketchEdit.ksLineSeg(4 + rW, -3 + rD, 3.5 + rW, -3 + rD, 1);
                        sketchEdit.ksLineSeg(5.5 + rW, -3 + rD, 5.5 + rW, -1 + rD, 1);
                        sketchEdit.ksLineSeg(3.5 + rW, -3 + rD, 3.5 + rW, -1 + rD, 1);
                        sketchEdit.ksLineSeg(5.5 + rW, -1 + rD, 3.5 + rW, -1 + rD, 1);
                        //Соединяющая линия для нижней части
                        sketchEdit.ksLineSeg(1 + rW, -10 + rD, 2 + rW, -10 + rD, 1);

                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entitySketch); // Выдавить эскиз.

                    }
                }
            }




            Part2 = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part2 != null)
            {
                // Интерфейс создания эскиза.
                var entitySketch2 = (ksEntity)Part2.NewEntity((short)Obj3dType.o3d_sketch);
                if (entitySketch2 != null)
                {
                    entitySketch2.name = @"Знак USB";
                    // Интерфейс свойств эскиза.
                    var sketchDef = (ksSketchDefinition)entitySketch2.GetDefinition();
                    if (sketchDef != null)
                    {
                        // Получим интерфейс базовой плоскости XOZ.
                        var basePlane = (ksEntity)Part2.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOZ базовой для эскиза.
                        entitySketch2.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
                        //Окружность для левой части
                        sketchEdit.ksArcByAngle(-1.5 + rW, -4.5 + rD, 1, 0, 0, 1, 1);
                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entitySketch2); // Выдавить эскиз.

                    }
                }
            }

            Part3 = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part3 != null)
            {
                // Интерфейс создания эскиза.
                var entitySketch3 = (ksEntity)Part3.NewEntity((short)Obj3dType.o3d_sketch);
                if (entitySketch3 != null)
                {
                    entitySketch3.name = @"Знак USB (нижний круг)";
                    // Интерфейс свойств эскиза.
                    var sketchDef = (ksSketchDefinition)entitySketch3.GetDefinition();
                    if (sketchDef != null)
                    {
                        // Получим интерфейс базовой плоскости XOZ.
                        var basePlane = (ksEntity)Part3.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                        sketchDef.SetPlane(basePlane);	// Установим плоскость XOZ базовой для эскиза.
                        entitySketch3.Create();			// Создадим эскиз.
                        //Интерфейс редактора эскиза.
                        var sketchEdit = (ksDocument2D)sketchDef.BeginEdit();
                        //Окружность для левой части
                        sketchEdit.ksArcByAngle(1.5 + rW, -11.5 + rD, 2, 0, 0, 1, 1);

                        sketchDef.EndEdit(); // Завершение редактирования эскиза.
                        Extrusion(data, entitySketch3); // Выдавить эскиз.
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
                entityExtr.name = @"Выдавливание знака USB";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtNormal;   // Направление выдавливания.
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, data[Parametr.CorpusHeight] + 0.3);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                    entityExtr.SetAdvancedColor(Color.Gray.ToArgb(), .2, .3, .9, .0, 5, .8);  // Цвет пинов.
                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}