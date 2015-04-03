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
        // Толщина стенки корпуса
        protected const double thickness = 0.5;
        // Толщина контактной части
        protected const double contactHeight = 1.5; 

        /// <summary>
        /// Построение пинов.
        /// </summary>
        /// <param name="doc3D">Докyмент КОМПАС-3D</param>
        /// <param name="data">Параметры разъема</param>
        /// 
        public override void Build(ksDocument3D doc3D, Dictionary<Parametr, double> data)
        {
            // Новый компонент.
            Part = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);	
            if (Part != null)
            {
                // Количество пинов задается пользователем
                var countPins = (data[Parametr.NumberOfPins]); 
                var countSpace = countPins + 1;
                // учитывая размер каждого = 1, расчет расстановки
                var pin = ((data[Parametr.BodyWidth] - (thickness * 2)) - countPins) / countSpace;
                //Начало расстановки пинов по X
                var startPinsX = thickness + pin; 

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
            var entitySketch = (ksEntity)Part.NewEntity((short)Obj3dType.o3d_sketch);

            if (entitySketch != null)
            {
                entitySketch.name = @"pin";
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
                    var pinHeight = 0.1;

                    //Линии.
                    sketchEdit.ksLineSeg(startPinsX, contactHeight, startPinsX + 1, contactHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX, contactHeight, startPinsX, contactHeight + pinHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX + 1, contactHeight, startPinsX + 1, contactHeight + pinHeight, 1);
                    sketchEdit.ksLineSeg(startPinsX, contactHeight + pinHeight, startPinsX + 1, contactHeight + pinHeight, 1);

                    // Завершение редактирования эскиза.
                    sketchDef.EndEdit();
                    // Выдавить эскиз.
                    Extrusion(entitySketch, Direction_Type.dtNormal, data[Parametr.BodyDepth] - 0.3, Color.Gold); 
                }
            }
        }
    }
}