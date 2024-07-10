using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricCar : Car
{
    private float _consumptionKwPerHour;

    public ElectricCar(string make, string model) : base(make, model)
    {
        
    }

    public override void SetGasConsumption(float consumption)
    {
        // Add different implementation for electric consumption
        _consumptionKwPerHour = consumption;
    }

    public override float CalculateEfficiency()
    {
        return _consumptionKwPerHour;
    }
}
