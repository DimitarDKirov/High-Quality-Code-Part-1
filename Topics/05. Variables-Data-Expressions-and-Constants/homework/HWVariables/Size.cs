//Task 1. Class Size in C#

using System;

public class Size
{
    public double width, height;

    public Size(double width, double hegiht)
    {
        this.width = width;
        this.height = hegiht;
    }

    public static Size GetRotatedSize(Size oldFigure, double angleOfRotation)
    {
        double rotatedFigureWidth = Math.Abs(Math.Cos(angleOfRotation)) * oldFigure.width + Math.Abs(Math.Sin(angleOfRotation)) * oldFigure.height;
        double rotatedFigureHeight = Math.Abs(Math.Sin(angleOfRotation)) * oldFigure.width + Math.Abs(Math.Cos(angleOfRotation)) * oldFigure.height;

        Size rotatedFigureSize = new Size(rotatedFigureWidth, rotatedFigureHeight);
        return rotatedFigureSize;
    }
}

