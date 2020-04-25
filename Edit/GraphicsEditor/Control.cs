using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Reflection;

namespace Edit
{
    static class Control           // класс организации взаимодействия GUI с классом хранения данных 
    {

        private static List<PointF> renderPoints = new List<PointF>();

        public static int Sides { get; set; } = 5;

        public static int BorderWidth { get; set; } = 3;

        public static Color penColor { get; set; }

        public static Color brushColor { get; set; }


        private static MethodInfo PreviewMethod = null;

        //Программная инициализация списка (для 1 задания)
        public static void ListInitialization(Model model)
        {
            model.Figures = new List<Figure>();
     
        }

        //Отрисовка списка фигур
        public static void DrawFigureList(Model model, Graphics graphics)
        {
            foreach (Figure figure in model.Figures)
            {
                figure.Draw(graphics);
            }
        }
        
        public static bool PreviewFigure(Graphics graphics, int index, Model data)
        {
            bool result = false;
            if (renderPoints.Count() > 1)
            {
                result = true;
                object value;
                //if (data.Types[index].Name == "RegularPolygon")
                try
                {
                    value = PreviewMethod.Invoke(null, new object[] { graphics, renderPoints.ToArray() });
                }
                catch
                {
                    value = PreviewMethod.Invoke(null, new object[] { graphics, Sides, renderPoints.ToArray() });
                }
                if ((bool)value)
                {
                    FinishDrawingFigure(index, data);
                    result = false;
                }
            }
            return result;
        }

        public static void FinishDrawingFigure(int index, Model data)
        {
            renderPoints.RemoveAt(renderPoints.Count() - 1);
            try
            {
                //if (data.Types[index].Name == "RegularPolygon")
                try
                {
                    Figure shape = (Figure)Activator.CreateInstance(data.Types[index], new object[] 
                    { "figure", brushColor, penColor, BorderWidth, Sides, renderPoints.ToArray() });
                    data.AddFigure(shape);
                }
                catch
                {
                    Figure shape = (Figure)Activator.CreateInstance(data.Types[index], new object[] 
                    { "figure", brushColor, penColor, BorderWidth, renderPoints.ToArray() });
                    data.AddFigure(shape);
                }
            }
            finally { }
            renderPoints.Clear();
        }


        //поиск метода preview (является единственным статическим методом класса)
        public static void OnBoxChangeEvent(int index, Model data)
        {
            MethodInfo[] methods = data.Types[index].GetMethods();
            foreach (var method in methods)
            {
                if (method.IsStatic)
                {
                    PreviewMethod = method;
                    break;
                }
            }
        }

        public static void OnMouseMoveEvent(bool renderingFlag, PointF point)
        {
            if (renderingFlag)
            {
                renderPoints.RemoveAt(renderPoints.Count() - 1);
                renderPoints.Add(point);
            }
        }

        public static void OnMouseLeftClickEvent(bool renderingFlag, PointF point)
        {
            if (!renderingFlag)
            {
                renderPoints.Add(point);   //добавление еще одной точки, если отрисовка только началась
            }
            renderPoints.Add(point);
        }


        // отмена отрисовки по нажатию пкм
        public static void OnMouseRightClickEvent(bool renderingFlag)
        {
            if (renderingFlag)
            {
                renderPoints.Clear();
            }
        }


        //завершение отрисовки многоугольника по двойному нажатию
        public static void OnMouseDoubleClickEvent(bool renderingFlag, PointF point, int index, Model data)
        {
            if (renderingFlag && data.Types[index].Name == "Polygon" && renderPoints.Count > 2)
            {
                renderPoints.RemoveAt(renderPoints.Count() - 1);
                renderPoints.Add(point);
                FinishDrawingFigure(index, data);
            }
        }
    }
}
