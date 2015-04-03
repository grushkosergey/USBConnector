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
        // Толщина стенки корпуса
        protected const double thickness = 0.5;
        // Толщина контактной части
        protected const double contactHeight = 1.5; 

        /// <summary>
        /// Построение эскиза для выреза под контактную часть.
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
                    entitySketch.name = @"Эскиз 2";
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

                        //Линии.

                        sketchEdit.ksLineSeg(thickness, thickness, data[Parametr.BodyWidth] - thickness, thickness, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - thickness, thickness, 
                            data[Parametr.BodyWidth] - thickness, 
                            data[Parametr.BodyHeight] - thickness, 1);
                        sketchEdit.ksLineSeg(data[Parametr.BodyWidth] - thickness, 
                            data[Parametr.BodyHeight] - thickness, thickness, 
                            data[Parametr.BodyHeight] - thickness, 1);
                        sketchEdit.ksLineSeg(thickness, data[Parametr.BodyHeight] - thickness, thickness, thickness, 1);
                        // Завершение редактирования эскиза.
                        sketchDef.EndEdit();
                        // Выдавить эскиз.
                        Extrusion(data, entitySketch); 

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
                    // Направление выдавливания.
                    extrusionDef.directionType = (short)Direction_Type.dtReverse;   
                    extrusionDef.SetSideParam(false, (short)End_Type.etBlind, data[Parametr.BodyDepth]);
                    extrusionDef.SetThinParam(false, 0, 0, 0);  // Без тонкой стенки.
                    extrusionDef.SetSketch(entity); // Эскиз операции выдавливания.

                    entityExtr.Create();    // Создать операцию.
                }
            }
        }
    }
}

