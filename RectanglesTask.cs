using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        return IsIntersected(r1.Left, r1.Right, r2.Left, r2.Right) &&
               IsIntersected(r1.Top, r1.Bottom, r2.Top, r2.Bottom);
    }

    private static bool IsIntersected(int a1, int a2, int b1, int b2)
    {
        return Math.Max(a1, b1) <= Math.Min(a2, b2);
    }


    // Площадь пересечения прямоугольников
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        int dx = Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left);
        int dy = Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top);
        return Math.Max(dx, 0) * Math.Max(dy, 0);
    }

    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (IsInside(r1.Left, r1.Top, r2) && IsInside(r1.Right, r1.Bottom, r2))
            return 0;
        if (IsInside(r2.Left, r2.Top, r1) && IsInside(r2.Right, r2.Bottom, r1))
            return 1;
        return -1;
    }

    private static bool IsInside(int x, int y, Rectangle r)
    {
        return r.Left <= x && x <= r.Right && r.Top <= y && y <= r.Bottom;
    }
}