using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : IShape
{
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw()
    {
        Debug.Log("Performing base class drawing.");
    }

    public virtual void CalculateArea()
    {
        Debug.Log("Performing base class area calculation.");
    }
}
