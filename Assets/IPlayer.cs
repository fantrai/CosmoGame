using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public static Action<Vector3> OnMove;
    public static Action<int> OnAddIron;

    public int Iron { get; set; }
    public int Plastic { get; set; }
    public int Aluminum { get; set; }
    public int Tungsten { get; set; }
    public int FuelCell { get; set; }
    public int EnergyBattery { get; set; }
    public int SolarPlate { get; set; }
    public int ControlUnit { get; set; }
    public int LongAntenna { get; set; }
    public int Copper { get; set; }
    public int Gold { get; set; }

    public void AddShipElement(IShipElement element);
}
