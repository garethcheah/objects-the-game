using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Car
{
    private string _make;
    private string _model;
    private float _consumptionLitresPer100km;

    public Car(string make, string model)
    {
        _make = make;
        _model = model;
    }

    public virtual void SetGasConsumption(float consumption)
    {
        _consumptionLitresPer100km = consumption;
    }

    public abstract float CalculateEfficiency();
}
