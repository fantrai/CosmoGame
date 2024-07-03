using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseProgressbar : ProgressBar
{
    private void Start()
    {
        IPlayerBase.OnUpdateBaseProgression += Progression;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        IPlayerBase.OnUpdateBaseProgression -= Progression;
    }
}
