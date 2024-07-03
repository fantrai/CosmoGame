using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer : IEntity
{
    public static Action<Vector3> OnMove;
    public static Action<IShipElement> OnAddShipElement;
    public static Action<IMatherial, int> OnUpdateMatherial;
    public static Action OnCreateBase;

    public int MaxCountItemOneType { get; set; }
    public Dictionary<EnumMatherials, int> Matherials { get; }
}
