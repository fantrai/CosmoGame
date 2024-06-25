using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : AbstractEntity
{
    Vector3 targetPos = Vector3.zero;

    private void OnEnable()
    {
        IPlayer.OnMove += TargetUpdate;
    }

    private void OnDisable()
    {
        IPlayer.OnMove -= TargetUpdate;
    }

    void TargetUpdate(Vector3 target)
    {
        targetPos = target;
    }

    protected override void Movement()
    {
        transform.Translate(targetPos * movementSpeed);
    }
}