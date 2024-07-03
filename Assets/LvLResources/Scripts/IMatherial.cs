using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatherial
{
    public EnumMatherials Matherial { get; protected set; }

    public void StartAnim(Transform target);

    public Sprite Ico { get; }
}
