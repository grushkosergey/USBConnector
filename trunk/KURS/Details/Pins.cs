using System;
using System.Collections.Generic;
using System.Drawing;
using Kompas6API5;
using Kompas6Constants3D;
using KURS.Enumerations;

namespace KURS.Details
{
    internal class Pins : Detail
    {
        /// <summary>
        /// Построение пинов.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        /// 


        public override void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	// Новый компонент.
            if (Part != null)
            {
                var countPins = (data[Parametr.NumberOfPins]); // Количество пинов задается пользователем
                var countSpace = countPins + 1;
                var pin = ((data[Parametr.BodyWidth] - (tolsh * 2)) - countPins) / countSpace; // учитывая размер каждого = 1, расчет расстановки
                var startPinsX = tolsh + pin; //Начало расстановки пинов по X

                for (int i = 0; i < countPins; i++)
                {
                    var pinsXNext = startPinsX + (1 + pin) * i;
                    BuildPin(data, pinsXNext);
                }
            }
        }


        //Построение эскиза
        public void BuildPin(Dictionary<Parametr, double> data, double startPinsX)
        {

            var entityContactSketch = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_sketch);
            if (entityContactSketch != null)
            {
                entityContactSketch.name = @"pin";
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
                    var pinHeight = 0.1;

                    //Линии.
                    sketchEdit.ksLineSeg(startPinsX, contactHeight, startPinsX + 1, contactHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX, contactHeight, startPinsX, contactHeight + pinHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX + 1, contactHeight, startPinsX + 1, contactHeight + pinHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX, contactHeight + pinHeight, startPinsX + 1, contactHeight + pinHeight, 1);


                    sketchDef.EndEdit(); // Завершение редактирования эскиза.
                    Extrusion(data, entityContactSketch); // Выдавить эскиз.
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
                entityExtr.name = @"Выдавливание тела";
                // Интерфейс свойств базовой операции выдавливания.
                var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition();
                if (extrusionDef != null)
                {
                    extrusionDef.directionType = (short)Direction_Type.dtNormal;   // Направление выдавливания.
                    extrusionDef.SetSideParam(true, (short)End_Type.etBlind, data[Parametr.BodyDepth] - 0.3);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.
                    entityExtr.SetAdvancedColor(Color.YellowGreen.ToArgb(), .2, .3, .9, .0, 5, .8);  // Цвет пинов.

                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}