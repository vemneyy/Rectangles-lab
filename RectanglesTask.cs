using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // Проверяем пересечение по горизонтальной и вертикальной оси
            return (Math.Max(r1.Left, r2.Left) <= Math.Min(r1.Right, r2.Right)) &&
                (Math.Max(r1.Top, r2.Top) <= Math.Min(r1.Bottom, r2.Bottom));
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            // Вычисляем длину и ширину пересечения
            int dx = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
            int dy = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);
            // Проверяем, что пересечение существует (неотрицательное пересечение)
            return Math.Max(dx, 0) * Math.Max(dy, 0);
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            bool r1InsideR2 = (r2.Left <= r1.Left && r1.Left <= r2.Right && r2.Top <= r1.Top && r1.Top <= r2.Bottom) &&
                (r2.Left <= r1.Right && r1.Right <= r2.Right && r2.Top <= r1.Bottom && r1.Bottom <= r2.Bottom);
            
            bool r2InsideR1 = (r1.Left <= r2.Left && r2.Left <= r1.Right && r1.Top <= r2.Top && r2.Top <= r1.Bottom) &&
                (r1.Left <= r2.Right && r2.Right <= r1.Right && r1.Top <= r2.Bottom && r2.Bottom <= r1.Bottom);

            if (r1InsideR2)
                return 0;
            else if (r2InsideR1)
                return 1;
            else
                return -1;

        }
    }
}
