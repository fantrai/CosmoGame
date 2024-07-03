using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBase
{
    public static Action<EnumStatusPlayerBase> OnUpdateStatus;
    public static Action<float, float, string> OnUpdateBaseProgression;
    public static Action OnUse;
    public static EnumStatusPlayerBase Status { get; protected set; }

    public void BaseMenu();

    public void StartRepair();

    public void StartTeleport();

    public void CreateMenu();

    public void UpgradeMenu();
}
