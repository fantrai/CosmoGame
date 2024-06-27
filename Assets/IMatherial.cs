using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatherial
{
    public EnamMatherials Matherial { get; protected set; }

    public void StartAnim(Transform target);
}
