using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : Shape
{
    public override void Draw()
    {
        Debug.Log("Drawing a triangle");
        base.Draw();
    }

    public override void CalculateArea()
    {
        Debug.Log("Calculating area of a triangle.");
        base.CalculateArea();
    }
}
