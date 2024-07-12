using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    public override void Draw()
    {
        Debug.Log("Drawing a circle");
        base.Draw();
    }

    public override void CalculateArea()
    {
        Debug.Log("Calculating area of a circle.");
        base.CalculateArea();
    }
}
