using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    public static Action<Vector3> OnMove;
    public static Action<IShipElement> OnAddShipElement;
    public static Action<EnamMatherials, int> OnUpdateMatherial;
}
