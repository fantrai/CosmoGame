using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipElement
{
    public float TimeAfterCooldown { get; set; }
    public string NameElement { get; protected set; }
    public string DescriptionElement { get; protected set; }

    public IShipElement StartUse(Transform parent);
}
