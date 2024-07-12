using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShapeTest
{
    private List<Shape> shapes;

    protected void TestDraw()
    {
        InitShapes();

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }

    protected void TestCalculateArea()
    {
        InitShapes();

        foreach (var shape in shapes)
        {
            shape.CalculateArea();
        }
    }

    private void InitShapes()
    {
        shapes.Clear();
        shapes.Add(new Circle());
        shapes.Add(new Triangle());
    }
}
