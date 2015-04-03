using System;
using Kompas6API5;

namespace KURS
{
    /// <summary>
    /// Связь с КОМПАС-3D.
    /// </summary>
    public class Kompas
    {
        /// <summary>
        /// Ссылка на интерфейс KompasObject
        /// </summary>
        public KompasObject KompasObject3D;

        /// <summary>
        /// Ссылка на интерфейс ksDocument3D
        /// </summary>
        public ksDocument3D Document3D;

        /// <summary>
        /// Процедура открытия КОМПАС-3D.
        /// </summary>
        public void OpenKompas3D()
        {
            if (KompasObject3D == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                KompasObject3D = (KompasObject) Activator.CreateInstance(type);
            }
            if (KompasObject3D != null)
            {
                try
                {
                    KompasObject3D.Visible = true;
                    KompasObject3D.ActivateControllerAPI();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Cоздание документа.
        /// </summary>
        public void CreateDocument()
        {
            try
            {
                if (KompasObject3D != null)
                {
                    CloseDocument(); // Закрыть открытый докyмент.
                    if (Document3D == null)
                    {
                        Document3D = (ksDocument3D) KompasObject3D.Document3D();
                        Document3D.Create(false, false);
                        Document3D = (ksDocument3D) KompasObject3D.ActiveDocument3D();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException(@"Сначала откройте КОМПАС-3D.");
            }
        }

        /// <summary>
        /// Закрыть открытый докyмент.
        /// </summary>
        public void CloseDocument()
        {
           if (Document3D != null)
            {
                Document3D.close();
                Document3D = null;
            }
        }

        /// <summary>
        /// Закрытие программы КОМПАС-3D.
        /// </summary>
        public void CloseKompas3D()
        {
            if (Document3D != null)
            {
                CloseDocument();
            }
            try
            {
                KompasObject3D.Quit();
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
